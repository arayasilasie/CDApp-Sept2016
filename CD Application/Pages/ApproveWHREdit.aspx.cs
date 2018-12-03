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
    public partial class Pages_ApproveWHREdit : System.Web.UI.Page
    {
        ECX.CD.BE.WR.ViewWarehouseRecieptDataTable items = new ECX.CD.BE.WR.ViewWarehouseRecieptDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDApproveWHREdit))
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Approve WHR Edit Request";

            PopulateItems();
        }

        void PopulateItems()
        {
            string[] transactionNos = new ECXWorkFlow.ECXEngine().GetTransactionsByTaskName("CDEditWHR", "ApproveWHREdit", "1");

            if (transactionNos.Length > 0)
            {
                rpWR.DataSource = new BL.WarehouseReciept().GetWHRForEditRequestApproval(transactionNos);
                rpWR.DataBind();
            }
        }

        private void ApproveWHREdit()
        {
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDApproveWHRCancel, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new ECX.CD.BL.WarehouseReciept().ApproveWHREdit(SelectedIds(), Common.GetUserId(Session, Response));

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

            //new ECX.CD.BL.WarehouseReciept().ApproveWHREdit(SelectedIds(), Common.GetUserId(Session, Response));
        }

        private void RejectWHREdit()
        {
            AuditTrail audit = new AuditTrail();
            List<Guid> selectedIds = SelectedIds();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.CDApproveWHRCancel, string.Format("ID = {0};", selected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new ECX.CD.BL.WarehouseReciept().RejectWHREdit(SelectedIds(), Common.GetUserId(Session, Response));

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

            //new ECX.CD.BL.WarehouseReciept().RejectWHREdit(SelectedIds(), Common.GetUserId(Session, Response));
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
        #endregion

        #region Event Handlers

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            ApproveWHREdit();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            RejectWHREdit();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }

        protected void lbtnWarehouseRecieptId_Command(object sender, CommandEventArgs e)
        {
            Session.Add("WRId", e.CommandArgument.ToString());
            ViewManager.ShowWRDetail(Session, Page);

            //wRDetail.Id = e.CommandArgument.ToString();
            //mdlWRDetail.Show();
        }

        #endregion
    }
}