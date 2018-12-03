using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ECX.CD.Lookup;
using ECX.CD.Security;
using System.Transactions;

namespace ECX.CD.UI
{
	public partial class Pages_ApproveExtendExpiryDate : System.Web.UI.Page
	{
		BE.PUN.ViewPickUpNoticeDataTable items = new ECX.CD.BE.PUN.ViewPickUpNoticeDataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
            Master.ErrorText = string.Empty;
			if (!SecurityHelper.CurrentUserGuid.HasValue)
			{
				ErrorHandler.RedirectToSessionExpiredPage();
			}
			if (!SecurityHelper.HasPermission(CDSecurityRights.CDAppWHRExtendExpiry))
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
			((MasterPage_pTop)Page.Master).DescriptionText = "Approve WHR extend expiry request";

			rpWR.DataSource = items;
			rpWR.DataBind();
		}

		void PopulateItems()
		{
			rpWR.DataSource = new BL.WarehouseReciept().GetWHRForExtendExpiryApproval();
			rpWR.DataBind();
		}

		private void Print()
		{
            new WHR().PrintWHR(SelectedWHRIds());
		}

		void Approve()
		{
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDApproveWHRExtendExpiryDate, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.WarehouseReciept().ApproveExtendExpiry(selectedIds, SecurityHelper.CurrentUserGuid.Value);

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
        }

		private void Reject()
		{
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDRejectWHRExtendExpiryDate, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.WarehouseReciept().RejectWHRExtendExpiry(selectedIds, SecurityHelper.CurrentUserGuid.Value);

                        audit.Commit();
                        scope.Complete();
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                }
                ((MasterPage_pTop)Page.Master).NotificationText = "Rejection successful";
                PopulateItems();
            }

			//new BL.WarehouseReciept().RejectWHRExtendExpiry(SelectedIds(), SecurityHelper.CurrentUserGuid.Value);
			//PopulateItems();
		}

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
		List<Guid> SelectedWHRIds()
		{
			List<Guid> ret = new List<Guid>();

			foreach (RepeaterItem item in rpWR.Items)
			{
				if (((HtmlInputCheckBox)item.FindControl("chkSelected")).Checked)
				{
					ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWarehouseRecieptId")).CommandName));
				}
			}

			return ret;
		}
		#endregion

		#region Event Handlers
		protected void btnApprovePUNCancel_Click(object sender, EventArgs e)
		{
			Approve();
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			PopulateItems();
		}

		protected void btnPrint_Click(object sender, EventArgs e)
		{
			Print();
		}

		protected void btnReject_Click(object sender, EventArgs e)
		{
			Reject();
		}

		protected void lbtnWarehouseRecieptId_Command(object sender, CommandEventArgs e)
		{
			Session.Add("WRId", e.CommandName);
			ViewManager.ShowWRDetail(Session, Page);
		}

		#endregion
	}
}