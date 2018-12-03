using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage_pTop)Master).DescriptionText = "Administration";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        System.Web.HttpRuntime.UnloadAppDomain();
        //AppDomain.Unload(AppDomain.CurrentDomain);
    }
}
