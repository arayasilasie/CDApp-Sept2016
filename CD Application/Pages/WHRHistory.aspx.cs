using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Pages_WHRHistory : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			InitializeControls();
		}
	}

	private void InitializeControls()
	{
		object id = Common.GetSessionValue(Session, Response, "WRId");
		ECXSecurity.ECXSecurityAccess sec = new ECXSecurity.ECXSecurityAccess();

		if (id != null)
		{
			lblWHRNumber.Text = "WHR NO - " + id.ToString();

			DataTable history = new ECX.CD.BL.WarehouseReciept().GetWHRHistory(Convert.ToInt32(id));

			foreach (DataRow row in history.Rows)
			{
				if(row["UserId"] != null)
					if(row["UserId"].ToString() != "")
						row["UserName"] = sec.GetUserName(new Guid(row["UserId"].ToString()));
			}

			rpHistory.DataSource = history;
			rpHistory.DataBind();
		}
	}

	void PopulateControls()
	{

	}
}