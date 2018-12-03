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
using System.Collections.Generic;
using ECX.CD.Lookup;
using MembershipLookup;
using ECX.CD.Security;
using System.Transactions;

namespace ECX.CD.UI
{
    public partial class Pages_TransferTitle : System.Web.UI.Page
    {
        BE.TitleTransfer.ViewTradeDataTable items = new ECX.CD.BE.TitleTransfer.ViewTradeDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDTransferTitle))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
            }

            PopulateItems();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeControls();
        }

        #region Methods

        private void AutorizeUser()
        {
            Common.CheckUserSession(Session, Response);
        }

        private void InitializeControls()
        {
            ((MasterPage_pTop)Page.Master).DescriptionText = "Pending Title Transfer";

            rpTrade.DataSource = items;
            rpTrade.DataBind();
        }

        void PopulateItems()
        {
			rpTrade.DataSource = new BL.WarehouseReciept().GetPendingWHRs();
            rpTrade.DataBind();
        }

        private void ApproveSelection()
        {
            List<int> selectedWRIds = new List<int>();

            foreach (RepeaterItem item in rpTrade.Items)
            {
                if(((HtmlInputCheckBox)item.FindControl("chkSelected")).Checked)
                    selectedWRIds.Add(Convert.ToInt32(((Label)item.FindControl("lblWRNO")).Text));
            }

            AuditTrail audit = new AuditTrail();

            foreach (int id in selectedWRIds)
            {
                audit.Add(AuditTrailModules.CDTransferTitle, string.Format("ID = {0}; ", id));
            }

            //if (audit.Save())
            //{
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        if (new BL.TitleTransfer().ApprovePendingTitleTransfer(selectedWRIds, Common.GetUserId(Session, Response)))
                        {
                            Snapshot.SaveDNSnapshot(selectedWRIds);

                            //audit.Commit();
                            scope.Complete();
                        }
                    }
                    catch(Exception ex)
                    {

                        //audit.RollBack();
                        throw;
                    }
                }
                ((MasterPage_pTop)Page.Master).NotificationText = "Titles transfered successfully!";
                PopulateItems();
            //}

            //((MasterPage_pTop)Page.Master).ErrorText = "Approval was not successful ! Please try again.";


            //success = new BL.TitleTransfer().ApprovePendingTitleTransfer(selectedWRIds, Common.GetUserId(Session, Response));

            //Snapshot.SaveDNSnapshot(selectedWRIds);
            //if (success)
            //{
            //    ((MasterPage_pTop)Page.Master).NotificationText = "Approval successful!";
            //}
            //else
            //{
                //((MasterPage_pTop)Page.Master).ErrorText = "Approval was not successful ! Please try again.";
            //}

            //PopulateItems();
        }

        #endregion

        #region Event Handlers

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rpTrade.Items)
            {
                ((CheckBox)item.FindControl("chkSelected")).Checked = ((CheckBox)sender).Checked;
            }
        }

        protected void dtTradingDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateItems();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            ApproveSelection();

            ECX.CD.BL.PRML.ImportReport(ECX.CD.Security.SecurityHelper.CurrentUserGuid.Value);
        }

        #endregion
    }
}