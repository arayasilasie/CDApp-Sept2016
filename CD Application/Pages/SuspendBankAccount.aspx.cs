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

public partial class Pages_SuspendBankAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDAppSusAcc))
        {
            ErrorHandler.RedirectToErrorPage(SettingAccessor.GetSetting("Err:NoPermissionToApproveSuspension"));
        }
        else
        {
            ((MasterPage_pTop)this.Master).DescriptionText = "Suspend Bank Account";
        }
    }
    protected void btnSuspend_Click(object sender, EventArgs e)
    {
        foreach (Guid accountID in balSuspensionList.SelectedBankAccounts)
        {
            if (BankAccount.IsAccountOpen(accountID))
            {
                string transactionNo = BankAccountFlow.GetTransactionNo(TransactionTypes.SuspendBankAccount, accountID, true);
                if (transactionNo == null)
                {
                    balSuspensionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionApprovalFailure"));
                    continue;
                }

                string oldValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
                string newValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccountStatus.Suspended.ToString();
                AuditTrail at = new AuditTrail(AuditTrailModules.CDAppAccSuspension, oldValue, newValue);
                if (at.Save())
                {
                    if (BankAccount.ApproveBankAccountSuspension(accountID, transactionNo))
                    {
                        at.Commit();
                    }
                    else
                    {
                        at.RollBack();
                        balSuspensionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionApprovalFailure"));
                    }
                }
                else
                {
                    balSuspensionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionApprovalFailure"));
                }
            }
            else
            {
                balSuspensionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionApprovalOnWrongStatus"));
            }
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        foreach (Guid accountID in balSuspensionList.SelectedBankAccounts)
        {
            string transactionNo = BankAccountFlow.GetTransactionNo(TransactionTypes.SuspendBankAccount, accountID, true);

            string value = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
            AuditTrail at = new AuditTrail(AuditTrailModules.CDRejAccSuspension, value);
            if (at.Save())
            {
                if (BankAccount.RejectBankAccountTransaction(accountID, transactionNo))
                {
                    at.Commit();
                }
                else
                {
                    at.RollBack();
                    balSuspensionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionRejectionFailure"));
                }
            }
            else
            {
                balSuspensionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionRejectionFailure"));
            }
        }
    }
}
