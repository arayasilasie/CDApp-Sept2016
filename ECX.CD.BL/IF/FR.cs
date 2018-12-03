using System;
using System.Collections.Generic;
using System.Data;
using ECX.CD.BE.IF;
using System.Transactions;
using ECX.CD.BL.ECXForeclosure;

namespace ECX.CD.BL
{
    public class FR
    {
        public static void ImportForclosureRequest(Guid userGuid)
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();

            foreach (Guid bankId in bankIds)
            {
                ecxRequest request = new transferTitleService().getTransferTitleByBank(IFCommon.GetDate(DateTime.Today), IFLookup.GetBankName(bankId));
                if (request != null)
                {
                    BE.IF.FRRequest fr = new BE.IF.FRRequest();

                    fr.RequestNumber = request.requestNumber;
                    fr.IsLive = request.ECXRequestHeader.IsLive;
                    fr.BankShortName = request.ECXRequestData.Bank;
                    fr.RequestDate = request.ECXRequestData.RequestDate;

                    foreach (transaction t in request.ECXRequestData.Transaction)
                    {
                        fr.BankBranchName = t.BranchName;
                        fr.ClientId = t.ECXClientID;
                        fr.MemberId = t.ECXMemberID;
                        fr.WHRId = t.WHRID;
                        fr.OrganizationName = t.OrganizationName;

                        fr.RequestId = Guid.NewGuid();

                        if (InsertForclosureRequest(bankId, fr, userGuid))
                        {
                            ValidateForclosureRequest(bankId, fr, userGuid);
                        }
                    }
                }
            }
        }
        private static bool InsertForclosureRequest(Guid bankId, BE.IF.FRRequest fr, Guid userGuid)
        {
            Guid bankBranchId = Guid.Empty;
            if (IFLookup.BankBranchExistsByName(bankId, fr.BankBranchName))
                bankBranchId = IFLookup.GetBankBranchIdByName(bankId, fr.BankBranchName);
            byte newStatusCode = new IFLookup().GetLookupId("tblForeclosureStatus", "New");

            bool result = new DA.Foreclosure().Insert(fr.RequestId,
                fr.WHRId,
                fr.ClientId,
                fr.MemberId,
                fr.OrganizationName,
                bankId,
                bankBranchId,
                fr.BankBranchName,
                newStatusCode,
                newStatusCode,
                userGuid,
                DateTime.Now);

            if (result)
            {
                result = DA.WarehouseReciept.SuspendWHR(fr.WHRId, userGuid, DateTime.Now);
            }
            return result;
        }
        private static void ValidateForclosureRequest(Guid bankId, BE.IF.FRRequest fr, Guid userGuid)
        {
            bool WHRExists = true;
            IFLookup ifLookup = new IFLookup();
            if (!Validation.IsRequestLive(fr.IsLive))
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "Request is not live"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.IsDateFormatValid(fr.RequestDate))
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "Date has invalid format"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.IsRequestDateValid(fr.RequestDate))
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "Request date is later than today"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.WHRNoExists(fr.WHRId))
            {
                WHRExists = false;
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "WHR ID does not exist"),//TODO: edit this line to new rejection reason name
                    userGuid, DateTime.Now);
            }

            //if WHRID exists check if it is approved.
            if (WHRExists && !Validation.IsWHRApproved(fr.WHRId))
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "WHR is not approved"),
                    userGuid, DateTime.Now);
            }
            if (fr.MemberId.Length > 0 && fr.ClientId.Length > 0)
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "Both ECXMemberID and ECXClientID specified"),
                    userGuid, DateTime.Now);
            }
            if (fr.MemberId.Length == 0 && fr.ClientId.Length == 0)
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "Must specify ECXMemberID or ECXClientID"),
                    userGuid, DateTime.Now);
            }
            if (fr.MemberId.Length > 0)
            {
                if (!Validation.MemberIdExists(fr.MemberId))
                {
                    DA.Foreclosure.SaveRejectionReason(
                        Guid.NewGuid(),
                        fr.RequestId,
                        ifLookup.GetLookupId("tblRejectionReasons", "Invalid ECXMemberID"),
                        userGuid, DateTime.Now);
                }
                else
                {
                    if (fr.OrganizationName.ToLower().Trim() == IFLookup.GetMembershipEntityOrganizationNameByIdNo((fr.MemberId).ToLower().Trim()))
                    {
                        DA.Foreclosure.SaveRejectionReason(
                            Guid.NewGuid(),
                            fr.RequestId,
                            ifLookup.GetLookupId("tblRejectionReasons", "Organization name mismatch"),
                            userGuid, DateTime.Now);
                    }

                }
                if (WHRExists && !Validation.IsWHRTrueOwner(fr.WHRId, fr.MemberId))
                {
                    DA.Foreclosure.SaveRejectionReason(
                        Guid.NewGuid(),
                        fr.RequestId,
                        ifLookup.GetLookupId("tblRejectionReasons", "WHR does not belong to specified member"),
                        userGuid, DateTime.Now);
                }
            }
            if (fr.ClientId.Length > 0)
            {
                if (!Validation.ClientIdExists(fr.ClientId))
                {
                    DA.Foreclosure.SaveRejectionReason(
                        Guid.NewGuid(),
                        fr.RequestId,
                        ifLookup.GetLookupId("tblRejectionReasons", "Invalid ECXClientID"),
                        userGuid, DateTime.Now);
                }
                else
                {
                    if (fr.OrganizationName.ToLower().Trim() == IFLookup.GetMembershipEntityOrganizationNameByIdNo((fr.ClientId).ToLower().Trim()))
                    {
                        DA.Foreclosure.SaveRejectionReason(
                            Guid.NewGuid(),
                            fr.RequestId,
                            ifLookup.GetLookupId("tblRejectionReasons", "Organization name mismatch"),
                            userGuid, DateTime.Now);
                    }

                }
                if (WHRExists && !Validation.IsWHRTrueOwner(fr.WHRId, fr.ClientId))
                {
                    DA.Foreclosure.SaveRejectionReason(
                        Guid.NewGuid(),
                        fr.RequestId,
                        ifLookup.GetLookupId("tblRejectionReasons", "WHR does not belong to specified client"),
                        userGuid, DateTime.Now);
                }
            }
            if (!Validation.BankNameExists(fr.BankShortName))
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "Bank name does not exist"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.BankBranchNameExists(fr.BankShortName, fr.BankBranchName))
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "Bank branch name does not exist"),
                    userGuid, DateTime.Now);
            }
            if (!Validation.IsPledgeStatusValidForUP(fr.WHRId))
            {
                DA.Foreclosure.SaveRejectionReason(
                    Guid.NewGuid(),
                    fr.RequestId,
                    ifLookup.GetLookupId("tblRejectionReasons", "Pledge status is not valid for unpledge request"),
                    userGuid, DateTime.Now);
            }
        }

        public bool Save(List<Guid> foreclosureRequestIds, List<bool> statuses, List<string> remarks, Guid userGuid)
        {
            byte rejectedStatusCode = new IFLookup().GetLookupId("tblForeclosureStatus", "Rejected");
            byte approvedStatusCode = new IFLookup().GetLookupId("tblForeclosureStatus", "Approved");

            using (TransactionScope scope = new TransactionScope())
            {
                int count = 0;
                foreach (Guid frId in foreclosureRequestIds)
                {
                    byte statusCode = (statuses[count] ? approvedStatusCode : rejectedStatusCode);
                    if (!new DA.Foreclosure().SaveTempStatus(frId, statusCode, remarks[count], userGuid, DateTime.Now))
                    {
                        return false;
                    }
                    count++;
                }
                scope.Complete();
            }

            return true;
        }
        public bool Commit(List<Guid> foreclosureRequestIds, List<bool> statuses, List<string> remarks, Guid userGuid)
        {
            byte rejectedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Rejected");
            byte approvedStatusCode = new IFLookup().GetLookupId("tblUPStatus", "Approved");

            using (TransactionScope scope = new TransactionScope())
            {
                int count = 0;
                foreach (Guid frId in foreclosureRequestIds)
                {
                    byte statusCode = (statuses[count] ? approvedStatusCode : rejectedStatusCode);
                    if (!new DA.Foreclosure().Confirm(frId, statusCode, remarks[count], userGuid, DateTime.Now))
                    {
                        return false;
                    }
                    count++;
                }
                scope.Complete();
            }

            return true;
        }
        public static bool AuthoriseResponse(List<Guid> foreclosureRequestIds, Guid bankId, byte[] keyFileContent, string keyFileName, string password, Guid userGuid)
        {
            //TODO: chage password by its hash value

            using (TransactionScope scope = new TransactionScope())
            {
                byte approvedStatusCode = new IFLookup().GetLookupId("tblForeclosureStatus", "Approved");
                foreach (Guid frId in foreclosureRequestIds)
                {
                    BE.IF.FR.ForeclosureRow row = new DA.Foreclosure().GetRequest(frId);
                    if (!new DA.Foreclosure().SaveForeclosureAuthorised(frId, userGuid, DateTime.Now))
                    {
                        return false;
                    }

                    if (row.StatusId == approvedStatusCode)
                    {
                        if (!BL.IF.WHR.SaveForeclosure(row.WHRNO, userGuid, DateTime.Now))
                            return false;
                    }
                }
                List<ecxMessage> messages = new List<ecxMessage>();

                ecxMessage message = new ecxMessage();

                message.ECXResponse = PrepareResponseInXMLFormat(foreclosureRequestIds, bankId);

                messages.Add(message);

                if (SendResponse(messages.ToArray(), keyFileContent, keyFileName, password))
                {
                    scope.Complete();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        public static bool RejectResponse(List<Guid> foreclosureRequestIds, Guid userGuid)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                byte status = new IFLookup().GetLookupId("tblForeclosureStatus", "New");
                foreach (Guid frId in foreclosureRequestIds)
                {
                    if (!new DA.Foreclosure().SaveStatus(frId, status, userGuid, DateTime.Now))
                    {
                        return false;
                    }
                }
                scope.Complete();
            }

            return true;
        }

        private static ECXResponse PrepareResponseInXMLFormat(List<Guid> foreclosureRequestIds, Guid bankId)
        {
            ECXResponse response = new ECXResponse();
            response.ECXResponseData = new ecxResponseData();
            response.ECXResponseHeader = new ecxResponseHeader();

            byte approvedStatusCode = new IFLookup().GetLookupId("tblForeclosureStatus", "Approved");
            string bankName = IFLookup.GetBankName(bankId);

            response.ECXResponseHeader.IsLive = "y";
            response.ECXResponseHeader.ResponseType = "Foreclosure";
            response.ECXResponseHeader.ResponseOriginator = bankName;
            response.ECXResponseHeader.ResponseSignature = string.Empty;

            response.ECXResponseData.Bank = bankName;
            response.ECXResponseData.ResponseDate = IFCommon.GetDate(DateTime.Today);

            List<transactionResponse> transactions = new List<transactionResponse>();
            foreach (Guid frId in foreclosureRequestIds)
            {
                BE.IF.FR.ForeclosureRow request = new DA.Foreclosure().GetRequest(frId);
                transactionResponse transaction = new transactionResponse();

                transaction.ECXMemberID = request.ECXMemberID;
                transaction.ECXClientID = request.ECXClientID;

                transaction.WHRID = request.WHRNO.ToString();

                if (Convert.ToByte(request.StatusId) == approvedStatusCode)
                {
                    transaction.Description = "";
                    transaction.Status = "Approved";
                }
                else
                {
                    transaction.Description = GetRejectionReasonRemark(frId);
                    transaction.Status = "Rejected";
                }

                transactions.Add(transaction);
            }
            response.ECXResponseData.TransactionResponse = transactions.ToArray();

            return response;
        }
        private static bool SendResponse(ecxMessage[] messages, byte[] keyFileContent, string keyFileName, string password)
        {
            string result = new ECXForeclosure.transferTitleService().authoriazeTranseferTitleResponce(messages, keyFileContent, password, keyFileName);
            if (result.ToLower() == "ok")
                return true;
            else
                throw new InvalidOperationException("Forclosure response authorisation failed. The Authorisation service returned : " + result);
        }

        public static List<BE.IF.ForeclosureView> GetListForConfirmation(Guid bankId)
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "New"));

            BE.IF.FR.ForeclosureDataTable table = new DA.Foreclosure().GetRequest(IFLookup.GetBankBranchIds(bankId), status);
            List<BE.IF.ForeclosureView> items = new List<ECX.CD.BE.IF.ForeclosureView>();

            foreach (BE.IF.FR.ForeclosureRow row in table.Rows)
            {
                BE.IF.ForeclosureView item = GetView(row);

                items.Add(item);
            }

            return items;
        }
        public static List<BE.IF.ForeclosureView> GetListForConfirmationFonUnknownBankBranches()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "New"));
            List<Guid> banks = new List<Guid>();
            banks.Add(Guid.Empty);

            BE.IF.FR.ForeclosureDataTable table = new DA.Foreclosure().GetRequest(banks, status);
            List<BE.IF.ForeclosureView> items = new List<ECX.CD.BE.IF.ForeclosureView>();

            foreach (BE.IF.FR.ForeclosureRow row in table.Rows)
            {
                BE.IF.ForeclosureView item = GetView(row);

                items.Add(item);
            }

            return items;
        }
        public static List<BE.IF.ForeclosureView> GetListForConfirmation()
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();
            List<BE.IF.ForeclosureView> items = new List<ECX.CD.BE.IF.ForeclosureView>();

            foreach (Guid bankId in bankIds)
            {
                items.AddRange(GetListForConfirmation(bankId));
            }
            //for records whose bankname is not found in the lookup database
            //  bankbranchid is set to empty Guid
            //The following code collects those records.
            items.AddRange(GetListForConfirmationFonUnknownBankBranches());

            return items;
        }

        public static List<BE.IF.ForeclosureView> GetListForAuthorisation(Guid bankId)
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "Rejected"));
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "Approved"));

            BE.IF.FR.ForeclosureDataTable table = new DA.Foreclosure().GetRequest(IFLookup.GetBankBranchIds(bankId), status, false);
            List<BE.IF.ForeclosureView> items = new List<ECX.CD.BE.IF.ForeclosureView>();

            foreach (BE.IF.FR.ForeclosureRow row in table.Rows)
            {
                BE.IF.ForeclosureView item = GetView(row);

                items.Add(item);
            }

            return items;
        }
        public static List<BE.IF.ForeclosureView> GetListForAuthorisation()
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();
            List<BE.IF.ForeclosureView> items = new List<ECX.CD.BE.IF.ForeclosureView>();

            foreach (Guid bankId in bankIds)
            {
                items.AddRange(GetListForAuthorisation(bankId));
            }
            //for records whose bankname is not found in the lookup database
            //  bankbranchid is set to empty Guid
            //The following code collects those records.
            items.AddRange(GetListForAuthorisationFonUnknownBankBranches());

            return items;
        }
        private static List<BE.IF.ForeclosureView> GetListForAuthorisationFonUnknownBankBranches()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "Rejected"));
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "Approved"));

            List<Guid> banks = new List<Guid>();
            banks.Add(Guid.Empty);

            BE.IF.FR.ForeclosureDataTable table = new DA.Foreclosure().GetRequest(banks, status, false);
            List<BE.IF.ForeclosureView> items = new List<ECX.CD.BE.IF.ForeclosureView>();

            foreach (BE.IF.FR.ForeclosureRow row in table.Rows)
            {
                BE.IF.ForeclosureView item = GetView(row);

                items.Add(item);
            }

            return items;
        }

        public static List<BE.RejectionReason> GetRejectionReasons(Guid frId)
        {
            return DA.Foreclosure.GetRejectionReasons(frId);
        }
        private static string GetRejectionReasonRemark(Guid foreclosureRequestId)
        {
            List<ECX.CD.BE.RejectionReason> reasons = DA.Foreclosure.GetRejectionReasons(foreclosureRequestId);
            string ret = string.Empty;
            int count = 1;
            foreach (ECX.CD.BE.RejectionReason reason in reasons)
            {
                ret += ((ret == "") ? "" : ",") + " (" + count + ")" + reason.Description;
                count++;
            }

            return ret;
        }

        public List<ForeclosureView> Search(int whrNoFrom, int whrNoTo, int grnNoFrom, int grnNoTo, Guid bankId, string mcId, DateTime expiryDateFrom, DateTime expiryDateTo, byte status)
        {
            DataTable table = new DA.Foreclosure().Search(whrNoFrom, whrNoTo, grnNoFrom, grnNoTo, bankId, mcId, expiryDateFrom, expiryDateTo, status);

            List<ForeclosureView> items = new List<ForeclosureView>();
            foreach (BE.IF.FR.ForeclosureRow row in table.Rows)
            {
                ForeclosureView item = GetView(row);

                items.Add(item);
            }
            return items;
        }
        private static ForeclosureView GetView(ECX.CD.BE.IF.FR.ForeclosureRow row)
        {
            BE.IF.ForeclosureView item = new ForeclosureView();

            item.Id = row.Id;
            item.BankName = IFLookup.GetBankShortName(row.BankId) + " - " + row.BankBranchName;

            item.WHRNO = row.WHRNO;
            item.ClientId = row.ECXClientID;
            item.MemberId = row.ECXMemberID;
            item.OrganizationName = row.OrganizationName;
            item.BankBranchName = row.BankBranchName;
            item.RejectionReasons = GetRejectionReasons(row.Id);
            item.Status = new IFLookup().GetLookupName("tblForeclosureStatus", row.StatusId);
            if (row.TempStatusId == new IFLookup().GetLookupId("tblForeclosureStatus", "Rejected"))
            {
                item.TempStatus = false;
            }
            else
            {
                item.TempStatus = true;
            }

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

        public static int GetAuthoriseTasksCount()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "Rejected"));
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "Approved"));

            return new DA.Foreclosure().GetRequest(status, false).Rows.Count;
            //return GetListForAuthorisation().Count;
        }
        public static int GetConfirmTasksCount()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblForeclosureStatus", "New"));

            return new DA.Foreclosure().GetRequest(status, false).Rows.Count;
            //return GetListForConfirmation().Count;
        }
    }
}