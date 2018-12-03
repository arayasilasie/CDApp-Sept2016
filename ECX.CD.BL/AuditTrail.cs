using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using ECX.CD.BL.ECXSecurity;
using ECX.CD.BL.Security;

namespace ECX.CD.BL.Security
{
    /// <summary>
    /// Summary description for AuditTrail
    /// </summary>
    public class AuditTrail
    {
        private ECXSecurityAccess sec;
        List<CAuditTrial> _auditData;
        public CAuditTrial[] AuditTrailData
        {
            get { return _auditData.ToArray(); }
        }
        
        #region Methods
        public AuditTrail(AuditTrailModules module, string oldValue, string newValue, Guid userGuid)
        {
            sec = new ECXSecurityAccess();
            sec.CookieContainer = new System.Net.CookieContainer();
            _auditData = new List<CAuditTrial>();
            Add(module, oldValue, newValue, userGuid);
        }


        /// <summary>
        /// Instantiate the AuditTrail Class with the first audit data.
        /// Add(,,) method can be used for more audit data.
        /// </summary>
        /// <param name="module">An instance of ECX.CD.Security.AuditTrailModules that describes the type of audit to be recorded.</param>
        /// <param name="oldValue">Concatenated value of the data before the change.
        /// E.g BankAccountID = 12; AccountNo = 147852; BankBranch = Bole;</param>
        /// <param name="newValue">Concatenated value of the data after the change.
        /// E.g BankAccountID = 12; AccountNo = 147852; BankBranch = Gotera;</param>
        public AuditTrail(AuditTrailModules module, string oldValue, string newValue)
        {
            sec = new ECXSecurityAccess();
            sec.CookieContainer = new System.Net.CookieContainer();
            _auditData = new List<CAuditTrial>();
            Add(module, oldValue, newValue);
        }
        
        /// <summary>
        /// Instantiate the AuditTrail Class with the first audit data.
        /// Add(,,) or Add(,) method can be used for more audit data.
        /// </summary>
        /// <param name="module">An instance of ECX.CD.Security.AuditTrailModules that describes the type of audit to be recorded</param>
        /// <param name="value">Concatenated value of the data action taken upon.
        /// E.g BankAccountID = 12; AccountNo = 147852;</param>
        public AuditTrail(AuditTrailModules module, string value)
        {
            sec = new ECXSecurityAccess();
            sec.CookieContainer = new System.Net.CookieContainer();
            _auditData = new List<CAuditTrial>();
            Add(module, value);
        }        
        
        /// <summary>
        /// Instantiate the AuditTrail Class with empty audit data.
        /// </summary>
        public AuditTrail()
        {
            sec = new ECXSecurityAccess();
            sec.CookieContainer = new System.Net.CookieContainer();
            _auditData = new List<CAuditTrial>();
        }


        public void Add(AuditTrailModules module, string oldValue, string newValue, Guid userGuid)
        {
            CAuditTrial auditData = new CAuditTrial();
            auditData.OldValue = oldValue;
            auditData.NewValue = newValue;
            auditData.UserGuid = userGuid;
            auditData.ModuleCode = module.ToString();

            _auditData.Add(auditData);
        }

        /// <summary>
        /// Add record change data to the AuditTrailData collection.
        /// </summary>
        /// <param name="module">An instance of ECX.CD.Security.AuditTrailModules enumeration that describes the type of AuditTrailData to be recorded.</param>
        /// <param name="oldValue">Concatenated value of the data before the change.
        /// E.g BankAccountID = 12; AccountNo = 147852; BankBranch = Bole;</param>
        /// <param name="newValue">Concatenated value of the data after the change.
        /// E.g BankAccountID = 12; AccountNo = 147852; BankBranch = Gotera;</param>
        public void Add(AuditTrailModules module, string oldValue, string newValue)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                throw new InvalidOperationException("There is no user Guid on the session object.");
            }

            CAuditTrial auditData = new CAuditTrial();
            auditData.OldValue = oldValue;
            auditData.NewValue = newValue;
            auditData.UserGuid = SecurityHelper.CurrentUserGuid.Value;
            auditData.ModuleCode = module.ToString();

