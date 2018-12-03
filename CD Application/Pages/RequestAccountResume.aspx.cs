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

public partial class Pages_RequestAccountResume : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!SecurityHelper.HasPermission(CDSecurityRights.CDResumeAccount))
        {
            ErrorHandler.RedirectToErrorPage(SettingAccessor.GetSetting("Err:NoPermissionToRequestResumption"));
        }
        else
        {
            ((MasterPage_pTop)this.Master).DescriptionText = "Request Bank Account Resume";
        }
    }
    protected void btnResume_Click(object sender, EventArgs e)
    {
        foreach (Guid accountID in basBankAccountSearch.SelectedBankAccounts)
        {
            if (BankAccount.IsAccountSuspended(accountID))
            {
                if (BankAccountFlow.CanOpenTransaction(TransactionTypes.ResumeBankAccount, accountID))
                {
                    string oldValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccount.GetBankAccountStatus(accountID).ToString();
                    string newValue = "BankAccountID = " + accountID.ToString() + "; " + "Status = " + BankAccountStatus.Open.ToString();
                    AuditTrail at = new AuditTrail(AuditTrailModules.CDReqAccResumption, oldValue, newValue);

                    if (at.Save())
                    {
                        if (BankAccount.RequestBankAccountResume(accountID))
                        {
                            at.Commit();
                        }
                        else
                        {
                            at.RollBack();
                            basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionRequestFailure"));
                        }
                    }
                    else
                    {
                        basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionRequestFailure"));
                    }
                }
                else
                {
                    basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionRequestExists"));
                }
            }
            else
            {
                basBankAccountSearch.MarkErroneousRow(accountID, SettingAccessor.GetSetting("Err:ResumptionRequestOnWrongStatus"));
            }
        }
    }
}
