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
using ECX.CD.Security;
using ECX.CD.BL.ECXLookup;
using System.Transactions;

namespace ECX.CD.UI
{
    public partial class IF_ConfirmLNS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDConfirmLNS))
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Confirm LNS Request";

            Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));

            PopulateItems();
        }

        void PopulateItems()
        {
            if (ddlBank.SelectedIndex > 0)
            {
                rpLNS.DataSource = new BL.LNS().GetLNSForConfirmation(
                    new ECXLookup().GetBank(Common.EnglishGuid, new Guid(ddlBank.SelectedValue)).BankShortName,
                    ddlBank.SelectedItem.Text, SecurityHelper.CurrentUserGuid.Value);
            }
            else
            {
                rpLNS.DataSource = new BE.IF.LNS.ViewLiftNoSaleDataTable();
            }

            rpLNS.DataBind();
        }

        private void Submit()
        {
            List<Guid> selectedIds = SelectedIds();
            List<Guid> unSelectedIds = UnSelectedIds();
            AuditTrail audit = new AuditTrail();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.WRFConfirmLNS, string.Format("ID = {0}; Approved = True", selected));
            }
            foreach (Guid unSelected in unSelectedIds)
            {
                audit.Add(AuditTrailModules.WRFConfirmLNS, string.Format("ID = {0}; Approved = False", unSelected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.LNS().ApproveLNS(SelectedIds(), SecurityHelper.CurrentUserGuid.Value);
                        new BL.LNS().RejectLNS(UnSelectedIds(), SecurityHelper.CurrentUserGuid.Value);

                        audit.Commit();
                        scope.Complete();
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                }
                PopulateItems();
                ((MasterPage_pTop)Page.Master).NotificationText = "Submit successful";
            }
        }

        private void Save()
        {
            List<Guid> ret = new List<Guid>();
            BE.IF.LNS.LNSStateDataTable items = new ECX.CD.BE.IF.LNS.LNSStateDataTable();
            AuditTrail audit = new AuditTrail();

            foreach (RepeaterItem item in rpLNS.Items)
            {
                bool selected = ((CheckBox)item.FindControl("chkSelected")).Checked;
                Guid lnsId = new Guid(((LinkButton)item.FindControl("lbtnDetail")).CommandArgument);


                items.AddLNSStateRow(
                    lnsId,
                    SecurityHelper.CurrentUserGuid.Value,
                    selected,
                    "");

                audit.Add(AuditTrailModules.WRFSaveLNS, string.Format("ID = {0}; Approved = {1}", lnsId, selected.ToString()));
            }

            if (audit.Save())
            {
                try
                {

                    new BL.LNS().SaveLNSState(items);
                    audit.Commit();
                    ((MasterPage_pTop)Page.Master).NotificationText = "Save successful";
                }
                catch
                {
                    audit.RollBack();
                    throw;
                }
            }
        }

        List<Guid> SelectedIds()
        {
            List<Guid> ret = new List<Guid>();

            foreach (RepeaterItem item in rpLNS.Items)
            {
                if (((CheckBox)item.FindControl("chkSelected")).Checked)
                {
                    ret.Add(new Guid(((LinkButton)item.FindControl("lbtnDetail")).CommandArgument));
                }
            }

            return ret;
        }

        List<Guid> UnSelectedIds()
        {
            List<Guid> ret = new List<Guid>();

            foreach (RepeaterItem item in rpLNS.Items)
            {
                if (!((CheckBox)item.FindControl("chkSelected")).Checked)
                {
                    ret.Add(new Guid(((LinkButton)item.FindControl("lbtnDetail")).CommandArgument));
                }
            }

            return ret;
        }

        private void Reevaluate()
        {
            BE.IF.LNS.ViewLiftNoSaleDataTable lNSs =
                new BL.LNS().GetLNSForConfirmation(
                 ddlBank.SelectedItem.Text, SecurityHelper.CurrentUserGuid.Value);

            new BL.LNS().Reevaluate(lNSs, SecurityHelper.CurrentUserGuid.Value);

            PopulateItems();
            ((MasterPage_pTop)Page.Master).NotificationText = "Re-evaluate successful";
        }

        private void Cancel()
        {
            Response.Redirect(UrlFactory.GetUrl(Pages.Inbox));
        }

        #endregion

        #region Event Handlers

        protected void timer_Tick(object sender, EventArgs e)
        {
            //Save();
            PopulateItems();
        }

        protected void lbtnDetail_Command(object sender, CommandEventArgs e)
        {
            BE.IF.LNS.LiftNoSaleRow lns = new BL.LNS().GetLNS(new Guid(e.CommandArgument.ToString()));
            BE.WR.WarehouseRecieptRow row = new BL.WarehouseReciept().GetWR(lns.WHRNO);

            if (row != null)
            {
                ViewManager.ShowWRDetail(Session, Page, row.Id);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnReevaluate_Click(object sender, EventArgs e)
        {
            Reevaluate();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }

        protected void lbtnWRNO_Command(object sender, CommandEventArgs e)
        {

        }

        protected void lbtnGRNNO_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateItems();
        }
        #endregion
    }
}