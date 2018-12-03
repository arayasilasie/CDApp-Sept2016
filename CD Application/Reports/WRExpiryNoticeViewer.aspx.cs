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
using DataDynamics.ActiveReports;
using ECX.CD.Security;

public partial class Reports_WRExpiryNoticeViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.CurrentUserGuid.HasValue)
        {
            ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewWHRExpNotice))
        {
            ErrorHandler.RedirectToErrorPage("You do not have permission to view Warehouse receipt expiry notice.");
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtLowerLimit.Text.Length <= 0 && txtUpperLimit.Text.Length >= 0)
                txtLowerLimit.Text = txtUpperLimit.Text;
            else if (txtLowerLimit.Text.Length >= 0 && txtUpperLimit.Text.Length <= 0)
                txtUpperLimit.Text = txtLowerLimit.Text;
            else if (txtLowerLimit.Text.Length <= 0 && txtUpperLimit.Text.Length <= 0)
            {//if both lower and upper limit are not given
                litError.Text = "Please specify lower boundary and upper boundary values or one of them.";
                return;
            }
            int iLowerLimit = Convert.ToInt32(txtLowerLimit.Text.Trim());
            int iUpperLimit = Convert.ToInt32(txtUpperLimit.Text.Trim());
            if (iLowerLimit > iUpperLimit)
            {//if the order is reversed, swap the values
                int temp = iLowerLimit;
                iLowerLimit = iUpperLimit;
                iUpperLimit = temp;
            }
            //if there is no exception, the numbers are valid
            litError.Text = "";//clear any error message
            ActiveReport report = new WRExpiryNotice();

            vwWRExpiryNotice.Report = report;//set the webviewer report to show
            //get the data to display
            DataTable reportSource = ECX.CD.BL.WRExpiryNotice.GetExpiredWHRsReport(iLowerLimit, iUpperLimit);
            //sort the dataTable
            DataView dView = reportSource.DefaultView;
            dView.Sort = ddlSort.SelectedValue + " " + lstSortOrder.SelectedValue;
            reportSource = dView.ToTable();//get the table type of the view

            report.DataSource = reportSource;//set the datasource to the report viewer control

            vwWRExpiryNotice.DataBind();//bind the webviewer to the data received
        }
        catch (Exception ex)
        {            
            litError.Text = ex.Message;
        }
    }
}
