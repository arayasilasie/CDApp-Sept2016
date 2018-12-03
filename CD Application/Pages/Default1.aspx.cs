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

public partial class Pages_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<Guid> members = new List<Guid>();
        members.Add(new Guid("07acdde2-12a5-4e30-959d-fc9216fcf86e"));
        members.Add(new Guid("1186d4e8-da58-4bcc-997a-29fbc23a9b2c"));
        members.Add(new Guid("b7f87746-3535-4393-b82f-35934d686cf5"));

        ManageMembersBankAccounts1.MembersList = members.ToArray();

        ManageMembersBankAccounts1.DataBind();
    }
    protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Unnamed1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}
