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

public partial class Reports_WHRViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewWHRPrint))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view this page");
        }
        ECX.CD.Reports.ReportBridge bridge = new ECX.CD.Reports.ReportBridge();
        bridge.WHRIDList = (List<Guid>)System.Web.HttpContext.Current.Session["WHRIDList"];
        rpvWHRViewer.Report = new rptWHR();
        rpvWHRViewer.Report.UserData = bridge;
    }
}
