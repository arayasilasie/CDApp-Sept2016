using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataDynamics.ActiveReports.Export.Xls;

public partial class Pages_ViewPUNExtensionReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ECX.CD.Security.SecurityHelper.CurrentUserGuid.HasValue)
        {
            ECX.CD.Security.ErrorHandler.RedirectToSessionExpiredPage();
        }
        if (!ECX.CD.Security.SecurityHelper.HasPermission(ECX.CD.Security.CDSecurityRights.CDPUNExt))
        {
            ECX.CD.Security.ErrorHandler.RedirectToErrorPage("You do not have permission to view PUN extension report.");
        }
        if (IsPostBack) return;
    }
    private XlsExport xlsExport1;
    rptPUNExtension rpt;
    protected void btnView_Click(object sender, EventArgs e)
    {
        WebViewer1.Visible = true;
        BindPUNExtenstionGrv(); 
        WebViewer1.Report = rpt;
    }
    void BindPUNExtenstionGrv()
    {
        DateTime DateApproved = DateTime.Parse("1/1/1800");
        if (txtDateApproved.Text != "")
            DateApproved = DateTime.Parse(txtDateApproved.Text);

        DateTime DateApproved2 = DateTime.Parse("1/1/9999");
        if (txtDateApproved2.Text != "")
            DateApproved2 = DateTime.Parse(txtDateApproved2.Text);

        DateTime DateRequested = DateTime.Parse("1/1/1800");
        if (txtDateRequested.Text != "")
            DateRequested = DateTime.Parse(txtDateRequested.Text);

        DateTime DateRequested2 = DateTime.Parse("1/1/9999");
        if (txtDateRequested2.Text != "")
            DateRequested2 = DateTime.Parse(txtDateRequested2.Text);

        try
        {
            DataTable dt = PUNExtension.GetPUNExtension(DateApproved, DateApproved2, DateRequested, DateRequested2);
            rpt= new rptPUNExtension();
            rpt.ApproveDate = txtDateApproved.Text;
            rpt.ApproveDate2 = txtDateApproved2.Text;
            rpt.RequestDate = txtDateRequested.Text;
            rpt.RequestDate2 = txtDateRequested2.Text;
            rpt.DataSource = dt;                    
        }
        catch (Exception ex)
        {
            //lblMessage.Text = "";
        }     
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        System.IO.MemoryStream m_stream = new System.IO.MemoryStream();
        BindPUNExtenstionGrv();

        rpt.Run();
        if (this.xlsExport1 == null)
        {
            this.xlsExport1 = new DataDynamics.ActiveReports.Export.Xls.XlsExport();
        }
        this.xlsExport1.Export(rpt.Document, m_stream);
        m_stream.Position = 0;
        Response.ContentType = "application/vnd.ms-excel";
        string fName = "inline; filename=PUNExtension_" + DateTime.Now.ToShortDateString()+".xls";
        Response.AddHeader("content-disposition", fName);
        //Response.AddHeader("content-disposition", "inline; filename=MyExport.xls");
        Response.BinaryWrite(m_stream.ToArray());
        Response.End();
    }
}