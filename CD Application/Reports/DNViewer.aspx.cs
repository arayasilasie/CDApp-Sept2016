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
using ECX.CD.Security;

public partial class Reports_DNViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewDeliveryNotice))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view delivery notices");
        }

        rpvDeliveryNotice.PdfExportOptions.Encrypt = true;
        rpvDeliveryNotice.PdfExportOptions.DisplayMode = DataDynamics.ActiveReports.Export.Pdf.DisplayMode.Thumbs;
        rpvDeliveryNotice.PdfExportOptions.Application = "ECX Central Depository Application";
        rpvDeliveryNotice.PdfExportOptions.Author = "ECX Central Depository";
        rpvDeliveryNotice.PdfExportOptions.Title = "Delivery Notice";
        rpvDeliveryNotice.PdfExportOptions.Subject = "DN as of " + DateTime.Now.ToString();
                
        if (Session["DNReportCriteria"] != null)
        {
            ECX.CD.Reports.DNReportBridge bridge = (ECX.CD.Reports.DNReportBridge)Session["DNReportCriteria"];
            rpvDeliveryNotice.Report = new rptDN();

            rpvDeliveryNotice.Report.UserData = bridge;
        }
        else
        {
            rpvDeliveryNotice.Report = new rptDN();
            rpvDeliveryNotice.Report.UserData = new ECX.CD.Reports.DNReportBridge();
        }
        
    }
}
