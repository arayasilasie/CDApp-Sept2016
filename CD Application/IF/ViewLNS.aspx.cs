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
using ECX.CD.BL.ECXLookup;
using ECX.CD.Security;

namespace ECX.CD.UI
{
	public partial class IF_ViewLNS : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Master.ErrorText = string.Empty;
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewLNS))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
            } 
            if (!IsPostBack)
			{
				InitializeControls();
			}
		}

		#region Methods

		private void InitializeControls()
		{
			((MasterPage_pTop)Page.Master).DescriptionText = "View LNS";	

			rpLNS.DataSource = new ECX.CD.BE.IF.LNS.ViewLiftNoSaleDataTable();
			rpLNS.DataBind();

			Common.PopulateLookUp(ddlStatus, new BL.IFLookup().SelectAll("tblLNSStatus"));
			//Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));
		}

		#endregion

		#region Event Handlers
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			byte status = 255;
			if (ddlStatus.SelectedItem.Text != "")
				status = Convert.ToByte(ddlStatus.SelectedValue);

			rpLNS.DataSource = new BL.LNS().SearchLNS(
				Common.GetNumberFrom(txtWHRNO.NumberFrom),
				Common.GetNumberTo(txtWHRNO.NumberTo),
				bankPicker.SelectedBankName,
				bankPicker.SelectedBranchName,
				txtLoanAccountNumber.Text,
				status);

			rpLNS.DataBind();
		}

		protected void lbtnDetail_Command(object sender, CommandEventArgs e)
		{
			BE.IF.LNS.LiftNoSaleRow lns = new BL.LNS().GetLNS(new Guid(e.CommandArgument.ToString()));
			BE.WR.WarehouseRecieptRow row = new BL.WarehouseReciept().GetWR(lns.WHRNO);

			if (row != null)
			{
				ViewManager.ShowWRDetail(Session, Page, row.Id);
			}
		}
		#endregion
	}
}