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
using ECX.CD.Security;

namespace ECX.CD.UI
{
	public partial class IF_ViewPR : System.Web.UI.Page
	{
		BE.IF.Pledge.ViewPledgeDataTable items = new ECX.CD.BE.IF.Pledge.ViewPledgeDataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
            Master.ErrorText = string.Empty;
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewPR))
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
			((MasterPage_pTop)Page.Master).DescriptionText = "View Pledge Requests";

            Common.PopulateLookUp(ddlStatus, new BL.IFLookup().SelectAll("tblPRStatus"));

			rpPR.DataSource = items;
			rpPR.DataBind();
		} 

		#endregion

		#region Event Handlers
		protected void btnSearch_Click(object sender, EventArgs e)
		{
			byte status = 255;
			if (ddlStatus.SelectedItem.Text != "")
				status = Convert.ToByte(ddlStatus.SelectedValue);

			rpPR.DataSource = new ECX.CD.BL.Pledge().SearchPR(
				Common.GetNumberFrom(txtWHRNO.NumberFrom),
				Common.GetNumberTo(txtWHRNO.NumberTo),
				Common.GetNumberFrom(txtGRNNO.NumberFrom),
				Common.GetNumberTo(txtGRNNO.NumberTo),
				txtMemberIdNo.Text,
				txtClientIdNo.Text,
				"",
				bankPicker.SelectedBankName,
				bankPicker.SelectedBranchName,
				Common.GetDateFrom(dtrExpiryDate.DateFrom),
				Common.GetDateTo(dtrExpiryDate.DateTo), "",
				status);

			rpPR.DataBind();
		}

		protected void lbtnDetail_Command(object sender, CommandEventArgs e)
		{
			BE.IF.Pledge.PledgeRow pledge = new BL.Pledge().GetPledge(new Guid(e.CommandArgument.ToString()));
			BE.WR.WarehouseRecieptRow row;

			if (pledge.WHRNO != 0)
				row = new BL.WarehouseReciept().GetWR(pledge.WHRNO);
			else
				row = new BL.WarehouseReciept().GetWRByGRN(pledge.GRNNO.ToString());

			if (row != null)
				ViewManager.ShowWRHistory(Session, Page, row.WarehouseRecieptId);
		}
		#endregion
	}
}