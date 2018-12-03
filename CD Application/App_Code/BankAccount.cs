using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using ECX.CD.Lookup;
using ECX.CD.WorkFlow;
using ECX.CD.Security;
using System.ComponentModel;

public enum BankAccountStatus
{
    New = 0,
    Open,
    Suspended,
    Closed
}
public enum BankAccountCreationStatus
{
    NothingRequired = 0,
    NothingCreated,
    PartiallyCreated,
    AllRequiredCreated,
    //AboveRequiredCreated,
    //NothingApproved,
    PartiallyApproved,
    AllRequiredApproved,
    //AboveRequiredApproved,
}
public class CBankAccount
{
    Guid _bankBranchID;
    Guid _accountTypeID;
    string _accountNo;
    string _status;
    bool _isMandatory;

    public Guid BankBranchID
    {
        get { return _bankBranchID; }
        set { _bankBranchID = value; }
    }
    public Guid AccountTypeID
    {
        get { return _accountTypeID; }
        set { _accountTypeID = value; }
    }
    public string AccountNo
    {
        get { return _accountNo; }
        set { _accountNo = value; }
    }
    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }
    public bool IsMandatory
    {
        get { return _isMandatory; }
        set { _isMandatory = value; }
    }
}


/// <summary>
/// Summary description for BankAccount
/// </summary>
[DataObject]
public class BankAccount
{
    static BankAccount()
    {
        _membersWithNonEmptyPayinAccount = new List<Guid>();
        SetMembersWithNonEmptyPayinAccount();
    }
    public BankAccount()
    {
    }

    static List<Guid> _membersWithNonEmptyPayinAccount;
    public static List<Guid> MembersWithNonEmptyPayinAccount
    {
        get
        {
            return _membersWithNonEmptyPayinAccount;
        }
    }

