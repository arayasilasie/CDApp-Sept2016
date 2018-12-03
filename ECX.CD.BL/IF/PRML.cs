using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECX.CD.BE.IF;
using System.Data;
using System.Transactions;
using ECX.CD.BL.ECXPRML;
using ECX.CD.BL.Security;

namespace ECX.CD.BL
{
    public class PRML
    {
        public static void ImportReport(Guid userGuid)
        {
            byte pledgedNoSaleCode = new IFLookup().GetLookupId("tblPRMLType", "Pledged No Sale");
            byte pledgedSaleCode = new IFLookup().GetLookupId("tblPRMLType", "Pledged Sale");
            byte pledgedForeclosedCode = new IFLookup().GetLookupId("tblPRMLType", "Foreclosed");
            byte unpledgedCode = new IFLookup().GetLookupId("tblPRMLType", "Unpledged");
            byte withdrawnCode = new IFLookup().GetLookupId("tblPRMLType", "Withdrawn");
            byte soldCode = new IFLookup().GetLookupId("tblPRMLType", "Sold");

            new DA.PRML().ClearNonAuthorizedPRML();
            new DA.PRML().ClearNonAuthorizedEmptyPRML();

            //Register
            //Import and save Pledged No Sale WHR List
            List<int> pledgedNoSaleWHRIds = BL.IF.WHR.GetPledgedNoSaleRegister();
            foreach (int whrId in pledgedNoSaleWHRIds)
            {
                InsertReport(whrId, pledgedNoSaleCode, userGuid);
            }

            //Import and save Pledged Sale WHR List
            List<int> pledgedSaleWHRIds = BL.IF.WHR.GetPledgedSaleRegister();
            foreach (int whrId in pledgedSaleWHRIds)
            {
                InsertReport(whrId, pledgedSaleCode, userGuid);
            }

            //Import and save Foreclosed WHR List
            List<int> pledgedForeclosedWHRIds = BL.IF.WHR.GetPledgedForeclosedRegister();
            foreach (int whrId in pledgedForeclosedWHRIds)
            {
                InsertReport(whrId, pledgedForeclosedCode, userGuid);
            }

            //Movement List
            //TODO: Import and save Unpledged WHR List for the last specified days
            DateTime unpledgeStartDate = DateTime.Today.Subtract(new TimeSpan(Properties.Settings.Default.DaysUnpledgedWHRAppearsInPRML, 0, 0, 0));
            List<int> unpledgedWHRIdsWithDateRange = new BL.UP().GetWhrsWithAuthorizedUP(unpledgeStartDate, DateTime.Now);
            byte approvedUnpledgeStatus = new IFLookup().GetLookupId("tblUPStatus", "Approved");
            foreach (int whrId in unpledgedWHRIdsWithDateRange)
            {
                BE.IF.UP.UnpledgeDataTable tblup = new DA.UnPledge().GetUnPledgeRequest(whrId, approvedUnpledgeStatus, true);
                DateTime unpledgedDate = tblup.First().AuthorizedDate;
                float qtyWhenUnpledged = DA.IF.WHR.GetQuantityOnUnpledge(whrId);

                InsertReport(whrId, unpledgedCode, userGuid, unpledgedDate, qtyWhenUnpledged);
            }

            //Import and save Sold WHR List for the last specified days            
            DateTime tradeStartDate = DateTime.Today.Subtract(new TimeSpan(Properties.Settings.Default.DaysSoldWHRAppearsInPRML, 0, 0, 0));

            foreach (int pledgedWHRID in pledgedSaleWHRIds)
            {
                DataTable table = new ECXTradingPRML.TradeClient().GetTradeDetails(pledgedWHRID, tradeStartDate, DateTime.Today);
                foreach (DataRow row in table.Rows)
                {
                    int whrId = Convert.ToInt32(row["WHRId"]);
                    double eventLots = Convert.ToDouble(row["Quantity"]);
                    DateTime eventDate = Convert.ToDateTime(row["TradeDate"]);
                    double tradePrice = Convert.ToDouble(row["TradePrice"]);
                    double tradePayoutValue = Convert.ToDouble(row["PayoutValue"]);

                    InsertReport(whrId, soldCode, userGuid, eventDate, eventLots, tradePrice, tradePayoutValue);
                }
            }

            //Import and save Withdrawn WHR List for the last specified days
            DateTime withdrawalStartDate = DateTime.Today.Subtract(new TimeSpan(Properties.Settings.Default.DaysWithdrawnWHRAppearsInPRML, 0, 0, 0));
            List<int> unpledgedWHRIdsForWithdrawal = new BL.UP().GetWhrsWithAuthorizedUP(withdrawalStartDate, DateTime.Now);

            foreach (int withdrawnWHRId in unpledgedWHRIdsForWithdrawal)
            {
                BE.PUN.PickUpNoticeWarehouseRecieptDataTable table = new BL.PUN().GetPUNWHRDetail(withdrawnWHRId, withdrawalStartDate, DateTime.Today);
                foreach (BE.PUN.PickUpNoticeWarehouseRecieptRow row in table.Rows)
                {
                    int whrId = row.WarehouseRecieptId;
                    float eventLots = (float)row.Quantity;
                    DateTime eventDate = row.DNReceivedDateTime;

                    InsertReport(whrId, withdrawnCode, userGuid, eventDate, eventLots, null, null);
                }
            }

            //Generate Empty PRML for banks engaged for WRF
            GenerateEmptyPRML(userGuid);
        }
        private static void GenerateEmptyPRML(Guid userGuid)
        {
            DA.PRML prmlDA = new DA.PRML();
            byte newPRMLStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "New");
            List<Guid> banks = GetBanksEngagedInWRF();