            _auditData.Add(auditData);
        }
       
        /// <summary>
        /// Add action taken record to the AuditTrailData collection.
        /// </summary>
        /// <param name="module">An instance of ECX.CD.Security.AuditTrailModules that describes the type of audit to be recorded</param>
        /// <param name="value">Concatenated value of the data action taken upon.
        /// E.g BankAccountID = 12; AccountNo = 147852;</param>
        public void Add(AuditTrailModules module, string value)
        {
            if (!SecurityHelper.CurrentUserGuid.HasValue)
            {
                throw new InvalidOperationException("There is no user Guid on the session object.");
            }

            CAuditTrial auditData = new CAuditTrial();
            auditData.OldValue = value;
            auditData.NewValue = string.Empty;
            auditData.UserGuid = SecurityHelper.CurrentUserGuid.Value;
            auditData.ModuleCode = module.ToString();

            _auditData.Add(auditData);
        }
        
        /// <summary>
        /// Saves the AuditTrailData collection using a transaction.
        /// 
        /// The transaction should be commited or rolled back.
        /// </summary>
        /// <returns>Returns true if the AuditTrailData collection is saved. Otherwise it returns false.</returns>
        public bool Save()
        {        
            if (_auditData.Count == 0)
            {
                return false;
            }
            else if (_auditData.Count == 1)
            {
                return sec.AddAuditTrail(_auditData[0].ModuleCode, _auditData[0].UserGuid, _auditData[0].OldValue, _auditData[0].NewValue);
            }
            else
            {
                return sec.AddAuditTrails(_auditData.ToArray());
            }            
        }

        /// <summary>
        /// Rolls back the transaction created by Save operation.
        /// </summary>
        public void RollBack()
        {
            sec.AuditTrailRollback();
        }

        /// <summary>
        /// Commits the transaction created by Save operation.
        /// </summary>
        public void Commit()
        {
            sec.AuditTrailCommit();
        }
        #endregion Methods
    }
    public enum AuditTrailModules
    {
        CDLoginSuccess = 0,
        CDLoginFailure,
        CDLogOut,
        CDAddNewAccount,
        CDRequestAccountClosure,
        CDRequestAccountSuspension,
        CDRequestAccountResumption,
        CDApproveNewAccount,
        CDApproveAccountSuspension,
        CDApproveAccountResumption,
        CDApproveAccountClosure,

        CDRejectAccountSuspension,
        CDRejectAccountResumption,
        CDRejectAccountClosure,
        
        CDRequestAccountModification,
        CDTakeSnapshot,
        CDRequestWHREdit,
        CDApproveWHREdit,
        CDEditWHR,
        CDPrepareTT,
        CDTransferTitle,
        CDApproveWHR,
        CDCancelWHR,
        CDCreatePUN,

        WRFSavePR,
        WRFConfirmPR,
        WRFAuthorizePR,
        WRFRejectPR,

        WRFSaveLNS,
        WRFConfirmLNS,
        WRFAuthorizeLNS,
        WRFRejectLNS,

        WRFSaveUP,
        WRFConfirmUP,
        WRFAuthorizeUP,
        WRFRejectUP,

        WRFSaveFR,
        WRFConfirmFR,
        WRFAuthorizeFR,
        WRFRejectFR,

        WRFSavePRML,
        WRFConfirmPRML,
        WRFConfirmEmptyPRML,
        WRFAuthorizePRML,
        WRFAuthorizeEmptyPRML,
        WRFRejectPRML,

        WRFSaveCWHR,
        WRFConfirmCWHR,
        WRFAuthorizeCWHR,
        WRFRejectCWHR,

        CDApproveWHRExtendExpiryDate,
        CDRejectWHRExtendExpiryDate,
        CDApprovePUNExtendExpiryDate,
        CDRejectPUNExtendExpiryDate,
        CDApprovePUNCancel,
        CDRejectPUNCancel,
        CDApprovePUNEdit,
        CDRejectPUNEdit
    }
}