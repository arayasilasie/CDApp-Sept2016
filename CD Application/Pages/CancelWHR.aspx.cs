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
using System.Collections.Specialized;
using ECX.CD.Lookup;
using ECX.CD.Security;

namespace ECX.CD.UI
{
    public partial class Pages_CancelWHR : System.Web.UI.Page
    {
        BE.WR.ViewWarehouseRecieptDataTable items = new ECX.CD.BE.WR.ViewWarehouseRecieptDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDCancelWHR))
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Cancel Warehouse Receipts";

			PopulateItems();

        }

		private void PopulateItems()
		{
			string[] transactionNos = new ECXWorkFlow.ECXEngine().GetTransactionsByTaskName("CDCancelWHR", "CancelWHR", "2");

			rpWR.DataSource = new BL.WarehouseReciept().GetWHRForWHRCancelApproval();
			rpWR.DataBind();
		}

        private void Cancel()
        {
            new BL.WarehouseReciept().CancelWHR(SelectedIds(), Common.GetUserId(Session, Response));

			PopulateItems();
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
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