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
using Lookup;
using ECX.CD.Security;
using System.Transactions;

namespace ECX.CD.UI
{
	public partial class IF_ConfirmPR : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//string bn = new ECXLookup().GetBankByName("Commercial Bank of Ethiopia", new Guid("9ad72f55-bc00-4382-873e-0c84d6eb3850")).Name;
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDConfirmPR))
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
			((MasterPage_pTop)Page.Master).DescriptionText = "Confirm Pledge Request";
			Common.PopulateLookUp(ddlBank, new ECXLookup().GetAllBanks(Common.EnglishGuid));

			PopulateItems();
		}

		void PopulateItems()
		{
			if (ddlBank.SelectedIndex > 0)
			{
				rpPR.DataSource = new BL.Pledge().GetPRForConfirmation(
					new ECXLookup().GetBank(Common.EnglishGuid, new Guid(ddlBank.SelectedValue)).BankShortName,
					ddlBank.SelectedItem.Text, "", SecurityHelper.CurrentUserGuid.Value);

			}
			else
			{
				rpPR.DataSource = new BE.IF.Pledge.ViewPledgeDataTable();

			}

			rpPR.DataBind();
		}

		private void Submit()
		{
            List<Guid> selectedIds = SelectedIds();
            List<Guid> unSelectedIds = UnSelectedIds();
            AuditTrail audit = new AuditTrail();

            foreach (Guid selected in selectedIds)
            {
                audit.Add(AuditTrailModules.WRFConfirmPR, string.Format("ID = {0}; Approved = True", selected));
            }
            foreach (Guid unSelected in unSelectedIds)
            {
                audit.Add(AuditTrailModules.WRFConfirmPR, string.Format("ID = {0}; Approved = False", unSelected));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        new BL.Pledge().ApprovePR(selectedIds, SecurityHelper.CurrentUserGuid.Value);
                        new BL.Pledge().RejectPR(unSelectedIds, SecurityHelper.CurrentUserGuid.Value);

                        audit.Commit();
                        scope.Complete();
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }
                }
                ((MasterPage_pTop)Page.Master).NotificationText = "Submit successful";
                PopulateItems();
            }
		}

		private void Reevaluate()
		{
			BE.IF.Pledge.ViewPledgeDataTable pledges =
				new BL.Pledge().GetPRForConfirmation(
					ddlBank.SelectedItem.Text, "",
					SecurityHelper.CurrentUserGuid.Value);

			new BL.Pledge().Reevaluate(pledges, SecurityHelper.CurrentUserGuid.Value);

			((MasterPage_pTop)Page.Master).NotificationText = "Re-evaluate successful";
			PopulateItems();
		}

		private void Save()
		{
            List<Guid> ret = new List<Guid>();
            BE.IF.Pledge.PledgeStateDataTable pss = new ECX.CD.BE.IF.Pledge.PledgeStateDataTable();
            AuditTrail audit = new AuditTrail();

            foreach (RepeaterItem item in rpPR.Items)
            {
                bool selected = ((CheckBox)item.FindControl("chkSelected")).Checked;
                Guid prId = new Guid(((LinkButton)item.FindControl("lbtnWHRNO")).CommandArgument);
                pss.AddPledgeStateRow(
                    prId,
                    SecurityHelper.CurrentUserGuid.Value,
                    selected,
                    "");

                audit.Add(AuditTrailModules.WRFSavePR, string.Format("ID = {0}; Approved = {1}", prId, selected.ToString()));
            }

            if (audit.Save())
            {
                try
                {
                    new BL.Pledge().SavePledgeState(pss);
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

			foreach (RepeaterItem item in rpPR.Items)
			{
				if (((CheckBox)item.FindControl("chkSelected")).Checked)
				{
					ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWHRNO")).CommandArgument));
				}
			}

			return ret;
		}

		List<Guid> UnSelectedIds()
		{
			List<Guid> ret = new List<Guid>();

			foreach (RepeaterItem item in rpPR.Items)
			{
				if (!((CheckBox)item.FindControl("chkSelected")).Checked)
				{
					ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWHRNO")).CommandArgument));
				}
			}

			return ret;
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
			BE.IF.Pledge.PledgeRow pledge = new BL.Pledge().GetPledge(new Guid(e.CommandArgument.ToString()));
			BE.WR.WarehouseRecieptRow row;

			if (pledge.WHRNO != 0)
				row = new BL.WarehouseReciept().GetWR(pledge.WHRNO);
			else
				row = new BL.WarehouseReciept().GetWRByGRN(pledge.GRNNO.ToString());

			if (row != null)
			{
				Session.Add("WRId", row.Id.ToString());

				ViewManager.ShowWRDetail(Session, Page);
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