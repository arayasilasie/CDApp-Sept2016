using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Controls_WHRHistory : System.Web.UI.UserControl
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
			DataTable history = new ECX.CD.BL.WarehouseReciept().GetWHRHistory(new ECX.CD.BL.WarehouseReciept().GetWarehouseRecieptId(new Guid(id.ToString())));

			foreach (DataRow row in history.Rows)
			{
				if (row["UserId"] != null)
					if (row["UserId"].ToString() != "")
						row["UserName"] = sec.GetUserName(new Guid(row["UserId"].ToString()));
			}

			rpHistory.DataSource = history;
			rpHistory.DataBind();
		}
	}
}
