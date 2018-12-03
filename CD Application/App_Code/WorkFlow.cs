using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ECXWorkFlow;
using ECX.CD.Security;
using System.Collections.Generic;
using System.Transactions;

namespace ECX.CD.WorkFlow
{
    public enum TransactionTypes
    {
        CancelWHR,
        CancelPUN,
        EditWHR,
        PrepareTT,
        TransferTitle,
        ApproveWHR,
        AddNewBankAccount,
        SuspendBankAccount,
        CloseBankAccount,
        ResumeBankAccount
    }

    public class WorkFlow
    {
        public WorkFlow()
        {
        }

        public static bool StepCompleted(string transactionNumber)
        {
            ECXEngine engine = new ECXEngine();
            if (transactionNumber == null)
            {
                return false;
            }
            string[] locationCodes = new string[] { };
            CMessage[] m = engine.Request(transactionNumber, SecurityHelper.CurrentUserGuid.Value, locationCodes);
            if (m.Length > 0)
            {
                m[0].IsCompleted = true;
                engine.Response(transactionNumber, m[0]);
                UnlockTask(transactionNumber);
                return true;
            }
            else
            {
                ErrorHandler.WriteLogEntry("workflow action failed", "Workflow step cannot be completed", string.Format("Transaction Number : {0} User Guid : {1}", transactionNumber, SecurityHelper.CurrentUserGuid.Value));
                return false;
            }
        }

        public static bool AbortTransaction(string transactionNumber)
        {
            bool success = false;
            try
            {
                if (transactionNumber != null)
                {
                    new ECXEngine().CloseTransaction(transactionNumber);
                    return true;
                }
            }
            finally
            {
                success = false;
            }
            return success;
        }

        public static string GetTransactionTypeCode(TransactionTypes transactionType)
        {
            return "CD" + transactionType.ToString();
        }

        public static string GetTaskName(CDSecurityRights right)
        {
            switch (right)
            {
                //case CDSecurityRights.CDApproveWHRCancel:
                //    return "ApproveWHRCancel";
                //case CDSecurityRights.CDApprovePUNCancel:
                //    return "ApprovePUNCancel";
                //case CDSecurityRights.CDApproveWHREdit:
                //    return "ApproveWHREdit";
                //case CDSecurityRights.CDEditWHR:
                //    return "EditWHR";
                //case CDSecurityRights.CDPrepareTT:
                //    return "PrepareTT";
                //case CDSecurityRights.CDTransferTitle:
                //    return "TransferTitle";
                case CDSecurityRights.CDNewAccount:
                    return "AddNewAccounts";
                case CDSecurityRights.CDOpenAccount:
                    return "ApproveNewAccounts";
                case CDSecurityRights.CDCloseAccount:
                    return "CloseBankAccount";
                case CDSecurityRights.CDAppCloAcc:
                    return "ApproveAccountClosure";
                case CDSecurityRights.CDAppSusAcc:
                    return "ApproveAccountSuspension";
                case CDSecurityRights.CDAppResAcc:
                    return "ApproveAccountResumption";
                default:
                    return string.Empty;
            }
        }

        public static string GetStepNo(CDSecurityRights right)
        {
            switch (right)
            {
                //case CDSecurityRights.CDApproveWHRCancel:
                //    return "1";
                //case CDSecurityRights.CDApprovePUNCancel:
                //    return "1";
                //case CDSecurityRights.CDCancelPUN:
                //    return "2";
                //case CDSecurityRights.CDApproveWHREdit:
                //    return "1";
                //case CDSecurityRights.CDEditWHR:
                //    return "2";
                //case CDSecurityRights.CDPrepareTT:
                //    return "1";
                //case CDSecurityRights.CDTransferTitle:
                //    return "1";
                case CDSecurityRights.CDNewAccount:
                    return "2";
                case CDSecurityRights.CDOpenAccount:
                    return "3";
                case CDSecurityRights.CDCloseAccount:
                    return "1";
                case CDSecurityRights.CDSuspendAccount:
                    return "1";
                case CDSecurityRights.CDAppCloAcc:
                    return "2";
                case CDSecurityRights.CDAppSusAcc:
                    return "2";
                case CDSecurityRights.CDAppResAcc:
                    return "2";
                default:
                    return string.Empty;
            }
        }

