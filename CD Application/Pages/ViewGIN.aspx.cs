using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ECX.CD.Lookup;
using ECX.CD.Security;

public partial class Pages_ViewGIN : System.Web.UI.Page
{
    //private ECX.CD.BE.GIN.GINDataTable items = new ECX.CD.BE.GIN.GINDataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewGIN))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }

        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Methods
    void RequestGINEdit()
    {
        //new ECX.CD.BL.GIN().RequestGINEdit(SelectedIds(), Common.GetUserId(Session, Response));
    }

    private List<Guid> SelectedIds()
    {
        List<Guid> gINIds = new List<Guid>();

        foreach (RepeaterItem item in rptblGIN.Items)
        {
            if (((HtmlInputCheckBox)item.Controls[1]).Checked)
            {
                gINIds.Add(
                    new Guid(((LinkButton)item.FindControl("lbtnDetail")).CommandArgument));
            }
        }

        return gINIds;
    }

    private void ApproveGINEditRequest()
    {
        //new ECX.CD.BL.GIN().ApproveGINEditRequest(SelectedIds(), Common.GetUserId(Session, Response));
    }

    private void InitializeControls()
    {
		Common.PopulateLookUp(ddlStatus, new Warehouse.GINDetail().GetGINStatusList());
        Common.PopulateWarehouses(ddlWarehouse);

        ((MasterPage_pTop)Page.Master).DescriptionText = "View GIN";
    }

    private void ShowDetail(string gINId)
    {
        Session.Add("GINId", gINId);
        ViewManager.ShowGIN(Session, Page);
    }

    private void ShowPUNDetail(string pUNId)
    {
        Session.Add("PUNId", pUNId);
        ViewManager.ShowPUNDetail(Session, Page);
    }
    #endregion

    #region Event Handlers
    protected void btnApproveRequestEdit_Click(object sender, EventArgs e)
    {
        ApproveGINEditRequest();
    }

    protected void btnRequestEdit_Click(object sender, EventArgs e)
    {
        RequestGINEdit();
    }

    protected void lbtnDetail_Command(object sender, CommandEventArgs e)
    {
        ShowDetail(e.CommandArgument.ToString());
    }

    protected void lbtnPUNDetail_Command(object sender, CommandEventArgs e)
    {
        ShowPUNDetail(e.CommandArgument.ToString());
    }

    protected void lkbSearch_Command(object sender, CommandEventArgs e)
    {
        Warehouse.CGINReport ginReport;
        Warehouse.GINDetail ginDetail = new Warehouse.GINDetail();
        ECX.CD.DA.ECXLookup.ECXLookup ecxLookup = new ECX.CD.DA.ECXLookup.ECXLookup();
        ECX.CD.DA.ECXLookup.CBag bag;

        ECX.CD.BE.GIN.GINDataTable items =
            new ECX.CD.BL.GIN().SearchGIN(
            nrGINNumber.NumberFrom, nrGINNumber.NumberTo, 
            Common.GetDateFrom(dtDateIssued.DateFrom).ToString(), 
            Common.GetDateTo(dtDateIssued.DateTo).ToString(),
            Common.GetDateFrom(dtDateApproved.DateFrom).ToString(), 
            Common.GetDateTo(dtDateApproved.DateTo).ToString(), ddlStatus.SelectedValue,
            ((nrWHRID.Number == "") ? -1 : Convert.ToInt32(nrWHRID.Number)),
            ((string.IsNullOrEmpty(ddlWarehouse.SelectedValue) ? Guid.Empty : new Guid(ddlWarehouse.SelectedValue))));

        //foreach (ECX.CD.BE.GIN.GINRow row in items)
        //{
        //    ginReport = new Warehouse.GINDetail().GetGINReport(row.Id.ToString());

        //    if (ginReport != null)
        //    {
        //        row.NumberOfBags = (int)ginReport.NumberOfBags;

        //        bag = ecxLookup.GetBag(Common.EnglishGuid, (Guid)ginReport.BagType);
        //        if (bag != null)
        //            row.BTN = bag.Name;
        //    }
        //}

        rptblGIN.DataSource = items;
        rptblGIN.DataBind();
    }
    #endregion
}
