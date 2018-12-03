using System;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class MasterPage_pTop : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mnuMain.MenuItemClick += new MenuEventHandler(mnuMain_MenuItemClick);
        }
    }

    #region Properties
    public string DescriptionText
    {
        set
        {
            lblPageDescription.Text = value;
        }
    }
    public string NotificationText
    {
        set
        {
            lblNotificationDisplay.Text = value;
            imgError.Visible = false;
            if (lblNotificationDisplay.Text.Length == 0)
            {
                imgOk.Visible = false;
                lblNotificationDisplay.Visible = false;
            }
            else
            {
                imgOk.Visible = true;
                lblNotificationDisplay.Visible = true;
                lblNotificationDisplay.CssClass = "NotificationLable";
            }
        }
    }
    public string ErrorText
    {
        set
        {
            lblNotificationDisplay.Text = value;
            imgOk.Visible = false;
            if (lblNotificationDisplay.Text.Length == 0)
            {
                imgError.Visible = false;
                lblNotificationDisplay.Visible = false;
            }
            else
            {
                imgError.Visible = true;
                lblNotificationDisplay.Visible = true;
                lblNotificationDisplay.CssClass = "ErrorLable";
            }
        }
    }
    #endregion Properties

    protected void loginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Response.Redirect(ConfigurationManager.AppSettings["LogOutUrl"]);
    }

    protected void mnuMain_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "Create PUN")
        {
            ViewManager.ShowPUNDetail(Session, Page);
        }
    }

    protected void lblUserName_PreRender(object sender, EventArgs e)
    {
        lblUserName.Text = ECX.CD.Security.SecurityHelper.CurrentUserName;
    }
}
