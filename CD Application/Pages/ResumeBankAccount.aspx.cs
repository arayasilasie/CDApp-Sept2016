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

public partial class Pages_ResumeBankAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDAppResAcc))
        {
            ErrorHandler.RedirectToErrorPage(SettingAccessor.GetSetting("Err:NoPermissionToApproveResumption"));
        }
        else
        {
            ((MasterPage_pTop)this.Master).DescriptionText = "Resume Bank Account from Suspension";
        }
    }
    protected void btnResume_Click(object sender, EventArgs e)
    {
        foreach (Guid accountID in balResumptionList.SelectedBankAccounts)
        {
            if (BankAccount.IsAccountSuspended(accountID))
            {
                string transactionNo = BankAccountFlow.GetTransactionNo(TransactionTypes.ResumeBankAccount, accountID, true);

                if (transactionNo == null)
                {
                    balResumptionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionApprovalFailure"));
                    continue;
                }

                string oldValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
                string newValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccountStatus.Open.ToString();
                AuditTrail at = new AuditTrail(AuditTrailModules.CDAppAccResumption, oldValue, newValue);
                if (at.Save())
                {
                    if (BankAccount.ApproveBankAccountResume(accountID, transactionNo))
                    {
                        at.Commit();
                    }
                    else
                    {
                        at.RollBack();
                        balResumptionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionApprovalFailure"));
                    }
                }
                else
                {
                    balResumptionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionApprovalFailure"));
                }
            }
            else
            {
                balResumptionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionApprovalOnWrongStatus"));
            }
        }
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        foreach (Guid accountID in balResumptionList.SelectedBankAccounts)
        {
            string transactionNo = BankAccountFlow.GetTransactionNo(TransactionTypes.ResumeBankAccount, accountID, true);

            string value = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
            AuditTrail at = new AuditTrail(AuditTrailModules.CDRejAccResumption, value);
            if (at.Save())
            {
                if (BankAccount.RejectBankAccountTransaction(accountID, transactionNo))
                {
                    at.Commit();
                }
                else
                {
                    at.RollBack();
                    balResumptionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionRejectionFailure"));
                }
            }
            else
            {
                balResumptionList.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionRejectionFailure"));
            }
        }
    }
}
