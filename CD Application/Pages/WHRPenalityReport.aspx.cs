using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ECX.CD.BL;

public partial class Pages_WHRPenalityReport : System.Web.UI.Page
{
    WHRPenality whrpen = new WHRPenality();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        dispayreport();
    }
    private void dispayreport()
    {

        DataTable dt = new DataTable();
        if (txtClientId.Text != "")
            whrpen.ClientIDNo = txtClientId.Text;
        else
            whrpen.ClientIDNo = "";
        if (txtWareHouseReceipt.Text != "")
            whrpen.WHR = Convert.ToInt32(txtWareHouseReceipt.Text);
        else
            whrpen.WHR = 0;
        if (TxtDateApproved.Text != "")
            whrpen.DateOfProcessing = Convert.ToDateTime(TxtDateApproved.Text);
        

        dt = whrpen.getWHRforReport();
        
        arViewer.Visible = false;
        rptWHRPen rpt = new rptWHRPen();
        rpt.DataSource = dt;
        arViewer.Report = rpt;

        arViewer.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {

        txtWareHouseReceipt.Text = "";
        txtClientId.Text = "";
        TxtDateApproved.Text = "";
    }
}