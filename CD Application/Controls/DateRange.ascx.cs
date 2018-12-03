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

public partial class Controls_DateRange : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitializeControls();
        }
    }

    #region Properties

    /// <summary>
    /// gets or sets the DateFrom value
    /// </summary>
    public string DateFrom
    {
        get { return txtDateFrom.Text; }
        set { txtDateFrom.Text = value; }
    }

    /// <summary>
    /// gets or sets the DateTo value
    /// </summary>
    public string DateTo
    {
        get { return txtDateTo.Text; }
        set { txtDateTo.Text = value; }
    }

    public bool Enabled
    {
        set { div.Disabled = !value; }
        get { return !this.div.Disabled; }
    }
    #endregion

    #region Methods

    private void InitializeControls()
    {

    }

    #endregion
}
