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
    public partial class Pages_PrepareTitleTransfer : System.Web.UI.Page
    {
        BE.TitleTransfer.ViewTradeDataTable items = new ECX.CD.BE.TitleTransfer.ViewTradeDataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                ErrorHandler.RedirectToSessionExpiredPage();
            }
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDPrepareTT))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to access Prepare Title Transefer.");
            }

            if (!IsPostBack)
            {
                //AutorizeUser();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeControls();
        }

        #region Methods

        private void AutorizeUser()
        {
            //Common.CheckUserSession(Session, Response);
        }

        private void InitializeControls()
        {
			((MasterPage_pTop)Page.Master).DescriptionText = "Prepare Title Transfer";

            DateTime[] tradingDates = new BL.TitleTransfer().GetTradingDatesForTitleTransfer();
            foreach (DateTime tradingDate in tradingDates)
                ddlTradingDate.Items.Add(tradingDate.ToShortDateString());

            //PopulateItems();
        }

        void PopulateItems()
        {
            if (ddlTradingDate.Items.Count == 0)
                return;

            AuthorizedMembershipLookup msLookup = new AuthorizedMembershipLookup();
			
            MembershipLookup.MembershipEntities buyMember;
			MembershipLookup.MembershipEntities sellMember;

			items = new ECX.CD.BE.TitleTransfer.ViewTradeDataTable();
            items.Merge(new BL.TitleTransfer().GetTradesForTitleTransfer(Convert.ToDateTime(ddlTradingDate.Text)));

            foreach (BE.TitleTransfer.ViewTradeRow row in items)
            {
                buyMember = msLookup.GetEntityByGuid(row.BuyerClientId);
				if (buyMember != null)
				{
					row.BuyerName = buyMember.OrganizationName + "(" + buyMember.StringIdNo + ")";
					row.BuyerClient = !buyMember.IsMember;
				}

				sellMember = msLookup.GetEntityByGuid(row.SellerClientId);

				if (sellMember != null)
				{
					row.SellerName = sellMember.OrganizationName + "(" + sellMember.StringIdNo + ")";
					row.SellerClient = !sellMember.IsMember;
				}
			}

            rptblTrade.DataSource = items;
            rptblTrade.DataBind();
        }

        private void CommitTitleTransfer()
        {
            string message;

            if (ddlTradingDate.Items.Count == 0)
                return;

            AuditTrail audit = new AuditTrail();

            foreach (RepeaterItem item in rptblTrade.Items)
            {
                audit.Add(AuditTrailModules.CDPrepareTT,
                    string.Format("WHR ID = {0}; Buyer = {1}; Seller = {2}; Quantity = {3}; ",
                    ((Label)item.FindControl("lblWRNO")).Text,
                    ((Label)item.FindControl("lblBuyerName")).Text,
                    ((Label)item.FindControl("lblSellerName")).Text,
                    ((Label)item.FindControl("lblQuantity")).Text
                    ));
            }
            
            //if (audit.Save())
            //{
               // using (TransactionScope scope = new TransactionScope())
               // {
                    try
                    {
                        if (new BL.TitleTransfer().CommitTitleTransfer(
                            Convert.ToDateTime(ddlTradingDate.Text),
                            Common.GetUserId(Session, Response),
                            out message))
                        {
                           // audit.Commit();
                           // scope.Complete();
                        }
                        else
                        {
                            ((MasterPage_pTop)Page.Master).ErrorText = "Titles transfere was not successful ! Please try again.";
                        }
                    }
                    catch ( Exception ex )
                    {
                        audit.RollBack();
                        string x = ex.Message;
                        throw ex ;
                    }
                    ((MasterPage_pTop)Page.Master).NotificationText = "Titles transfered successfully!";
                    PopulateItems();
               // }
            //}
            //else
            //{
            //    ((MasterPage_pTop)Page.Master).ErrorText = "Titles transfere was not successful ! Please try again.";
            //}
        }

        private void RejectTitleTransfer()
        {
            string message;
            if (ddlTradingDate.Items.Count == 0)
                return;

            AuditTrail audit = new AuditTrail();

            foreach (RepeaterItem item in rptblTrade.Items)
            {
                audit.Add(AuditTrailModules.CDRejectPrepareTT,
                    string.Format("WRN ID = {0}; Buyer = {1}; Seller = {2}; Quantity = {3}; ",
                    ((Label)item.FindControl("lblWRNO")).Text,
                    ((Label)item.FindControl("lblBuyerName")).Text,
                    ((Label)item.FindControl("lblSellerName")).Text,
                    ((Label)item.FindControl("lblQuantity")).Text
                    ));
            }

            if (audit.Save())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        if (new BL.TitleTransfer().RejectTitleTransfer(
                            Convert.ToDateTime(ddlTradingDate.Text),
                            Common.GetUserId(Session, Response),
                            out message))
                        {
                            audit.Commit();
                            scope.Complete();
                        }
                    }
                    catch
                    {
                        audit.RollBack();
                        throw;
                    }

                    ((MasterPage_pTop)Page.Master).NotificationText = "Rejection successfull";
                    PopulateItems();
                }
            }
        }

        #endregion

        #region Event Handlers
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CommitTitleTransfer();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            RejectTitleTransfer();
        }

        #endregion
    }
}