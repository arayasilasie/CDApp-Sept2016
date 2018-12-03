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

public partial class Controls_MemberInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public Guid MemberId
    {
        get
        {
            if (hdnMemberId.Value != null && hdnMemberId.Value.Length > 0)
            {
                return new Guid(hdnMemberId.Value);
            }
            else
            {
                return Guid.Empty;
            }
        }
        set
        {
            hdnMemberId.Value = value.ToString();
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        PopulateMemberInfo();
        base.OnPreRender(e);
    }

    private void PopulateMemberInfo()
    {
        if (MemberId != Guid.Empty)
        {
            lblMemberId.Text = Members.GetMemberId(MemberId);
            lblMemberName.Text = Members.GetMemberName(MemberId);
        }
    }
}
