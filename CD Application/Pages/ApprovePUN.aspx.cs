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
using ECX.CD.Lookup;
using System.Collections.Generic;
using ECX.CD.Security;

namespace ECX.CD.UI
{
    public partial class Pages_ViewPUN : System.Web.UI.Page
    {
        BE.PUN.ViewPickUpNoticeDataTable items = new ECX.CD.BE.PUN.ViewPickUpNoticeDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDApprovePUN))
            {
                //btnRequestPUNCancel.Visible = false;
                ErrorHandler.RedirectToErrorPage("You do not have permission to perform this task.");
            }

            if (!IsPostBack)
            {
                InitializeControls();
            }
        }

        #region Methods

        private void InitializeControls()
        {
            ((MasterPage_pTop)Page.Master).DescriptionText = "Approve Pickup Notices";

			PopulateItems(0);
        }

		private int PopulateItems(int currentPage)
        {
            int totalRecordCount = 0;
            BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
            MembershipLookup.MemberShipLookUp msl = new AuthorizedMembershipLookup();

			items.Merge(new CD.BL.PUN().GetPUNForCancel());

            //Get display values of fields from services
            foreach (BE.PUN.ViewPickUpNoticeRow row in items)
            {
                row.WarehouseName = new ECXLookup().GetWarehouse(Common.EnglishGuid, row.WarehouseId).Name;
                row.WarehouseRecieptIds = new BL.PUN().GetWarehouseRecieptIds(row.Id);
            }

            rpPickUpNotice.DataSource = items;
            rpPickUpNotice.DataBind();
            
            return totalRecordCount;
        }

        private void ShowDetail(string pUNId)
        {
            Session.Add("PUNId", pUNId);
            ViewManager.ShowPUNDetail(Session, Page);
        }

		private void Approve()
        {
			//new PUN().Approve(SelectedIds());
        }

        private List<Guid> SelectedIds()
        {
            List<Guid> ret = new List<Guid>();

            foreach (RepeaterItem item in rpPickUpNotice.Items)
            {
                if (((HtmlInputCheckBox)item.FindControl("chkSelected")).Checked)
                {
                    ret.Add(new Guid(((LinkButton)item.FindControl("lkbDetail")).CommandArgument));
                }
            }

            return ret;
        }

        #endregion

        #region Event Handlers
        protected void paging_FillRepeater(Navigation n)
        {
			//paging.RecordCount = Search(paging.CurrentPosition);
			//paging.SetCurrentPosition(n);
        }

        protected void lkbDetail_Command(object sender, CommandEventArgs e)
        {
            ShowDetail(e.CommandArgument.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //int totalRecordCount = Search(0);
            //paging.SetCurrentPosition(Navigation.First, totalRecordCount);
        }

		protected void btnApprove_Click(object sender, EventArgs e)
        {
			Approve();
        }

        #endregion
    }
}