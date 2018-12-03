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
using ECXControlsCollection;
using MembershipLookup;
using ECX.CD.Security;
using AjaxControlToolkit;
using Lookup;
using System.Collections.Specialized;

public partial class Controls_ManageBankAccounts : System.Web.UI.UserControl
{
    AuditTrail audit = new AuditTrail();

    public Guid SelectedMember
    {
        get
        {
            object selectedMember = ViewState["SelectedMember"];
            if (selectedMember is Guid)
            {
                return new Guid(selectedMember.ToString());
            }
            else
            {
                return Guid.Empty;
            }
        }
        set
        {
            ViewState["SelectedMember"] = value;
        }
    }
    public Guid? SelectedClient
    {
        get
        {
            object selectedClient = ViewState["SelectedClient"];
            if (selectedClient is Guid)
            {
                return new Guid(selectedClient.ToString());
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (value.HasValue)
            {
                ViewState["SelectedClient"] = value.Value;
            }
            else
            {
                ViewState["SelectedClient"] = Guid.Empty;
            }
        }
    }

    public int MaximumListCount
    {
        get
        {
            int result = 10;
            string size = ConfigurationManager.AppSettings["MaximumGridRows"];
            if (int.TryParse(size, out result))
            {
                return result;
            }
            else
            {
                return 10;
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = string.Empty;

        if (!IsPostBack)
        {
            DataBindGridveiw();
        }
    }

    #region Events handlers
    protected void ddlAccountType_DataBinding(object sender, EventArgs e)
    {
        if (SelectedClient.HasValue)
        {
            Common.FillClientBankAccountType((DropDownList)sender, true);
        }
        else
        {
            Common.FillBankAccountType((DropDownList)sender, true);
        }

        //if (gvMembers.SelectedIndex > -1 && gvMembers.SelectedDataKey != null)
        //{
        //    string memberClass = gvMembers.SelectedDataKey["MemberClassID"].ToString();
        //    Common.FillBankAccountType((DropDownList)sender, int.Parse(memberClass), true);
        //}
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

    protected void fvBankAccount_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        e.Values.Add("MemberID", SelectedMember);
        if (SelectedClient.HasValue)
        {
            e.Values.Add("ClientId", SelectedClient.Value);
        }
        e.Values["BankBranchID"] = new Guid(e.Values["BankBranchID"].ToString().Substring(0, 36));

        //the following line is added to remove white spaces from bank account number.
        e.Values["AccountNumber"] = e.Values["AccountNumber"].ToString().Trim();

        audit = new AuditTrail();
        Dictionary<string, object> dataList = new Dictionary<string, object>();
        foreach (string key in e.Values.Keys)
        {
            dataList.Add(key, e.Values[key]);
        }

        string newValue = Common.FormatAuditTrail(dataList);
        audit.Add(AuditTrailModules.CDAddNewAccount, newValue);

        if (!audit.Save())
            e.Cancel = true;

        //e.Values.Add("ID", Guid.NewGuid());
        //e.Values.Add("Balance", 0);
        //e.Values.Add("BalanceUpdatedDate", DateTime.Now);


        //if (e.Values["AccountTypeID"] == null)
        //{
        //    throw new Exception("Account type not valid.");
        //}
        //if (e.Values["Status"] == null)
        //{
        //    throw new Exception("Account status not valid");
        //}
        //int bankAccountStatus = 0;
        //if (!int.TryParse(e.Values["Status"].ToString(), out bankAccountStatus))
        //{
        //    throw new Exception("Account status not valid");
        //}
        //if (e.Values["BankBranchID"] == null || !Common.IsGuid(e.Values["BankBranchID"].ToString()))
        //{
        //    throw new Exception("Bank branch not valid.");
        //}

        Guid accountId = Guid.Empty;
        Guid accountTypeId = new Guid(e.Values["AccountTypeID"].ToString());
        Guid bankBranchId = new Guid(e.Values["BankBranchID"].ToString());
        string accountNumber = e.Values["AccountNumber"].ToString();
        string error = string.Empty;

        if (!BankAccount.IsAccountValid(accountId, SelectedMember, SelectedClient, bankBranchId, accountTypeId, accountNumber, out error))
        {
            e.Cancel = true;
            lblError.Text = error;
            //throw new ECX.CD.BL.BankAccountValidationException(error);
        }
    }
    protected void fvBankAccount_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        Guid ownerGuid = new Guid(e.Values["MemberID"].ToString());

        if (e.Values["ClientId"] != null)
        {
            ownerGuid = new Guid(e.Values["ClientId"].ToString());
        }
        string accountNumber = e.Values["AccountNumber"].ToString();
        tblBankAccount account = BankAccount.GetBankAccount(accountNumber);

        try
        {
            BankAccount.SendBankAccountCreationNotice(account.ID, ownerGuid, account.BankBranchID, account.AccountTypeID, accountNumber, SecurityHelper.CurrentUserGuid.Value);
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteLogEntry(ex);
        }
        finally
        {
            BankAccount.SendBankAccountStatus(account.ID, account.Status, SecurityHelper.CurrentUserGuid.Value);
        }
        gvBankAccounts.DataBind();
        if (e.AffectedRows != 0)
        {
            audit.Commit();
        }
        else
            audit.RollBack();
    }
    protected void fvBankAccount_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        e.NewValues["BankBranchID"] = new Guid(e.NewValues["BankBranchID"].ToString().Substring(0, 36));

        //the following line is added to remove white spaces from bank account number.
        e.NewValues["AccountNumber"] = e.NewValues["AccountNumber"].ToString().Trim();

        Dictionary<string, object> oldDataList = new Dictionary<string, object>();
        foreach (string key in e.OldValues.Keys)
        {
            oldDataList.Add(key, e.OldValues[key]);
        }
        Dictionary<string, object> newDataList = new Dictionary<string, object>();
        foreach (string key in e.NewValues.Keys)
        {
            newDataList.Add(key, e.NewValues[key]);
        }

        audit = new AuditTrail();
        string oldValue = Common.FormatAuditTrail(oldDataList);
        string newValue = Common.FormatAuditTrail(newDataList);
        audit.Add(AuditTrailModules.CDModifyBankAcc, oldValue, newValue);

        if (!audit.Save())
            e.Cancel = true;

        Guid accountId = new Guid(fvBankAccount.SelectedValue.ToString());

        Guid accountTypeId = new Guid(e.NewValues["AccountTypeID"].ToString());
        Guid bankBranchId = new Guid(e.NewValues["BankBranchID"].ToString());
        string accountNumber = e.NewValues["AccountNumber"].ToString();
        string error = string.Empty;

        if (!BankAccount.IsAccountValid(accountId, SelectedMember, SelectedClient, bankBranchId, accountTypeId, accountNumber, out error))
        {
            e.Cancel = true;
            lblError.Text = error;
            //throw new ECX.CD.BL.BankAccountValidationException(error);
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
        gvBankAccounts.DataBind();
        if (e.AffectedRows != 0)
        {
            audit.Commit();

            if (e.OldValues["Status"].ToString() != e.NewValues["Status"].ToString())
            {
                short newStatus = short.Parse(e.NewValues["Status"].ToString());
                Guid accountId = (Guid)(fvBankAccount.SelectedValue);
                
                BankAccount.SendBankAccountStatus(accountId, newStatus, SecurityHelper.CurrentUserGuid.Value);
            }
        }
        else
            audit.RollBack();
    }

    protected void fvBankAccount_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            fvBankAccount.ChangeMode(FormViewMode.Insert);
        }
    }

