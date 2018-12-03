using System;
using ECX.CD.Security;

public partial class Admin_ExceptionLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.ErrorText = string.Empty;
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewException))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }
    }
    public Guid SelectedExceptionId
    {
        get
        {
            if (GridView1.SelectedValue != null)
            {
                return new Guid(GridView1.SelectedValue.ToString());
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
