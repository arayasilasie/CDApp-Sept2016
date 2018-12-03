using System;
using System.Collections.Generic;
using ECX.CD.BL.ECXUnpledge;
using ECX.CD.BE.IF;
using System.Transactions;
using System.Data;
using ECX.CD.BL.ECXLookup;
using ECX.CD.BL.Security;

namespace ECX.CD.BL
{
    public class UP
    {

        public static bool SaveNewUP(ecxRequest request, Guid userGuid)
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();
            UPRequest upRequest = new UPRequest();

            bool success = true;

            using (TransactionScope scope = new TransactionScope())
            {
                if (request != null)
                {
                    upRequest.RequestNumber = request.requestNumber;
                    upRequest.IsLive = request.ECXRequestHeader.IsLive;
                    upRequest.BankShortName = request.ECXRequestData.Bank;
                    upRequest.RequestDate = request.ECXRequestData.RequestDate;

                    Guid bankId = Guid.Empty;
                    CBank bank = IFLookup.GetBankByName(upRequest.BankShortName);
                    if (bank != null)
                    {
                        bankId = bank.UniqueIdentifier;
                    }

                    foreach (transaction t in request.ECXRequestData.Transaction)
                    {
                        upRequest.BankBranchName = t.BranchName;
                        upRequest.ClientId = t.ECXClientID;
                        upRequest.MemberId = t.ECXMemberID;
                        upRequest.WHRId = t.WHRID;
                        //upRequest.OrganizationName = t.OrganizationName;

                        upRequest.UPRequestGuid = Guid.NewGuid();

                        if (InsertUP(bankId, upRequest, userGuid))
                        {
                            ValidateUP(bankId, upRequest, userGuid);
                        }
                        else
                        {
                            success = false;
                            break;
                        }
                    }
                }

                if (success)
                {
                    scope.Complete();
                }
            }
            return success;
        }
        public static void ImportUP(Guid userGuid)
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();

