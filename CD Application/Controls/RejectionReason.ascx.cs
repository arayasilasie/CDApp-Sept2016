using System;
using System.Collections.Generic;
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

public partial class Controls_RejectionReason : System.Web.UI.UserControl
{
	public Guid ObjectId
	{
		get
		{
			if (ViewState["ObjectId"] == null)
				return Guid.Empty;
			else
				return new Guid(ViewState["ObjectId"].ToString());
		}
		set 
		{
			ViewState["ObjectId"] = value;

			if (RejectionType == RejectionTypes.PledgeRequest)
			{
				List<int> rejectionReasons = new ECX.CD.BL.Pledge().GetRejectionReasonIds(ObjectId);

				foreach (ListItem item in cblRejectionReason.Items)
				{
					if (rejectionReasons.Contains(Convert.ToInt32(item.Value)))
					{
						item.Selected = true;
						item.Enabled = false;
					}
				}
			}

		}
	}

	public string RejectionType
	{
		get
		{
			if (ViewState["RejectionType"] == null)
				return "";
			else
				return ViewState["RejectionType"].ToString();
		}
		set
		{
			ViewState["RejectionType"] = value;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		//if (!IsPostBack)
		//{
			cblRejectionReason.DataSource = new ECX.CD.BL.IFLookup().SelectAll("tblRejectionReasons");
			cblRejectionReason.DataTextField = "Name";
			cblRejectionReason.DataValueField = "Id";
			cblRejectionReason.DataBind();
		//}
	}

	public List<byte> SelectedValues
	{
		get 
		{
			List<byte> ret = new List<byte>();

			foreach (ListItem item in cblRejectionReason.Items)
			{
				if (item.Selected)
					ret.Add(Convert.ToByte(item.Value));
			}

			return ret;
		}
	}
}
