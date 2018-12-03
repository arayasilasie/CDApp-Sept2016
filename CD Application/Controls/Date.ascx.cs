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

public partial class Controls_Date : System.Web.UI.UserControl
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
    public string Date
    {
        get 
        {
            if (!txtDate.Enabled)
                return "";
            else
                return txtDate.Text;
        }
        set { txtDate.Text = value; }
    }

    /// <summary>
    /// gets or sets the Enabled value
    /// </summary>
    public bool Enabled
    {
        get
        {
            return txtDate.Enabled;
        }
        set { txtDate.Enabled = value; }
    }

    /// <summary>
    /// sets the AutoPostBack value
    /// </summary>
    public bool AutoPostBack
    {
        set { txtDate.AutoPostBack = value; }
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

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        if (ValueChanged != null)
            ValueChanged(sender, e);
    }

    #endregion
}