        public static string GetTransactionTypeCode(CDSecurityRights right)
        {
            switch (right)
            {
                //case CDSecurityRights.CDApproveWHRCancel:
                //    return GetTransactionTypeCode(TransactionTypes.CancelWHR);
                //case CDSecurityRights.CDApprovePUNCancel:
                //    return GetTransactionTypeCode(TransactionTypes.CancelPUN);
                //case CDSecurityRights.CDApproveWHREdit:
                //return GetTransactionTypeCode(TransactionTypes.EditWHR);
                case CDSecurityRights.CDPrepareTT:
                    return GetTransactionTypeCode(TransactionTypes.PrepareTT);
                case CDSecurityRights.CDTransferTitle:
                    return GetTransactionTypeCode(TransactionTypes.TransferTitle);
                case CDSecurityRights.CDNewAccount:
                    return GetTransactionTypeCode(TransactionTypes.AddNewBankAccount);
                case CDSecurityRights.CDOpenAccount:
                    return GetTransactionTypeCode(TransactionTypes.AddNewBankAccount);
                case CDSecurityRights.CDCloseAccount:
                    return GetTransactionTypeCode(TransactionTypes.CloseBankAccount);
                case CDSecurityRights.CDAppCloAcc:
                    return GetTransactionTypeCode(TransactionTypes.CloseBankAccount);
                case CDSecurityRights.CDSuspendAccount:
                    return GetTransactionTypeCode(TransactionTypes.SuspendBankAccount);
                case CDSecurityRights.CDAppSusAcc:
                    return GetTransactionTypeCode(TransactionTypes.SuspendBankAccount);
                case CDSecurityRights.CDResumeAccount:
                    return GetTransactionTypeCode(TransactionTypes.ResumeBankAccount);
                case CDSecurityRights.CDAppResAcc:
                    return GetTransactionTypeCode(TransactionTypes.ResumeBankAccount);
                default:
                    return string.Empty;
            }
        }

        public static string GetTaskListUrl(CDSecurityRights right)
        {
            switch (right)
            {
                //case CDSecurityRights.CDApproveWHRCancel:
                //    return "~/Pages/ApproveWHRCancel.aspx";
                //case CDSecurityRights.CDApprovePUNCancel:
                //    return "~/Pages/ApprovePUNCancel.aspx";
                //case CDSecurityRights.CDApproveWHREdit:
                //    return "~/Pages/ApproveWHREdit.aspx";
                //case CDSecurityRights.CDEditWHR:
                //    return "~/Pages/EditWHR.aspx";
                //case CDSecurityRights.CDPrepareTT:
                //    return "~/Pages/TransferTitle.aspx";
                case CDSecurityRights.CDTransferTitle:
                    return "~/Pages/TransferTitle.aspx";
                case CDSecurityRights.CDViewWHR:
                    return "~/Pages/WarehouseReciept.aspx";
                case CDSecurityRights.CDNewAccount:
                    return "~/Pages/BankAccount.aspx";
                case CDSecurityRights.CDOpenAccount:
                    return "~/Pages/ActivateNewBankAccount.aspx";
                case CDSecurityRights.CDAppCloAcc:
                    return "~/Pages/CloseBankAccount.aspx";
                case CDSecurityRights.CDAppSusAcc:
                    return "~/Pages/SuspendBankAccount.aspx";
                case CDSecurityRights.CDAppResAcc:
                    return "~/Pages/ResumeBankAccount.aspx";
                default:
                    return string.Empty;
            }
        }

