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
    public partial class ActivateNewBankAccount : System.Web.UI.Page
    {
        BankAccountStatus NewBankAccountStatus = BankAccountStatus.New;
        BankAccountCreationStatus AccountCreationStatus = BankAccountCreationStatus.NothingCreated;

        List<Guid> FinilizedMembersList
        {
            get
            {
                if (Session["MembersListWithActivatedAccount"] == null)
                {
                    return new List<Guid>();
                }
                else
                {
                    return (List<Guid>)Session["MembersListWithActivatedAccount"];
                }
            }
            set
            {
                Session["MembersListWithActivatedAccount"] = value;
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
        public Guid SelectedMember
        {
            get
            {
                object obj = Session["SelectedMemberGuid"];
                if (obj == null)
                {
                    return Guid.Empty;
                }
                else if (!Common.IsGuid(obj.ToString()))
                {
                    return Guid.Empty;
                }
                else
                {
                    return new Guid(obj.ToString());
                }
            }
            set { Session["SelectedMemberGuid"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SecurityHelper.HasPermission(CDSecurityRights.CDOpenAccount))
            {
                ErrorHandler.RedirectToErrorPage("You donot have permission to activate bank accounts.");
            }

            NewBankAccountStatus = BankAccountStatus.New;
            AccountCreationStatus = GetAccountCreationStatus();

            if (!Page.IsPostBack)
            {
                Master.DescriptionText = "";//Bank account manager
                Master.NotificationText = "Select a member and activate the bank accounts.";

                SelectedMember = Guid.Empty;
                gvBankAccount.DataBind();
            }
            else
            {
                Master.ErrorText = string.Empty;
            }

        }

        #region Events handlers
        protected override void OnPreRender(EventArgs e)
        {
            if (gvMembers.SelectedIndex == -1)
            {
                SelectedMember = Guid.Empty;
            }
            AccountCreationStatus = BankAccountCreationStatus.NothingCreated;
            AccountCreationStatus = GetAccountCreationStatus();
            SetFinishButtonVisibility();
            base.OnPreRender(e);
        }
        protected void ddlAccountType_DataBinding(object sender, EventArgs e)
        {
            if (gvMembers.SelectedIndex > -1 && gvMembers.SelectedDataKey != null)
            {
                int i = gvBankAccount.SelectedIndex;
                if (gvBankAccount.SelectedIndex > -1)
                {
                    string id = gvBankAccount.SelectedDataKey["ID"].ToString();
                }
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
        protected void ddlMethod_DataBinding(object sender, EventArgs e)
        {
            //Common.FillMethod((DropDownList)sender, true);
        }
        protected void gvMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fvBankAccount.ChangeMode(FormViewMode.Insert);
            if (gvMembers.Rows.Count > 0 && gvMembers.SelectedValue != null)
            {
                SelectedMember = new Guid(gvMembers.SelectedValue.ToString());
                //Biruk.Abel newly added code to get member class 
                Session["MemberClass"] = gvMembers.SelectedDataKey["MemberClassID"].ToString();
                int mc = Convert.ToInt32(gvMembers.SelectedDataKey["MemberClassID"]);
                //end of newly added code
            }
            else
            {
                SelectedMember = Guid.Empty;
            }

            AccountCreationStatus = GetAccountCreationStatus();
        }
        protected void gvMembers_DataBound(object sender, EventArgs e)
        {
            if (gvMembers.SelectedValue == null)
            {
                SelectedMember = Guid.Empty;
            }
            else
            {
                SelectedMember = new Guid(gvMembers.SelectedValue.ToString());
            }
            gvBankAccount.DataBind();
        }

        //Biruk.Abel Newly added code
        protected void fvBankAccount_DataBinding(object sender, EventArgs e)
        {
            //if (gvBankAccount.SelectedIndex >= 0)
            //{
            //    DropDownList ddlS = (DropDownList)fvBankAccount.FindControl("ddlStatus");
            //    Guid accountId = new Guid(gvBankAccount.SelectedValue.ToString());
            //    tblBankAccount tba = BankAccount.GetBankAccountDetail(accountId);
            //    if (ddlS.Items.Count > 0)
            //        ddlS.SelectedValue = tba.Status.ToString();

            //    DropDownList ddlAt = (DropDownList)fvBankAccount.FindControl("ddlAccountType");
            //    if (ddlAt.Items.Count > 0)
            //        ddlAt.SelectedValue = tba.AccountTypeID.ToString();

            //    TextBox AccountNumberTextBox = (TextBox)fvBankAccount.FindControl("AccountNumberTextBox");
            //    if (AccountNumberTextBox.Text.Equals(""))
            //        AccountNumberTextBox.Text = tba.AccountNumber;


            //}
        }

        protected void fvBankAccount_DataBound(object sender, EventArgs e)
        {
            //if (gvBankAccount.SelectedIndex >= 0)
            //{
            //    DropDownList ddlS = (DropDownList)fvBankAccount.FindControl("ddlStatus");
            //    Guid accountId = new Guid(gvBankAccount.SelectedValue.ToString());
            //    tblBankAccount tba = BankAccount.GetBankAccountDetail(accountId);
            //    if (ddlS.Items.Count > 0)
            //        ddlS.SelectedValue = tba.Status.ToString();

            //    DropDownList ddlAt = (DropDownList)fvBankAccount.FindControl("ddlAccountType");
            //    if (ddlAt.Items.Count > 0)
            //        ddlAt.SelectedValue = tba.AccountTypeID.ToString();

            //    TextBox AccountNumberTextBox = (TextBox)fvBankAccount.FindControl("AccountNumberTextBox");
            //    if (!AccountNumberTextBox.Text.Equals(""))
            //        AccountNumberTextBox.Text = tba.AccountNumber;
            //}
        }
        //end of newly added code

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
                e.Cancel = true;
                return;
            }

            //Account status changing is handled here
            //if the buttons for account status changing are clicked, 
            //      the following code changes the new BankAccountStatus.
            if (NewBankAccountStatus != BankAccountStatus.New)
            {
                e.NewValues["Status"] = (byte)NewBankAccountStatus;
                try
                {
                    BankAccount.SendBankAccountCreationNotice(accountId, memberId, bankBranchId, accountTypeId, accountNumber, SecurityHelper.CurrentUserGuid.Value);
                }
                catch (Exception ex)
                {
                    ErrorHandler.WriteLogEntry(ex);
                }
                finally
                {
                    BankAccount.SendBankAccountStatus(accountId, (byte)NewBankAccountStatus, SecurityHelper.CurrentUserGuid.Value);
                }
            }
        }
        protected void fvBankAccount_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            Guid selectedMemberGuid = new Guid(gvMembers.SelectedValue.ToString());
            if (AccountCreationStatus != BankAccountCreationStatus.AllRequiredCreated)//AllMandatoryAccountsCreated
            {
                string memberStatus = gvMembers.SelectedRow.Cells[6].Text;
                if (memberStatus != "AuthorityApproved")
                {
                    dsMembers.SelectParameters.Clear();
                    gvMembers.DataBind();
                }
            }
            gvBankAccount.DataBind();
        }

        protected void fvBankAccount_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                //fvBankAccount.ChangeMode(FormViewMode.Insert);
            }
        }

        protected void gvBankAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvBankAccount.SelectedIndex > -1)
            {
                /*fvBankAccount.PageIndex = gvBankAccount.SelectedIndex;
                fvBankAccount.ChangeMode(FormViewMode.Edit);
                btnNewBankAccount_ModalPopupExtender.Show();*/

                //Biruk.Abel Newly added code
                tblAccountDetail.Visible = true;
                Guid accountId = new Guid(gvBankAccount.SelectedValue.ToString());
                tblBankAccount tba = BankAccount.GetBankAccountDetail(accountId);
                Guid bankGuid = Common.GetBankGuidByBranchGuid(tba.BankBranchID);
                Dictionary<Guid, string> dicBanks = GetAllBanks();
                Dictionary<Guid, string> dicBankBranchs = GetBankBranchs(bankGuid);
                ddAllBank.DataSource = dicBanks;
                ddlAccountBankBranch.DataSource = dicBankBranchs;
                ddAllBank.DataTextField = "Value";
                ddAllBank.DataValueField= "Key";
                ddAllBank.DataBind();
                ddAllBank.SelectedValue = bankGuid.ToString();

                ddlAccountBankBranch.DataTextField = "Value";
                ddlAccountBankBranch.DataValueField = "Key";
                ddlAccountBankBranch.DataBind();
                ddlAccountBankBranch.SelectedValue = tba.BankBranchID.ToString();
                
                ddlAccountStatus.DataSource = Common.GetBankAccountStatus();
                ddlAccountStatus.DataTextField = "Value";
                ddlAccountStatus.DataValueField = "Key";
                ddlAccountStatus.DataBind();
                ddlAccountStatus.SelectedValue = tba.Status.ToString();

                if (gvMembers.SelectedIndex > -1)
                {
                    string memberClass = gvMembers.SelectedDataKey["MemberClassID"].ToString();
                    Common.FillBankAccountType(ddlAccountAccountType, int.Parse(memberClass), true);
                    ddlAccountAccountType.DataBind();

                    ddlAccountAccountType.SelectedValue = tba.AccountTypeID.ToString();
                }
                
                txtAccountNumber.Text = tba.AccountNumber;
                accTimeStamp.Date = tba.DocumentPresentedTimeStamp;
                
                //end of newly added code
            }
        }

        //Biruk.Abel newly added code

        protected void btnSaveacc_OnClick(object sender, EventArgs e)
        {
            string error = ""; ;
            if (!BankAccount.IsAccountValid(new Guid(gvBankAccount.SelectedValue.ToString()),new Guid(gvMembers.SelectedValue.ToString()),new Guid(ddlAccountBankBranch.SelectedValue),new Guid(ddlAccountAccountType.SelectedValue),txtAccountNumber.Text, out error))
            {
                Master.ErrorText = error;
                return;
            }
            BankAccount.UpdateBankAccount(new Guid(ddlAccountBankBranch.SelectedValue), new Guid(ddlAccountAccountType.SelectedValue), txtAccountNumber.Text, Convert.ToByte(ddlAccountStatus.SelectedValue), accTimeStamp.Date, new Guid(gvBankAccount.SelectedValue.ToString()));
            gvBankAccount.DataBind();
            Master.NotificationText = "bank account update was successful.";
            tblAccountDetail.Visible = false;
        }

        protected void btnCancelacc_OnClick(object sender, EventArgs e)
        {
            tblAccountDetail.Visible = false;
        }

        protected void btnOpenacc_OnClick(object sender, EventArgs e)
        {
            Guid accountId = new Guid(gvBankAccount.SelectedValue.ToString());
            tblBankAccount tba = BankAccount.GetBankAccountDetail(accountId);

            try
            {
                BankAccount.SendBankAccountCreationNotice(accountId, tba.MemberID, tba.BankBranchID, tba.AccountTypeID, txtAccountNumber.Text, SecurityHelper.CurrentUserGuid.Value);
                BankAccount.UpdateBankAccount(new Guid(ddlAccountBankBranch.SelectedValue), new Guid(ddlAccountAccountType.SelectedValue), txtAccountNumber.Text, Convert.ToByte(1), accTimeStamp.Date, new Guid(gvBankAccount.SelectedValue.ToString()));
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteLogEntry(ex);
            }
            finally
            {
                BankAccount.SendBankAccountStatus(accountId, (byte)1, SecurityHelper.CurrentUserGuid.Value);
            }           
            
            Master.NotificationText = "bank account opening was successful.";

            gvBankAccount.DataBind();
            tblAccountDetail.Visible = false;
        }

        private Dictionary<Guid, string> GetAllBanks()
        {
            ECXLookup lookup = new ECXLookup();
            CBank[] banks = new CBank[] { };
            banks = lookup.GetActiveBanks(Common.EnglishGuid);
            Dictionary<Guid, string> allBanks = new Dictionary<Guid, string>();
            if (banks.Length > 0)
            {
                foreach (CBank bank in banks)
                {
                    allBanks.Add(bank.UniqueIdentifier, bank.Name);
                }
            }
            return allBanks;
        }

        private Dictionary<Guid,string> GetBankBranchs(Guid bankID)
        {
            ECXLookup lookup = new ECXLookup();
            CBankBranch[] branches = new CBankBranch[] { };
            branches = lookup.GetActiveBankBranches(Common.EnglishGuid, bankID);
            Dictionary<Guid, string> allBankbranchs = new Dictionary<Guid, string>();
           
            if (branches.Length > 0)
            {
                foreach (CBankBranch branch in branches)
                {
                    allBankbranchs.Add(branch.UniqueIdentifier, branch.Name);
                }
            }
            return allBankbranchs;
        }

       //end of newly added code

        protected void lkbOpenAccount_Click(object sender, EventArgs e)
        {
            NewBankAccountStatus = BankAccountStatus.Open;
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
                        if (AccountCreationStatus == BankAccountCreationStatus.AllRequiredApproved || AccountCreationStatus == BankAccountCreationStatus.NothingRequired)
                        {
                            if (new AuthorizedMembershipLookup().NotifyAccountCreated(memberGuid.Value, SecurityHelper.CurrentUserName, SecurityHelper.CurrentUserGuid.Value))
                            {
                                if (BankAccount.WorkFlowStepCompleted(memberGuid.Value))
                                {
                                    AddFinilizedMember(SelectedMember);
                                    Master.NotificationText = "Account approval is complete for the current member.";
                                }
                                else
                                {
                                    Master.ErrorText = "Operation failed.";
                                    return;
                                }
                            }
                            else
                            {
                                Master.ErrorText = "Account creation notification failed.";
                                return;
                            }
                        }
                        //Biruk.Abel newly added code for NMDT
                        else
                        {
                            if (Session["MemberClass"] != null && Convert.ToInt32(Session["MemberClass"]) == 2)
                            {//Selected Member is Tradeing Member
                                BankAccountCreationStatus accCreationStatus = GetAccountCreationStatus();
                                if (accCreationStatus == BankAccountCreationStatus.PartiallyApproved)
                                {
                                    if (new AuthorizedMembershipLookup().NotifyAccountCreated(memberGuid.Value, SecurityHelper.CurrentUserName, SecurityHelper.CurrentUserGuid.Value))
                                    {
                                        if (BankAccount.WorkFlowStepCompleted(memberGuid.Value))
                                        {
                                            AddFinilizedMember(SelectedMember);
                                            Master.NotificationText = "Account approval is complete for the current member.";
                                        }
                                        else
                                        {
                                            Master.ErrorText = "Operation failed.";
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Master.ErrorText = "Account creation notification failed.";
                                        return;
                                    }
                                }
                            }
                        }
                        //end of newly added code
                        scope.Complete();
                    }
                }
                else
                {
                    Master.ErrorText = "Please select a member.";
                }
            }
            else
            {
                Master.ErrorText = "Please select a member.";
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
        protected void SetFinishButtonVisibility()
        {
            if (IsMemberFinilized(SelectedMember))
            {
                btnFinish.Enabled = false;
                return;
            }


            switch (AccountCreationStatus)
            {
                case BankAccountCreationStatus.NothingCreated:
                    btnFinish.Enabled = false;
                    break;
                case BankAccountCreationStatus.PartiallyCreated:
                    btnFinish.Enabled = false;
                    break;
                case BankAccountCreationStatus.NothingRequired:
                    btnFinish.Enabled = true;
                    break;
                case BankAccountCreationStatus.AllRequiredCreated:
                    btnFinish.Enabled = false;
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
                if (accCreationStatus == BankAccountCreationStatus.PartiallyApproved)
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