using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_MCPReportViewer2 : System.Web.UI.Page
{
    protected int ReportViewerMinimizedHeight = 380;
    protected int ReportViewerMaximizedHeight = 520;
    protected bool AllowReportPrint
    {
        get
        {
            return true;
            //if (ViewState["AllowReportPrint"] != null)
            //    return (bool)ViewState["AllowReportPrint"];
            //else
            //    return false;
        }
        set
        {
            ViewState["AllowReportPrint"] = value;
        }
    }
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
        bool allowPrintingMCP = ECX.CD.Security.SecurityHelper.HasPermission(ECX.CD.Security.CDSecurityRights.CDTakeSnapshot);
        lnkShowReport.Enabled = allowPrintingMCP;
        chkSave.Enabled = allowPrintingMCP;

        arViewer.PdfExportOptions.Encrypt = true;
        arViewer.PdfExportOptions.DisplayMode = DataDynamics.ActiveReports.Export.Pdf.DisplayMode.Thumbs;
        arViewer.PdfExportOptions.Application = "ECX Central Depository Application";
        arViewer.PdfExportOptions.Author = "ECX Central Depository";
        arViewer.PdfExportOptions.Title = "Member Client Position";
        arViewer.PdfExportOptions.Subject = "MCP as of " + DateTime.Now.ToString();
        SetReportPrintPermission();

        arViewer.Height = ReportViewerMaximizedHeight;

        //this.Master.DescriptionText = "MCP Report";
        //this.Master.NotificationText = string.Empty;
    }

   
    protected void SetReportPrintPermission()
    {
        if (AllowReportPrint)
        {
            arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint;
        }
        else
        {
            arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.None;
        }
    }
    
    
    protected void lnkShowReport_Click(object sender, EventArgs e)
    {
        bool morningSession = (ddlSession.SelectedValue=="1"?true:false);
        DateTime minDate, maxDate;
        minDate = new DateTime(1900,1,1);
        maxDate = DateTime.Today.AddDays(1).AddSeconds(-1);
        DateTime approvalStart, approvalEnd, depositeStart, depositeEnd;
        if(!DateTime.TryParse(txtApprovalFrom.Text, out approvalStart))
            approvalStart = minDate;
        if(!DateTime.TryParse(txtApprovalTo.Text, out approvalEnd))
            approvalEnd = maxDate;

        if(!DateTime.TryParse(txtDepositeFrom .Text, out depositeStart))
            depositeStart = minDate;
        if(!DateTime.TryParse(txtDepositeTo.Text, out depositeEnd))
            depositeEnd = maxDate;

        Datalayer.MCPService mcpService =
            new Datalayer.MCPService(tMemberID.Text,
                new Guid(ddlCommodity.SelectedValue),
                 morningSession,
                 depositeStart, depositeEnd,
                 approvalStart, approvalEnd, chkSave.Checked);

        System.Data.DataTable dtWH, dtBank;

        //Newly added code
        //List<Datalayer.MCP_WHR> mcp_WHR;
        //mcp_WHR = mcpService.getMCPEntityFromDataReader();
        //end of newly added code

        dtWH = mcpService.WHR;
        dtBank = mcpService.BankBalance;
        if(dtWH.Rows.Count ==0)
        {
            arViewer.Visible = false;
            ((MasterPage_pTop)this.Master).ErrorText = "No result found. Please change your criteria and try again.";
            return;
        }
        //if the MCP generated is going to be printed take snapshot.
        if (AllowReportPrint)
        {
            //arViewer.PdfExportOptions.FileName = "MCP-" + DateTime.Now.ToShortDateString();
            arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.AllowPrint;
        }
        else
        {
            //arViewer.PdfExportOptions.FileName = "MCP-" + DateTime.Now.ToShortDateString();
            arViewer.PdfExportOptions.Permissions = DataDynamics.ActiveReports.Export.Pdf.PdfPermissions.None;
        }

        lnkShowReport.Enabled = false;
        arViewer.Visible = false;
        arViewer.Report = new MCP2.rptMCP(dtWH, dtBank);
        //arViewer.Report = new MCP2.rptMCP(mcp_WHR, dtBank);
        
        arViewer.Visible = true;
       
        lnkShowReport.Enabled = true;
    }
}
