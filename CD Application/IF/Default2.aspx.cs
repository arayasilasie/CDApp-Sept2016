using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class IF_Default2 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		DataTable tbl = new DataTable();
		
		tbl.Columns.Add("Id", typeof(string));
		tbl.Rows.Add(new object[] { 1 });

		rp1.DataSource = tbl;
		rp1.DataBind();
	}

	protected void lbtnDetail_Command(object sender, CommandEventArgs e)
	{
		Page.ClientScript.RegisterStartupScript(typeof(Page), "OnLoad", "<script language='javascript'>alert('"+e.CommandArgument.ToString()+"');</script>");
	}
}
