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
using System.Transactions;

namespace ECX.CD.UI
{
    public partial class Pages_ApprovePUNCancel : System.Web.UI.Page
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Approve PUN Cancel Request";

            rpPickUpNotice.DataSource = items;
            rpPickUpNotice.DataBind();
        }

        void PopulateItems()
        {
            //string[] transactionNos = new ECXWorkFlow.ECXEngine().GetTransactionsByTaskName("CDCancelPUN", "ApprovePUNCancel", "1");
            
			//if (transactionNos.Length > 0)
			//{
                rpPickUpNotice.DataSource = new BL.PUN().GetPUNForPUNCancelApproval();
                rpPickUpNotice.DataBind();
            //}
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

        void Approve()
        {
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDApprovePUNCancel, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.PUN().ApprovePUNCancel(Common.GetUserId(Session, Response), selectedIds);

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
            
            //new BL.PUN().ApprovePUNCancel(Common.GetUserId(Session, Response), SelectedIds());
            //PopulateItems();
		}

		private void Reject()
        {
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDRejectPUNCancel, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.PUN().RejectPUNCancel(Common.GetUserId(Session, Response), selectedIds);

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


            //new BL.PUN().RejectPUNCancel(Common.GetUserId(Session, Response), SelectedIds());
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
        #endregion

        #region Event Handlers
        protected void btnApprovePUNCancel_Click(object sender, EventArgs e)
        {
            Approve();
        }

        protected void lkbDetail_Command(object sender, CommandEventArgs e)
        {
            ShowDetail(e.CommandArgument.ToString());
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

        #endregion
    }
}