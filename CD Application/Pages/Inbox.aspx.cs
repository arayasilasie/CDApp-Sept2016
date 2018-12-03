using System;
using ECX.CD.Security;

public partial class Pages_Inbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Refresh();
        }
    }

    #region Methods
    private void PopulateWHRTasks()
    {
        #region WHR
        //ECX.CD.BE.Workflow.InboxDataTable inboxes = new ECX.CD.BE.Workflow.InboxDataTable();
        //ECX.CD.WorkFlow.Inbox inboxes = new Inbox();

        //string[] transactionIds = new ECXWorkFlow.ECXEngine().GetTransactionsByTaskName(
        //    TransactionTypes.CDApproveWHR.ToString(), "CDApproveWHR", "1");

        //inboxes.AddInboxRow(
        //    "Approve WHR",
        //    new ECX.CD.BL.WarehouseReciept().GetWHRForApprovalCount(), "CDApproveWHR");

        //dtgWHR.DataSource = ECX.CD.WorkFlow.Inbox.GetList();
        //dtgWHR.DataBind();
        #endregion

        #region Prepare TT
        //ECX.CD.BE.Workflow.InboxDataTable tTs = new ECX.CD.BE.Workflow.InboxDataTable();

        //tTs.AddInboxRow(
        //    "Prepare Title Transfer (TT1)",
        //    new ECX.CD.BL.TitleTransfer().GetPrepareTitleTransferCount(), "CDPrepareTitleTransfer");
        //tTs.AddInboxRow(
        //    "Transfer Title (TT2)",
        //    new ECX.CD.BL.TitleTransfer().GetTransferTitleCount(), "CDTransferTitle");

        //dtgTitleTransfer.DataSource = tTs;
        //dtgTitleTransfer.DataBind();
        #endregion
    }

    protected void ImportNewMembers()
    {
        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (SecurityHelper.HasPermission(CDSecurityRights.CDNewAccount))
        {
            ECX.CD.WorkFlow.WorkFlow.ImportNewMembersForAccountCreation();
        }
    }

    void Refresh()
    {
        PopulateWHRTasks();
        ImportNewMembers();
        //ImportIFTasks();

        dsCDTasks.DataBind();
        dsWHRTasks.DataBind();
    }

    private void ImportIFTasks()
    {
        ECX.CD.BL.FR.ImportForclosureRequest(SecurityHelper.CurrentUserGuid.Value);
        ECX.CD.BL.UP.ImportUP(SecurityHelper.CurrentUserGuid.Value);
    }
    #endregion

    #region Event Handlers
    protected void lkbRefreshList_Click(object sender, EventArgs e)
    {
        Refresh();
    }

    //protected void NavigateToTaskList(object sender, GridViewCommandEventArgs e)
    //{
    //    if(((GridView)sender).ID == dtgWHR.ID && e.CommandName == "TaskList")
    //    {
    //        Session.Add("CDApproveWHRTransactionIds", 
    //            new ECXWorkFlow.ECXEngine().GetTransactionsByTaskName(TransactionTypes.CDApproveWHR.ToString(), "CDApproveWHR", "1"));

    //        Response.Redirect(UrlFactory.GetUrl(TransactionTypes.CDApproveWHR.ToString()));
    //    }
    //    else if (((GridView)sender).ID == dtgTitleTransfer.ID && e.CommandName == "TaskList")
    //    {
    //        if (e.CommandArgument == "CDPrepareTitleTransfer")
    //        {
    //            Session.Add("CDPrepareTitleTransferIds",
    //                new ECXWorkFlow.ECXEngine().GetTransactionsByTaskName(TransactionTypes.CDApproveWHR.ToString(), "CDPrepareTitle", "1"));
    //        }
    //        Response.Redirect(UrlFactory.GetUrl(TransactionTypes.CDApproveWHR.ToString()));
    //    }
    //}
    #endregion
}
