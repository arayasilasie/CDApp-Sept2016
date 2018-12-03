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

public partial class Controls_Authorise : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Properties
    public string Password { get { return txtPassword.Text; } }
    public string FileName { get { return KeyFileUploader.FileName; } }
    public byte[] KeyFileBytes { get { return KeyFileUploader.FileBytes; } }

    public bool IsValid
    {
        get
        {
            if (KeyFileUploader.HasFile && txtPassword.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public string ValidationError
    {
        get
        {
            if (!KeyFileUploader.HasFile && txtPassword.Text.Length == 0)
            {
                return "Key file and password not specified.";
            }
            else if (!KeyFileUploader.HasFile)
            {
                return "Key file not specified.";
            }
            else if (txtPassword.Text.Length == 0)
            {
                return "Password not specified.";
            }
            else
            {
                return string.Empty;
            }
        }
    }

    #endregion

    #region Event Handlers
    protected void KeyFileValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (!KeyFileUploader.HasFile)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    #endregion
}