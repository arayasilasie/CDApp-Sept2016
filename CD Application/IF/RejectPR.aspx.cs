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

namespace ECX.CD.UI
{
	public partial class IF_RejectPR : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //if (!SecurityHelper.HasPermission(CDSecurityRights.CDRejectPR))
            //{
            //    ErrorHandler.RedirectToErrorPage("You donot have permission to perform this task.");
            //}

			if (!IsPostBack)
			{
				InitializeControls();
			}
		}

		#region Methods

		private void InitializeControls()
		{
			((MasterPage_pTop)Page.Master).DescriptionText = "Reject Pledge Request";

			PopulateItems();
		}

		void PopulateItems()
		{
			//rpPR.DataSource = new BL.Pledge().GetPRForConfirmation(
			//    bankPicker.SelectedBranch, SecurityHelper.CurrentUserGuid.Value);

			rpPR.DataBind();
		}

		private void Reject()
		{
			//new BL.Pledge().RejectPR(SelectedIds());
		}

		private void Cancel()
		{
			Response.Redirect(UrlFactory.GetUrl(Pages.Inbox));
		}

		List<Guid> SelectedIds()
		{
			List<Guid> ret = new List<Guid>();

			foreach (RepeaterItem item in rpPR.Items)
			{
				if (((HtmlInputCheckBox)item.FindControl("chkSelected")).Checked)
				{
					ret.Add(new Guid(((LinkButton)item.FindControl("lbtnWRNO")).CommandArgument));
				}
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
			//rpPR.DataSource = new BL.Pledge().SearchPR();
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
			PopulateItems();
		}

		protected void btnReject_Click(object sender, EventArgs e)
		{
			Reject();
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
		#endregion
	}
}