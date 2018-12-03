using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

public partial class Reports_TradableWhrViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!ECX.CD.Security.SecurityHelper.CurrentUserGuid.HasValue)
        //{
        //    ECX.CD.Security.ErrorHandler.RedirectToSessionExpiredPage();
        //}
        //if (!ECX.CD.Security.SecurityHelper.HasPermission(ECX.CD.Security.CDSecurityRights.CDViewTradableWHR))
        //{
        //    ECX.CD.Security.ErrorHandler.RedirectToErrorPage("You do not have permission to view tradable warehouse receipts.");
        //}
        if (!IsPostBack)
        {
            BindPageControls();
        }
    }
    private void BindPageControls()
    {
        //TODO: Cache commodities where it can be reused
        ECX.CD.BL.ECXLookup.CCommodity[] _commodities = new ECX.CD.BL.Lookup().GetAllCommodities();
        drpCommodityId.DataSource = _commodities;
        drpCommodityId.DataTextField = "Description";
        drpCommodityId.DataValueField = "UniqueIdentifier";
        drpCommodityId.DataBind();
        ((MasterPage_pTop)Page.Master).DescriptionText = "Tradable Warehouse Receipt Summary Report";
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    } 
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            Guid _commodityId = Guid.Parse(drpCommodityId.SelectedValue);
            DataTable _resultSet = new ECX.CD.BL.WarehouseReciept().GetTradableWarehouseReceipts(_commodityId);       

            TradablesReport rpt = new TradablesReport();
            rpt.DataSource = _resultSet;
            wvReportViewer.Report = rpt;
          
            GridView1.DataSource = _resultSet;
            GridView1.DataBind();
            btnExportToExcel.Enabled = true;
        }
        catch
        {
        }
    }
    public void ExportToExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        string FileName = "tradableWHRs" + DateTime.Now + ".xls";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);

        GridView1.GridLines = GridLines.Both;
        GridView1.HeaderStyle.Font.Bold = true;        
        GridView1.RenderControl(htmltextwrtter);
  
        Response.Write(strwritter.ToString());
        Response.End();
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = GridView1.Rows.Count - 1; i > 0; i--)
        {
            GridViewRow row = GridView1.Rows[i];
            GridViewRow previousRow = GridView1.Rows[i - 1];
            for (int j = 0; j < row.Cells.Count; j++)
            {
                if (j == 3) continue;

                row.Cells[j].VerticalAlign = System.Web.UI.WebControls.VerticalAlign.Middle;
               
                if (row.Cells[j].Text == previousRow.Cells[j].Text)
                {
                    if (previousRow.Cells[j].RowSpan == 0)
                    {
                        if (row.Cells[j].RowSpan == 0)
                        {
                            previousRow.Cells[j].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                        }
                        row.Cells[j].Visible = false;
                    }
                }
            }
        }
    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        ExportToExcel();
        GridView1.Visible = false;
    }
}