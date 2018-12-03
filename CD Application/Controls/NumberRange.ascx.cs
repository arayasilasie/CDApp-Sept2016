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

public partial class Controls_NumberRange : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Properties

    /// <summary>
    /// gets or sets the NumberFrom value
    /// </summary>
    public string NumberFrom
    {
        get { return txtNumberFrom.Text; }
        set { txtNumberFrom.Text = value; }
    }

    /// <summary>
    /// gets or sets the NumberTo value
    /// </summary>
    public string NumberTo
    {
        get { return txtNumberTo.Text; }
        set { txtNumberTo.Text = value; }
    }

    #endregion
}
