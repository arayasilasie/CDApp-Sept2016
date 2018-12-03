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

public partial class Admin_ExceptionDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Master.ErrorText = string.Empty;
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewException))
        {
            ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
        }
    }
    protected void dsExceptionDetail_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        if (PreviousPage != null)
        {
            e.InputParameters["exceptionId"] = PreviousPage.SelectedExceptionId;
            praNavigateBack.Visible = true;
            praNoresult.Visible = false;
        }
        else
        {
            praNoresult.Visible = true;
            praNavigateBack.Visible = false;
            e.Cancel = true;
        }
    }
}
