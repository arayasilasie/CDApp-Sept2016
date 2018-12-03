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

public partial class IF_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lkbPledgeRegisterList_Click(object sender, EventArgs e)
    {
        arIFViewer.Report = new PledgeRegisterList();
        arIFViewer.DataBind();
    }
    protected void lkbPledgeRegisterListByBank_Click(object sender, EventArgs e)
    {
        arIFViewer.Report = new PledgeRegisterListByBank();
        arIFViewer.DataBind();
    }
    protected void lkbPledgedWHRExpiry_Click(object sender, EventArgs e)
    {
        arIFViewer.Report = new PledgedWHRExpiry();
        arIFViewer.DataBind();
    }
    protected void lkbCollateralMovementList_Click(object sender, EventArgs e)
    {
        arIFViewer.Report = new CollateralMovementList();
        arIFViewer.DataBind();
    }
}