    protected void lkbEdit_Click(object sender, EventArgs e)
    {
        string accountGuid = ((LinkButton)sender).CommandArgument;

        dsBankAccount.SelectParameters[0].DefaultValue = accountGuid;
        dsBankAccount.DataBind();

        fvBankAccount.DataBind();

        fvBankAccount.ChangeMode(FormViewMode.Edit);
        dlgBankAccount_PopupExtender.Show();
        //dsBankAccounts.SelectParameters
    }
    protected override void OnDataBinding(EventArgs e)
    {
        base.OnDataBinding(e);

        DataBindGridveiw();

    }

    void DataBindGridveiw()
    {
        List<tblBankAccount> accounts = new List<tblBankAccount>();

        if (SelectedClient.HasValue)
            accounts = BankAccount.GetBankAccounts(SelectedMember, SelectedClient, true);
        else if (SelectedMember != Guid.Empty)
            accounts = BankAccount.GetBankAccounts(SelectedMember, null, false);

        gvBankAccounts.DataSource = accounts;
        gvBankAccounts.DataBind();

        bool clientAccounts = !(SelectedClient == null);

        if (clientAccounts)//working on client accounts
        {
            //if both member and client ids are valid
            if (SelectedMember != Guid.Empty && SelectedClient != Guid.Empty)
            {
                btnAddNew.Enabled = true;
            }
            else
            {
                btnAddNew.Enabled = false;
            }
        }
        else//working on member accounts
        {
            if (SelectedMember != Guid.Empty)
            {
                btnAddNew.Enabled = true;
            }
            else
            {
                btnAddNew.Enabled = false;
            }
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        //dsBankAccount.DataBind();

        fvBankAccount.ChangeMode(FormViewMode.Insert);
        fvBankAccount.DataBind();


        dlgBankAccount_PopupExtender.Show();
    }
    #endregion

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
    protected void lkbSaveBankAccount_Click(object sender, EventArgs e)
    {

    }
}