            foreach (Guid bankId in bankIds)
            {
                ecxRequest request = new UnpledgeService().getUnPledgeRequestByBank(IFCommon.GetDate(DateTime.Today), IFLookup.GetBankName(bankId));
                UPRequest upRequest = new UPRequest();

                if (request != null)
                {
                    upRequest.RequestNumber = request.requestNumber;
                    upRequest.IsLive = request.ECXRequestHeader.IsLive;
                    upRequest.BankShortName = request.ECXRequestData.Bank;
                    upRequest.RequestDate = request.ECXRequestData.RequestDate;

                    foreach (transaction t in request.ECXRequestData.Transaction)
                    {
                        upRequest.BankBranchName = t.BranchName;
                        upRequest.ClientId = t.ECXClientID;
                        upRequest.MemberId = t.ECXMemberID;
                        upRequest.WHRId = t.WHRID;
                        //upRequest.OrganizationName = t.OrganizationName;

                        upRequest.UPRequestGuid = Guid.NewGuid();
                        if (!new DA.UnPledge().UPRequestExists(upRequest.WHRId, upRequest.RequestDate, false))
                        {
                            if (InsertUP(bankId, upRequest, userGuid))
                            {
                                ValidateUP(bankId, upRequest, userGuid);
                            }
                        }
                    }
                }
            }
        }

        private static bool InsertUP(Guid bankId, UPRequest upRequest, Guid userGuid)
        {
            byte newStatusCode = new IFLookup().GetLookupId("tblUPStatus", "New");
            if (!new DA.UnPledge().UPRequestExists(upRequest.WHRId, upRequest.RequestDate, false))
            {
                return new DA.UnPledge().Insert(
                                        upRequest.UPRequestGuid,
                                        upRequest.WHRId,
                                        upRequest.ClientId,
                                        upRequest.MemberId,
                                        bankId,
                                        upRequest.BankShortName,
                                        upRequest.BankBranchName,
                                        newStatusCode,
                                        newStatusCode,
                                        upRequest.RequestNumber,
                                        upRequest.RequestDate,
                                        userGuid,
                                        DateTime.Now);
            }
            else
            {
                throw new InvalidOperationException("Unpledge request already exists");
            }
        }
        private static void ValidateUP(Guid bankId, UPRequest upRequest, Guid userGuid)
        {
            bool WHRExists = true;
            IFLookup iFLookup = new IFLookup();
            if (!Validation.IsRequestLive(upRequest.IsLive))
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "Request is not live"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.IsDateFormatValid(upRequest.RequestDate))
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "Date has invalid format"),
                    userGuid, DateTime.Now);
            }
            //if (upRequest.OrganizationName == IFLookup.GetMembershipEntityOrganizationNameByIdNo((upRequest.ClientId != null) ? upRequest.ClientId : upRequest.MemberId))
            //{
            //    DA.UnPledge.SaveRejectionReason(
            //        Guid.NewGuid(),
            //        upRequest.UPRequestGuid,
            //        iFLookup.GetLookupId("tblRejectionReasons", "Organization name mismatch"),
            //        userGuid, DateTime.Now);
            //}
            if (!Validation.IsRequestDateValid(upRequest.RequestDate))
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "Request date is later than today"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.WHRNoExists(upRequest.WHRId))
            {
                WHRExists = false;
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "WHR ID does not exist"),
                    userGuid, DateTime.Now);
            }

            //if WHRID exists check if it is approved.
            if (WHRExists && !Validation.IsWHRApproved(upRequest.WHRId))
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "WHR is not approved"),
                    userGuid, DateTime.Now);
            }
            if (upRequest.MemberId.Length > 0 && upRequest.ClientId.Length > 0)
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "Both ECXMemberID and ECXClientID specified"),
                    userGuid, DateTime.Now);
            }
            if (upRequest.MemberId.Length == 0 && upRequest.ClientId.Length == 0)
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "Must specify ECXMemberID or ECXClientID"),
                    userGuid, DateTime.Now);
            }
            if (upRequest.MemberId.Length > 0)
            {
                if (!Validation.MemberIdExists(upRequest.MemberId))
                {
                    DA.UnPledge.SaveRejectionReason(
                        Guid.NewGuid(),
                        upRequest.UPRequestGuid,
                        iFLookup.GetLookupId("tblRejectionReasons", "Invalid ECXMemberID"),
                        userGuid, DateTime.Now);
                }
                if (WHRExists && !Validation.IsWHRTrueOwner(upRequest.WHRId, upRequest.MemberId))
                {
                    DA.UnPledge.SaveRejectionReason(
                        Guid.NewGuid(),
                        upRequest.UPRequestGuid,
                        iFLookup.GetLookupId("tblRejectionReasons", "WHR does not belong to specified member"),
                        userGuid, DateTime.Now);
                }
            }
            if (upRequest.ClientId.Length > 0)
            {
                if (!Validation.ClientIdExists(upRequest.ClientId))
                {
                    DA.UnPledge.SaveRejectionReason(
                        Guid.NewGuid(),
                        upRequest.UPRequestGuid,
                        iFLookup.GetLookupId("tblRejectionReasons", "Invalid ECXClientID"),
                        userGuid, DateTime.Now);
                }
                if (WHRExists && !Validation.IsWHRTrueOwner(upRequest.WHRId, upRequest.ClientId))
                {
                    DA.UnPledge.SaveRejectionReason(
                        Guid.NewGuid(),
                        upRequest.UPRequestGuid,
                        iFLookup.GetLookupId("tblRejectionReasons", "WHR does not belong to specified client"),
                        userGuid, DateTime.Now);
                }
            }
            if (!Validation.BankNameExists(upRequest.BankShortName))
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "Bank name does not exist"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.BankBranchNameExists(upRequest.BankShortName, upRequest.BankBranchName))
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "Bank branch name does not exist"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.IsPledgeStatusValidForUP(upRequest.WHRId))
            {
                DA.UnPledge.SaveRejectionReason(
                    Guid.NewGuid(),
                    upRequest.UPRequestGuid,
                    iFLookup.GetLookupId("tblRejectionReasons", "Pledge status is not valid for unpledge request"),
                    userGuid, DateTime.Now);
            }
        }

        public bool SaveUP(List<Guid> upRequestIds, List<bool> statuses, List<string> remarks, Guid userGuid)
        {
            byte rejectedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Rejected");
            byte approvedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Approved");
            AuditTrail audit = new AuditTrail();

            using (TransactionScope scope = new TransactionScope())
            {
                int count = 0;
                foreach (Guid upRequestId in upRequestIds)
                {
                    BE.IF.UP.UnpledgeRow row = new DA.UnPledge().GetUnPledgeRequest(upRequestId);
                    string oldAuditValue = string.Format("ID = {0}; WHRNO = {1}; Approved = {2}; Remark = {3}", upRequestId, row.WRNo, (row.Status == (int)approvedStatusCode).ToString(), row.Remark);
                    string newAuditValue = string.Format("Approved = {0}; Remark = {1}", (statuses[count]).ToString(), remarks[count]);

                    audit.Add(AuditTrailModules.WRFSaveUP, oldAuditValue, newAuditValue);

                    byte statusCode = (statuses[count] ? approvedStatusCode : rejectedStatusCode);
                    if (!new DA.UnPledge().SaveUPTempStatus(upRequestId, statusCode, remarks[count], userGuid, DateTime.Now))
                    {
                        return false;
                    }
                    count++;
                }

                if (audit.Save())
                {
                    scope.Complete();
                    audit.Commit();
                }
            }

            return true;
        }
        public bool CommitUP(List<Guid> upRequestIds, List<bool> statuses, List<string> remarks, Guid userGuid)
        {
            byte rejectedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Rejected");
            byte approvedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Approved");
            AuditTrail audit = new AuditTrail();

            using (TransactionScope scope = new TransactionScope())
            {
                int count = 0;
                foreach (Guid upRequestId in upRequestIds)
                {
                    BE.IF.UP.UnpledgeRow row = new DA.UnPledge().GetUnPledgeRequest(upRequestId);
                    string oldAuditValue = string.Format("ID = {0}; WHRNO = {1}; Approved = {2}; Remark = {3}", upRequestId, row.WRNo, (row.Status == (int)approvedStatusCode).ToString(), row.Remark);
                    string newAuditValue = string.Format("Approved = {0}; Remark = {1}", (statuses[count]).ToString(), remarks[count]);

                    audit.Add(AuditTrailModules.WRFConfirmUP, oldAuditValue, newAuditValue);

                    byte statusCode = (statuses[count] ? approvedStatusCode : rejectedStatusCode);
                    if (!new DA.UnPledge().ConfirmUP(upRequestId, statusCode, remarks[count], userGuid, DateTime.Now))
                    {
                        return false;
                    }
                    count++;
                }

                if (audit.Save())
                {
                    scope.Complete();
                    audit.Commit();
                }
            }

            return true;
        }

        public List<BE.IF.UPView> GetUPForConfirmation(Guid bankId)
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "New"));

            BE.IF.UP.UnpledgeDataTable table = new DA.UnPledge().GetUnPledgeRequest(bankId, status);
            List<BE.IF.UPView> items = new List<ECX.CD.BE.IF.UPView>();

            foreach (BE.IF.UP.UnpledgeRow row in table.Rows)
            {
                BE.IF.UPView item = GetUPView(row);

                items.Add(item);
            }

            return items;
        }
        public List<BE.IF.UPView> GetUPForConfirmationForUnknownBanks()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "New"));

            BE.IF.UP.UnpledgeDataTable table = new DA.UnPledge().GetUnPledgeRequest(Guid.Empty, status);
            List<BE.IF.UPView> items = new List<ECX.CD.BE.IF.UPView>();

            foreach (BE.IF.UP.UnpledgeRow row in table.Rows)
            {
                BE.IF.UPView item = GetUPView(row);

                items.Add(item);
            }

            return items;
        }
        public List<BE.IF.UPView> GetUPForConfirmation()
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();
            List<BE.IF.UPView> items = new List<ECX.CD.BE.IF.UPView>();

            foreach (Guid bankId in bankIds)
            {
                items.AddRange(GetUPForConfirmation(bankId));
            }
            //for records whose bankname is not found in the lookup database
            //  bankbranchid is set to empty Guid
            //The following code collects those records.
            items.AddRange(GetUPForConfirmationForUnknownBanks());

            return items;
        }

        public List<BE.IF.UPView> GetUPForAuthorisation(Guid bankId)
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "Rejected"));
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "Approved"));

            BE.IF.UP.UnpledgeDataTable table = new DA.UnPledge().GetUnPledgeRequest(bankId, status, false);
            List<BE.IF.UPView> items = new List<ECX.CD.BE.IF.UPView>();

            foreach (BE.IF.UP.UnpledgeRow row in table.Rows)
            {
                BE.IF.UPView item = GetUPView(row);

                items.Add(item);
            }

            return items;
        }
        public List<BE.IF.UPView> GetUPForAuthorisation()
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();
            List<BE.IF.UPView> items = new List<ECX.CD.BE.IF.UPView>();

            foreach (Guid bankId in bankIds)
            {
                items.AddRange(GetUPForAuthorisation(bankId));
            }
            //for records whose bankname is not found in the lookup database
            //  bankbranchid is set to empty Guid
            //The following code collects those records.
            items.AddRange(GetUPForAuthorisationForUnknownBanks());

            return items;
        }
        private List<BE.IF.UPView> GetUPForAuthorisationForUnknownBanks()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "Rejected"));
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "Approved"));

            BE.IF.UP.UnpledgeDataTable table = new DA.UnPledge().GetUnPledgeRequest(Guid.Empty, status, false);
            List<BE.IF.UPView> items = new List<ECX.CD.BE.IF.UPView>();

            foreach (BE.IF.UP.UnpledgeRow row in table.Rows)
            {
                BE.IF.UPView item = GetUPView(row);

                items.Add(item);
            }

            return items;
        }

        private static UPView GetUPView(BE.IF.UP.UnpledgeRow row)
        {
            BE.IF.UPView item = new UPView();
            //System.Data.DataRow whrRow = new DA.WarehouseReciept().GetWR(row.WRNo);

            //Guid mcGuid = Guid.Empty;
            //Guid commodityGradeId = Guid.Empty;
            //double quantity = 0;

            //if (whrRow != null)
            //{
            //    mcGuid = new Guid(whrRow["ClientId"].ToString());
            //    commodityGradeId = new Guid(whrRow["CommodityGradeId"].ToString());
            //    quantity = Convert.ToDouble(whrRow["CurrentQuantity"]);
            //}

            //bool isMember = IFLookup.IsMemberGuid(mcGuid);
            //string mcId = "";
            //if (isMember)
            //    mcId = IFLookup.GetMemberIDNoByMemberGuid(mcGuid);
            //else
            //    mcId = IFLookup.GetClientIDNoByClientGuid(mcGuid);

            item.Id = row.UnpledgeID;
            item.Bank = row.Bank;
            item.BankBranch = row.BankBranch;

            item.WHRNo = row.WRNo;
            item.MemberId = row.MemberIdNo;
            item.ClientId = row.ClientIdNo;
            //item.Quantity = quantity;
            //item.CommodityGrade = IFLookup.GetCGradeSymbol(commodityGradeId);

            item.RejectionReasons = GetRejectionReasons(row.UnpledgeID);
            item.Status = new IFLookup().GetLookupName("tblUPStatus", (byte)row.Status);

            item.TempStatus = (new IFLookup().GetLookupId("tblUPStatus", "Rejected") == Convert.ToByte(row.TempStatus) ? false : true);
            item.RejectedBySystem = ((item.RejectionReasons.Count == 0) ? false : true);
            item.Remark = row.Remark;

            if (!row.IsConfirmedByNull())
                item.ConfirmedBy = Security.SecurityHelper.GetUserName(row.ConfirmedBy);
            if (!row.IsConfirmedDateNull())
                item.ConfirmedDate = row.ConfirmedDate.ToString("dd-MMM-yyyy");
            if (!row.IsAuthorizedByNull())
                item.AuthorizedBy = Security.SecurityHelper.GetUserName(row.AuthorizedBy);
            if (!row.IsAuthorizedDateNull())
                item.AuthorizedDate = row.AuthorizedDate.ToString("dd-MMM-yyyy");

            return item;
        }

        public bool AuthoriseUPResponse(List<Guid> upRequestIds, Guid bankId, byte[] keyFileContent, string keyFileName, string password, Guid userGuid)
        {
            //TODO: chage password by its hash value
            AuditTrail audit = new AuditTrail();

            using (TransactionScope scope = new TransactionScope())
            {
                byte approvedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Approved");

                foreach (Guid upRequestId in upRequestIds)
                {
                    BE.IF.UP.UnpledgeRow row = new DA.UnPledge().GetUnPledgeRequest(upRequestId);

                    string newAuditValue = string.Format("ID = {0}; WHRNO = {1}; Approved = {2};", upRequestId, row.WRNo, (row.Status == approvedStatusCode).ToString());

                    audit.Add(AuditTrailModules.WRFAuthorizeUP, newAuditValue);
                    
                    if (!new DA.UnPledge().SaveUPAuthorised(upRequestId, userGuid, DateTime.Now))
                    {
                        return false;
                    }
                    if (row.Status == approvedStatusCode)
                    {
                        if (!BL.IF.WHR.SaveUnpledge(row.WRNo, userGuid, DateTime.Now))
                            return false;
                    }
                }
                List<ecxMessage> messages = new List<ecxMessage>();

                ecxMessage message = new ecxMessage();

                message.ECXResponse = PrepareResponseInXMLFormat(upRequestIds, bankId);

                messages.Add(message);

                if (audit.Save())
                {
                    if (SendResponse(messages.ToArray(), keyFileContent, keyFileName, password))
                    {
                        scope.Complete();
                        audit.Commit();
                    }
                    else
                    {
                        audit.RollBack();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        public bool RejectUPResponse(List<Guid> upRequestIds, string rejectionReason, Guid userGuid)
        {
            AuditTrail audit = new AuditTrail();
            using (TransactionScope scope = new TransactionScope())
            {
                byte status = new IFLookup().GetLookupId("tblUPStatus", "New");
                foreach (Guid upRequestId in upRequestIds)
                {
                    BE.IF.UP.UnpledgeRow row = new DA.UnPledge().GetUnPledgeRequest(upRequestId);

                    string newAuditValue = string.Format("ID = {0}; WHRNO = {1}; RejectionReason = {2};", upRequestId, row.WRNo, rejectionReason);

                    audit.Add(AuditTrailModules.WRFRejectUP, newAuditValue);

                    if (!new DA.UnPledge().SaveUPStatus(upRequestId, status, rejectionReason, userGuid, DateTime.Now))
                    {
                        return false;
                    }
                }
                if (audit.Save())
                {
                    scope.Complete();
                    audit.Commit();
                }
            }

            return true;
        }

        public static List<BE.RejectionReason> GetRejectionReasons(Guid upRequestId)
        {
            return DA.UnPledge.GetRejectionReasons(upRequestId);
        }
        public static bool SaveRejectionReasons(Guid upRequestId, List<int> reasonIds, Guid userGuid)
        {
            bool saved = true;
            foreach (int reasonId in reasonIds)
            {
                if (!DA.UnPledge.SaveRejectionReason(Guid.NewGuid(), upRequestId, reasonId, userGuid, DateTime.Now))
                    saved = false;
            }
            return saved;
        }

        private ECXResponse PrepareResponseInXMLFormat(List<Guid> upRequestIds, Guid bankId)
        {
            ECXResponse response = new ECXResponse();
            response.ECXResponseData = new ecxResponseData();
            response.ECXResponseHeader = new ecxResponseHeader();

            byte approvedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Approved");
            string bankName = IFLookup.GetBankName(bankId);

            response.ECXResponseHeader.IsLive = "y";
            response.ECXResponseHeader.ResponseType = "UnPledge";
            response.ECXResponseHeader.ResponseOriginator = bankName;
            response.ECXResponseHeader.ResponseSignature = string.Empty;

            response.ECXResponseData.Bank = bankName;
            response.ECXResponseData.ResponseDate = IFCommon.GetDate(DateTime.Today);

            List<transactionResponse> transactions = new List<transactionResponse>();
            foreach (Guid upRequestId in upRequestIds)
            {
                BE.IF.UP.UnpledgeRow request = new DA.UnPledge().GetUnPledgeRequest(upRequestId);
                System.Data.DataRow whrRow = new DA.WarehouseReciept().GetWR(request.WRNo);

                transactionResponse transaction = new transactionResponse();

                transaction.ECXMemberID = request.MemberIdNo;
                transaction.ECXClientID = request.ClientIdNo;

                transaction.WHRID = request.WRNo.ToString();

                if (Convert.ToByte(request.Status) == approvedStatusCode)
                {
                    transaction.Description = "Successful";
                    transaction.Status = "Confirmed";
                }
                else
                {
                    transaction.Description = GetRejectionReasonRemark(upRequestId);
                    transaction.Status = "Rejected";
                }

                transactions.Add(transaction);
            }
            response.ECXResponseData.TransactionResponse = transactions.ToArray();

            return response;
        }
        private bool SendResponse(ecxMessage[] messages, byte[] keyFileContent, string keyFileName, string password)
        {
            string result = new ECXUnpledge.UnpledgeService().authoriazeUnpledgeResponce(messages, keyFileContent, password, keyFileName);
            if (result.ToLower() == "ok")
                return true;
            else
                throw new BL.IF.ResponseAuthorizationException("Unpledge response authorisation failed. The Authorisation service returned : " + result);
        }

        private string GetRejectionReasonRemark(Guid upRequestId)
        {
            List<ECX.CD.BE.RejectionReason> reasons = DA.UnPledge.GetRejectionReasons(upRequestId);
            string ret = string.Empty;
            int count = 1;
            foreach (ECX.CD.BE.RejectionReason reason in reasons)
            {
                ret += ((ret == "") ? "" : ",") + " (" + count + ")" + reason.Description;
                count++;
            }

            return ret;
        }

        public static int GetConfirmTasksCount()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "New"));

            return new DA.UnPledge().GetUnPledgeRequest(status, false).Rows.Count;
        }
        public static int GetAuthoriseTasksCount()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "Rejected"));
            status.Add(new IFLookup().GetLookupId("tblUPStatus", "Approved"));

            return new DA.UnPledge().GetUnPledgeRequest(status, false).Rows.Count;
        }

        //public List<BE.IF.UPView> SearchUP(int whrNoFrom, int whrNoTo, int grnNoFrom, int grnNoTo, Guid bankId, Guid bankBranchId, string mcId, DateTime expiryDateFrom, DateTime expiryDateTo, byte status)
        //{
        //    //TODO: finilize the Search method
        //    List<Guid> bankBranchIds = new List<Guid>();
        //    if (bankBranchId != Guid.Empty)
        //    {
        //        bankBranchIds.Add(bankBranchId);
        //    }
        //    else if (bankId != Guid.Empty)
        //    {
        //        bankBranchIds = IFLookup.GetBankBranchIds(bankId);
        //    }
        //    DataTable table = new DA.UnPledge().SearchUP(whrNoFrom, whrNoTo, grnNoFrom, grnNoTo, bankBranchIds, mcId, expiryDateFrom, expiryDateTo, status);

        //    List<BE.IF.UPView> items = new List<UPView>();
        //    foreach (BE.IF.UP.UnpledgeRow row in table.Rows)
        //    {
        //        BE.IF.UPView item = GetUPView(row);

        //        items.Add(item);
        //    }
        //    return items;
        //}

        public List<BE.IF.UPView> GetUP(DateTime unpledgedDateFrom, DateTime unpledgedDateTo, byte status)
        {
            List<Guid> bankBranchIds = new List<Guid>();
            DataTable table = new DA.UnPledge().GetUnPledgeRequest(unpledgedDateFrom, unpledgedDateTo, status);

            List<BE.IF.UPView> items = new List<UPView>();
            foreach (BE.IF.UP.UnpledgeRow row in table.Rows)
            {
                BE.IF.UPView item = GetUPView(row);

                items.Add(item);
            }
            return items;
        }
        public List<BE.IF.UPView> SearchUP(Guid bankId, DateTime dtFrom, DateTime dtTo, byte status, bool onlyAuthorized)
        {
            DataTable table = new DA.UnPledge().SearchUP(bankId, dtFrom, dtTo, status, onlyAuthorized);

            List<BE.IF.UPView> items = new List<UPView>();
            foreach (BE.IF.UP.UnpledgeRow row in table.Rows)
            {
                BE.IF.UPView item = GetUPView(row);

                items.Add(item);
            }
            return items;
        }

        public List<int> GetWhrsWithAuthorizedUP(DateTime unpledgedDateFrom, DateTime unpledgedDateTo)
        {
            byte approvedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Approved");
            DataTable table = new DA.UnPledge().GetUnpledgedWhrs(unpledgedDateFrom, unpledgedDateTo, approvedStatusCode);

            List<int> items = new List<int>();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    items.Add(Convert.ToInt32(row["WRNo"]));
                }
            }
            return items;
        }
    }
}