        public static Guid GetTransactionTypeId(TransactionTypes transactionTypes)
        {
            switch (transactionTypes)
            {
                //case TransactionTypes.CancelWHR:
                //    return new Guid(ConfigurationManager.AppSettings["CancelWHR"]);
                //case TransactionTypes.CancelPUN:
                //    return new Guid(ConfigurationManager.AppSettings["CancelPUN"]);
                //case TransactionTypes.EditWHR:
                //    return new Guid(ConfigurationManager.AppSettings["EditWHR"]);
                //case TransactionTypes.PrepareTT:
                //    return new Guid(ConfigurationManager.AppSettings["PrepareTTTransType"]);
                //case TransactionTypes.TransferTitle:
                //    return new Guid(ConfigurationManager.AppSettings["TransferTitleTransType"]);
                //case TransactionTypes.ApproveWHR:
                //    return new Guid(ConfigurationManager.AppSettings["ApproveWHRTransType"]);
                case TransactionTypes.AddNewBankAccount:
                    return new Guid(ConfigurationManager.AppSettings["AddNewBankAccountTransType"]);
                case TransactionTypes.SuspendBankAccount:
                    return new Guid(ConfigurationManager.AppSettings["SuspendBankAccountTransType"]);
                case TransactionTypes.CloseBankAccount:
                    return new Guid(ConfigurationManager.AppSettings["CloseBankAccountTransType"]);
                case TransactionTypes.ResumeBankAccount:
                    return new Guid(ConfigurationManager.AppSettings["ResumeBankAccountTransType"]);
                default:
                    return Guid.Empty;
            }
        }

        public static bool OpenTransaction(TransactionTypes transactionType, out string transactionNo)
        {
            ECXEngine engine = new ECXEngine();
            Guid transactionTypeGuid = WorkFlow.GetTransactionTypeId(transactionType);
            string[] locationCodes = new string[] { };

            CMessage[] m = engine.OpenTransaction(transactionTypeGuid, SecurityHelper.CurrentUserGuid.Value, locationCodes, "", out transactionNo);
            return true;
        }

        public static bool InsertMemberTransaction(Guid transactionType, Guid member, string transactionNo, string memberTransactionNo)
        {
            MainDataContextDataContext db = new MainDataContextDataContext();
            int count = db.spMemberTransaction_Insert(transactionType, member, transactionNo, memberTransactionNo);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ImportNewMembersForAccountCreation()
        {
            ECXEngine engine = new ECXEngine();
            string trasactionTypeCode = ConfigurationManager.AppSettings["MembershipNewAccountTransTypeCode"];
            string taskName = ConfigurationManager.AppSettings["MembershipNewAccountTaskName"];
            string stepNo = ConfigurationManager.AppSettings["MembershipNewAccountStepNo"];
            Guid trasactionTypeGuid = GetTransactionTypeId(TransactionTypes.AddNewBankAccount);



            //Get list of transactions from membership application waiting account creation
            List<string> membershipTransactions = engine.GetTransactionsByTaskName(trasactionTypeCode, taskName, stepNo).ToList<string>();

            //bool found = false;
            //if (membershipTransactions.Contains("MMF-1-275997") && membershipTransactions.Contains("MMF-1-275999") && membershipTransactions.Contains("MMF-1-276000") && membershipTransactions.Contains("MMF-1-276002"))
            //{
            //    found = true;
            //}


            //Get Member Guids collected from membership application before this session
            MainDataContextDataContext db = new MainDataContextDataContext();
            var existingMember = from mt in db.tblMemberTransactions
                                 where mt.TransactionTypeId == GetTransactionTypeId(TransactionTypes.AddNewBankAccount)
                                 select new { mt.MemberId, mt.MembershipTransactionNo };

            List<string> listMember = new List<string>();
            foreach (var x in existingMember)
                listMember.Add(x.MemberId + "         " + x.MembershipTransactionNo);


            List<string> transNos = new List<string>();
            //if(existingMember.ToString().Contains("MMF-1-276002"))
            //{
            //    found = true;
            //}

            foreach (string transNo in membershipTransactions)
            {
                int count = existingMember.Count(x => x.MembershipTransactionNo == transNo);

                if (count == 0)
                {
                    //Get member id from membership application using membership transaction number.
                    //Guid memberGuid = Members.GetMembersGuid(transactionNumber, TransactionTypes.AddNewBankAccount);
                    Guid memberGuid = Members.GetMembersGuidByTransNo(transNo);
                    if (memberGuid != Guid.Empty)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            string transactionNumber = string.Empty;
                            if(!WorkFlow.OpenTransaction(TransactionTypes.AddNewBankAccount, out transactionNumber))
                                ErrorHandler.WriteLogEntry("workflow operation failed", "OpenTransaction failed", string.Format("Transaction Type : {0}, User name: {1}, User Guid: {2}", TransactionTypes.AddNewBankAccount.ToString(), SecurityHelper.CurrentUserName, SecurityHelper.CurrentUserGuid.Value));
                            if(!WorkFlow.StepCompleted(transactionNumber))
                                ErrorHandler.WriteLogEntry("workflow operation failed", "StepCompleted failed", string.Format("Transaction Number : {0}, User name: {1}: User Guid: {2}", transNo, SecurityHelper.CurrentUserName, SecurityHelper.CurrentUserGuid.Value));

                            WorkFlow.InsertMemberTransaction(trasactionTypeGuid, memberGuid, transactionNumber, transNo);
                            
                            if (!WorkFlow.UnlockTask(transNo))
                                ErrorHandler.WriteLogEntry("workflow operation failed", "UnlockTask failed", string.Format("Transaction Number : {0}, User name: {1}, User Guid: {2}", transNo, SecurityHelper.CurrentUserName, SecurityHelper.CurrentUserGuid.Value));
                            scope.Complete();
                            scope.Dispose();
                        }
                    }
                }
            }
            return true;
        }

