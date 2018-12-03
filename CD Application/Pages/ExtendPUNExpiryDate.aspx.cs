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
    public partial class Pages_ExtendPUNExpiryDate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDReqPUNExtendExpiry))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task..");
            }

            if (!IsPostBack)
            {
                InitializeControls();
            }
        }

		#region Methods
		private void InitializeControls()
		{
			((MasterPage_pTop)Page.Master).DescriptionText = "Request PUN Expiry Date Extension";
			Common.PopulateLookUp(ddlStatus, new BL.Lookup().SelectAll("tblPUNStatus"));

			rpPickUpNotice.DataSource = new BE.PUN.ViewPickUpNoticeDataTable();
			rpPickUpNotice.DataBind();
		}

		private int PopulateItems()
		{
			int totalRecordCount = 0;
			BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
			MembershipLookup.MemberShipLookUp msl = new AuthorizedMembershipLookup();
            BE.PUN.ViewPUNForEditDataTable items = new ECX.CD.BE.PUN.ViewPUNForEditDataTable();
			ECXLookup ecxLookup = new ECXLookup();
			CWarehouse warehouse;

			items.Merge(new CD.BL.PUN().SearchPickUpNotice(
				nrWarehouseReceiptID.NumberFrom, nrWarehouseReceiptID.NumberTo,
				nrPUNId.NumberFrom, nrPUNId.NumberTo,
				dtrExpectedPickupDate.DateFrom, dtrExpectedPickupDate.DateTo,
				dtrExpirationDate.DateFrom, dtrExpirationDate.DateTo, 
                ddlStatus.SelectedValue, Guid.Empty, Guid.Empty, "", "", "", ""));

			//Get display values of fields from services
			foreach (BE.PUN.ViewPUNForEditRow row in items)
			{
				warehouse = ecxLookup.GetWarehouse(Common.EnglishGuid, row.WarehouseId);

				if (warehouse != null)
					row.WarehouseName = warehouse.Name;

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

		private void ExtendExpiryDate()
		{
            AuditTrail audit = new AuditTrail();
			Dictionary<Guid, int> pickupNotices = new Dictionary<Guid, int>();

			foreach (RepeaterItem item in rpPickUpNotice.Items)
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

					pickupNotices.Add(
                        new Guid(((LinkButton)item.FindControl("lkbDetail")).CommandArgument),
						Convert.ToInt32(((Controls_Number)item.FindControl("txtNumberOfDays")).Number));
				}
			}

            foreach (KeyValuePair<Guid, int> pun in pickupNotices)
            {
                audit.Add(AuditTrailModules.CDRequestPUNExtendExpiryDate, string.Format("ID = {0}; Number of Days = {1}", pun.Key, pun.Value));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.PUN().SaveExtendExpiryDateRequest(pickupNotices, SecurityHelper.CurrentUserGuid.Value);

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

			//new BL.PUN().SaveExtendExpiryDateRequest(pickupNotices, SecurityHelper.CurrentUserGuid.Value);
		}
        #endregion

		#region Event Handlers
		protected void lkbDetail_Command(object sender, CommandEventArgs e)
		{
			ShowDetail(e.CommandArgument.ToString());
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ExtendExpiryDate();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
			PopulateItems();
            //paging.CurrentPosition = 0;
            //int totalRecordCount = PopulateItems();
            //paging.SetCurrentPosition(Navigation.First, totalRecordCount);
        }
        #endregion
    }
}