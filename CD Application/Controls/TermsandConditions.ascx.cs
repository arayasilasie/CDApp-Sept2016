using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_TermsandConditions : System.Web.UI.UserControl
{
	public void SetValue(Guid commodityGradeId, double quantity)
	{
        lblValue.Text = (new ECXTrade.TradeClient().GetLastSellingPrice(commodityGradeId) * quantity).ToString("0.00");
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			//lblValue.Text = "";
		}
	}
}
