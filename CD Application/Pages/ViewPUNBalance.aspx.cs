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
using Lookup;
using MembershipLookup;
using System.Collections.Generic;
using System.Collections.Specialized;
using ECX.CD.Lookup;
using ECX.CD.Security;

namespace ECX.CD.UI
{
	public partial class Pages_ViewPUNBalance : System.Web.UI.Page
    {
		BE.PUN.ViewPUNBalanceDataTable items = new ECX.CD.BE.PUN.ViewPUNBalanceDataTable();

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!SecurityHelper.CurrentUserGuid.HasValue)
			{
				ErrorHandler.RedirectToSessionExpiredPage();
			}
			if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewPUNBalance))
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
			((MasterPage_pTop)Page.Master).DescriptionText = "View PUN Balance";

			rpPickUpNotice.DataSource = items;
			rpPickUpNotice.DataBind();
        }

        private void Search()
        {
			items.Merge(new CD.BL.PUN().SearchViewPUNBalance(
				nrWarehouseReceiptID.NumberFrom, nrWarehouseReceiptID.NumberTo, txtMemberId.Text, txtClientId.Text, chkRemainingQtyGreaterThan0OrLessThan0.Checked));

            rpPickUpNotice.DataSource = items;
            rpPickUpNotice.DataBind();

            btnSearch.Text = "Refresh";
        }
        #endregion

		#region Event Handlers

        protected void btnSearch_Click(object sender, EventArgs e)
        {
			Search();
        }

        #endregion
    }
}