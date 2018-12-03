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

public partial class Controls_Number : System.Web.UI.UserControl
{
    protected void Page_Render(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(rangeValidator.MaximumValue))
            rangeValidator.MaximumValue = "999999999";
        if (string.IsNullOrEmpty(rangeValidator.MinimumValue))
            rangeValidator.MinimumValue = "1";

        if (!IsPostBack)
		{
		}
    }

    #region Properties
    public bool Enabled
    {
        set { this.Enabled = value;}
    }

    /// <summary>
    /// gets or sets the Date value
    /// </summary>
    public string Number
    {
        get { return txtNumber.Value; }
        set { txtNumber.Value = value; }
	}

	public string MaxValue
	{
		get { return rangeValidator.MaximumValue; }
		set
		{
			rangeValidator.MaximumValue = value;
		}
	}

	public string MinValue
	{
		get { return rangeValidator.MinimumValue; }
		set
		{
			rangeValidator.MinimumValue = value;
		}
	}

	public string Width
	{
		set 
		{
			txtNumber.Attributes["width"] = value;
		}
	}

	public string ErrorMessage
	{
		get { return rangeValidator.ErrorMessage; }
		set
		{
			rangeValidator.ErrorMessage = value;
		}
	}
    #endregion
}