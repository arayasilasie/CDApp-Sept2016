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

public partial class Controls_DateTime : System.Web.UI.UserControl
{
    public event ValueChangedHandler ValueChanged;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object sender, EventArgs e)
    {

    }

    #region Properties

    public bool ShowCheckBox
    {
        get { return chkSelectDate.Visible; }
        set { chkSelectDate.Visible = value; }
    }

    /// <summary>
    /// gets or sets the Date value
    /// </summary>
    public string DateTime
    {
        get 
        {
            if (!txtDateTime.Enabled)
                return "";
            else
                return txtDateTime.Text;
        }
        set { txtDateTime.Text = value; }
    }

    /// <summary>
    /// gets or sets the Enabled value
    /// </summary>
    public bool Enabled
    {
        get
        {
            return txtDateTime.Enabled;
        }
        set { txtDateTime.Enabled = value; }
    }

    /// <summary>
    /// sets the AutoPostBack value
    /// </summary>
    public bool AutoPostBack
    {
        set { txtDateTime.AutoPostBack = value; }
    }

	public string MaxValue
	{
		get{return rangeValidator.MaximumValue;}
		set 
		{ 
			rangeValidator.MaximumValue = value;

            if (rangeValidator.MaximumValue.Length > 0)
            {
                rangeValidator.Type = ValidationDataType.Date;
            }
            //rangeValidator.ErrorMessage = "Value should be >= " + rangeValidator.MinimumValue + " and " + rangeValidator.MaximumValue;
		}
	}

	public string MinValue
	{
		get{return rangeValidator.MinimumValue;}
		set
		{
            rangeValidator.MinimumValue = value;

            if (rangeValidator.MinimumValue.Length > 0)
            {
                rangeValidator.Type = ValidationDataType.Date;
            }
            //rangeValidator.ErrorMessage = "Value should be >= " + rangeValidator.MinimumValue + " and " + rangeValidator.MaximumValue;
		}
	}
    #endregion

    #region Event Handlers

    protected void txtDateTime_TextChanged(object sender, EventArgs e)
    {
        if (ValueChanged != null)
            ValueChanged(sender, e);
    }

    #endregion
}
