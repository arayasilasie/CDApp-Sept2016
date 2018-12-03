using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataDynamics.ActiveReports;
using ECX.CD.Security;

namespace Reports
{
    public partial class DNSignSheet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewDNSignSheet))
            {
                ErrorHandler.RedirectToErrorPage("You do not have permission to view DN sign sheet.");
            }
            if (!IsPostBack)
            {
                //TradeDateCalendar.Date = DateTime.Today;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //try
            //{
                DateTime dtTradeDate = Convert.ToDateTime(txtTradeDate.Text);
                System.Data.DataTable wrTable = ECX.CD.BL.DNSignSheet.GetWarehouseReceiptReport(dtTradeDate);

                ActiveReport report = new WReport.DNSignSheet();

                //WRSignatureViewer.ViewerType = DataDynamics.ActiveReports.Web.ViewerType.AcrobatReader;
                DNSignSheetViewer.Report = report;
                report.DataSource = wrTable;
                //WRSignatureViewer.Report.DataSource = wrTable;

                DNSignSheetViewer.DataBind();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        protected void gvwWarehouseReceiptReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //for each data row show about 10 underscore (_) chars
                e.Row.Cells[2].Text = "_______________";//receivedby line
                e.Row.Cells[3].Text = "_______________";//signature line
            }
        }
    }
}
