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
    public partial class Pages_RequestPUNEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDRequestPUNEdit))
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
			((MasterPage_pTop)Page.Master).DescriptionText = "Request PUN Edit";
			Common.PopulateLookUp(ddlStatus, new BL.Lookup().SelectAll("tblPUNStatus"));

			rpPickUpNotice.DataSource = new BE.PUN.ViewPickUpNoticeDataTable();
			rpPickUpNotice.DataBind();
		}

		private int Search()
		{
			int totalRecordCount = 0;
			BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
			MembershipLookup.MemberShipLookUp msl = new AuthorizedMembershipLookup();
            BE.PUN.ViewPUNForEditDataTable items = new ECX.CD.BE.PUN.ViewPUNForEditDataTable();
			ECXLookup ecxLookup = new ECXLookup();
			CWarehouse warehouse;

			items.Merge(new CD.BL.PUN().SearchPUNForEdit(
				nrWarehouseReceiptID.NumberFrom, nrWarehouseReceiptID.NumberTo,
				nrPUNId.NumberFrom, nrPUNId.NumberTo,
				dtrExpectedPickupDate.DateFrom, dtrExpectedPickupDate.DateTo,
				dtrExpirationDate.DateFrom, dtrExpirationDate.DateTo, ddlStatus.SelectedValue,
                Guid.Empty, Guid.Empty, "", "", "", ""));

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
            
            DropDownList ddlNIDType;
            foreach (RepeaterItem ri in rpPickUpNotice.Items)
            {
                ddlNIDType = (DropDownList)ri.FindControl("ddlNIDType");
                Common.PopulateLookUp(ddlNIDType, new BL.Lookup().SelectAll("tblNIDType"));
            }

			return totalRecordCount;
		}

		private void ShowDetail(string pUNId)
		{
			Session.Add("PUNId", pUNId);
			ViewManager.ShowPUNDetail(Session, Page);
		}

		private void RequestPUNEdit()
		{
            AuditTrail audit = new AuditTrail();
            BE.PUN.PUNEditDataTable items = GetItems();
            
            foreach (BE.PUN.PUNEditRow row in items)
            {
                audit.Add(AuditTrailModules.CDRequestPUNEdit,
                    string.Format("ID = {0}, AgentName = {1}, AgentTel = {2}, NIDNumber = {3}, NIDType = {4}, PUNId = {5}", 
                    row.Id, row.AgentName, row.AgentTel, row.NIDNumber, row.NIDType, row.PUNId ));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        if (new BL.PUN().SavePUNEditRequest(SecurityHelper.CurrentUserGuid.Value, items))
                            ((MasterPage_pTop)this.Master).ErrorText = "Request submitted successfully.";
                        {
                            audit.Commit();
                            scope.Complete();
                        }
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                }
                ((MasterPage_pTop)Page.Master).NotificationText = "Request submitted successful";
                Search();
            }

            //if(new BL.PUN().SavePUNEditRequest(SecurityHelper.CurrentUserGuid.Value, items))
            //    ((MasterPage_pTop)this.Master).ErrorText = "Request submitted successfully.";

            //Search();
		}

        BE.PUN.PUNEditDataTable GetItems()
        {
            BE.PUN.PUNEditDataTable ret = new ECX.CD.BE.PUN.PUNEditDataTable();

            foreach (RepeaterItem item in rpPickUpNotice.Items)
            {
                if (((HtmlInputCheckBox)item.FindControl("chkSelected")).Checked)
                {
                    ret.AddPUNEditRow(
                        Guid.NewGuid(),
                        new Guid(((LinkButton)item.FindControl("lkbDetail")).CommandArgument),
                        ((TextBox)item.FindControl("txtNIDNumber")).Text,
                        ((TextBox)item.FindControl("txtAgentName")).Text,
                        ((TextBox)item.FindControl("txtAgentTel")).Text,
                        Convert.ToInt32(((DropDownList)item.FindControl("ddlNIDType")).SelectedValue));
                }
            }

            return ret;
        }
        #endregion

		#region Event Handlers
		protected void lkbDetail_Command(object sender, CommandEventArgs e)
		{
			ShowDetail(e.CommandArgument.ToString());
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RequestPUNEdit();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
			Search();
            //paging.CurrentPosition = 0;
            //int totalRecordCount = Search();
            //paging.SetCurrentPosition(Navigation.First, totalRecordCount);
        }
        #endregion
    }
}