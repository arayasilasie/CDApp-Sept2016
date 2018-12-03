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
using System.Collections.Generic;

public partial class Controls_ManageMembersBankAccountsSearch : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Guid memberId = Members.GetMemberGuidFromID(txtMemberId.Text);

        List<Guid> members = new List<Guid>();
        if (memberId != Guid.Empty)
        {
            members.Add(memberId);
        }
        ManageMembersBankAccounts1.MembersList = members.ToArray();
        ManageMembersBankAccounts1.DataBind();

    }
}
