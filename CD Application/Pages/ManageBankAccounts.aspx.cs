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
using ECX.CD;

public partial class Pages_ManageBankAccounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDManageAccount))
        {
            ErrorHandler.RedirectToErrorPage(SettingAccessor.GetSetting("Err:NoPermissionToRequestSuspension"));
        }
        else
        {
            ((MasterPage_pTop)this.Master).DescriptionText = "Manage bank account";
        }
    }
}