    public static string GetStatus(object statusID)
    {
        string status = Enum.GetName(typeof(BankAccountStatus), statusID);
        if (status == null)
        {
            return "-";
        }
        return status;
    }
    public static void FillStatus(DropDownList ddlAccountStatus)
    {
        ddlAccountStatus.Items.Clear();
        Array enumValues = Enum.GetValues(typeof(BankAccountStatus));
        ListItem[] items = new ListItem[enumValues.Length];
        foreach (int statusID in enumValues)
        {
            items[statusID] = new ListItem(((BankAccountStatus)statusID).ToString(), statusID.ToString());
        }
        ddlAccountStatus.Items.AddRange(items);
    }
    public static void GetStatus(DropDownList ddlAccountStatus)
    {
        ddlAccountStatus.Items.Clear();
        Array enumValues = Enum.GetValues(typeof(BankAccountStatus));
        ListItem[] items = new ListItem[enumValues.Length];
        foreach (int statusID in enumValues)
        {
            items[statusID] = new ListItem(((BankAccountStatus)statusID).ToString(), statusID.ToString());
        }
        ddlAccountStatus.Items.AddRange(items);
    }
    public static MembershipLookup.Member[] GetMembersToCreateAccount()
    {
        AuthorizedMembershipLookup membership = new AuthorizedMembershipLookup();
        MembershipLookup.Member[] members = membership.GetAccountCreationList();
        return members;
    }
    public static string GetMemberClass(object id)
    {
        AuthorizedMembershipLookup membership = new AuthorizedMembershipLookup();
        return membership.GetMemberClassName(int.Parse(id.ToString()));
    }
    public static bool IsAccountCreationComplete(Guid memberID, int memberClassID, out List<string> accountTypesNotCreated, out List<Guid> accountTypesNotCreatedGuid)
    {
        bool isComplete = true;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        SqlCommand comm = new SqlCommand("spAccountTypesNotCreatedForMember", conn);
        comm.CommandType = CommandType.StoredProcedure;

        comm.Parameters.AddWithValue("@MemberID", memberID);
        comm.Parameters.AddWithValue("@MemberClass", memberClassID);

        accountTypesNotCreated = new List<string>();
        accountTypesNotCreatedGuid = new List<Guid>();
        conn.Open();
        using (SqlDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection))
        {
            if (reader.HasRows)
            {
                isComplete = false;

                while (reader.Read())
                {
                    accountTypesNotCreated.Add(reader["Name"].ToString());
                    accountTypesNotCreatedGuid.Add(new Guid(reader["ID"].ToString()));
                }
            }
        }
        comm.Dispose();
        conn.Dispose();
        return isComplete;
    }
    public static bool IsAccountValid(Guid accountId, Guid memberId, Guid? ClientId, Guid bankBranchId, Guid accountTypeId, string accountNumber, out string error)
    {
        Guid bankId = ECX.CD.BL.IFLookup.GetBankByBranchGuid(bankBranchId).UniqueIdentifier;
        List<Guid> bankBranchIds = ECX.CD.BL.IFLookup.GetBankBranchIds(bankId);

        //Convert list of bank branch ids into comma separated string values
        //This will be used by the stored procedure to filter any bank accounts with in those branches.
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("(");
        foreach (var branchId in bankBranchIds)
        {
            sb.AppendFormat("'{0}', ", branchId);
        }
        sb.Remove(sb.Length - 2, 2);
        sb.Append(")");

        string formattedBankBranchIds = sb.ToString();

        MainDataContextDataContext db = new MainDataContextDataContext(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        error = string.Empty;
        db.spIsAccountValid(accountId, memberId, ClientId, bankId, formattedBankBranchIds, accountTypeId, accountNumber, ref error);

        if (error == string.Empty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool IsAccountValid(Guid accountId, Guid memberId, Guid bankBranchId, Guid accountTypeId, string accountNumber, out string error)
    {
        return IsAccountValid(accountId, memberId, null, bankBranchId, accountTypeId, accountNumber, out error);
    }

    public static void SetMembersWithNonEmptyPayinAccount()
    {
        MainDataContextDataContext db = new MainDataContextDataContext(ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString);
        var balanceList = from ba in db.tblBankAccounts
                          where ba.Status == (byte)BankAccountStatus.Open
                          group ba by ba.MemberID into list
                          select new { list.Key, MaximumPayinBalance = list.Max(ba => ba.Balance) };

        lock (_membersWithNonEmptyPayinAccount)
        {
            _membersWithNonEmptyPayinAccount.Clear();
            foreach (var v in balanceList)
            {
                if (v.MaximumPayinBalance > 0)
                    _membersWithNonEmptyPayinAccount.Add(v.Key);
            }
        }
    }

    public static bool WorkFlowStepCompleted(Guid memberGuid)
    {
        try
        {
            string transactionNumber = ECX.CD.WorkFlow.WorkFlow.GetMemberTransactionNo(memberGuid, TransactionTypes.AddNewBankAccount);
            if (transactionNumber == null)
            {
                throw new ArgumentNullException("transactionNumber", string.Format("Transaction associated with the member is not found. MemberGuid = {0} and TransactionTypeId = {1}", memberGuid, TransactionTypes.AddNewBankAccount));
            }
            if (ECX.CD.WorkFlow.WorkFlow.StepCompleted(transactionNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            ErrorHandler.WriteLogEntry(ex);
            return false;
        }
    }

    public static BankAccountCreationStatus GetBankAccountCreationStatus(Guid memberId, int memberClassID)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();

        var requiredAccountTypes = from mcbat in db.tblMembershipClassBankAccountTypes
                                   where mcbat.IsMandatory == true && mcbat.MembershipClassID == memberClassID
                                   select mcbat.AccountTypeID;

        var accounts = from ba in db.tblBankAccounts
                       where ba.MemberID == memberId && (ba.Status == 0 || ba.Status == 1)
                       select new
                       {
                           ba.AccountTypeID,
                           ba.Status
                       };

        //no account is required
        if (requiredAccountTypes.Count() == 0)
        {
            return BankAccountCreationStatus.NothingRequired;
        }
        //no account is created for the member.
        else if (accounts.Count() == 0)
        {
            return BankAccountCreationStatus.NothingCreated;
        }

        bool allRequiredApproved = true;
        bool anyAccountApproved = false;
        foreach (Guid accType in requiredAccountTypes)
        {
            if (accounts.Count(b => b.AccountTypeID == accType && b.Status == (int)BankAccountStatus.Open) == 0)
            {
                allRequiredApproved = false;
            }
            else
            {
                anyAccountApproved = true;
            }
        }

        if (allRequiredApproved)
        {
            return BankAccountCreationStatus.AllRequiredApproved;
        }
        else
        {
            if (anyAccountApproved)
            {
                return BankAccountCreationStatus.PartiallyApproved;
            }
            else//approval has not yet started
            {
                bool allRequiredCreated = true;
                foreach (Guid accType in requiredAccountTypes)
                {
                    if (accounts.Count(b => b.AccountTypeID == accType && b.Status == (byte)BankAccountStatus.New) == 0)
                    {
                        allRequiredCreated = false;
                    }
                }

                if (allRequiredCreated)
                {
                    return BankAccountCreationStatus.AllRequiredCreated;
                }
                else
                {
                    return BankAccountCreationStatus.PartiallyCreated;
                }
            }
        }
    }
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<tblBankAccount> GetBankAccounts(Guid bank, Guid branch, Guid memberId, Guid accountType, BankAccountStatus accountStatus, string accountNo)
    {
        List<Guid> bankBranches = Common.GetBankBranches(bank);

        MainDataContextDataContext db = new MainDataContextDataContext();
        var bankAccounts = from ba in db.tblBankAccounts
                           where (bankBranches.Contains(ba.BankBranchID) || bank == Guid.Empty) &&
                                (branch == ba.BankBranchID || branch == Guid.Empty) &&
                                (memberId == ba.MemberID || memberId == Guid.Empty) &&
                                (accountType == ba.AccountTypeID || accountType == Guid.Empty) &&
                                (accountStatus == (BankAccountStatus)ba.Status || accountStatus == (BankAccountStatus)byte.MaxValue) &&
                                (accountNo == ba.AccountNumber || accountNo == string.Empty || accountNo == null)
                           select ba;
        return bankAccounts.ToList();
    }
    public static List<tblBankAccount> GetBankAccounts()
    {
        string pagePhysicalUrl = HttpContext.Current.Request.PhysicalPath;
        if (HttpContext.Current.Session[pagePhysicalUrl] == null)
        {
            return null;
        }
        List<string> transNos = (List<string>)HttpContext.Current.Session[pagePhysicalUrl];

        MainDataContextDataContext db = new MainDataContextDataContext();

        var bankAccounts = from trans in db.tblBankAccountTransactions
                           where transNos.Contains(trans.TransactionNo)
                           select trans.tblBankAccount;

        return bankAccounts.ToList();
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<tblBankAccount> GetBankAccounts(Guid memberId)
    {
        if (memberId == Guid.Empty)
        {
            return new List<tblBankAccount>();
        }
        MainDataContextDataContext db = new MainDataContextDataContext();
        var bankAccounts = from ba in db.tblBankAccounts
                           where (memberId == ba.MemberID)
                           select ba;
        return bankAccounts.ToList();
    }
    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<tblBankAccount> GetBankAccounts(Guid memberId, Guid? ClientId, bool clientAccounts)
    {
        if (memberId == Guid.Empty)
        {
            return new List<tblBankAccount>();
        }
        MainDataContextDataContext db = new MainDataContextDataContext();

        IQueryable<tblBankAccount> bankAccounts;

        if (clientAccounts)
        {
            bankAccounts = from ba in db.tblBankAccounts
                           where memberId == ba.MemberID &&
                           ba.ClientId == ClientId &&
                           ba.ClientId != null
                           select ba;
        }
        else
        {
            bankAccounts = from ba in db.tblBankAccounts
                           where
                           memberId == ba.MemberID &&
                           ba.ClientId == null
                           select ba;
        }

        return bankAccounts.ToList();
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static tblBankAccount GetBankAccounts(Guid accountId, int nothing)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var bankAccounts = from ba in db.tblBankAccounts
                           where (accountId == ba.ID)
                           select ba;
        return bankAccounts.FirstOrDefault();
    }

    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void InsertBankAccount(Guid bankBranchId, Guid memberId, Guid accountTypeId, string accountNumber, byte status, DateTime documentPresentedTimeStamp)
    {
        InsertBankAccount(bankBranchId, memberId, accountTypeId, accountNumber, status, documentPresentedTimeStamp, null);
    }
    [DataObjectMethod(DataObjectMethodType.Insert)]
    public static void InsertBankAccount(Guid bankBranchId, Guid memberId, Guid accountTypeId, string accountNumber, byte status, DateTime documentPresentedTimeStamp, Guid? ClientId)
    {
        if (memberId == Guid.Empty)
        {

        }
        MainDataContextDataContext db = new MainDataContextDataContext();
        tblBankAccount ba = new tblBankAccount();

        ba.ID = Guid.NewGuid();
        ba.MemberID = memberId;
        ba.ClientId = ClientId;
        ba.AccountTypeID = accountTypeId;
        ba.AccountNumber = accountNumber;
        ba.Status = status;
        ba.BankBranchID = bankBranchId;
        ba.DocumentPresentedTimeStamp = documentPresentedTimeStamp;

        ba.Balance = 0;
        ba.BalanceUpdatedDate = DateTime.Now;
        ba.CreatedBy = SecurityHelper.CurrentUserGuid.Value;
        ba.CreatedDate = DateTime.Now;

        db.tblBankAccounts.InsertOnSubmit(ba);
        db.SubmitChanges();
    }

    [DataObjectMethod(DataObjectMethodType.Update)]
    public static void UpdateBankAccount(Guid bankBranchId, Guid accountTypeId, string accountNumber, byte status, DateTime documentPresentedTimeStamp, Guid original_Id)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();

        tblBankAccount ba = (from b in db.tblBankAccounts
                             where b.ID == original_Id
                             select b).Single();

        ba.AccountTypeID = accountTypeId;
        ba.AccountNumber = accountNumber;
        ba.Status = status;
        ba.BankBranchID = bankBranchId;
        ba.DocumentPresentedTimeStamp = documentPresentedTimeStamp;

        ba.UpdatedBy = SecurityHelper.CurrentUserGuid;
        ba.UpdatedDate = DateTime.Now;

        db.SubmitChanges();
    }

    public static bool RequestBankAccountSuspension(Guid bankAccountID)
    {
        bool done = false;
        string transactionNo = "";

        using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        {
            if (ECX.CD.WorkFlow.WorkFlow.OpenTransaction(ECX.CD.WorkFlow.TransactionTypes.SuspendBankAccount, out transactionNo))
            {
                if (ECX.CD.WorkFlow.WorkFlow.StepCompleted(transactionNo))
                {
                    tblBankAccountTransaction bat = new tblBankAccountTransaction();

                    bat.BankAccountId = bankAccountID;
                    bat.TransactionNo = transactionNo;
                    bat.TransactionTypeId = ECX.CD.WorkFlow.WorkFlow.GetTransactionTypeId(ECX.CD.WorkFlow.TransactionTypes.SuspendBankAccount);
                    bat.IsClosed = false;

                    MainDataContextDataContext db = new MainDataContextDataContext();
                    db.tblBankAccountTransactions.InsertOnSubmit(bat);
                    db.SubmitChanges();
                    db.Dispose();

                    done = true;
                    scope.Complete();
                }
            }
        }
        return done;
    }
    public static bool ApproveBankAccountSuspension(Guid bankAccountID, string transactionNo)
    {
        bool done = false;

        using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        {

            if (BankAccountFlow.CloseLocalTransaction(transactionNo))
            {
                MainDataContextDataContext db = new MainDataContextDataContext();
                var bankAccount = from ba in db.tblBankAccounts
                                  where ba.ID == bankAccountID
                                  select ba;

                if (bankAccount.Count() > 0)
                {
                    bankAccount.FirstOrDefault().Status = (byte)BankAccountStatus.Suspended;

                    SendBankAccountStatus(bankAccountID, (byte)BankAccountStatus.Suspended, SecurityHelper.CurrentUserGuid.Value);
                    db.SubmitChanges();

                    if (ECX.CD.WorkFlow.WorkFlow.StepCompleted(transactionNo))
                    {
                        done = true;
                        scope.Complete();
                    }
                }
            }
        }
        return done;
    }

    public static bool RequestBankAccountClosure(Guid bankAccountID)
    {
        bool done = false;
        string transactionNo = "";

        using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        {
            if (ECX.CD.WorkFlow.WorkFlow.OpenTransaction(ECX.CD.WorkFlow.TransactionTypes.CloseBankAccount, out transactionNo))
            {
                if (ECX.CD.WorkFlow.WorkFlow.StepCompleted(transactionNo))
                {
                    tblBankAccountTransaction bat = new tblBankAccountTransaction();

                    bat.BankAccountId = bankAccountID;
                    bat.TransactionNo = transactionNo;
                    bat.TransactionTypeId = ECX.CD.WorkFlow.WorkFlow.GetTransactionTypeId(ECX.CD.WorkFlow.TransactionTypes.CloseBankAccount);
                    bat.IsClosed = false;

                    MainDataContextDataContext db = new MainDataContextDataContext();
                    db.tblBankAccountTransactions.InsertOnSubmit(bat);
                    db.SubmitChanges();
                    db.Dispose();

                    done = true;
                    scope.Complete();
                }
            }
        }
        return done;
    }
    public static bool ApproveBankAccountClosure(Guid bankAccountID, string transactionNo)
    {
        bool done = false;

        using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        {
            if (BankAccountFlow.CloseLocalTransaction(transactionNo))
            {
                MainDataContextDataContext db = new MainDataContextDataContext();
                var bankAccount = from ba in db.tblBankAccounts
                                  where ba.ID == bankAccountID
                                  select ba;

                if (bankAccount.Count() > 0)
                {
                    bankAccount.FirstOrDefault().Status = (byte)BankAccountStatus.Closed;

                    SendBankAccountStatus(bankAccountID, (byte)BankAccountStatus.Closed, SecurityHelper.CurrentUserGuid.Value);
                    db.SubmitChanges();
                    if (ECX.CD.WorkFlow.WorkFlow.StepCompleted(transactionNo))
                    {
                        done = true;
                        scope.Complete();
                    }
                }
            }
        }

        return done;
    }

    public static bool RequestBankAccountResume(Guid bankAccountID)
    {
        bool done = false;
        string transactionNo = "";

        using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        {
            if (ECX.CD.WorkFlow.WorkFlow.OpenTransaction(ECX.CD.WorkFlow.TransactionTypes.ResumeBankAccount, out transactionNo))
            {
                if (ECX.CD.WorkFlow.WorkFlow.StepCompleted(transactionNo))
                {
                    tblBankAccountTransaction bat = new tblBankAccountTransaction();

                    bat.BankAccountId = bankAccountID;
                    bat.TransactionNo = transactionNo;
                    bat.TransactionTypeId = ECX.CD.WorkFlow.WorkFlow.GetTransactionTypeId(ECX.CD.WorkFlow.TransactionTypes.ResumeBankAccount);
                    bat.IsClosed = false;

                    MainDataContextDataContext db = new MainDataContextDataContext();
                    db.tblBankAccountTransactions.InsertOnSubmit(bat);
                    db.SubmitChanges();
                    db.Dispose();

                    done = true;
                    scope.Complete();
                }
            }
        }
        return done;
    }
    public static bool ApproveBankAccountResume(Guid bankAccountID, string transactionNo)
    {
        bool done = false;

        using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        {
            if (BankAccountFlow.CloseLocalTransaction(transactionNo))
            {
                MainDataContextDataContext db = new MainDataContextDataContext();
                var bankAccount = from ba in db.tblBankAccounts
                                  where ba.ID == bankAccountID
                                  select ba;

                if (bankAccount.Count() > 0)
                {
                    bankAccount.FirstOrDefault().Status = (byte)BankAccountStatus.Open;

                    SendBankAccountStatus(bankAccountID, (byte)BankAccountStatus.Open, SecurityHelper.CurrentUserGuid.Value);
                    db.SubmitChanges();
                    if (ECX.CD.WorkFlow.WorkFlow.StepCompleted(transactionNo))
                    {
                        done = true;
                        scope.Complete();
                    }
                }
            }
        }
        return done;
    }

    public static bool IsAccountSuspended(Guid bankAccountID)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var account = from ba in db.tblBankAccounts
                      where ba.ID == bankAccountID && (BankAccountStatus)ba.Status == BankAccountStatus.Suspended
                      select ba.ID;

        if (account.Count() == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool IsAccountClosed(Guid bankAccountID)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var account = from ba in db.tblBankAccounts
                      where ba.ID == bankAccountID && (BankAccountStatus)ba.Status == BankAccountStatus.Closed
                      select ba.ID;

        if (account.Count() == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool IsAccountOpen(Guid bankAccountID)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var account = from ba in db.tblBankAccounts
                      where ba.ID == bankAccountID && (BankAccountStatus)ba.Status == BankAccountStatus.Open
                      select ba.ID;

        if (account.Count() == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static BankAccountStatus GetBankAccountStatus(Guid bankAccountID)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var account = from ba in db.tblBankAccounts
                      where ba.ID == bankAccountID
                      select new { ba.Status };

        if (account.Count() == 1)
        {
            return (BankAccountStatus)account.First().Status;
        }
        else
        {
            return (BankAccountStatus)(-1);
        }

    }
    public static bool RejectBankAccountTransaction(Guid bankAccountID, string transactionNo)
    {
        bool done = false;

        using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
        {
            if (ECX.CD.WorkFlow.WorkFlow.AbortTransaction(transactionNo))
            {
                if (BankAccountFlow.CloseLocalTransaction(transactionNo))
                {
                    done = true;
                    scope.Complete();
                }
            }
        }
        return done;
    }

    public static Guid GetAccountOwnerId(Guid bankAccountID)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var account = from ba in db.tblBankAccounts
                      where ba.ID == bankAccountID
                      select new { ba.MemberID };

        if (account.Count() == 1)
        {
            return account.First().MemberID;
        }
        else
        {
            return Guid.Empty;
        }
    }

    public static bool IsAccountEmpty(Guid bankAccountID)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var account = from ba in db.tblBankAccounts
                      where ba.ID == bankAccountID
                      select new { ba.Balance };

        if (account.Count() == 1)
        {
            if (account.First().Balance == 0)
                return true;
            else
                return false;
        }
        else
        {
            throw new InvalidOperationException("No bank account found");
        }
    }

    public static List<Guid> GetMembersForDepositRange(DateTime depositDateFrom, DateTime depositDateTo)
    {
        MainDataContextDataContext db = new MainDataContextDataContext();
        var members =
            (from ba in db.tblBankAccounts
             where ba.BalanceUpdatedDate >= depositDateFrom && ba.BalanceUpdatedDate <= depositDateTo
             select new { ba.MemberID }.MemberID).Distinct();

        return members.ToList();
    }

    /// <summary>
    /// Copies bank account balance from CNS to CD
    /// </summary>
    public static void UpdateBalance()
    {
        //Elias Remove
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;

            SqlCommand command = new SqlCommand();

            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText =
                "UPDATE    dbCentralDepository.dbo.tblBankAccount " +
                "SET              Balance = aa.Balance " +
                "FROM         (SELECT     cn.guid, cn.Balance " +
                "                       FROM          stagingCNS.dbo.tblBankAccount cn INNER JOIN " +
                "                                              dbCentralDepository.dbo.tblBankAccount cd ON cn.GUID = cd.ID) aa " +
                "WHERE     dbCentralDepository.dbo.tblBankAccount.Id = aa.guid ";

            conn.Open();

            command.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// Sends bank account creation notice to CNS application
    /// </summary>
    /// <param name="accountGuid">Guid of bank account being created</param>
    /// <param name="ownerGuid">Guid of the owner of the bank account</param>
    /// <param name="branchGuid">Guid of bank branch</param>
    /// <param name="accountTypeGuid">Guid of account type</param>
    /// <param name="accountNumber">Bank account number</param>
    /// <param name="createdBy">Guid of user creating bank account</param>
    public static void SendBankAccountCreationNotice(Guid accountGuid, Guid ownerGuid, Guid branchGuid, Guid accountTypeGuid, string accountNumber, Guid createdBy)
    {
        CNS.CNSService cns = new CNS.CNSService();

        cns.InsertAccount(accountGuid, ownerGuid, branchGuid, accountTypeGuid, accountNumber, 0, DateTime.Now, 0, createdBy);

        cns.Dispose();
    }

    /// <summary>
    /// Sends bank account status update notice to CNS application
    /// </summary>
    /// <param name="accountGuid">Guid of the bank account being updated</param>
    /// <param name="newStatus">New status of bank account</param>
    /// <param name="updatedBy">Guid of user commiting this update</param>
    public static void SendBankAccountStatus(Guid accountGuid, short newStatus, Guid updatedBy)
    {
        CNS.CNSService cns = new CNS.CNSService();

        cns.UpdateAccountStatus(accountGuid, newStatus, updatedBy);

        cns.Dispose();
    }

    /// <summary>
    /// Gets a bank account with the specified account number
    /// </summary>
    /// <param name="accountNumber">Bank account number</param>
    /// <returns></returns>
    public static tblBankAccount GetBankAccount(string accountNumber)
    {
        using (MainDataContextDataContext context = new MainDataContextDataContext())
        {
            return context.tblBankAccounts.Where(x => x.AccountNumber == accountNumber).FirstOrDefault();
        }
    }

    //Biruk.Abel Newly added code
    public static tblBankAccount GetBankAccountDetail(Guid accountGuid)
    {
        using (MainDataContextDataContext context = new MainDataContextDataContext())
        {
            return context.tblBankAccounts.Where(x => x.ID == accountGuid).FirstOrDefault();
        }
    }
    
    //end of newly added code
}
