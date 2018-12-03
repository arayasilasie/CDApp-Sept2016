using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using ECX.CD.Security;

public partial class Reports_MCPArchiveDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewMCPArchive))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view MCP archive.");
        }

        arViewer.PdfExportOptions.Encrypt = true;
        arViewer.PdfExportOptions.DisplayMode = DataDynamics.ActiveReports.Export.Pdf.DisplayMode.Thumbs;
        arViewer.PdfExportOptions.Application = "ECX Central Depository Application";
        arViewer.PdfExportOptions.Author = "ECX Central Depository";
        arViewer.PdfExportOptions.Title = "Member Client Position";
        arViewer.PdfExportOptions.Subject = "MCP Archive";

        string viewerType = Request.QueryString["ViewerType"];
        if (viewerType == null || viewerType == "PDF")
        {
            arViewer.ViewerType = DataDynamics.ActiveReports.Web.ViewerType.AcrobatReader;
        }
        else
        {
            arViewer.ViewerType = DataDynamics.ActiveReports.Web.ViewerType.RawHtml;
        }

        if (SecurityHelper.HasPermission(CDSecurityRights.CDTakeSnapshot))
        {
            arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint;
        }
        else
        {
            arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.None;
        }

        if (Common.IsGuid(Request.QueryString["Id"]))
        {
            Guid mcpId = new Guid(Request.QueryString["Id"]);

            ECX.CD.BE.MCP.MCPWarehouseReceiptDataTable tblWHR = ECX.CD.BL.MCP.GetWarehouseReceiptList(mcpId);

            DataTable tblTempWHR = tblWHR.OrderBy(x => x.MemberId).ThenBy(x => x.ClientId).ThenBy(x => x.CommodityGrade).ThenBy(x => x.Warehouse).CopyToDataTable();
            tblWHR.Clear();
            tblWHR.Merge(tblTempWHR);

            arViewer.Report = new rptMCPArchive();

            if (txtMemberId.Text.Length > 0)
            {
                arViewer.Report.DataSource = tblWHR.Select("MemberId = '" + txtMemberId.Text + "'");
            }
            else
            {
                arViewer.Report.DataSource = tblWHR;
            }


        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {

    }
}
