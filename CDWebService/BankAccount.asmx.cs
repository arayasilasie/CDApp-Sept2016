using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace CD_Web_Service
{
    /// <summary>
    /// Summary description for BankAccount
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BankAccount : System.Web.Services.WebService
    {
        [WebMethod]
        public void AddBankAccounts(Guid memberGuid, string reason, Guid userGuid)
        {
            ECX.CD.BL.BankAccount.StartAddAccountTransaction(memberGuid, userGuid);
        }
        [WebMethod]
        public void CloseBankAccounts(Guid memberGuid, string reason, Guid userGuid)
        {
            ECX.CD.BL.BankAccount.StartClosureTransaction(memberGuid, userGuid);
        }
        [WebMethod]
        public void SuspendBankAccounts(Guid memberGuid, string reason, Guid userGuid)
        {
            ECX.CD.BL.BankAccount.StartSuspensionTransaction(memberGuid, userGuid);            
        }
        //[WebMethod]
        //public void ResumeBankAccounts(Guid memberGuid, string reason, Guid userGuid)
        //{            
        //}

        [WebMethod]
        public bool HasClearingAccounts(Guid memberGuid)
        {
            return ECX.CD.BL.BankAccount.HasClearingAccounts(memberGuid);
        }

        [WebMethod]
        public void MembershipClassChanged(Guid memberGuid, int oldClassId, int newClassId)
        {
        }
        [WebMethod]
        public void ModifyBankAccounts(Guid memberGuid, string reason, Guid userGuid)
        {
        }
    
        [WebMethod]
        public bool ClientHasOpenAccounts(Guid clientGuid)
        {
            return ECX.CD.BL.BankAccount.ClientHasOpenAccounts(clientGuid);
        }
    }
}
