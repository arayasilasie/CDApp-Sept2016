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
using ECX.CD.Lookup;
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
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDCancelPUN))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
            }

            if (!IsPostBack)
            {
                InitializeControls();

                PopulateItems();
            }
        }

        #region Methods

        private void InitializeControls()
        {
            ((MasterPage_pTop)Page.Master).DescriptionText = "View Pickup Notices";
            //Common.PopulateWRStatus(ddlWRStatus);
            Common.PopulateLookUp(ddlStatus, new BL.Lookup().SelectAll("tblPUNStatus"));

            rpPickUpNotice.DataSource = items;
            rpPickUpNotice.DataBind();
        }

        void PopulateItems()
        {
            string[] transactionNos = new ECXWorkFlow.ECXEngine().GetTransactionsByTaskName("CDCancelPUN", "CancelPUN", "2");

            if (transactionNos.Length > 0)
            {
                rpPickUpNotice.DataSource = new BL.PUN().GetPUNForCancel(transactionNos);
                rpPickUpNotice.DataBind();
            }
        }

        private int Search()
        {
            int totalRecordCount = 0;
            BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
            MembershipLookup.MemberShipLookUp msl = new AuthorizedMembershipLookup();

            items.Merge(new CD.BL.PUN().SearchPUNForCancel(
                nrWarehouseReceiptID.NumberFrom, nrWarehouseReceiptID.NumberTo,
                nrPUNId.NumberFrom, nrPUNId.NumberTo,
                dtrExpectedPickupDate.DateFrom, dtrExpectedPickupDate.DateTo,
                dtrExpirationDate.DateFrom, dtrExpirationDate.DateTo, ddlStatus.SelectedValue));

            //Get display values of fields from services
            foreach (BE.PUN.ViewPickUpNoticeRow row in items)
            {
                row.WarehouseName = new ECXLookup().GetWarehouse(Common.EnglishGuid, row.WarehouseId).Name;
                row.WarehouseRecieptIds = new BL.PUN().GetWarehouseRecieptIds(row.Id);
            }

            btnSearch.Text = "Refresh";
            rpPickUpNotice.DataSource = items;
            rpPickUpNotice.DataBind();
            
            return totalRecordCount;
        }

        private void ShowDetail(string pUNId)
        {
            Session.Add("PUNId", pUNId);
            ViewManager.ShowPUNDetail(Session, Page);
        }

        private void Print()
        {
            new PUN().PrintPUN(SelectedIds());
        }

        void Cancel()
        {
            new BL.PUN().CancelPUN(SelectedIds(), Common.GetUserId(Session, Response));
        }

        List<Guid> SelectedIds()
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        protected void lkbDetail_Command(object sender, CommandEventArgs e)
        {
            ShowDetail(e.CommandArgument.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        #endregion
    }
}