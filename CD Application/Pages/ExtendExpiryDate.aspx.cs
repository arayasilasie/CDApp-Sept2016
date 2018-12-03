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
using ECXControlsCollection;
using System.Transactions;

namespace ECX.CD.UI
{
    public partial class Pages_ExtendExpiryDate : System.Web.UI.Page
    {
        BE.WR.ViewWarehouseRecieptDataTable items = new ECX.CD.BE.WR.ViewWarehouseRecieptDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDReqWHRExtendExpiry))
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Request Expiry Date Extention";

            Common.PopulateLookUp(ddlWareHouse, new ECXLookup().GetAllWarehouses(Common.EnglishGuid, Common.WarehouseTypeGuid));

            rpWR.DataSource = items;
            rpWR.DataBind();
            //CCommodity[] items = new ECXLookup().GetAll(Common.EnglishGuid);

            //Common.PopulateLookUp(ddlStatus, items);
        }

        private int PopulateItems()
        {
			#region Variables
			ECXLookup eCXLookup = new ECXLookup();
			AuthorizedMembershipLookup membershipLookup = new AuthorizedMembershipLookup();
			MembershipEntities memEntity;
			List<string> commodityGradeIds = new List<string>();
			string clientId = "";
			int totalRecordCount;
			BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
			CCommodityGrade commodityGrade;

			if (txtClientId.Text != "")
			{
				memEntity = membershipLookup.GetEntityByIdNo(txtClientId.Text);
				if (memEntity != null)
					clientId = memEntity.UniqueIdentifier.ToString();
			}
			#endregion

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
			items.Merge(new CD.BL.WarehouseReciept().SearchWRForExtendExpiryRequest(
                nrWRId.NumberFrom, nrWRId.NumberTo,
                nrGRNNumber.NumberFrom, nrGRNNumber.NumberTo, clientId, 
                ddlWareHouse.SelectedValue, commodityGradeIds, dtrDateDeposited.DateFrom, 
                dtrDateDeposited.DateTo, dtrExpiryDate.DateFrom, dtrExpiryDate.DateTo, paging.CurrentPosition, paging.PageSize, out totalRecordCount));
			#endregion

			#region Get display values of fields from services
			foreach (BE.WR.ViewWarehouseRecieptRow row in items)
            {
                memEntity = membershipLookup.GetEntityByGuid(row.ClientGuid);
				commodityGrade = eCXLookup.GetCommodityGrade(Common.EnglishGuid, new Guid(row["CommodityGradeId"].ToString()));

				row.ClientId = ((memEntity == null) ? "" : memEntity.StringIdNo);
				row.ClientName = ((memEntity == null) ? "" : memEntity.OrganizationName);

                row.CommodityGradeName = ((commodityGrade == null)?"":commodityGrade.Name);
                row.WRStatusName = lookupBl.GetLookupName("tblWarehouseRecieptStatus", row.WRStatusId);
			}
			#endregion

			rpWR.DataSource = items;
            rpWR.DataBind();

            return totalRecordCount;
        }

        private void ExtendExpiryDate()
        {
			Dictionary<Guid, int> warehouseReceipts = new Dictionary<Guid, int>();
            AuditTrail audit = new AuditTrail();

            foreach (RepeaterItem item in rpWR.Items)
            {
				if (((HtmlInputCheckBox)item.FindControl("chkSelected")).Checked)
                {
					string numberOfDays = ((Controls_Number)item.FindControl("txtNumberOfDays")).Number;
					if (numberOfDays == "")
					{
						((MasterPage_pTop)this.Master).ErrorText = 
							"Number of Days was not specified for some of the selected WHRs.";

						return;
					}

					warehouseReceipts.Add(
						new Guid(((LinkButton)item.FindControl("lbtnWarehouseRecieptId")).CommandArgument),
						Convert.ToInt32(((Controls_Number)item.FindControl("txtNumberOfDays")).Number));
                }
            }

            foreach (KeyValuePair<Guid, int> whr in warehouseReceipts)
            {
                audit.Add(AuditTrailModules.CDRequestWHRExtendExpiryDate, string.Format("ID = {0}; Number of Days = {1}", whr.Key, whr.Value));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.WarehouseReciept().SaveExtendExpiryDateRequest(warehouseReceipts, SecurityHelper.CurrentUserGuid.Value);
                        //new ECX.CD.BL.WarehouseReciept().ApproveWHRCancel(SecurityHelper.CurrentUserGuid.Value, selectedIds);

                        audit.Commit();
                        scope.Complete();
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                }
                ((MasterPage_pTop)Page.Master).NotificationText = "Request sent successfully";
                PopulateItems();
            }

			//new BL.WarehouseReciept().SaveExtendExpiryDateRequest(warehouseReceipts, SecurityHelper.CurrentUserGuid.Value);

            PopulateItems();
        }

        #endregion

        #region Event Handlers

		protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ExtendExpiryDate();
        }

        protected void paging_FillRepeater(Navigation n)
        {
            paging.RecordCount = PopulateItems();

            paging.SetCurrentPosition(n);
        }

        protected void lbtnWarehouseRecieptId_Command(object sender, CommandEventArgs e)
        {
            Session.Add("WRId", e.CommandArgument.ToString());
            ViewManager.ShowWRDetail(Session, Page);

            //wRDetail.Id = e.CommandArgument.ToString();
            //mdlWRDetail.Show();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            paging.CurrentPosition = 0;
            int totalRecordCount = PopulateItems();
            //paging.SetCurrentPosition(Navigation.First, totalRecordCount);
        }

        #endregion
    }
}