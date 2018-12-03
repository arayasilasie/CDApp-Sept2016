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
using AjaxControlToolkit;
using Lookup;
using System.Collections.Generic;
using System.Collections.Specialized;
using ECX.CD.Security;
using ECX.CD.Lookup;
using ECXControlsCollection;
namespace ECX.CD.UI
{
    public partial class BankAccountUI : System.Web.UI.Page
    {
        bool AllMandatoryAccountsCreated = false;
        BankAccountStatus NewBankAccountStatus = BankAccountStatus.New;
        BankAccountCreationStatus AccountCreationStatus = BankAccountCreationStatus.NothingCreated;
        List<Guid> FinilizedMembersList
        {
            get
            {
                if (Session["MembersListWithAllAccountsCreated"] == null)
                {
                    return new List<Guid>();
                }
                else
                {
                    return (List<Guid>)Session["MembersListWithAllAccountsCreated"];
                }
            }
            set
            {
                Session["MembersListWithAllAccountsCreated"] = value;
            }
        }
        void AddFinilizedMember(Guid memberId)
        {
            List<Guid> li = FinilizedMembersList;
            li.Add(memberId);
            FinilizedMembersList = li;
        }
        bool IsMemberFinilized(Guid memberId)
        {
            return FinilizedMembersList.Contains(memberId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDNewAccount))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to add new bank accounts.");
            }

            NewBankAccountStatus = BankAccountStatus.New;
            AccountCreationStatus = GetAccountCreationStatus();

