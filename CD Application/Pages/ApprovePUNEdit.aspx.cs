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
    public partial class Pages_ApprovePUNEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDApprovePUNEdit))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to perform this operation.");
            }

            if (!IsPostBack)
            {
                InitializeControls();
            }
        }

		#region Methods
		private void InitializeControls()
		{
			((MasterPage_pTop)Page.Master).DescriptionText = "Approve PUN Edit";

            PopulateItems();
		}

		private int PopulateItems()
		{
			int totalRecordCount = 0;
			BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
			MembershipLookup.MemberShipLookUp msl = new AuthorizedMembershipLookup();
            DataTable items = new CD.BL.PUN().GetPUNForEditApproval();
			ECXLookup ecxLookup = new ECXLookup();
			CWarehouse warehouse;

			//Get display values of fields from services
            foreach(DataRow row in items.Rows)
			{
                warehouse = ecxLookup.GetWarehouse(Common.EnglishGuid, new Guid(row["WarehouseId"].ToString()));

				if (warehouse != null)
                    row["WarehouseName"] = warehouse.Name;

                row["WarehouseRecieptIds"] = new BL.PUN().GetWarehouseRecieptIds(new Guid(row["PickUpNoticeId"].ToString()));
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
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDApprovePUNEdit, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                //using (TransactionScope scope = new TransactionScope())
                //{
                    try
                    {
                        new BL.PUN().ApprovePUNEdit(SecurityHelper.CurrentUserGuid.Value, selectedIds);

                        audit.Commit();
                        //scope.Complete();
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                //}
                ((MasterPage_pTop)Page.Master).NotificationText = "Approval successful";
                PopulateItems();
            }


            //List<Guid> items = SelectedIds();

            //if (items.Count == 0)
            //{
            //    ((MasterPage_pTop)this.Master).ErrorText = "No PUN selected.";

            //    return;
            //}

            //if(new BL.PUN().ApprovePUNEdit(SecurityHelper.CurrentUserGuid.Value, items))
            //    ((MasterPage_pTop)this.Master).NotificationText = "Approval successful.";

			PopulateItems();
		}

        private void Reject()
        {
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDRejectPUNEdit, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.PUN().RejectPUNEdit(SecurityHelper.CurrentUserGuid.Value, SelectedIds());

                        audit.Commit();
                        scope.Complete();
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                }
                ((MasterPage_pTop)Page.Master).NotificationText = "Approval successful";
                PopulateItems();
            }


            //List<Guid> items = SelectedIds();

            //if (items.Count == 0)
            //{
            //    ((MasterPage_pTop)this.Master).ErrorText = "No PUN selected.";

            //    return;
            //}

            //if (new BL.PUN().RejectPUNEdit(SecurityHelper.CurrentUserGuid.Value, SelectedIds()))
            //    ((MasterPage_pTop)this.Master).ErrorText = "Rejection successful.";
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
		protected void lkbDetail_Command(object sender, CommandEventArgs e)
		{
			ShowDetail(e.CommandArgument.ToString());
		}

		protected void btnApprove_Click(object sender, EventArgs e)
        {
            Approve();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
			PopulateItems();
            //paging.CurrentPosition = 0;
            //int totalRecordCount = Search();
            //paging.SetCurrentPosition(Navigation.First, totalRecordCount);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Reject();
        }
        #endregion
    }
}