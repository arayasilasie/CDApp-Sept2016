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
using ECX.CD.Lookup;
using System.Collections.Generic;
using ECX.CD.Security;

namespace ECX.CD.UI
{
    public partial class Pages_MembersAllowedToTrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDViewMAT))
            {
                //btnRequestPUNCancel_Click.Visible = false;
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
            ((MasterPage_pTop)Page.Master).DescriptionText = "Members allowed to trade";

            dtTradeDate.MinValue = DateTime.Today.AddDays(-100).ToShortDateString();
            dtTradeDate.MaxValue = DateTime.Today.ToShortDateString();
            //rpMembers.DataSource = new BE.MATT.MembersAllowedToTradeDataTable();
            //rpMembers.DataBind();

            CCommodity[] cs = new ECXLookup().GetAllCommodities(Common.EnglishGuid);
            cs = cs.OrderBy(x => x.Name).ToArray();

            Common.PopulateLookUp(ddlCommodity, new ECXLookup().GetAllCommodities(Common.EnglishGuid));
            if (ddlCommodity.SelectedIndex < 1)
                return;

            CCommodityClass[] items = new ECXLookup().GetAllCommodityClasses(Common.EnglishGuid, new Guid(ddlCommodity.SelectedValue.ToString()));
            Common.PopulateLookUp(ddlCommodityClass, items);
        }

        private void PopulateMembers()
        {
            if (string.IsNullOrEmpty(ddlCommodityClass.Text) || dtTradeDate.Date == "")
            {
                Master.ErrorText = "Select a Commodity Class and Trade Date.";
                return;
            }
            Master.ErrorText = "";

            if (new BL.MAT().MATAvailable(ddlCommodityClass.SelectedItem.Text,
                    Convert.ToDateTime(dtTradeDate.Date),
                    Convert.ToDateTime(dtTradeDate.Date)))
            {
                BE.MATT.MembersAllowedToTradeDataTable mats =  new BL.MAT().SearchMAT(
                    ddlCommodityClass.SelectedItem.Text,
                    Convert.ToDateTime(dtTradeDate.Date),
                    Convert.ToDateTime(dtTradeDate.Date));
                
                mats.DefaultView.Sort = "MemberId";

                dtgMembers.DataSource = mats;

                btnSubmit.Enabled = false;
                dtgMembers.Enabled = false;
            }
            else
            {
                BE.MATT.MembersAllowedToTradeDataTable mats = new BL.MAT().GetMAT(
                    new Guid(ddlCommodity.SelectedValue),
                    new Guid(ddlCommodityClass.SelectedValue));
                //BE.MATT.MembersAllowedToTradeDataTable mats = new BL.MAT().GetMAT(new Guid(ddlCommodityClass.SelectedValue));

                mats.DefaultView.Sort = "MemberId";

                dtgMembers.DataSource = mats;

                btnSubmit.Enabled = true;
                dtgMembers.Enabled = true;
            }

            dtgMembers.DataBind();
        }

        private void Submit()
        {
            new BL.MAT().SaveMAT(GetItems());
            btnSubmit.Enabled = false;
            dtgMembers.Enabled = false;
        }

        private BE.MATT.MembersAllowedToTradeDataTable GetItems()
        {
            BE.MATT.MembersAllowedToTradeDataTable mats = new ECX.CD.BE.MATT.MembersAllowedToTradeDataTable();

            foreach (GridViewRow row in dtgMembers.Rows)
            {
                Label lblMemberGuid = (Label)row.FindControl("lblMemberGuid");
                Label lblMemberId = (Label)row.FindControl("lblMemberId");
                Label lblMemberName = (Label)row.FindControl("lblMemberName");
                Label lblId = (Label)row.FindControl("lblId");
                DropDownList ddlRep = (DropDownList)row.FindControl("ddlRep");
                TextBox txtToken = (TextBox)row.FindControl("txtToken");
                CheckBox chkChecked = (CheckBox)row.FindControl("chkChecked");

                mats.AddMembersAllowedToTradeRow(
                    new Guid(lblId.Text),
                    ddlCommodityClass.SelectedItem.Text,
                    Convert.ToDateTime(dtTradeDate.Date),
                    new Guid(lblMemberGuid.Text),
                    lblMemberId.Text,
                    lblMemberName.Text,
                    ((ddlRep.SelectedItem == null)?"":ddlRep.SelectedItem.Text),
                    txtToken.Text,
                    chkChecked.Checked);
            }
            return mats;
        }

        private void Print()
        {
            System.Web.HttpContext.Current.Session["MATIdList"] = SelectedIds();
            System.Web.HttpContext.Current.Session["CommodityClassName"] = ddlCommodityClass.SelectedItem.Text;
            System.Web.HttpContext.Current.Session["TradeDate"] = Convert.ToDateTime(dtTradeDate.Date).ToString("MMM-dd-yyyy");

            System.Web.HttpContext.Current.Response.Redirect("~/Reports/MATViewer.aspx");
        }

        private List<Guid> SelectedIds()
        {
            List<Guid> ret = new List<Guid>();

            foreach (GridViewRow item in dtgMembers.Rows)
            {
                ret.Add(new Guid(((Label)item.FindControl("lblId")).Text));
            }

            return ret;
        }
        #endregion

        #region Event Handlers

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateMembers();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        protected void ddlCommodity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCommodity.SelectedIndex < 1)
                return;

            CCommodityClass[] items = new ECXLookup().GetAllCommodityClasses(Common.EnglishGuid, new Guid(ddlCommodity.SelectedValue.ToString()));

            Common.PopulateLookUp(ddlCommodityClass, items);
        }

        protected void dtgMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblMemberGuid = (Label)e.Row.FindControl("lblMemberGuid");

                if (lblMemberGuid != null && lblMemberGuid.Text != "")
                {
                    Rep[] reps = new MemberShipLookUp().GetReps(new Guid(lblMemberGuid.Text));
                    DropDownList ddlRep = (DropDownList)e.Row.FindControl("ddlRep");

                    if (ddlRep != null)
                    {
                        ddlRep.Items.Clear();
                        foreach (MembershipLookup.Rep rep in reps)
                            ddlRep.Items.Add(new ListItem(rep.RepName, rep.Guid.ToString()));
                    }
                }
            }
        }
        #endregion
    }
}