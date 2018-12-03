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

public partial class Controls_RequiredTextBox : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    #region Properties

    /// <summary>
    /// gets or sets the Date value
    /// </summary>
    public string Text
    {
        get 
        {
            if (!txtRequiredTextBox.Enabled)
                return "";
            else
                return txtRequiredTextBox.Text;
        }
        set { txtRequiredTextBox.Text = value; }
    }

    /// <summary>
    /// gets or sets the Enabled value
    /// </summary>
    public bool Enabled
    {
        get
        {
            return txtRequiredTextBox.Enabled;
        }
        set { txtRequiredTextBox.Enabled = value; }
    }
    #endregion

    #region Event Handlers

    #endregion
}
