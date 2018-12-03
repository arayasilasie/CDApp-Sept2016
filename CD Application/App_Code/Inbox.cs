using System.Linq;
using System.Web;
using System.Collections.Generic;
using ECXWorkFlow;
using ECX.CD.Security;
using System.ComponentModel;

namespace ECX.CD.WorkFlow
{
    public class CInbox
    {
        public string Category { get; set; }
        public string TaskName { get; set; }
        public string DisplayName { get; set; }
        public int Count { get; set; }
        public string TaskListUrl { get; set; }
        public List<string> TransactionNumberList { get; set; }

    }
    [DataObject]
    public class Inbox
    {
        List<CInbox> list = new List<CInbox>();
        public Inbox()
        {
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<CInbox> GetList(string taskCategory)
        {
            ECXEngine engine = new ECXEngine();
            List<CInbox> inbox = new List<CInbox>();

            foreach (CDSecurityRights right in SecurityHelper.CurrentUserRights)
            {
                string transactionTypeCode = WorkFlow.GetTransactionTypeCode(right);
                string taskName = WorkFlow.GetTaskName(right);
                string stepNo = WorkFlow.GetStepNo(right);

                List<string> tranNos = engine.GetTransactionsByTaskName(transactionTypeCode, taskName, stepNo).ToList<string>();

                string displayName = SecurityHelper.GetRightDisplayName(right);
                string taskListUrl = WorkFlow.GetTaskListUrl(right);
                string category = Inbox.GetCategory(right);

                if (displayName.Length > 0 && category == taskCategory)
                {
                    CInbox i = new CInbox();
                    i.DisplayName = displayName;
                    i.TaskName = taskName;
                    i.Category = category;
                    i.TransactionNumberList = tranNos;
                    i.Count = tranNos.Count;

                    i.TaskListUrl = taskListUrl;
                    inbox.Add(i);

                    string taskListAbsoluteUrl = HttpContext.Current.Server.MapPath(taskListUrl);

                    if (HttpContext.Current.Session[taskListAbsoluteUrl] == null)
                    {
                        HttpContext.Current.Session.Add(taskListAbsoluteUrl, tranNos);
                    }
                    else
                    {
                        HttpContext.Current.Session[taskListAbsoluteUrl] = tranNos;
                    }
                }
            }

            if (taskCategory == "CD")
            {
                inbox.AddRange(GetApproveWHRTaskList());

				//inbox.Add(GetInboxItem(
				//            "Approve WHR",
				//            new BL.WarehouseReciept().GetApproveWHRCancelCount(),
				//            "CD",
				//            "~/Pages/ApproveWHR.aspx"));

                inbox.Add(GetInboxItem(
                            "Approve WHR Cancellation",
                            new BL.WarehouseReciept().GetApproveWHRCancelCount(),
                            "CD",
                            "~/Pages/ApproveWHRCancel.aspx"));

                //inbox.Add(GetInboxItem(
                //            "Approve PUN Cancellation",
                //            new BL.PUN().GetApprovePUNCancelCount(),
                //            "CD",
                //            "~/Pages/ApprovePUNCancel.aspx"));

                inbox.Add(GetInboxItem(
                             "Approve Expiry Date Extentsion",
                             new BL.WarehouseReciept().GetApproveExtendExpiryDateCount(),
                             "CD",
                             "~/Pages/ApproveExtendExpiryDate.aspx"));

                inbox.Add(GetInboxItem(
                             "Approve PUN Expiry Date Extentsion",
                             new BL.PUN().GetPUNForExtendExpiryApprovalCount(),
                             "CD",
                             "~/Pages/ApproveExtendPUNExpiryDate.aspx"));

                inbox.Add(GetInboxItem(
                             "Approve PUN Edit",
                             new BL.PUN().GetPUNEditApprovalCount(),
                             "CD",
                             "~/Pages/ApprovePUNEdit.aspx"));

				//inbox.Add(GetInboxItem(
				//             "Prepare Title Transfer",
				//             new BL.TitleTransfer().GetPrepareTitleTransferCount(),
				//             "CD",
				//             "~/Pages/PrepareTitleTransfer.aspx"));

				//inbox.Add(GetInboxItem(
				//             "Transfer Title",
				//             new BL.TitleTransfer().GetTransferTitleCount(),
				//             "CD",
				//             "~/Pages/TransferTitle.aspx"));
            }

            if (taskCategory == "IF")
            {
                inbox.AddRange(GetIFTaskList());
            }

            return inbox;
        }

        private static List<CInbox> GetIFTaskList()
        {
			List<CInbox> list = new List<CInbox>();

			list.Add(GetInboxItem(
						"Confirm Pledge Requests",
						new BL.Pledge().GetPledgeForConfirmationCount(),
						"IF",
						"~/IF/ConfirmPR.aspx"));

			list.Add(GetInboxItem(
						"Authorise Pledge Response",
						new BL.Pledge().GetPledgeForAuthoriseCount(),
						"IF",
						"~/IF/AuthorisePR.aspx"));

			list.Add(GetInboxItem(
						"Confirm LNS Requests",
						new BL.LNS().GetLNSForConfirmationCount(),
						"IF",
						"~/IF/ConfirmLNS.aspx"));

			list.Add(GetInboxItem(
						"Authorise LNS Response",
						new BL.LNS().GetLNSForAuthorizationCount(),
						"IF",
						"~/IF/AuthoriseLNS.aspx"));

            list.Add(GetInboxItem(
                        "Confirm Unpledge Requests",
                        BL.UP.GetConfirmTasksCount(),
                        "IF",
                        "~/IF/ConfirmUP.aspx"));

            list.Add(GetInboxItem(
                        "Authorise Unpledge Requests",
                        BL.UP.GetAuthoriseTasksCount(),
                        "IF",
                        "~/IF/AuthoriseUP.aspx"));

            list.Add(GetInboxItem(
                        "Confirm PRML",
                        BL.PRML.GetConfirmTasksCount(),
                        "IF",
                        "~/IF/ConfirmPRML.aspx"));

            list.Add(GetInboxItem(
                        "Authorise PRML",
                        BL.PRML.GetAuthoriseTasksCount(),
                        "IF",
                        "~/IF/AuthorisePRML.aspx"));

            list.Add(GetInboxItem(
                        "Confirm Foreclosure",
                        BL.FR.GetConfirmTasksCount(),
                        "IF",
                        "~/IF/ConfirmForeclosure.aspx"));

            list.Add(GetInboxItem(
                        "Authorise Foreclosure",
                        BL.FR.GetAuthoriseTasksCount(),
                        "IF",
                        "~/IF/AuthoriseForeclosure.aspx"));
            return list;
        }
        static CInbox GetInboxItem(string displayName, int taskCount, string category, string taskListUrl)
        {
            CInbox inbox = new CInbox();
            inbox.Count = taskCount;
            inbox.DisplayName = displayName;
            inbox.Category = category;
            inbox.TaskListUrl = taskListUrl;

            return inbox;
        }
        private static List<CInbox> GetApproveWHRTaskList()
        {
            List<CInbox> list = new List<CInbox>();

            list.Add(GetInboxItem(
                "Approve WHR",
                new BL.WarehouseReciept().GetWHRForApprovalCount(),
                "CD", "~/Pages/ApproveWHR.aspx"));

            return list;
        }

        private static string GetCategory(CDSecurityRights right)
        {
            switch (right)
            {
                case CDSecurityRights.CDPrepareTT:
                    return "CD";
                case CDSecurityRights.CDTransferTitle:
                    return "CD";
                case CDSecurityRights.CDApproveWHR:
                    return "CD";
                case CDSecurityRights.CDNewAccount:
                    return "CH";
                case CDSecurityRights.CDOpenAccount:
                    return "CH";
                //case CDSecurityRights.CDCloseAccount:
                //    return "Bank Account";
                //case CDSecurityRights.CDSuspendAccount:
                //    return "Bank Account";
                case CDSecurityRights.CDAppCloAcc:
                    return "CH";
                case CDSecurityRights.CDAppSusAcc:
                    return "CH";
                case CDSecurityRights.CDAppResAcc:
                    return "CH";
                default:
                    return string.Empty;
            }
        }
    }
}
