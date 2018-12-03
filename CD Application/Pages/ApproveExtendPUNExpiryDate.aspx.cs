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
	public partial class Pages_ApproveExtendPUNExpiryDate : System.Web.UI.Page
	{
		BE.PUN.ViewPickUpNoticeDataTable items = new ECX.CD.BE.PUN.ViewPickUpNoticeDataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDAppPUNExtendExpiry))
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Approve PUN extend expiry request";

			rpPickUpNotice.DataSource = items;
			rpPickUpNotice.DataBind();
		}

		void PopulateItems()
		{
			rpPickUpNotice.DataSource = new BL.PUN().GetPUNForExtendExpiryApproval();
			rpPickUpNotice.DataBind();
		}

		void Approve()
        {
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDApprovePUNExtendExpiryDate, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        if (new BL.PUN().ApprovePUNExtendExpiry(SelectedIds(), SecurityHelper.CurrentUserGuid.Value))
                        {
                            audit.Commit();
                            scope.Complete();
                            
                            ((MasterPage_pTop)Page.Master).NotificationText = "Approval successful!";
                        }
                        else
                        {
                            ((MasterPage_pTop)Page.Master).ErrorText = "Approval was not successful!";
                        }
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                }
            }

            PopulateItems();

            //new BL.PUN().ApprovePUNExtendExpiry(SelectedIds(), SecurityHelper.CurrentUserGuid.Value);
            //PopulateItems();
		}

		private void Reject()
        {
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDRejectPUNExtendExpiryDate, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.PUN().RejectPUNExtendExpiry(SelectedIds(), SecurityHelper.CurrentUserGuid.Value);

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



            //new BL.PUN().RejectPUNExtendExpiry(SelectedIds(), SecurityHelper.CurrentUserGuid.Value);
            //PopulateItems();
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

		private void ShowDetail(string pUNId)
		{
			Session.Add("PUNId", pUNId);
			ViewManager.ShowPUNDetail(Session, Page);
		}
		#endregion

		#region Event Handlers
		protected void btnApprove_Click(object sender, EventArgs e)
		{
			Approve();
		}

		protected void btnReject_Click(object sender, EventArgs e)
		{
			Reject();
		}

		protected void lkbDetail_Command(object sender, CommandEventArgs e)
		{
			ShowDetail(e.CommandArgument.ToString());
		}
		#endregion
	}
}