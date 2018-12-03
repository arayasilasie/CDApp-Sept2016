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

public partial class Controls_ManageMembersBankAccounts : System.Web.UI.UserControl
{
    public Guid[] MembersList 
    {
        get 
        {
            object membersList = ViewState["MembersList"];
            if (membersList is Guid[])
            {
                return (Guid[])membersList;
            }
            else
            {
                return new List<Guid>().ToArray();
            }
        }
        set 
        {
            ViewState["MembersList"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnDataBinding(EventArgs e)
    {
        base.OnDataBinding(e);

        //dsMembers.DataBind();
        gvMembers.DataBind();
        object selectedMember = gvMembers.SelectedValue;

        if (selectedMember is Guid)
        {
            ManageBankAccounts1.SelectedMember = (selectedMember as Guid?).Value;
        }
        else
        {
            ManageBankAccounts1.SelectedMember = Guid.Empty;
        }
        ManageBankAccounts1.DataBind();

    }
    protected void dsMembers_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = MembersList;
    }

    protected void gvMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        object selectedMember = gvMembers.SelectedDataKey["MemberId"];

        if (selectedMember is Guid)
        {
            ManageBankAccounts1.SelectedMember = (selectedMember as Guid?).Value;
        }
        else
        {
            ManageBankAccounts1.SelectedMember = Guid.Empty;
        }
        
        ManageBankAccounts1.DataBind();
    }

}
