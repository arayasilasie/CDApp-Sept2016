using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using ECX.CD.Security;

public partial class Pages_ClientBankAccounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDManageClientAcc))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to manage client bank accounts.");
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetMembersCompletionList(string prefixText, int count, string contextKey)
    {
        List<MembershipLookup.Member> allMembersList = Members.GetAllMembers();

        var idNamePair = from m in allMembersList
                         where m.IdNo.ToLower().Contains(prefixText.ToLower()) || m.Name.ToLower().Contains(prefixText.ToLower())
                         select string.Format("{0}-({1})", m.Name, m.IdNo);

        return idNamePair.ToArray();
    }

    protected void btnShowClients_Click(object sender, EventArgs e)
    {
        string memberStringId = GetSelectedMemberId();
        if (memberStringId != null)
        {
            dsClients.SelectParameters["MemberId"].DefaultValue = memberStringId;

            dsClients.DataBind();

            gvBankAccounts_SelectedIndexChanged(sender, e);
        }
        else
        {
            RegularExpressionValidator1.IsValid = false;
        }

        FillBankAccounts();

    }

    string GetSelectedMemberId()
    {
        Regex regex = new Regex(@"[Mm]\d{4,}");

        if (regex.Match(txtMemberId.Text).Success)
        {
            string memberStringId = regex.Match(txtMemberId.Text).Value;

            return memberStringId;
        }
        else
        {
            return null;
        }
    }
    Guid? GetSelectedMemberGuid()
    {
        Regex regex = new Regex(@"[Mm]\d{4,}");

        if (regex.Match(txtMemberId.Text).Success)
        {
            string memberStringId = regex.Match(txtMemberId.Text).Value;

            return Members.GetMemberGuidFromID(memberStringId);
        }
        else
        {
            return null;
        }
    }

    protected void gvBankAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBankAccounts();
    }

    private void FillBankAccounts()
    {
        Guid? clientGuid = Guid.Empty;
        if (gvClients.SelectedValue is Guid)
            clientGuid = new Guid(gvClients.SelectedValue.ToString());

        cntClientsBankAccounts.SelectedMember = GetSelectedMemberGuid().Value;
        cntClientsBankAccounts.SelectedClient = clientGuid;

        cntClientsBankAccounts.DataBind();
    }
}
