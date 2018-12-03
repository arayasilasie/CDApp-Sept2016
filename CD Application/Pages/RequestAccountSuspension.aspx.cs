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

public partial class Pages_RequestAccountSuspension : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDSuspendAccount))
        {
            ErrorHandler.RedirectToErrorPage(SettingAccessor.GetSetting("Err:NoPermissionToRequestSuspension"));
        }
        else
        {
            ((MasterPage_pTop)this.Master).DescriptionText = "Request Bank Account Suspension";
        }
    }
    protected void btnSuspend_Click(object sender, EventArgs e)
    {
        foreach (Guid accountID in basBankAccountSearch.SelectedBankAccounts)
        {
            if (BankAccount.IsAccountOpen(accountID))
            {
                if (BankAccountFlow.CanOpenTransaction(TransactionTypes.SuspendBankAccount, accountID))
                {
                    string oldValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
                    string newValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccountStatus.Suspended.ToString();
                    AuditTrail at = new AuditTrail(AuditTrailModules.CDReqAccSuspension, oldValue, newValue);

                    if (at.Save())
                    {
                        if (BankAccount.RequestBankAccountSuspension(accountID))
                        {
                            at.Commit();
                        }
                        else
                        {
                            at.RollBack();
                            basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionRequestFailure"));
                        }
                    }
                    else
                    {
                        basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionRequestFailure"));
                    }
                }
                else
                {
                    basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionRequestExists"));
                }
            }
            else
            {
                basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:SuspensionRequestOnWrongStatus"));
            }
        }
    }
}
