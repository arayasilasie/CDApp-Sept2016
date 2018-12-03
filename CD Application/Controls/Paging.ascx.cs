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

public delegate void FillRepeaterHandler(Navigation n);

public partial class Controls_Paging : System.Web.UI.UserControl
{
    public event FillRepeaterHandler FillRepeater;

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
			//ViewState["_CurrentPosition"] = -1;
		}
    }

    #region Properties

    /// <summary>
    /// Managing the new viewing page into viewstate
    /// </summary>
    public int CurrentPosition
    {
        get
        {
            object obj = ViewState["_CurrentPosition"];

            if (obj == null)
                return -1;
            else
                return (int)obj;
        }
        set
        {
            this.ViewState["_CurrentPosition"] = value;
        }
    }

    public int PageSize
    {
        get { return 20; }
    }

	public int RecordCount
	{
		get
		{
			object obj = ViewState["_RecordCount"];

			if (obj == null)
				return 0;
			else
				return (int)obj;
		}
		set
		{
			this.ViewState["_RecordCount"] = value;
		}	
	}

    #endregion

    #region Methods

    //Set the visibility based on message.
    public string Visibility(string message)
    {
        string visibility = "visibility: {0}";

        //Generates the visibility for Mmessage
        if (message.Equals("MSG", StringComparison.CurrentCultureIgnoreCase))
            return string.Format(visibility, RecordCount == 0 ? "visible" : "hidden");

        //Generates the visibility for Navigation
        if (message.Equals("Navigation", StringComparison.CurrentCultureIgnoreCase))
			return string.Format(visibility, RecordCount == 0 ? "hidden" : "visible");

        //Generates the visibility for Repeater
        if (message.Equals("Repeater", StringComparison.CurrentCultureIgnoreCase))
			return string.Format(visibility, RecordCount > 0 ? "visible" : "hidden");

        //Default visibility
        return string.Format(visibility, "hidden");
    }

    public void SetCurrentPosition(Navigation navigation)
	{
		lbtnFirst.Enabled = true;
		lbtnPrevious.Enabled = true;
		lbtnNext.Enabled = true;
		lbtnLast.Enabled = true;

        switch (navigation)
        {
			case Navigation.First:
				{
					lbtnFirst.Enabled = false;
					lbtnPrevious.Enabled = false;

					if (RecordCount > PageSize)
					{
						lblCurrentPage.Text = "1 - " + PageSize.ToString() + " of " + RecordCount.ToString();
					}
					else
					{
						lblCurrentPage.Text = "1 - " + RecordCount.ToString() + " of " + RecordCount.ToString();

						lbtnNext.Enabled = false;
						lbtnLast.Enabled = false;
					}
				}
				break;
			case Navigation.Next:
				{
					if (RecordCount < PageSize * CurrentPosition)
					{
						lblCurrentPage.Text =
						(PageSize * (CurrentPosition + 1)).ToString() + " - " +
						RecordCount.ToString() + " of " + RecordCount.ToString();

						lbtnNext.Enabled = false;
						lbtnLast.Enabled = false;
					}
					else
					{
						lblCurrentPage.Text = 
						(PageSize * (CurrentPosition + 1)).ToString() + " - " +
						(PageSize * (CurrentPosition + 2)).ToString() + " of " + RecordCount.ToString();
					}
				}
				break;
			case Navigation.Previous:
				{
					if (CurrentPosition == -1)
					{
						lblCurrentPage.Text = "1 - " + PageSize.ToString() + " of " + RecordCount.ToString();
						lbtnFirst.Enabled = false;
						lbtnPrevious.Enabled = false;
					}
					else
					{
						lblCurrentPage.Text =
						(PageSize * (CurrentPosition + 1) + 1).ToString() + " - " +
						(PageSize * (CurrentPosition + 1)).ToString() + " of " + RecordCount.ToString();
					}
				}
				break;
			case Navigation.Last:
				{
					lblCurrentPage.Text =
					(PageSize * (CurrentPosition + 1)).ToString() + " - " +
					RecordCount.ToString() + " of " + RecordCount.ToString();

					lbtnNext.Enabled = false;
					lbtnLast.Enabled = false;
				}
                break;
            default:                    //Default CurrentPosition set to 0
                CurrentPosition = 0;
                break;
        }
    }

    #endregion

    #region Event Handlers

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void lbtnPrevious_Click(object sender, EventArgs e)
    {
		CurrentPosition--;

        if (FillRepeater != null)
        {
            FillRepeater(Navigation.Previous);
        }
    }

    protected void lbtnNext_Click(object sender, EventArgs e)
    {
		CurrentPosition++;
        if (FillRepeater != null)
        {
            FillRepeater(Navigation.Next);
        }
    }

    protected void lbtnFirst_Click(object sender, EventArgs e)
    {
		CurrentPosition = -1;

        if (FillRepeater != null)
        {
            FillRepeater(Navigation.First);
        }
    }

    protected void lbtnLast_Click(object sender, EventArgs e)
    {
		CurrentPosition = (RecordCount / PageSize - 1);

        if (FillRepeater != null)
        {
            FillRepeater(Navigation.Last);
        }
    }

    #endregion
}