        private static bool UnlockTask(string transNo)
        {
            ECXEngine engine = new ECXEngine();
            if (transNo == null)
            {
                return false;
            }
            engine.UnlockTask(transNo);//, "BankInformation", SecurityHelper.CurrentUserGuid.Value);

            return true;
        }

        public static bool ImportNewPrepareTransferTitleTransaction(
            Guid transactionType, Guid member, string transactionNo, string memberTransactionNo)
        {
            MainDataContextDataContext db = new MainDataContextDataContext();
            int count = db.spMemberTransaction_Insert(transactionType, member, transactionNo, memberTransactionNo);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ImportNewPrepareTransferTitleTransactions()
        {
            //ECXEngine engine = new ECXEngine();


            //string trasactionTypeCode = ConfigurationManager.AppSettings["PrepareTransferTitleTransTypeCode"];
            //string taskName = ConfigurationManager.AppSettings["PrepareTransferTitleTaskName"];
            //string stepNo = ConfigurationManager.AppSettings["PrepareTransferTitleStepNo"];
            //Guid trasactionTypeGuid = GetTransactionTypeId(TransactionTypes.PrepareTitleTransfer);

            ////Get list of transactions from membership application waiting account creation
            //List<string> membershipTransactions = engine.GetTransactionsByTaskName(
            //    GetTransactionTypeCode(TransactionTypes.PrepareTitleTransfer), taskName, stepNo).ToList<string>();

            ////Get Member Guids collected from membership application before this session
            //MainDataContextDataContext db = new MainDataContextDataContext();
            //var existingMember = from mt in db.tblMemberTransactions
            //                     where mt.TransactionTypeId == GetTransactionTypeId(TransactionTypes.AddNewBankAccount)
            //                     select new { mt.MemberId, mt.MembershipTransactionNo };

            //List<string> transNos = new List<string>();

            //foreach (string transNo in membershipTransactions)
            //{
            //    int count = existingMember.Count(x => x.MembershipTransactionNo == transNo);
            //    if (count == 0)
            //    {
            //        string transactionNumber = string.Empty;
            //        //Get member id from membership application using membership transaction number.
            //        Guid memberGuid = Members.GetMembersGuid(transactionNumber);

            //        using (TransactionScope scope = new TransactionScope())
            //        {
            //            WorkFlow.OpenTransaction(TransactionTypes.AddNewBankAccount, out transactionNumber);
            //            WorkFlow.StepCompleted(transactionNumber);
            //            WorkFlow.InsertMemberTransaction(trasactionTypeGuid, memberGuid, transactionNumber, transNo);
            //            scope.Complete();
            //        }
            //    }
            //}

            return true;
        }

        public static string GetMemberTransactionNo(Guid memberGuid, TransactionTypes transactionTypes)
        {
            Guid transType = GetTransactionTypeId(transactionTypes);
            MainDataContextDataContext db = new MainDataContextDataContext();
            var trans = from memberTransactions in db.tblMemberTransactions
                        where memberTransactions.MemberId == memberGuid && memberTransactions.TransactionTypeId == transType
                        orderby memberTransactions.Timestamp descending
                        select memberTransactions.TransactionNo;

            if (trans.Count() > 0)
            {
                return trans.ToList<string>()[0];
            }
            return null;
        }
    }
}