            foreach (Guid bankId in banks)
            {
                List<Guid> bankBranchIds = IFLookup.GetBankBranchIds(bankId);

                if (!prmlDA.UnAuthorizedReportExists(bankBranchIds))
                {
                    if (!prmlDA.UnAuthorizedEmptyReportExists(bankId))
                    {
                        prmlDA.SaveEmptyPRML(Guid.NewGuid(), bankId, newPRMLStatusCode, userGuid, DateTime.Now);
                    }
                }
            }
        }

        private static List<Guid> GetBanksEngagedInWRF()
        {
            string[] arrBanks = Properties.Settings.Default.BanksEngagedInWRF.Split(';');

            List<Guid> banks = new List<Guid>();
            foreach (string stringBankId in arrBanks)
            {
                banks.Add(new Guid(stringBankId));
            }

            return banks;
        }
        
        private static bool InsertReport(int whrId, int prmlTypeId, Guid userGuid, DateTime? eventDate, double? eventLots, double? tradePrice, double? payoutPrice)
        {
            byte newStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "New");
            byte approvedPledgeStatusCode = new IFLookup().GetLookupId("tblPRStatus", "Approved");

            BE.WR.WarehouseRecieptRow whrRow = new BL.WarehouseReciept().GetWR(whrId);
            List<Guid> pledgeIds = new DA.Pledge().GetPledgeId(whrId, approvedPledgeStatusCode);
            if (pledgeIds.Count > 1)
            {
                throw new InvalidOperationException("Multiple pledge requests are approved on WHRNo " + whrId);
            }
            else if (pledgeIds.Count == 1)
            {
                string memberIdNo = "";
                string clientIdNo = "";

                Guid ownerId = whrRow.ClientId;

                if (prmlTypeId == new IFLookup().GetLookupId("tblPRMLType", "Foreclosed"))
                {
                    ownerId = new Guid(whrRow["OwnerId"].ToString());
                }

                if (IFLookup.IsMemberGuid(ownerId))
                {
                    memberIdNo = IFLookup.GetMemberIDNoByMemberGuid(ownerId);
                }
                else if (IFLookup.IsClientGuid(ownerId))
                {
                    clientIdNo = IFLookup.GetClientIDNoByClientGuid(ownerId);
                }

                Guid bankId = IFLookup.GetBankByName(new DA.Pledge().GetPledge(pledgeIds[0]).BankName).UniqueIdentifier;
                Guid bankBranchId = IFLookup.GetBankBranchIdByName(bankId, new DA.Pledge().GetPledge(pledgeIds[0]).BankBranchName);
                string organizationName = IFLookup.GetMembershipEntityOrganizationNameByIdNo((clientIdNo.Length > 0 ? clientIdNo : memberIdNo));
                string commodityGradeSymbol = IFLookup.GetCGradeSymbol(whrRow.CommodityGradeId);
                //if (CanInsertReport(whrId, prmlTypeId))
                //{
                bool result = new DA.PRML().Insert(
                   Guid.NewGuid(),
                   prmlTypeId,
                   bankBranchId,
                   whrId,
                   clientIdNo,
                   memberIdNo,
                   organizationName,
                   commodityGradeSymbol,
                   (float)whrRow.OriginalQuantity,
                   (float)whrRow.CurrentQuantity,
                   DateTime.Parse(whrRow["ExpiryDate"].ToString()),
                   newStatusCode,
                   newStatusCode,
                   userGuid,
                   DateTime.Now,
                   eventDate, eventLots, tradePrice, payoutPrice);
                return result;
                //}
                //else
                //{
                //    return true;
                //}
            }
            return true;
        }
        private static bool InsertReport(int whrId, int prmlTypeId, Guid userGuid)
        {
            return InsertReport(whrId, prmlTypeId, userGuid, null, null, null, null);
        }
        private static bool InsertReport(int whrId, int prmlTypeId, Guid userGuid, DateTime? eventDate, double? eventLots)
        {
            return InsertReport(whrId, prmlTypeId, userGuid, eventDate, eventLots, null, null);
        }
        
        private static bool CanInsertReport(int whrId, int prmlTypeId)
        {
            int count = new DA.PRML().GetPRMLCount(whrId, prmlTypeId, false);
            if (count > 0)
                return false;
            else
                return true;
        }

        private static PRMLView GetPRMLView(BE.IF.PRML.PRMLRow row)
        {
            BE.IF.PRMLView item = new PRMLView();

            item.Id = row.Id;
            item.Type = new IFLookup().GetLookupName("tblPRMLType", (byte)row.TypeId);

            item.WHRNO = row.WHRNO;
            item.ClientId = row.ECXClientId;
            item.MemberId = row.ECXMemberId;
            item.OrganizationName = row.OrganizationName;

            item.BankName = IFLookup.GetBankByBranchId(row.BankBranchId);
            item.BankBranchName = IFLookup.GetBankBranchName(row.BankBranchId);

            item.ComodityGradeSymbol = row.CommodityGradeSymbol;//IFLookup.GetCGradeSymbol(commodityGradeId);
            item.OriginalLots = (float)row.OriginalLots;
            item.CurrentLots = (float)row.CurrentLots;
            item.ExpiryDate = row.ExpiryDate.ToString("dd-MMM-yyyy");
            if (!row.IsEventDateNull())
                item.EventDate = row.EventDate.ToString("dd-MMM-yyyy");
            if (!row.IsEventLotsNull())
                item.EventLots = row.EventLots.ToString("N4");
            if (!row.IsTradePriceNull())
                item.TradePrice = row.TradePrice.ToString("N2");
            if (!row.IsPayoutValueNull())
                item.PayoutValue = row.PayoutValue.ToString("N2");
            if (!row.IsConfirmedByNull())
                item.ConfirmedBy = Security.SecurityHelper.GetUserName(row.ConfirmedBy);
            if (!row.IsConfirmedDateNull())
                item.ConfirmedDate = row.ConfirmedDate.ToString("dd-MMM-yyyy");
            if (!row.IsAuthorizedByNull())
                item.AuthorizedBy = Security.SecurityHelper.GetUserName(row.AuthorizedBy);
            if (!row.IsAuthorizedDateNull())
                item.AuthorizedDate = row.AuthorizedDate.ToString("dd-MMM-yyyy");

            item.Status = new IFLookup().GetLookupName("tblPRMLStatus", row.Status);
            item.TempStatus = true;

            item.Remark = row.Remark;

            return item;
        }
        private EmptyPRMLView GetEmptyPRMLView(ECX.CD.BE.IF.PRML.EmptyPRMLRow row)
        {
            BE.IF.EmptyPRMLView item = new EmptyPRMLView();

            item.Id = row.Id;
            item.BankName = IFLookup.GetBankName(row.BankId);
            if (!row.IsConfirmedByNull())
                item.ConfirmedBy = Security.SecurityHelper.GetUserName(row.ConfirmedBy);
            if (!row.IsConfirmedDateNull())
                item.ConfirmedDate = row.ConfirmedDate.ToString("dd-MMM-yyyy");
            if (!row.IsAuthorizedByNull())
                item.AuthorizedBy = Security.SecurityHelper.GetUserName(row.AuthorizedBy);
            if (!row.IsAuthorizedDateNull())
                item.AuthorizedDate = row.AuthorizedDate.ToString("dd-MMM-yyyy");

            item.Status = new IFLookup().GetLookupName("tblPRMLStatus", row.Status);

            return item;
        }

        public List<BE.IF.PRMLView> SearchPRML(int whrNoFrom, int whrNoTo, int grnNoFrom, int grnNoTo, Guid bankId, Guid bankBranchId, string mcId, DateTime expiryDateFrom, DateTime expiryDateTo, byte status)
        {
            List<Guid> bankBranchIds = new List<Guid>();
            if (bankBranchId != Guid.Empty)
            {
                bankBranchIds.Add(bankBranchId);
            }
            else if (bankId != Guid.Empty)
            {
                bankBranchIds = IFLookup.GetBankBranchIds(bankId);
            }
            DataTable table = new DA.PRML().SearchPRML(whrNoFrom, whrNoTo, grnNoFrom, grnNoTo, bankBranchIds, mcId, expiryDateFrom, expiryDateTo, status);

            List<PRMLView> items = new List<PRMLView>();
            foreach (BE.IF.PRML.PRMLRow row in table.Rows)
            {
                BE.IF.PRMLView item = GetPRMLView(row);

                items.Add(item);
            }
            return items;
        }
        public List<BE.IF.PRMLView> SearchPRML(Guid? bankId, DateTime authorizedDateFrom, DateTime authorizedDateTo, byte status, bool onlyAuthorized)
        {
            List<Guid> bankBranchIds = new List<Guid>();
            if (bankId.HasValue)
            {
                bankBranchIds = IFLookup.GetBankBranchIds(bankId.Value);
            }
            DataTable table = new DA.PRML().SearchPRML(bankBranchIds, authorizedDateFrom, authorizedDateTo, status, onlyAuthorized);

            List<PRMLView> items = new List<PRMLView>();
            foreach (BE.IF.PRML.PRMLRow row in table.Rows)
            {
                BE.IF.PRMLView item = GetPRMLView(row);

                items.Add(item);
            }
            return items;
        }
        public List<BE.IF.EmptyPRMLView> SearchEmptyPRML(Guid? bankId, DateTime authorizedDateFrom, DateTime authorizedDateTo, byte status, bool onlyAuthorized)
        {
            DataTable table = new DA.PRML().SearchEmptyPRML(bankId, authorizedDateFrom, authorizedDateTo, status, onlyAuthorized);

            List<EmptyPRMLView> items = new List<EmptyPRMLView>();
            foreach (BE.IF.PRML.EmptyPRMLRow row in table.Rows)
            {
                BE.IF.EmptyPRMLView item = GetEmptyPRMLView(row);

                items.Add(item);
            }
            return items;
        }

        public static int GetAuthoriseTasksCount()
        {
            BL.PRML prml = new BL.PRML();

            return prml.GetPRMLForAuthorisation().Count + prml.GetEmptyPRMLForAuthorisation().Count;
        }
        public static int GetConfirmTasksCount()
        {
            BL.PRML prml = new BL.PRML();

            return prml.GetPRMLForConfirmation().Count + prml.GetEmptyPRMLForConfirmation().Count;
        }

        public List<BE.IF.PRMLView> GetPRMLForConfirmation()
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();
            List<BE.IF.PRMLView> items = new List<ECX.CD.BE.IF.PRMLView>();

            foreach (Guid bankId in bankIds)
            {
                items.AddRange(GetPRMLForConfirmation(bankId));
            }
            //for records whose bankname is not found in the lookup database
            //  bankbranchid is set to empty Guid
            //The following code collects those records.
            items.AddRange(GetPRMLForConfirmationFonUnknownBankBranches());

            return items;
        }
        public List<BE.IF.PRMLView> GetPRMLForConfirmation(Guid bankId)
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblPRMLStatus", "New"));
            if (IFLookup.GetBankBranchIds(bankId).Count == 0)
            {
            }
            BE.IF.PRML.PRMLDataTable table = new DA.PRML().GetPRML(IFLookup.GetBankBranchIds(bankId), status);
            List<BE.IF.PRMLView> items = new List<ECX.CD.BE.IF.PRMLView>();

            foreach (BE.IF.PRML.PRMLRow row in table.Rows)
            {
                BE.IF.PRMLView item = GetPRMLView(row);

                items.Add(item);
            }

            return items;
        }
        public List<BE.IF.PRMLView> GetPRMLForConfirmationFonUnknownBankBranches()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblPRMLStatus", "New"));
            List<Guid> banks = new List<Guid>();
            banks.Add(Guid.Empty);

            BE.IF.PRML.PRMLDataTable table = new DA.PRML().GetPRML(banks, status);
            List<BE.IF.PRMLView> items = new List<ECX.CD.BE.IF.PRMLView>();

            foreach (BE.IF.PRML.PRMLRow row in table.Rows)
            {
                BE.IF.PRMLView item = GetPRMLView(row);

                items.Add(item);
            }

            return items;
        }
        public List<BE.IF.EmptyPRMLView> GetEmptyPRMLForConfirmation(Guid bankId)
        {
            byte newStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "New");
            DataTable table = new DA.PRML().GetEmptyPRML(bankId, newStatusCode, false);

            List<EmptyPRMLView> items = new List<EmptyPRMLView>();
            foreach (BE.IF.PRML.EmptyPRMLRow row in table.Rows)
            {
                BE.IF.EmptyPRMLView item = GetEmptyPRMLView(row);

                items.Add(item);
            }
            return items;
        }
        public List<BE.IF.EmptyPRMLView> GetEmptyPRMLForConfirmation()
        {
            List<BE.IF.EmptyPRMLView> items = new List<ECX.CD.BE.IF.EmptyPRMLView>();
            List<Guid> bankIds = GetBanksEngagedInWRF();
            foreach (Guid bankId in bankIds)
            {
                items.AddRange(GetEmptyPRMLForConfirmation(bankId));
            }
            return items;
        }

        public List<BE.IF.PRMLView> GetPRMLForAuthorisation(Guid bankId)
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblPRMLStatus", "Rejected"));
            status.Add(new IFLookup().GetLookupId("tblPRMLStatus", "Approved"));

            BE.IF.PRML.PRMLDataTable table = new DA.PRML().GetPRML(IFLookup.GetBankBranchIds(bankId), status, false);
            List<BE.IF.PRMLView> items = new List<BE.IF.PRMLView>();

            foreach (BE.IF.PRML.PRMLRow row in table.Rows)
            {
                BE.IF.PRMLView item = GetPRMLView(row);

                items.Add(item);
            }

            return items;
        }
        public List<BE.IF.PRMLView> GetPRMLForAuthorisation()
        {
            List<Guid> bankIds = IFLookup.GetAllBankIds();
            List<BE.IF.PRMLView> items = new List<ECX.CD.BE.IF.PRMLView>();

            foreach (Guid bankId in bankIds)
            {
                items.AddRange(GetPRMLForAuthorisation(bankId));
            }
            //for records whose bankname is not found in the lookup database
            //  bankbranchid is set to empty Guid
            //The following code collects those records.
            items.AddRange(GetPRMLForAuthorisationForUnknownBankBranches());

            return items;
        }
        private List<BE.IF.PRMLView> GetPRMLForAuthorisationForUnknownBankBranches()
        {
            List<byte> status = new List<byte>();
            status.Add(new IFLookup().GetLookupId("tblPRMLStatus", "Rejected"));
            status.Add(new IFLookup().GetLookupId("tblPRMLStatus", "Approved"));

            List<Guid> banks = new List<Guid>();
            banks.Add(Guid.Empty);

            BE.IF.PRML.PRMLDataTable table = new DA.PRML().GetPRML(banks, status, false);
            List<BE.IF.PRMLView> items = new List<ECX.CD.BE.IF.PRMLView>();

            foreach (BE.IF.PRML.PRMLRow row in table.Rows)
            {
                BE.IF.PRMLView item = GetPRMLView(row);

                items.Add(item);
            }

            return items;
        }
        public List<BE.IF.EmptyPRMLView> GetEmptyPRMLForAuthorisation(Guid bankId)
        {
            byte approvedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Approved");
            DataTable table = new DA.PRML().GetEmptyPRML(bankId, approvedStatusCode, false);

            List<EmptyPRMLView> items = new List<EmptyPRMLView>();
            foreach (BE.IF.PRML.EmptyPRMLRow row in table.Rows)
            {
                BE.IF.EmptyPRMLView item = GetEmptyPRMLView(row);

                items.Add(item);
            }
            return items;
        }
        public List<BE.IF.EmptyPRMLView> GetEmptyPRMLForAuthorisation()
        {
            List<BE.IF.EmptyPRMLView> items = new List<ECX.CD.BE.IF.EmptyPRMLView>();
            List<Guid> bankIds = GetBanksEngagedInWRF();
            foreach (Guid bankId in bankIds)
            {
                items.AddRange(GetEmptyPRMLForAuthorisation(bankId));
            }
            return items;
        }

        public bool SavePRML(List<Guid> prmlIds, List<bool> statuses, List<string> remarks, Guid userGuid)
        {
            byte rejectedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Rejected");
            byte approvedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Approved");
            AuditTrail audit = new AuditTrail();

            using (TransactionScope scope = new TransactionScope())
            {
                int count = 0;
                foreach (Guid prmlId in prmlIds)
                {
                    byte statusCode = (statuses[count] ? approvedStatusCode : rejectedStatusCode);

                    BE.IF.PRML.PRMLRow row = new DA.PRML().GetPRML(prmlId);
                    string reportType = new IFLookup().GetLookupName("tblPRMLType", (byte)row.TypeId);

                    string oldAuditValue = string.Format("ID = {0}; WHRNO = {1}; ReportType = {2}; Approved = {3};  Remark = {4}", prmlId, row.WHRNO, reportType, (statuses[count]).ToString(), row.Remark);
                    string newAuditValue = string.Format("Approved = {0}; Remark = {1}", (statuses[count]).ToString(), remarks[count]);

                    audit.Add(AuditTrailModules.WRFSavePRML, oldAuditValue, newAuditValue);

                    if (!new DA.PRML().SavePRMLTempStatus(prmlId, statusCode, remarks[count], userGuid, DateTime.Now))
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
        public bool CommitPRML(List<Guid> prmlIds, List<bool> statuses, List<string> remarks, Guid userGuid)
        {
            byte rejectedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Rejected");
            byte approvedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Approved");
            AuditTrail audit = new AuditTrail();

            using (TransactionScope scope = new TransactionScope())
            {
                int count = 0;
                foreach (Guid prmlId in prmlIds)
                {
                    BE.IF.PRML.PRMLRow row = new DA.PRML().GetPRML(prmlId);
                    string reportType = new IFLookup().GetLookupName("tblPRMLType", (byte)row.TypeId);

                    string oldAuditValue = string.Format("ID = {0}; WHRNO = {1}; ReportType = {2}; Approved = {3};  Remark = {4}", prmlId, row.WHRNO, reportType, (statuses[count]).ToString(), row.Remark);
                    string newAuditValue = string.Format("Approved = {0}; Remark = {1}", (statuses[count]).ToString(), remarks[count]);

                    audit.Add(AuditTrailModules.WRFConfirmPRML, oldAuditValue, newAuditValue);

                    byte statusCode = (statuses[count] ? approvedStatusCode : rejectedStatusCode);
                    if (!new DA.PRML().ConfirmPRML(prmlId, statusCode, remarks[count], userGuid, DateTime.Now))
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
        public bool CommitEmptyPRML(Guid emptyPRMLId, string bankName, Guid userGuid)
        {
            byte approvedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Approved");
            AuditTrail audit = new AuditTrail();

            BE.IF.PRML.EmptyPRMLRow row = new DA.PRML().GetEmptyPRML(emptyPRMLId);

            string auditValue = string.Format("ID = {0}; Bank = {1};", emptyPRMLId, bankName);

            audit.Add(AuditTrailModules.WRFConfirmEmptyPRML, auditValue);

            if (audit.Save())
            {
                if (new DA.PRML().ConfirmEmptyPRML(emptyPRMLId, approvedStatusCode, userGuid, DateTime.Now))
                {
                    audit.Commit();
                    return true;
                }
                else
                {
                    audit.RollBack();
                    return false;
                }
            }
            else
            {
                throw new InvalidOperationException("Saving audit trail data failed.");
            }
        }

        public bool AuthorisePRML(List<Guid> prmlIds, Guid bankId, byte[] keyFileContent, string keyFileName, string password, Guid userGuid)
        {
            //TODO: chage password by its hash value
            AuditTrail audit = new AuditTrail();
            byte approvedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Approved");

            using (TransactionScope scope = new TransactionScope())
            {
                foreach (Guid prmlId in prmlIds)
                {
                    BE.IF.PRML.PRMLRow row = new DA.PRML().GetPRML(prmlId);
                    string reportType = new IFLookup().GetLookupName("tblPRMLType", (byte)row.TypeId);

                    string newAuditValue = string.Format("ID = {0}; WHRNO = {1}; ReportType = {2}; Approved = {3};  Remark = {4}", prmlId, row.WHRNO, reportType, (row.Status == approvedStatusCode).ToString(), row.Remark);

                    audit.Add(AuditTrailModules.WRFAuthorizePRML, newAuditValue);
                    if (!new DA.PRML().SavePRMLAuthorised(prmlId, userGuid, DateTime.Now))
                    {
                        return false;
                    }
                }
                List<ECXRequest> messages = new List<ECXRequest>();

                ECXRequest message = new ECXRequest();

                message = PrepareResponseInXMLFormat(prmlIds, bankId);

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
        public bool RejectPRML(List<Guid> prmlIds, string rejectionReason, Guid userGuid)
        {
            AuditTrail audit = new AuditTrail();
            byte approvedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Approved");

            using (TransactionScope scope = new TransactionScope())
            {
                byte status = new IFLookup().GetLookupId("tblPRMLStatus", "New");
                foreach (Guid prmlId in prmlIds)
                {
                    BE.IF.PRML.PRMLRow row = new DA.PRML().GetPRML(prmlId);
                    string reportType = new IFLookup().GetLookupName("tblPRMLType", (byte)row.TypeId);

                    string newAuditValue = string.Format("ID = {0}; WHRNO = {1}; ReportType = {2}; Approved = {3};  RejectionReason = {4}", prmlId, row.WHRNO, reportType, (row.Status == approvedStatusCode).ToString(), rejectionReason);

                    audit.Add(AuditTrailModules.WRFRejectPRML, newAuditValue);
                    if (!new DA.PRML().SavePRMLStatus(prmlId, status, rejectionReason, userGuid, DateTime.Now))
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
        public bool AuthoriseEmptyPRML(Guid emptyPRMLId, Guid bankId, byte[] keyFileContent, string keyFileName, string password, Guid userGuid)
        {
            AuditTrail audit = new AuditTrail();

            BE.IF.PRML.PRMLRow row = new DA.PRML().GetPRML(emptyPRMLId);
            string bankName = IFLookup.GetBankName(bankId);

            string auditValue = string.Format("ID = {0}; Bank = {1};", emptyPRMLId, bankName);

            audit.Add(AuditTrailModules.WRFAuthorizeEmptyPRML, auditValue);

            using (TransactionScope scope = new TransactionScope())
            {
                if (new DA.PRML().AutorizeEmptyPRML(emptyPRMLId, userGuid, DateTime.Now))
                {
                    List<ECXRequest> messages = new List<ECXRequest>();

                    ECXRequest message = new ECXRequest();

                    message = PrepareResponseInXMLFormat(new List<Guid>(), bankId);

                    messages.Add(message);

                    if (audit.Save())
                    {
                        if (SendResponse(messages.ToArray(), keyFileContent, keyFileName, password))
                        {
                            scope.Complete();
                            audit.Commit();
                            return true;
                        }
                        else
                        {
                            audit.RollBack();
                            return false;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Saving audit trail data failed.");
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        private ECXRequest PrepareResponseInXMLFormat(List<Guid> prmlIds, Guid bankId)
        {
            ECXRequest message = new ECXRequest();
            message.ECXRequestHeader = new ecxRequestHeader();
            message.ECXRequestData = new ecxRequestData();

            byte approvedStatusCode = new IFLookup().GetLookupId("tblPRMLStatus", "Approved");
            string bankName = IFLookup.GetBankName(bankId);

            message.ECXRequestHeader.IsLive = "y";
            message.ECXRequestHeader.RequestType = "PRML";
            message.ECXRequestHeader.RequestDestination = bankName;
            message.ECXRequestHeader.RequestSignature = string.Empty;

            message.ECXRequestData.Bank = bankName;
            message.ECXRequestData.ReportDate = IFCommon.GetDate(DateTime.Today);


            BE.IF.PRML.PRMLDataTable prmlTable = new BE.IF.PRML.PRMLDataTable();
            if (prmlIds.Count > 0) prmlTable = new DA.PRML().GetPRML(prmlIds);

            List<section> sections = new List<section>();

            List<ECXPRML.Transaction> transactions = new List<ECXPRML.Transaction>();

            section registerSection = new section();
            registerSection.SectionType = "Register";
            transactions.Add(GetTransaction(prmlTable, "Pledged No Sale"));
            transactions.Add(GetTransaction(prmlTable, "Pledged Sale"));
            transactions.Add(GetTransaction(prmlTable, "Foreclosed"));
            registerSection.Transaction = transactions.ToArray();
            sections.Add(registerSection);

            section movementSection = new section();
            transactions = new List<ECXPRML.Transaction>();
            movementSection.SectionType = "Movement";
            transactions.Add(GetTransaction(prmlTable, "Sold"));
            transactions.Add(GetTransaction(prmlTable, "Withdrawn"));
            transactions.Add(GetTransaction(prmlTable, "Unpledged"));
            movementSection.Transaction = transactions.ToArray();
            sections.Add(movementSection);

            message.ECXRequestData.Section = sections.ToArray();

            return message;
        }

        ECXPRML.Transaction GetTransaction(BE.IF.PRML.PRMLDataTable prmlTable, string prmlType)
        {
            byte prmlTypeCode = new IFLookup().GetLookupId("tblPRMLType", prmlType);

            ECXPRML.Transaction currentTransaction = new ECXPRML.Transaction();
            currentTransaction.Type = prmlType;
            List<instruction> instructions = new List<instruction>();

            foreach (BE.IF.PRML.PRMLRow row in prmlTable.Rows)
            {
                if (row.TypeId == prmlTypeCode)
                {
                    instruction currentInstruction = new instruction();

                    currentInstruction.BranchName = IFLookup.GetBankBranchName(row.BankBranchId);
                    currentInstruction.ECXClientID = row.ECXClientId;
                    currentInstruction.ECXMemberID = row.ECXMemberId;
                    currentInstruction.OrganizationName = row.OrganizationName;
                    currentInstruction.WHRID = row.WHRNO;
                    currentInstruction.OriginalLots = row.OriginalLots.ToString();
                    currentInstruction.CurrentLots = row.CurrentLots.ToString();
                    currentInstruction.ExpiryDate = IFCommon.GetDate(row.ExpiryDate);

                    currentInstruction.Date = null;
                    if (prmlType == "Sold" || prmlType == "Withdrawn" || prmlType == "Unpledged")
                    {
                        currentInstruction.Date = IFCommon.GetDate(row.EventDate);
                        currentInstruction.Quantity = row.EventLots;
                    }
                    if (prmlType == "Sold")
                    {
                        currentInstruction.TradePrice = row.TradePrice;
                        currentInstruction.PayOutValue = row.PayoutValue;
                    }

                    instructions.Add(currentInstruction);
                }
            }

            currentTransaction.Instruction = instructions.ToArray();

            return currentTransaction;
        }

        private bool SendResponse(ECXRequest[] messages, byte[] keyFileContent, string keyFileName, string password)
        {
            string result = new ECXPRML.PRMLService().authorisePRML(messages, keyFileContent, password, keyFileName);
            if (result.ToLower() == "ok")
                return true;
            else
                throw new BL.IF.ResponseAuthorizationException("PRML authorisation failed. The Authorisation service returned : " + result);
        }
    }
}
