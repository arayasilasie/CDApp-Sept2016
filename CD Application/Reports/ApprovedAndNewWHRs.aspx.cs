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
using ECX.CD.Lookup;
using Lookup;
using ECX.CD.Security;

public partial class Reports_ApprovedAndNewWHRs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (SecurityHelper.HasPermission(CDSecurityRights.CDApproveWHR) || SecurityHelper.HasPermission(CDSecurityRights.MRWHRApprovalView))
        {
            if (IsPostBack) return;
            dtpFromDate.Text = DateTime.Today.AddMonths(-1).ToShortDateString();
        }
        else
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }

        
        //if (IsPostBack) return;
        //dtpFromDate.Text = DateTime.Today.AddMonths(-1).ToShortDateString();
      
    }

  
   

    protected void btnFind_Click(object sender, EventArgs e)
    {
        bool getApprovedList;
        if (ddlApprovalStatus.SelectedIndex == 0)
            getApprovedList = true;
        else
            getApprovedList = false;
        DateTime dtmFrom, dtmTo;
        dtmFrom = new DateTime(1900, 1, 1);
        dtmTo = DateTime.Today.AddDays(1);
        DateTime.TryParse(dtpFromDate.Text, out dtmFrom);
        if (dtmFrom.Year < DateTime.Today.Year - 5)
            dtmFrom = DateTime.Today.AddMonths(-1);
        DateTime.TryParse(dtpTo.Text, out dtmTo);
        if (dtmTo.Year < DateTime.Today.Year - 2)
            dtmTo = DateTime.Today.AddDays(1);
        dtmTo = dtmTo.AddDays(1).AddSeconds(-1);
        rpWR.DataSource = WarehouseReceiptModel.GetReportList(dtmFrom, dtmTo, getApprovedList);
        rpWR.DataBind();
    }
}
