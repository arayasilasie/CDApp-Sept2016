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
using ECX.CD.WorkFlow;
using ECX.CD.Security;
using ECX.CD;
using System.Transactions;

public partial class Pages_CloseBankAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDAppCloAcc))
        {
            ErrorHandler.RedirectToErrorPage(SettingAccessor.GetSetting("Err:NoPermissionToApproveClosure"));
        }
        else
        {
            ((MasterPage_pTop)this.Master).DescriptionText = "Close Bank Account";
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        MembershipLookup.MemberShipLookUp membership = new MembershipLookup.MemberShipLookUp();

        foreach (Guid accountID in balClosureList.SelectedBankAccounts)
        {
            if (!BankAccount.IsAccountClosed(accountID))
            {
                if (BankAccount.IsAccountEmpty(accountID))
                {
                    string transactionNo = BankAccountFlow.GetTransactionNo(TransactionTypes.CloseBankAccount, accountID, true);
                    if (transactionNo == null)
                    {
                        balClosureList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureApprovalFailure"));
                        continue;
                    }

                    string oldValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
                    string newValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccountStatus.Closed.ToString();
                    AuditTrail at = new AuditTrail(AuditTrailModules.CDAppAccClosure, oldValue, newValue);

                    if (at.Save())
                    {
                        if (BankAccount.ApproveBankAccountClosure(accountID, transactionNo))
                        {
                            Guid memberId = BankAccount.GetAccountOwnerId(accountID);

                            at.Commit();
                            BankAccount.GetBankAccountCreationStatus(memberId, Members.GetMemberClassId(memberId));
                            
                        }
                        else
                        {
                            at.RollBack();
                            balClosureList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureApprovalFailure"));
                        }
                    }
                    else
                    {
                        balClosureList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureApprovalFailure"));
                    }
                }
                else
                {
                    balClosureList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureOnAccountWithBalance"));
                }
            }
            else
            {
                balClosureList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureApprovalOnWrongStatus"));
            }
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        foreach (Guid accountID in balClosureList.SelectedBankAccounts)
        {
            string transactionNo = BankAccountFlow.GetTransactionNo(TransactionTypes.CloseBankAccount, accountID, true);

            string value = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
            AuditTrail at = new AuditTrail(AuditTrailModules.CDRejAccClosure, value);
            if (at.Save())
            {
                if (BankAccount.RejectBankAccountTransaction(accountID, transactionNo))
                {
                    at.Commit();
                }
                else
                {
                    at.RollBack();
                    balClosureList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureRejectionFailure"));
                }
            }
            else
            {
                balClosureList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureRejectionFailure"));
            }
        }
    }
}
