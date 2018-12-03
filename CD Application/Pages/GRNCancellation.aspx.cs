using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECX.CD.Security;
using Warehouse;
using System.Data;
using Lookup;


public partial class Pages_GRNCancellation : System.Web.UI.Page
{
    GRNInformation grn;
    bool isApproved;

    DataSet dtbl
    {
        get
        {
            if (ViewState["dtbl"] != null)
                return (DataSet)(ViewState["dtbl"]);
            else
                return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;

        //if (!SecurityHelper.CurrentUserGuid.HasValue)
        //{
        //    ErrorHandler.RedirectToSessionExpiredPage();
        //}
        //if (!SecurityHelper.HasPermission(CDSecurityRights.CDCancelWHR))
        //{
        //    ErrorHandler.RedirectToErrorPage("You donot have permission to view Expiry Date Extension Request.");
        //}

        BindGRNCancellationGridview();
        BindWarhouseDropdown();
    }
    public void BindWarhouseDropdown()
    {
        try
        {
            ECXLookup l = new ECXLookup();
            ddWarehouse.DataSource = l.GetAllWarehouses(Common.EnglishGuid, Common.WarehouseTypeGuid);
            ddWarehouse.DataValueField = "UniqueIdentifier";
            ddWarehouse.DataTextField = "Name";
            ddWarehouse.DataBind();
            ddWarehouse.Items.Insert(0, new ListItem("", ""));
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.OrangeRed;
            lblMessage.Text = "Unable to display data. Please try again.";
        }
    }
    
    void BindGRNCancellationGridview()
    {
        try
        {
            grn = new GRNInformation();
            grvGRNCancellation.DataSource = grn.GetGRNCancellationRequests();
            grvGRNCancellation.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.OrangeRed;
            lblMessage.Text = "Unable to display data. Please try again.";
        }
    }
    protected void lnkApproved_Click(object sender, EventArgs e)
    {
        isApproved = true;
    }
    protected void lnkReject_Click(object sender, EventArgs e)
    {
       
        isApproved = false;
    }
    protected void grvGRNCancellation_SelectedIndexChanged(object sender, EventArgs e)
    {        
        try
        {
            grn = new GRNInformation();
            if (isApproved)
            {
                WarehouseReceiptModel.CancelWHRForGRNCancellation(
                   ((Label)grvGRNCancellation.SelectedRow.FindControl("lblGRNN0")).Text,
                   SecurityHelper.GetUserGuid().Value, DateTime.Now);

                grn.ApproveGRNCancellationRequest(grvGRNCancellation.SelectedDataKey.Value.ToString(), SecurityHelper.GetUserGuid().Value.ToString(), DateTime.Now, true);
            }
            else
            {
                grn.RejectGRNCancellationRequest2(grvGRNCancellation.SelectedDataKey.Value.ToString(), SecurityHelper.GetUserGuid().Value.ToString(), DateTime.Now, true,txtReason.Text);
            } 

            lblMessage.Text = "Record saved successfully.";
            BindGRNCancellationGridview();
           
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.OrangeRed;
            lblMessage.Text = "Unable to save record. Please try again.";
        }

        txtReason.Text = "";
    }
    protected void btnSrch_Click(object sender, EventArgs e)
    {
        PreparedForSearch();
    }
    public void PreparedForSearch()
    {
        string WarehouseID = "00000000-0000-0000-0000-000000000000";
        if (ddWarehouse.SelectedValue.ToString() != "")
            WarehouseID = ddWarehouse.SelectedValue.ToString();

        string GRNNo = "";
        if (txtGRN.Text != "")
            GRNNo = txtGRN.Text;

        int Status = 0;
        if (ddStatus.SelectedValue.ToString() != "")
            Status = int.Parse(ddStatus.SelectedValue.ToString());

        DateTime DateRequested = DateTime.Parse("1/1/1800");
        if (txtDateIssued.Text != "")
            DateRequested = DateTime.Parse(txtDateIssued.Text);

        DateTime DateRequested2 = DateTime.Parse("1/1/9999");
        if (txtDateIssued2.Text != "")
            DateRequested2 = DateTime.Parse(txtDateIssued2.Text);

        DateTime DateApproved = DateTime.Parse("1/1/1800");
        if (txtDateApproved.Text != "")
            DateApproved = DateTime.Parse(txtDateApproved.Text);

        DateTime DateApproved2 = DateTime.Parse("1/1/9999");
        if (txtDateApproved2.Text != "")
            DateApproved2 = DateTime.Parse(txtDateApproved2.Text);

        BindSearchGridview(WarehouseID, Status, GRNNo, DateRequested, DateRequested2, DateApproved, DateApproved2);

    }

    public void BindSearchGridview(string WarehouseID, int Status, string GRNNo, DateTime DateRequested, DateTime DateRequested2, DateTime DateApproved, DateTime DateApproved2)
    {
        try
        {
            lblMessage.Text = "";
            GRNInformation g = new GRNInformation();
           DataSet dt = g.GetGRNCancellationRequestSearch(WarehouseID, Status, true, GRNNo, DateRequested, true, DateRequested2, true, DateApproved, true, DateApproved2, true);
           
            ViewState.Add("dtbl", dt);
            grvSearch.DataSource = dtbl;
            grvSearch.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.OrangeRed;
            lblMessage.Text = "Unable to display data. Please try again.";
        }
    }

    protected void grvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvSearch.PageIndex = e.NewPageIndex;
        grvSearch.DataSource = dtbl;
        grvSearch.DataBind();
    }
    protected void grvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = "Reason: " + ((Label)e.Row.FindControl("lblRemark")).Text;
        }
    }
    protected void grvGRNCancellation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.ToolTip = "Reason: " + ((Label)e.Row.FindControl("lblRemark")).Text;
        }
    }
}