            if (!Page.IsPostBack)
            {
                this.Master.DescriptionText = "";//Bank account manager
                this.Master.NotificationText = "Select a member and process the bank account.";

                Session["SelectedMemberGuid"] = Guid.Empty;

                //List<MembershipLookup.Member> members = new List<MembershipLookup.Member>();
               
                //ECX.CD.Lookup.AuthorizedMembershipLookup loo = ;
                 //List<MembershipLookup.Member> lm= new AuthorizedMembershipLookup().GetMembersByTransactionNo(new string[] { });
                //gvBankAccount.DataSource = new List<tblBankAccount>();
                //gvBankAccount.DataBind();
            }
            else
            {
                //dsBankAccount.ContextTypeName = "MainDataContextDataContext";
                //dsBankAccount.TableName = "tblBankAccount";
                //dsBankAccount.SelectParameters.Add("MemberId", DbType.Guid, Session["SelectedMemberGuid"].ToString());

                gvBankAccount.DataBind();

                //gvBankAccount.DataSource = BankAccount.GetBankAccounts();
                Master.ErrorText = string.Empty;
            }
        }
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }
        #region Events handlers
        protected override void OnPreRender(EventArgs e)
        {
            if (Session["SelectedMemberGuid"] == null || gvMembers.SelectedIndex == -1)
            {
                Session["SelectedMemberGuid"] = Guid.Empty;
            }
            AccountCreationStatus = BankAccountCreationStatus.NothingCreated;
            AccountCreationStatus = GetAccountCreationStatus();
            SetButtonsVisibility();
            base.OnPreRender(e);
        }
        protected void ddlAccountType_DataBinding(object sender, EventArgs e)
        {
            if (gvMembers.SelectedIndex > -1 && gvMembers.SelectedDataKey != null)
            {
                string memberClass = gvMembers.SelectedDataKey["MemberClassID"].ToString();
                Common.FillBankAccountType((DropDownList)sender, int.Parse(memberClass), true);
            }
        }
        protected void txtDocumentReceivedTimestamp_Load(object sender, EventArgs e)
        {
            CalendarDateTimeOnly ctl = sender as CalendarDateTimeOnly;
            if (ctl != null)
            {
                ctl.Date = DateTime.Now;
            }
        }
        protected void ddlAccountStatus_DataBinding(object sender, EventArgs e)
        {
            BankAccount.FillStatus((DropDownList)sender);
        }

        protected void gvMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            fvBankAccount.ChangeMode(FormViewMode.Insert);
            if (gvMembers.Rows.Count > 0 && gvMembers.SelectedValue != null)
            {
                Session["SelectedMemberGuid"] = gvMembers.SelectedValue;
                //Biruk.Abel newly added code to get member class 
                Session["MemberClass"] = gvMembers.SelectedDataKey["MemberClassID"].ToString();
                int mc = Convert.ToInt32(gvMembers.SelectedDataKey["MemberClassID"]);
                //end of newly added code
            }
            else
            {
                Session["SelectedMemberGuid"] = Guid.Empty;
            }

            AccountCreationStatus = GetAccountCreationStatus();
        }
        protected void gvMembers_DataBound(object sender, EventArgs e)
        {
            if (gvMembers.SelectedValue == null)
            {
                Session["SelectedMemberGuid"] = Guid.Empty;
                btnNewBankAccount.Enabled = false;
            }
            else if (gvMembers.Rows.Count == 0)            
            {
                Session["SelectedMemberGuid"] = gvMembers.SelectedValue;
                btnNewBankAccount.Enabled = true;
            }
            //gvBankAccount.DataBind();
        }

        protected void fvBankAccount_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            e.Values.Add("ID", Guid.NewGuid());
            e.Values.Add("Balance", 0);
            e.Values.Add("BalanceUpdatedDate", DateTime.Now);
            e.Values.Add("MemberID", (Guid)gvMembers.SelectedValue);
            e.Values.Add("CreatedBy", SecurityHelper.CurrentUserGuid);
            e.Values.Add("CreatedDate", DateTime.Now);

            if (e.Values["AccountTypeID"] == null)
            {
                Master.ErrorText = "Please select account type.";//Check if bank account type is properly set.
                e.Cancel = true;
                return;
            }
            if (e.Values["Status"] == null)
            {
                Master.ErrorText = "selected status not valid.";//Check if bank account status is properly set.
                e.Cancel = true;
                return;
            }
            if (e.Values["BankBranchID"] == null || !Common.IsGuid(e.Values["BankBranchID"].ToString()))
            {
                Master.ErrorText = "Bank Branch not selected.";//Check if bank account Bank Branch ID is properly set.
                e.Cancel = true;
                return;
            }

            Guid accountId = Guid.Empty;
            Guid memberId = new Guid(gvMembers.SelectedValue.ToString());
            Guid accountTypeId = new Guid(e.Values["AccountTypeID"].ToString());
            Guid bankBranchId = new Guid(e.Values["BankBranchID"].ToString());

            //this line is added to remove any leading and trailing white spaces from account number
            e.Values["AccountNumber"] = e.Values["AccountNumber"].ToString().Trim();

            string accountNumber = e.Values["AccountNumber"].ToString();
            string error = string.Empty;

            if (!BankAccount.IsAccountValid(accountId, memberId, bankBranchId, accountTypeId, accountNumber, out error))
            {
                Master.ErrorText = error;
                e.Cancel = true;
                btnNewBankAccount_ModalPopupExtender.Show();
                return;
            }

            Guid bankAccountType = new Guid(e.Values["AccountTypeID"].ToString());
            int bankAccountStatus = 0;
            if (!int.TryParse(e.Values["Status"].ToString(), out bankAccountStatus))
            {
                Master.ErrorText = "Account not inserted.";//Check if bank account status is properly set.
                e.Cancel = true;
                return;
            }


            if (AreMandatoryAccountsCreated(bankAccountType, (BankAccountStatus)bankAccountStatus))
            {
                AllMandatoryAccountsCreated = true;
            }
            else
            {
                AllMandatoryAccountsCreated = false;
            }
        }
        protected void fvBankAccount_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Guid selectedMemberGuid = new Guid(e.Values["MemberID"].ToString());
            if (AllMandatoryAccountsCreated)
            {
                new AuthorizedMembershipLookup().NotifyAccountCreated(selectedMemberGuid, Guid.Empty.ToString(), Guid.Empty);
                gvMembers.DataBind();
                Master.NotificationText = "Account creation is complete for the current member.";
            }            
        }
        protected void fvBankAccount_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            e.NewValues["BankBranchID"] = new Guid(e.NewValues["BankBranchID"].ToString().Substring(0, 36));
            e.NewValues.Add("UpdatedBy", SecurityHelper.CurrentUserGuid);
            e.NewValues.Add("UpdatedDate", DateTime.Now);

            Guid accountId = new Guid(gvBankAccount.SelectedValue.ToString());
            Guid memberId = new Guid(gvMembers.SelectedValue.ToString());
            Guid accountTypeId = new Guid(e.NewValues["AccountTypeID"].ToString());
            Guid bankBranchId = new Guid(e.NewValues["BankBranchID"].ToString());

            //this line is added to remove any leading and trailing white spaces from account number
            e.NewValues["AccountNumber"] = e.NewValues["AccountNumber"].ToString().Trim();

            string accountNumber = e.NewValues["AccountNumber"].ToString();
            string error = string.Empty;

            if (!BankAccount.IsAccountValid(accountId, memberId, bankBranchId, accountTypeId, accountNumber, out error))
            {
                Master.ErrorText = error;
                btnNewBankAccount_ModalPopupExtender.Show();
                e.Cancel = true;
                return;
            }

            //Account status changing is handled here
            //if the buttons for account status changing are clicked, 
            //      the following code changes the new BankAccountStatus.
            if (NewBankAccountStatus != BankAccountStatus.New)
            {
                e.NewValues["Status"] = (byte)NewBankAccountStatus;
            }

            //Guid bankAccountType = new Guid(e.NewValues["AccountTypeID"].ToString());

            //if (AreMandatoryAccountsCreated(bankAccountType, NewBankAccountStatus))
            //{
            //    AllMandatoryAccountsCreated = true;
            //}
            //else
            //{
            //    AllMandatoryAccountsCreated = false;
            //}
        }
        protected void fvBankAccount_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            gvBankAccount.DataBind();
            fvBankAccount.ChangeMode(FormViewMode.Insert);
        }

        protected void fvBankAccount_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                fvBankAccount.ChangeMode(FormViewMode.Insert);
            }
        }

        protected void gvBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvBankAccount.SelectedIndex > -1)
            {
                fvBankAccount.PageIndex = gvBankAccount.SelectedIndex;
                fvBankAccount.ChangeMode(FormViewMode.Edit);
                btnNewBankAccount_ModalPopupExtender.Show();

            }
        }
        protected void btnNewBankAccount_Click(object sender, EventArgs e)
        {
            if (SecurityHelper.HasPermission(CDSecurityRights.CDNewAccount))
            {
                fvBankAccount.ChangeMode(FormViewMode.Insert);
                fvBankAccount.DataBind();
                btnNewBankAccount_ModalPopupExtender.Show();
            }
            else
            {
                Master.ErrorText = "You donot have permission to add new account.";
            }
        }

        protected void btnSearchMembers_Click(object sender, EventArgs e)
        {
            //if (txtMemberID.Text.Trim().Length == 0)
            //{
            dsMembers.SelectMethod = "GetAccountCreationList";
            dsMembers.SelectParameters.Clear();
            //}
            //else
            //{
            //    dsMembers.SelectMethod = "GetMemberByIdNo";
            //    dsMembers.SelectParameters.Clear();
            //    dsMembers.SelectParameters.Add("IdNo", TypeCode.String, txtMemberID.Text.Trim());
            //}

            gvMembers.DataBind();

            //gvBankAccount.DataBind();
        }
        protected void lkbOpenAccount_Click(object sender, EventArgs e)
        {
            NewBankAccountStatus = BankAccountStatus.Open;
        }
        protected void lkbCloseAccount_Click(object sender, EventArgs e)
        {
            NewBankAccountStatus = BankAccountStatus.Closed;
        }
        protected void lkbSuspendAccount_Click(object sender, EventArgs e)
        {
            NewBankAccountStatus = BankAccountStatus.Suspended;
        }

        protected void AccountStatusChangeButtons_Load(object sender, EventArgs e)
        {
            LinkButton lkb = sender as LinkButton;
            if (lkb == null)
            {
                return;
            }

            string buttonType = lkb.CommandArgument;
            //if (PageMode == "New")
            //{
            if (buttonType == "Insert")
            {
                lkb.Enabled = SecurityHelper.HasPermission(CDSecurityRights.CDNewAccount);
            }
            else if (buttonType == "Update")
            {
                lkb.Enabled = SecurityHelper.HasPermission(CDSecurityRights.CDModifyAccount);
            }
            if (buttonType == "Open")
            {
                lkb.Enabled = SecurityHelper.HasPermission(CDSecurityRights.CDOpenAccount);
            }
            //}
        }
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            if (gvMembers.SelectedIndex > -1)
            {
                Guid? memberGuid = gvMembers.SelectedValue as Guid?;

                if (memberGuid.HasValue && memberGuid != Guid.Empty)
                {
                    using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
                    {
                        if (AccountCreationStatus == BankAccountCreationStatus.AllRequiredApproved || AccountCreationStatus == BankAccountCreationStatus.AllRequiredCreated || AccountCreationStatus == BankAccountCreationStatus.NothingRequired)
                        {
                            if (BankAccount.WorkFlowStepCompleted(memberGuid.Value))
                            {
                                AddFinilizedMember(memberGuid.Value);
                                Master.NotificationText = "Account creation is complete for the current member.";
                            }
                            else
                            {
                                Master.ErrorText = "Operation failed.";
                                return;
                            }
                        }
                        //Biruk.Abel newly added code for NMDT
                        else 
                        {
                            if (Session["MemberClass"] != null && Convert.ToInt32(Session["MemberClass"]) == 2)
                            {//Selected Member is Tradeing Member
                                BankAccountCreationStatus accCreationStatus = GetAccountCreationStatus();
                                if (accCreationStatus == BankAccountCreationStatus.PartiallyCreated)
                                {
                                    if (BankAccount.WorkFlowStepCompleted(memberGuid.Value))
                                    {
                                        AddFinilizedMember(memberGuid.Value);
                                        Master.NotificationText = "Account creation is complete for the current member.";
                                    }
                                    else
                                    {
                                        Master.ErrorText = "Operation failed.";
                                        return;
                                    }
                                }
                            }
                        }
                        //end of newly added code
                        scope.Complete();
                        scope.Dispose();
                    }
                }
            }
            else
            {
                Master.ErrorText = "Please select a member first.";
            }
        }
        #endregion Events handlers

        #region Methods
        protected bool AreMandatoryAccountsCreated(Guid exceptionalAccount, BankAccountStatus newBankAccountStatus)
        {
            Guid member = new Guid(gvMembers.SelectedValue.ToString());
            if (gvMembers.SelectedDataKey.Values["MemberClassID"] == null)
            {
                Master.ErrorText = "Check if member class is properly set.";
                return false;
            }
            int memberClassID = 0;
            if (!int.TryParse(gvMembers.SelectedDataKey.Values["MemberClassID"].ToString(), out memberClassID))
            {
                Master.ErrorText = "Check if member class is properly set.";
                return false;
            }

            List<string> accountsTobeCreated = new List<string>();
            List<Guid> accountsTobeCreatedGuid = new List<Guid>();
            if (!BankAccount.IsAccountCreationComplete(member, memberClassID, out accountsTobeCreated, out accountsTobeCreatedGuid))
            {
                //if more than 1 accounts are left account creation cannot be completed at this step.
                //because one account can be created at once.
                if (accountsTobeCreated.Count > 1)
                {
                    return false;
                }
                else if (accountsTobeCreated.Count == 1)
                {
                    if (accountsTobeCreatedGuid[0] == exceptionalAccount && newBankAccountStatus == BankAccountStatus.Open)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        protected bool AreMandatoryAccountsCreated()
        {
            Guid member = new Guid(gvMembers.SelectedValue.ToString());
            if (gvMembers.SelectedDataKey.Values["MemberClassID"] == null)
            {
                Master.ErrorText = "Check if member class is properly set.";
                return false;
            }
            int memberClassID = 0;
            if (!int.TryParse(gvMembers.SelectedDataKey.Values["MemberClassID"].ToString(), out memberClassID))
            {
                Master.ErrorText = "Check if member class is properly set.";
                return false;
            }

            List<string> accountsTobeCreated = new List<string>();
            List<Guid> accountsTobeCreatedGuid = new List<Guid>();
            if (BankAccount.IsAccountCreationComplete(member, memberClassID, out accountsTobeCreated, out accountsTobeCreatedGuid))
            {
                return true;
            }
            return false;
        }

        protected BankAccountCreationStatus GetAccountCreationStatus()
        {
            if (gvMembers.SelectedIndex > -1)
            {
                Guid? memberGuid = Guid.Empty;
                if (gvMembers.SelectedValue != null && Common.IsGuid(gvMembers.SelectedValue.ToString()))
                {
                    memberGuid = new Guid(gvMembers.SelectedValue.ToString());
                }

                if (memberGuid != Guid.Empty)
                {
                    int memberClassID = int.Parse(gvMembers.SelectedDataKey["MemberClassID"].ToString());

                    return BankAccount.GetBankAccountCreationStatus(memberGuid.Value, memberClassID);
                }
                else
                {
                    return BankAccountCreationStatus.NothingCreated;
                }
            }
            else
            {
                return BankAccountCreationStatus.NothingCreated;
            }
        }
        protected void SetButtonsVisibility()
        {
            Guid? memberGuid = gvMembers.SelectedValue as Guid?;

            if (memberGuid.HasValue && memberGuid != Guid.Empty)
            {
                if (IsMemberFinilized(memberGuid.Value))
                {//selected member is not TM
                    btnFinish.Enabled = false;
                    btnNewBankAccount.Enabled = false;
                    return;
                }
            }

            btnNewBankAccount.Enabled = true;
            switch (AccountCreationStatus)
            {
                case BankAccountCreationStatus.NothingRequired:
                    btnNewBankAccount.Enabled = false;
                    btnFinish.Enabled = true;
                    break;
                case BankAccountCreationStatus.NothingCreated:
                    btnFinish.Enabled = false;
                    break;
                case BankAccountCreationStatus.PartiallyCreated:
                    btnFinish.Enabled = false;
                    break;
                case BankAccountCreationStatus.AllRequiredCreated:
                    btnFinish.Enabled = true;
                    break;
                case BankAccountCreationStatus.PartiallyApproved:
                    btnFinish.Enabled = false;
                    break;
                case BankAccountCreationStatus.AllRequiredApproved:
                    btnFinish.Enabled = true;
                    break;
                default:
                    break;
            }
            //Biruk.Abel newly added code for NMDT
            if (Session["MemberClass"] != null && Convert.ToInt32(Session["MemberClass"]) == 2)
            {//Selected Member is Tradeing Member
                BankAccountCreationStatus accCreationStatus = GetAccountCreationStatus();
                if (accCreationStatus == BankAccountCreationStatus.PartiallyCreated)
                {
                    btnFinish.Enabled = true;
                }
            }
            //end of newly added code.
        }

        
        #endregion Methods

        #region Web service Page Methods
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static CascadingDropDownNameValue[] GetBanks(string knownCategoryValues, string category)
        {
            ECXLookup lookup = new ECXLookup();
            CBank[] banks = new CBank[] { };
            banks = lookup.GetActiveBanks(Common.EnglishGuid);

            List<CascadingDropDownNameValue> items = new List<CascadingDropDownNameValue>();
            if (banks.Length > 0)
            {
                foreach (CBank bank in banks)
                {
                    items.Add(new CascadingDropDownNameValue(bank.Name, bank.UniqueIdentifier.ToString()));
                }
            }

            lookup.Dispose();
            return items.ToArray();
        }
        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static AjaxControlToolkit.CascadingDropDownNameValue[] GetBankBranches(string knownCategoryValues, string category)
        {
            StringDictionary kv = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            if (!kv.ContainsKey("bank"))
            {
                return default(CascadingDropDownNameValue[]);
            }

            string bankID = kv["bank"];
            if (bankID.Length != 36)
            {
                return default(CascadingDropDownNameValue[]);
            }
            PropertyCollection p = new PropertyCollection();

            ECXLookup lookup = new ECXLookup();
            CBankBranch[] branches = new CBankBranch[] { };
            branches = lookup.GetActiveBankBranches(Common.EnglishGuid, new Guid(bankID));

            List<CascadingDropDownNameValue> items = new List<CascadingDropDownNameValue>();
            if (branches.Length > 0)
            {
                foreach (CBankBranch branch in branches)
                {
                    items.Add(new CascadingDropDownNameValue(branch.Name, branch.UniqueIdentifier.ToString()));
                }
            }
            lookup.Dispose();
            return items.ToArray();
        }
        #endregion Web service Page Methods
    }
}