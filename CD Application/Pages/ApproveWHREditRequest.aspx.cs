using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ECX.CD.Lookup;
using ECX.CD.Security;

public partial class Pages_ApproveWHREditRequest : System.Web.UI.Page
{
    ECX.CD.BE.WR.ViewWarehouseRecieptDataTable items = new ECX.CD.BE.WR.ViewWarehouseRecieptDataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDApproveWHREdit))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }

        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Methods
    private void InitializeControls()
    {
        ((MasterPage_pTop)Page.Master).DescriptionText = "Approve WHR Edit Request";

        //rpWR.DataSource = new ECX.CD.BL.WarehouseReciept().GetWHRForEditRequestApproval();
        //rpWR.DataBind();

        string[] transactionIds = (string[])Session["TransactionId"];
    }

    private void ApproveWHREditRequest()
    {
        //new ECX.CD.BL.WarehouseReciept().ApproveWHREditRequest(SelectedIds(), Common.GetUserId(Session, Response));
    }

    List<Guid> SelectedIds()
    {
        List<Guid> ret = new List<Guid>();

        foreach (RepeaterItem item in rpWR.Items)
        {
            if (((HtmlInputCheckBox)item.FindControl("chkSelected")).Checked)
            {
                ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWarehouseRecieptId")).CommandArgument));
            }
        }

        return ret;
    }
    #endregion

    #region Event Handlers

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        ApproveWHREditRequest();
    }

    protected void lbtnWarehouseRecieptId_Command(object sender, CommandEventArgs e)
    {
        Session.Add("WRId", e.CommandArgument.ToString());
        ViewManager.ShowWRDetail(Session, Page);

        //wRDetail.Id = e.CommandArgument.ToString();
        //mdlWRDetail.Show();
    }

    #endregion
}
