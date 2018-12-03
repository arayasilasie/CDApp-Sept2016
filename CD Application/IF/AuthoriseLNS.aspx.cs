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
    public partial class IF_AuthoriseLNS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDAuthoriseLNS))
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Authorise LNS Response";

            Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));

            PopulateItems();
        }

        void PopulateItems()
        {
            if (ddlBank.SelectedIndex != -1)
            {
                rpLNS.DataSource = new BL.LNS().GetLNSForAuthorization(
                    ddlBank.SelectedItem.Text,
                    SecurityHelper.CurrentUserGuid.Value);

                rpLNS.DataBind();
            }
        }

        private void Authorise()
        {
            if (ddlBank.SelectedIndex != -1 && rpLNS.Items.Count > 0)
            {
                BE.IF.LNS.ViewLiftNoSaleDataTable lNSs = new BL.LNS().GetLNSForAuthorization(
                    ddlBank.SelectedItem.Text, SecurityHelper.CurrentUserGuid.Value);

                AuditTrail audit = new AuditTrail();
                foreach (BE.IF.LNS.ViewLiftNoSaleRow row in lNSs.Rows)
                {
                    audit.Add(AuditTrailModules.WRFAuthorizeLNS, string.Format("ID = {0}; WHRNO = {1}; Status = {2}", row.Id, row.WHRNO, row.StatusName));
                }
                string result = string.Empty;
                if (audit.Save())
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        result = new ECX.CD.BL.LNS().AuthoriseLNSesponse(
                                lNSs,
                                ddlBank.SelectedItem.Text,
                                //new ECXLookup().GetBank(Common.EnglishGuid, new Guid(ddlBank.SelectedValue)).BankShortName,
                                authorise.KeyFileBytes,
                                authorise.FileName, authorise.Password, SecurityHelper.CurrentUserGuid.Value);

                        if (result == "OK")
                        {
                            scope.Complete();
                            audit.Commit();
                        }
                        else
                        {
                            audit.RollBack();
                        }
                    }
                }
                if (result == "OK")
                {
                    Master.NotificationText = "Authorize successful";
                    PopulateItems();
                }
                else if (result != "")
                {
                    Master.ErrorText = "Request failed due to " + result + ".";
                }
                else
                {
                    Master.ErrorText = "Request failed due to some internal system error. Please contact IT support.";
                }
            }
        }

        private void Cancel()
        {
            Response.Redirect(UrlFactory.GetUrl(Pages.Inbox));
        }

        private void Reject()
        {
            if (txtRejectionReason.Text != "")
            {
                List<Guid> selectedIds = SelectedIds();
                AuditTrail audit = new AuditTrail();
                foreach (Guid selected in selectedIds)
                {
                    audit.Add(AuditTrailModules.WRFRejectLNS, string.Format("ID = {0}; Reason = {1}", selected, txtRejectionReason.Text));
                }


                if (audit.Save())
                {
                    try
                    {
                        new BL.LNS().RejectLNSAuthorization(SelectedIds(), SecurityHelper.CurrentUserGuid.Value, txtRejectionReason.Text);

                        audit.Commit();
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }

                    Master.NotificationText = "Reject successful";
                    PopulateItems();
                }

            }
            else
            {
                Master.ErrorText = "Please enter Rejection Reason.";
            }
        }

        List<Guid> SelectedIds()
        {
            List<Guid> ret = new List<Guid>();

            foreach (RepeaterItem item in rpLNS.Items)
            {
                ret.Add(new Guid(((LinkButton)item.FindControl("lbtnDetail")).CommandArgument));
            }

            return ret;
        }
        #endregion

        #region Event Handlers

        protected void timer_Tick(object sender, EventArgs e)
        {
            PopulateItems();
        }

        protected void lbtnDetail_Command(object sender, CommandEventArgs e)
        {
            BE.IF.LNS.LiftNoSaleRow lns = new BL.LNS().GetLNS(new Guid(e.CommandArgument.ToString()));
            BE.WR.WarehouseRecieptRow row = new BL.WarehouseReciept().GetWR(lns.WHRNO);

            if (row != null)
            {
                Session.Add("WRId", row.Id.ToString());
                ViewManager.ShowWRDetail(Session, Page);

                //ViewManager.ShowWRDetail(Session, Page, row.Id);
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Reject();
        }

        protected void btnAuthorise_Click(object sender, EventArgs e)
        {
            Authorise();
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