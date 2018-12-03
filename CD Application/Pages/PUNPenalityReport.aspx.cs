using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ECX.CD.BL;

public partial class Pages_PUNPenalityReport : System.Web.UI.Page
{

    PUNPenality punpen = new PUNPenality();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DisplayReport();
    }

    private void DisplayReport()
    {

        DataTable dt = new DataTable();
        if (txtClientId.Text != "")
            punpen.ClientIDNo = txtClientId.Text;
        else
            punpen.ClientIDNo = "";
        if (txtWareHouseReceipt.Text != "")
            punpen.WHR = Convert.ToInt32(txtWareHouseReceipt.Text);
        else
            punpen.WHR = 0;
        if (TxtDateApproved.Text != "")
            punpen.DateOfProcessing = Convert.ToDateTime(TxtDateApproved.Text);


        dt = punpen.GetPUNPENForReport();

        arViewer.Visible = false;
        rptPUNPen rpt = new rptPUNPen();
        rpt.DataSource = dt;
        arViewer.Report = rpt;

        arViewer.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Cancel();
    }

    private void Cancel()
    {

        txtWareHouseReceipt.Text = "";
        txtClientId.Text = "";
        TxtDateApproved.Text = "";
    }
}