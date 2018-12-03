using System;
using ECX.CD;
using ECX.CD.Security;

public partial class Pages_ViewBankAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewAccount))
        {
            ErrorHandler.RedirectToErrorPage(SettingAccessor.GetSetting("Err:NoPermissionToViewBankAccounts"));
        }
        else
        {
            ((MasterPage_pTop)this.Master).DescriptionText = "View Bank Account";
        }
    }
}
