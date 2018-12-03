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
    public partial class IF_AuthorisePR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDAuthorisePR))
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Authorise Pledge Response";

            Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));

            PopulateItems();
        }

        void PopulateItems()
        {
            if (ddlBank.SelectedIndex != -1)
            {
                rpPR.DataSource = new BL.Pledge().GetPRForAuthorization(
                    ddlBank.SelectedItem.Text,
                    SecurityHelper.CurrentUserGuid.Value);

                rpPR.DataBind();
            }
        }

        private void Authorise()
        {
            if (authorise.IsValid && ddlBank.SelectedIndex != 0)
            {
                BE.IF.Pledge.ViewPledgeDataTable pledges =
                    new BL.Pledge().GetPRForAuthorization(ddlBank.SelectedItem.Text, SecurityHelper.CurrentUserGuid.Value);

                AuditTrail audit = new AuditTrail();
                foreach (BE.IF.Pledge.ViewPledgeRow row in pledges.Rows)
                {
                    audit.Add(AuditTrailModules.WRFAuthorizePR, string.Format("ID = {0}; WHRNO = {1}; Status = {2}", row.Id, row.WHRNO, row.StatusName));
                }
                string result = string.Empty;
                if (audit.Save())
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        result = new BL.Pledge().AuthorisePResponse(pledges,
                            ddlBank.SelectedItem.Text,
                            authorise.KeyFileBytes, authorise.FileName,
                            authorise.Password, SecurityHelper.CurrentUserGuid.Value).ToUpper();

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
                    audit.Add(AuditTrailModules.WRFRejectPR, string.Format("ID = {0}; Reason = {1}", selected, txtRejectionReason.Text));
                }


                if (audit.Save())
                {
                    try
                    {
                        new BL.Pledge().RejectPRAuthorization(SelectedIds(), SecurityHelper.CurrentUserGuid.Value, txtRejectionReason.Text);
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

            foreach (RepeaterItem item in rpPR.Items)
            {
                ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWHRNO")).CommandArgument));
            }

            return ret;
        }
        #endregion

        #region Event Handlers
        protected void lbtnDetail_Command(object sender, CommandEventArgs e)
        {
            BE.IF.Pledge.PledgeRow pledge = new BL.Pledge().GetPledge(new Guid(e.CommandArgument.ToString()));
            BE.WR.WarehouseRecieptRow row;

            if (pledge.WHRNO != 0)
                row = new BL.WarehouseReciept().GetWR(pledge.WHRNO);
            else
                row = new BL.WarehouseReciept().GetWRByGRN(pledge.GRNNO.ToString());

            if (row != null)
                ViewManager.ShowWRDetail(Session, Page, row.Id);
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