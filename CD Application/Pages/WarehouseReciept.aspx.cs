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
using System.Transactions;

namespace ECX.CD.UI
{
    public partial class Pages_WarehouseReciept : System.Web.UI.Page
    {
        BE.WR.ViewWarehouseRecieptDataTable items = new ECX.CD.BE.WR.ViewWarehouseRecieptDataTable();

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!SecurityHelper.CurrentUserGuid.HasValue)
			{
				ErrorHandler.RedirectToSessionExpiredPage();
			}
			if (!SecurityHelper.HasPermission(CDSecurityRights.CDApproveWHR))
			{
				ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
			}
			if (SecurityHelper.HasPermission(CDSecurityRights.CDReqWHRCancellation))
			{
                btnRequestWHRCancel.Visible = true;
                txtRequestWHRRemark.Visible = true;
			}
            else
            {
                btnRequestWHRCancel.Visible = false;
                txtRequestWHRRemark.Visible = false;
            }
            
            if (!IsPostBack)
            {
                InitializeControls();
            }
        }

        #region Methods
        private void InitializeControls()
        {
            ((MasterPage_pTop)Page.Master).DescriptionText = "Warehouse Receipts";

            Common.PopulateWRStatus(ddlWRStatus);
            
			//TODO:
            Common.PopulateLookUp(ddlWareHouse, new ECXLookup().GetAllWarehouses(Common.EnglishGuid, Common.WarehouseTypeGuid));
            Common.PopulateLookUp(ddlSourceType, new BL.Lookup().SelectAll("tblSourceType"));

            rpWR.DataSource = items;
            rpWR.DataBind();

			paging.RecordCount = Search();
			paging.SetCurrentPosition(Navigation.First);
        }

        private int Search()
        {
            ECXLookup eCXLookup = new ECXLookup();
            AuthorizedMembershipLookup membershipLookup = new AuthorizedMembershipLookup();
            MembershipLookup.MembershipEntities memberEntity;
            //MembershipLookup.Client client ;
            List<string> commodityGradeIds = new List<string>();
            string clientId = "";
            byte sourceTypeId = 255;
            int totalRecordCount;
            BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
			CCommodityGrade grade;
			CWarehouse warehouse;

			if (txtClientId.Text != "")
			{
				memberEntity = membershipLookup.GetEntityByIdNo(txtClientId.Text);
				if (memberEntity != null)
					clientId = memberEntity.UniqueIdentifier.ToString();
			}

            if (ddlSourceType.SelectedIndex > 0)
                sourceTypeId = Convert.ToByte(ddlSourceType.SelectedValue);

            #region Get the list of CommodityGradeIds
            if (commodityPicker.CommodityGradeId != "")
            {
                commodityGradeIds.Add(commodityPicker.CommodityGradeId);
            }
            else if (commodityPicker.CommodityClassId != "")
            {
                CCommodityGrade[] cgs = eCXLookup.GetAllCommodityGrades(Common.EnglishGuid, new Guid(commodityPicker.CommodityClassId));

                foreach (CCommodityGrade cg in cgs)
                {
                    commodityGradeIds.Add(cg.UniqueIdentifier.ToString());
                }
            }
            else if (commodityPicker.CommodityId != "")
            {
                CCommodityClass[] ccs = eCXLookup.GetAllCommodityClasses(Common.EnglishGuid, new Guid(commodityPicker.CommodityId));

                foreach (CCommodityClass cc in ccs)
                {
                    CCommodityGrade[] cgs = eCXLookup.GetAllCommodityGrades(Common.EnglishGuid, cc.UniqueIdentifier);

                    foreach (CCommodityGrade cg in cgs)
                    {
                        commodityGradeIds.Add(cg.UniqueIdentifier.ToString());
                    }
                }
            }
            #endregion

			#region Get data grom db
            int consType = Convert.ToInt16(ddlConsType.SelectedValue);
			items.Merge(new CD.BL.WarehouseReciept().SearchWR(
                nrWRId.NumberFrom, nrWRId.NumberTo,
                nrGRNNumber.NumberFrom, nrGRNNumber.NumberTo, clientId, 
                ddlWareHouse.SelectedValue, ddlWRStatus.SelectedValue, commodityGradeIds, dtrDateDeposited.DateFrom, 
                dtrDateDeposited.DateTo, dtrExpiryDate.DateFrom, dtrExpiryDate.DateTo, sourceTypeId,
				paging.CurrentPosition + 1, paging.PageSize,consType, out totalRecordCount));
			#endregion

			#region Get display values of fields from services
			foreach (BE.WR.ViewWarehouseRecieptRow row in items)
			{
				memberEntity = membershipLookup.GetEntityByGuid(row.ClientGuid);

				if (memberEntity != null)
				{
					row.ClientId = memberEntity.StringIdNo;
					row.ClientName = memberEntity.OrganizationName;
				}

				grade = eCXLookup.GetCommodityGrade(Common.EnglishGuid, new Guid(row["CommodityGradeId"].ToString()));
				if (grade != null)
					row.CommodityGradeName = grade.Symbol;

				warehouse = eCXLookup.GetWarehouse(Common.EnglishGuid, row.WarehouseId);
				if(warehouse != null)
					row.WarehouseName = warehouse.Name;

				row.WRStatusName = lookupBl.GetLookupName("tblWarehouseRecieptStatus", row.WRStatusId);
				//row.WarehouseName = eCXLookup.GetWarehouse(Common.EnglishGuid, row.WarehouseId).Name;
			}
			#endregion

			rpWR.DataSource = items;
            rpWR.DataBind();

            btnSearch.Text = "Refresh";
            return totalRecordCount;
        }

        private void Print()
        {
            List<Guid> selectedWHRIds = new List<Guid>();

            foreach (RepeaterItem item in rpWR.Items)
            {
                if (((HtmlInputCheckBox)item.Controls[1]).Checked)
                {
                    selectedWHRIds.Add(new Guid(((LinkButton)item.FindControl("lbtnWarehouseRecieptId")).CommandArgument));
                }
            }

            new WHR().PrintWHR(selectedWHRIds);
        }

        //private void RequestWHREdit()
        //{
        //    new BL.WarehouseReciept().RequestWHREdit(SelectedIds(), Common.GetUserId(Session, Response));
        //}

        List<Guid> SelectedIds()
        {
            List<Guid> ret = new List<Guid>();

            foreach (RepeaterItem item in rpWR.Items)
            {
                if (((HtmlInputCheckBox)item.FindControl("chkSelected")).Checked)
                {
                    ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWarehouseRecieptId")).CommandArgument));
                }
            }

            return ret;
		}

		private void RequestWHRCancel()
		{
            List<Guid> wHRIds = SelectedIds();

            if (txtRequestWHRRemark.Text == "")
            {
                Master.ErrorText = "Remark can not be empty.";
            }
            else if(new BL.WarehouseReciept().IsSourceTypeTrade(SelectedIds()))
            {
                Master.ErrorText = "Cancellation not allowed for some of the selected values! Their source is Trade.";
            }
            else
            {
                AuditTrail audit = new AuditTrail();

                foreach (Guid selected in wHRIds)
                {
                    audit.Add(AuditTrailModules.CDApproveWHRCancel, string.Format("ID = {0};", selected));
                }

                if (audit.Save())
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        try
                        {
                            new BL.WarehouseReciept().RequestWHRCancel(Common.GetUserId(Session, Response), wHRIds, txtRequestWHRRemark.Text);

                            audit.Commit();
                            scope.Complete();
                        }
                        catch
                        {
                            audit.RollBack();
                            throw;
                        }
                    }
                    Master.NotificationText = "Cancel request is sent successfully.";
                    Search();
                    return;
                }

                //new BL.WarehouseReciept().RequestWHRCancel(Common.GetUserId(Session, Response), wHRIds, txtRequestWHRRemark.Text);
                //Master.NotificationText = "Cancel request is sent successfully.";
            }
		}
        #endregion

		#region Event Handlers
		protected void btnRequestWHRCancel_Click(object sender, EventArgs e)
		{
			RequestWHRCancel();
		}

        //protected void btnRequestEdit_Click(object sender, EventArgs e)
        //{
        //    RequestWHREdit();
        //}

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        protected void paging_FillRepeater(Navigation n)
        {
            paging.RecordCount = Search();

            paging.SetCurrentPosition(n);
        }

        protected void lbtnWarehouseRecieptId_Command(object sender, CommandEventArgs e)
        {
            Session.Add("WRId", e.CommandArgument.ToString());
            ViewManager.ShowWRDetail(Session, Page);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
			paging.CurrentPosition = -1;
            paging.RecordCount = Search();
            paging.SetCurrentPosition(Navigation.First);
        }

        #endregion
    }
}