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
using System.Collections.Specialized;
using Microsoft.ReportingServices.ReportRendering;
using System.Collections.Generic;
using ECX.CD.Lookup;
using Lookup;

public partial class Reports_MATViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewMAT))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view MAT");
        }

        ECX.CD.Reports.ReportBridge bridge = new ECX.CD.Reports.ReportBridge();
        
        bridge.MATIdList = (List<Guid>)HttpContext.Current.Session["MATIdList"];
        bridge.mATReportBridge.Session = HttpContext.Current.Session["CommodityClassName"].ToString();
        bridge.mATReportBridge.TradeDate = HttpContext.Current.Session["TradeDate"].ToString();

        rpvMATViewer.Report = new rptMAT();
        rpvMATViewer.Report.UserData = bridge;
    }
}
