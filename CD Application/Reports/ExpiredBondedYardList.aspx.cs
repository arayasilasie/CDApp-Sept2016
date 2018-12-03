using System;
using System.Data;
using System.Web.UI;
using System.Windows.Forms.VisualStyles;
using ECX.CD.BL;

public partial class Reports_ExpiredBondedYardList : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ECX.CD.Security.SecurityHelper.CurrentUserGuid.HasValue)
        {
            ECX.CD.Security.ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!ECX.CD.Security.SecurityHelper.HasPermission(ECX.CD.Security.CDSecurityRights.CDViewMCP))
        {
            ECX.CD.Security.ErrorHandler.RedirectToErrorPage("You do not have permission to view MCP.");
        }
        if (!IsPostBack)
        {
            PopulateWarehouse();
            Guid wrid = new Guid(drpWarehouse.SelectedValue);
            DataTable rpt = ExpiredBondedYard.GetExpiredList(wrid);
            epblViewer.Report = new rptExpiredBondedYardList(rpt);
            epblViewer.Visible = true;
        }
        //DataTable rpt = ExpiredBondedYard.GetAllExpiredList();
        //epblViewer.Report = new rptExpiredBondedYardList(rpt);
        //epblViewer.Visible = true;
        
        
    }

    private void PopulateWarehouse()
    {
        DataTable _wh = new ECX.CD.BL.Lookup().GetAllWarehouses();
        drpWarehouse.DataSource = _wh;
        drpWarehouse.DataTextField = "Description";
        drpWarehouse.DataValueField = "ID";
        drpWarehouse.DataBind();
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Guid wrid = new Guid(drpWarehouse.SelectedValue);
        DataTable rpt = ExpiredBondedYard.GetExpiredList(wrid);
        epblViewer.Report=new rptExpiredBondedYardList(rpt);
        epblViewer.Visible = true;
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        DataTable rpt = ExpiredBondedYard.GetAllExpiredList();
        epblViewer.Report = new rptExpiredBondedYardList(rpt);
        epblViewer.Visible = true;
    }
}