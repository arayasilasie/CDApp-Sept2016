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

public partial class Pages_RequestAccountClosure : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDCloseAccount))
        {
            ErrorHandler.RedirectToErrorPage(SettingAccessor.GetSetting("Err:NoPermissionToRequestClosure"));
        }
        else
        {
            ((MasterPage_pTop)this.Master).DescriptionText = "Request Bank Account Closure";
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        foreach (Guid accountID in basBankAccountSearch.SelectedBankAccounts)
        {
            if (!BankAccount.IsAccountClosed(accountID))
            {
                if (BankAccountFlow.CanOpenTransaction(TransactionTypes.CloseBankAccount, accountID))
                {
                    if (BankAccount.IsAccountEmpty(accountID))
                    {
                        string oldValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
                        string newValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccountStatus.Closed.ToString();
                        AuditTrail at = new AuditTrail(AuditTrailModules.CDReqAccClosure, oldValue, newValue);

                        if (at.Save())
                        {
                            if (BankAccount.RequestBankAccountClosure(accountID))
                            {
                                at.Commit();
                            }
                            else
                            {
                                at.RollBack();
                                basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureRequestFailure"));
                            }
                        }
                        else
                        {
                            basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureRequestFailure"));
                        }
                    }
                    else
                    {
                        basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureOnAccountWithBalance"));
                    }
                }
                else
                {
                    basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureRequestExists"));
                }
            }
            else
            {
                basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ClosureRequestOnWrongStatus"));
            }
        }
    }
}
