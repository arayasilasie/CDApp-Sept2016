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
            //if (!SecurityHelper.CurrentUserGuid.HasValue)
            //{
            //    ErrorHandler.RedirectToSessionExpiredPage();
            //}
            //if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewPUN))
            //{
            //    //btnRequestPUNCancel_Click.Visible = false;
            //    ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
            //}

            if (!IsPostBack)
            {
                InitializeControls();
            }
        }

        #region Methods
        private void InitializeControls()
        {
            ((MasterPage_pTop)Page.Master).DescriptionText = "View Pickup Notices";
            
            //Common.PopulateWRStatus(ddlWRStatus);
            Common.PopulateLookUp(ddlStatus, new BL.Lookup().SelectAll("tblPUNStatus"));
            Common.PopulateLookUp(ddlWareHouse, new ECXLookup().GetAllWarehouses(Common.EnglishGuid, Common.WarehouseTypeGuid));

            rpPickUpNotice.DataSource = items;
            rpPickUpNotice.DataBind();
        }

        //private int Search(int currentPage)
        //{
        //    int totalRecordCount = 0;
        //    BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
        //    MembershipLookup.MemberShipLookUp msl = new AuthorizedMembershipLookup();
        //    ECXLookup ecxLookup = new ECXLookup();
        //    CWarehouse warehouse;
        //    MembershipEntities memEntity;
        //    CCommodityGrade commodityGrade;
        //    Guid clientId = Guid.Empty;
        //    Guid wareHouseId = Guid.Empty;

        //    Master.ErrorText = "";
        //    if(txtClientID.Text != "")
        //    {
        //        memEntity = msl.GetEntityByIdNo(txtClientID.Text);
        //        if (memEntity != null)
        //            clientId = memEntity.UniqueIdentifier;
        //        else
        //            Master.ErrorText = "Invalid Client Id";
        //    }

        //    if(ddlWareHouse.SelectedIndex > 0)
        //    {
        //        warehouse = ecxLookup.GetWarehouse(Common.EnglishGuid, new Guid(ddlWareHouse.SelectedValue));
        //        if(warehouse != null)
        //            wareHouseId = warehouse.UniqueIdentifier;
        //    }

        //    totalRecordCount = new CD.BL.PUN().TotalRecordCount(
        //        nrWarehouseReceiptID.NumberFrom, nrWarehouseReceiptID.NumberTo,
        //        nrPUNId.NumberFrom, nrPUNId.NumberTo,
        //        dtrExpectedPickupDate.DateFrom, dtrExpectedPickupDate.DateTo,
        //        dtrExpirationDate.DateFrom, dtrExpirationDate.DateTo, ddlStatus.SelectedValue);

        //    items.Merge(new CD.BL.PUN().SearchPickUpNotice(
        //        nrWarehouseReceiptID.NumberFrom, nrWarehouseReceiptID.NumberTo,
        //        nrPUNId.NumberFrom, nrPUNId.NumberTo,
        //        dtrExpirationDate.DateFrom, dtrExpirationDate.DateTo, 
        //        dtrExpectedPickupDate.DateFrom, dtrExpectedPickupDate.DateTo,
        //        ddlStatus.SelectedValue, clientId, wareHouseId, 
        //        dtrDateCreated.DateFrom, dtrDateCreated.DateTo,
        //        dtrTradeDate.DateFrom, dtrTradeDate.DateTo));

        //    //Get display values of fields from services
        //    foreach (BE.PUN.ViewPickUpNoticeRow row in items)
        //    {
        //        warehouse = ecxLookup.GetWarehouse(Common.EnglishGuid, row.WarehouseId);
        //        if(warehouse != null)
        //            row.WarehouseName = warehouse.Name;

        //        memEntity = msl.GetEntityByGuid(row.ClientGuid);
        //        if (memEntity != null)
        //        {
        //            row.ClientId = memEntity.StringIdNo;
        //            row.ClientName = memEntity.OrganizationName;
        //        }
        //        commodityGrade = ecxLookup.GetCommodityGrade(Common.EnglishGuid, row.CommodityGradeId);
        //        if (commodityGrade != null)
        //            row.Symbol = commodityGrade.Symbol;

        //        row.WarehouseRecieptIds = new BL.PUN().GetWarehouseRecieptIds(row.Id);
        //        row.TradeDates = new BL.PUN().GetTradeDates(row.Id);
        //    }

        //    rpPickUpNotice.DataSource = items;
        //    rpPickUpNotice.DataBind();
            
        //    return totalRecordCount;
        //}

        private int Search(int currentPage)
        {
            int totalRecordCount = 0;
            BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
            MembershipLookup.MemberShipLookUp msl = new AuthorizedMembershipLookup();
            ECXLookup ecxLookup = new ECXLookup();
            CWarehouse warehouse;
            MembershipEntities memEntity;
            CCommodityGrade commodityGrade;
            Guid clientId = Guid.Empty;
            Guid wareHouseId = Guid.Empty;

            Master.ErrorText = "";
            if (txtClientID.Text != "")
            {
                memEntity = msl.GetEntityByIdNo(txtClientID.Text);
                if (memEntity != null)
                    clientId = memEntity.UniqueIdentifier;
                else
                    Master.ErrorText = "Invalid Client Id";
            }

            if (ddlWareHouse.SelectedIndex > 0)
            {
                warehouse = ecxLookup.GetWarehouse(Common.EnglishGuid, new Guid(ddlWareHouse.SelectedValue));
                if (warehouse != null)
                    wareHouseId = warehouse.UniqueIdentifier;
            }

            totalRecordCount = new CD.BL.PUN().TotalRecordCount(
                nrWarehouseReceiptID.NumberFrom, nrWarehouseReceiptID.NumberTo,
                nrPUNId.NumberFrom, nrPUNId.NumberTo,
                dtrExpectedPickupDate.DateFrom, dtrExpectedPickupDate.DateTo,
                dtrExpirationDate.DateFrom, dtrExpirationDate.DateTo, ddlStatus.SelectedValue);

            items.Merge(new CD.BL.PUN().SearchPickUpNoticeForView(
                nrWarehouseReceiptID.NumberFrom, nrWarehouseReceiptID.NumberTo,
                nrPUNId.NumberFrom, nrPUNId.NumberTo,
                dtrExpirationDate.DateFrom, dtrExpirationDate.DateTo,
                dtrExpectedPickupDate.DateFrom, dtrExpectedPickupDate.DateTo,
                ddlStatus.SelectedValue, clientId, wareHouseId,
                dtrDateCreated.DateFrom, dtrDateCreated.DateTo,
                dtrTradeDate.DateFrom, dtrTradeDate.DateTo));

            //Get display values of fields from services
            foreach (DataRow row in items.Rows)
            {
                warehouse = ecxLookup.GetWarehouse(Common.EnglishGuid, new Guid(row["WarehouseId"].ToString()));
                if (warehouse != null)
                    row["WarehouseName"] = warehouse.Name;

                memEntity = msl.GetEntityByGuid(new Guid(row["ClientGuid"].ToString()));
                if (memEntity != null)
                {
                    row["ClientId"] = memEntity.StringIdNo;
                    row["ClientName"] = memEntity.OrganizationName;
                }
                commodityGrade = ecxLookup.GetCommodityGrade(Common.EnglishGuid, new Guid(row["CommodityGradeId"].ToString()));
                if (commodityGrade != null)
                    row["Symbol"] = commodityGrade.Symbol;

                row["WarehouseRecieptIds"] = new BL.PUN().GetWarehouseRecieptIds(new Guid(row["Id"].ToString()));
                row["TradeDates"] = new BL.PUN().GetTradeDates(new Guid(row["Id"].ToString()));
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

        private void Print()
        {
            List<Guid> selectedIds = SelectedIds();

            if (selectedIds.Count > 0)
            {
                System.Web.HttpContext.Current.Session["PUNIDList"] = selectedIds;
                System.Web.HttpContext.Current.Response.Redirect("~/Reports/PUNViewer.aspx");
            }
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

        private void RequestPUNCancel()
        {
            new BL.PUN().RequestPUNCancel(Common.GetUserId(Session, Response), SelectedIds());
        }
        #endregion

        #region Event Handlers
        protected void btnRequestPUNCancel_Click(object sender, EventArgs e)
        {
            RequestPUNCancel();
        }

        protected void paging_FillRepeater(Navigation n)
        {
			paging.RecordCount = Search(paging.CurrentPosition);
            paging.SetCurrentPosition(n);
        }

        protected void lkbDetail_Command(object sender, CommandEventArgs e)
        {
            ShowDetail(e.CommandArgument.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int totalRecordCount = Search(0);
            //paging.SetCurrentPosition(Navigation.First, totalRecordCount);
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        #endregion
        protected void btnNew_Click(object sender, EventArgs e)
        {

        }
}
}