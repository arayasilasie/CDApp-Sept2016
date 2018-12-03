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
using ECXSecurity;
using System.DirectoryServices;
using ECX.CD.Security;

namespace ECX.CD.Security
{
    public enum CDSecurityRights
    {
        CDViewAccount = 0,
        CDNewAccount,
        CDOpenAccount,
        CDCloseAccount,
        CDSuspendAccount,
        CDResumeAccount,
        CDAppCloAcc,
        CDAppSusAcc,
        CDAppResAcc,
        CDModifyAccount,
        CDViewMCP,
        CDViewAllMemberMCP,
        CDTakeSnapshot,
        CDViewDeliveryNotice,


        CDViewApprovedAndNewWHRs,
        CDViewMAT,
        CDApproveWHREdit,
        CDRequestWHREdit,
        CDReqWHRExtendExpiry,
        CDAppWHRExtendExpiry,
        CDPrepareTT,
        CDTransferTitle,
        CDRequestPUNCancel,
        CDApprovePUNCancel,
        CDApproveWHR,
        CDEditWHRStatus,
        CDEditWHRRemark,
        CDRequestWHRCancel,
        CDApproveWHRCancel,
        CDCancelWHR,
        CDViewWHR,
        CDViewPUN,
        CDCreatePUN,
        CDCancelPUN,
        CDReqPUNExtendExpiry,
        CDAppPUNExtendExpiry,
        CDApprovePUNEdit,
        CDRequestPUNEdit,
        CDViewGIN,

        CDViewUP,
        CDConfirmUP,
        CDAuthoriseUP,

        CDViewFR,
        CDConfirmFR,
        CDAuthoriseFR,

        CDViewPRML,
        CDConfirmPRML,
        CDAuthorisePRML,

        CDViewPR,
        CDConfirmPR,
        CDAuthorisePR,

        CDViewLNS,
        CDConfirmLNS,
        CDAuthoriseLNS,

        CDViewCheck,
        CDConfirmCheck,
        CDAuthoriseCheck,

        CDManageAccount,
        CDViewException,
        CDManageClientAcc,

        CDViewMCPArchive,
        CDViewWHRPrint,
        CDViewDNSignSheet,
        CDViewWHRExpNotice,

        CDAppPUNEdit,
        CDReqWHRCancellation,
        CDApprovePUN,
        CDViewPUNBalance,
        CDViewTradableWHR,
        CDViewExpiryNoticeLetter,

        MRPUNExt,
        WHPUNExt,
        CDPUNExt,
        COOPUNExt,
        TRDPUNExt,

        CDMRAccess,

        MRWHRApprovalView

    }
    enum SecurityPermissions
    {
        NotAssigned = 0,
        Grant = 1,
        Deny = 2,
        GrantAllLocation = 3
    }

    public class SecurityHelper
    {
        public SecurityHelper()
        {
        }
        public static Guid? CurrentUserGuid
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return Guid.Empty;
                }

                Guid? currentUserGuid = HttpContext.Current.Session["CurrentUserGuid"] as Guid?;
                if (!currentUserGuid.HasValue)
                {
                    return Guid.Empty;
                }
                else
                {
                    return currentUserGuid.Value;
                }
            }
            set
            {
                HttpContext.Current.Session["CurrentUserGuid"] = value;
            }
        }
        public static List<CDSecurityRights> CurrentUserRights
        {
            get
            {
                return (List<CDSecurityRights>)System.Web.HttpContext.Current.Session["UserRights"];
            }
        }
        public static string CurrentUserName
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }

                string userName = HttpContext.Current.User.Identity.Name.Remove(0, HttpContext.Current.User.Identity.Name.LastIndexOf(@"\") + 1);
                userName = userName.Replace('.', ' ');
                return userName;
            }
        }
        public static Guid? GetUserGuid(string userName, string userPassword)
        {
            ECXSecurityAccess sec = new ECXSecurityAccess();
            Guid userGuid = Guid.Empty;
            AuthenticationStatus s = sec.IsAuthenticated(userName, userPassword, "ECXCD", out userGuid);
            if (userGuid == Guid.Empty)
            {
                return null;
            }
            return userGuid;
        }

        //private Guid? GetUser(string UserName)
        //{
        //    try
        //    {
        //        DirectoryEntry de = new DirectoryEntry(ConfigurationManager.AppSettings["DirPath"]);
        //        de.Username = ConfigurationManager.AppSettings["ACDUser"];
        //        de.Password = ConfigurationManager.AppSettings["ACDPass"];

        //        DirectorySearcher deSearch = new DirectorySearcher();
        //        deSearch.SearchRoot = de;

        //        deSearch.Filter = "(&(objectClass=user))";
        //        deSearch.SearchScope = SearchScope.Subtree;
        //        //deSearch.Sort = new SortOption();
        //        //deSearch.Sort.Direction = System.DirectoryServices.SortDirection.Ascending;

        //        SearchResultCollection results = deSearch.FindAll();

        //        for (int i = 0; i < results.Count; i++)
        //        {
        //            //if (results[i].GetDirectoryEntry().Name.Remove(0, 3).Replace(" ", ".").ToUpper() == UserName.ToUpper())
        //            if (results[i].GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString().ToUpper() == UserName.ToUpper())
        //            {
        //                return results[i].GetDirectoryEntry().Guid;
        //            }
        //        }
        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public static Guid? GetUserGuid()
        {
            try
            {
                string UserName = HttpContext.Current.User.Identity.Name.Remove(0, HttpContext.Current.User.Identity.Name.LastIndexOf(@"\") + 1);

                DirectoryEntry de = new DirectoryEntry(ConfigurationManager.AppSettings["DirPath"]);
                de.Username = ConfigurationManager.AppSettings["ACDUser"];
                de.Password = ConfigurationManager.AppSettings["ACDPass"];

                DirectorySearcher deSearch = new DirectorySearcher();
                deSearch.SearchRoot = de;

                deSearch.Filter = "(&(objectClass=user)(sAMAccountName=" + UserName + "))";
                deSearch.SearchScope = SearchScope.Subtree;

                SearchResultCollection results = deSearch.FindAll();

                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].GetDirectoryEntry().Properties["sAMAccountName"].Value.ToString().ToUpper() == UserName.ToUpper())
                    {
                        return results[i].GetDirectoryEntry().Guid;
                    }
                }

                //for (int i = 0; i < results.Count; i++)
                //{
                //    if (results[i].GetDirectoryEntry().Name.Remove(0, 3).Replace(" ", ".").ToUpper() == UserName.ToUpper())
                //    {
                //        return results[i].GetDirectoryEntry().Guid;
                //    }
                //}

                return null;
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteLogEntry(ex);
                return null;
            }
        }

        static bool HasPermission(Guid userGuid, CDSecurityRights securityRight)
        {
            List<CDSecurityRights> rights = (List<CDSecurityRights>)System.Web.HttpContext.Current.Session["UserRights"];
            return rights.Contains(securityRight);
        }
        public static bool HasPermission(CDSecurityRights securityRight)
        {
            if (SecurityHelper.CurrentUserGuid.HasValue)
            {
                return HasPermission(SecurityHelper.CurrentUserGuid.Value, securityRight);
            }
            else
            {
                ErrorHandler.RedirectToSessionExpiredPage();
                return false;
            }
        }
        public static List<CDSecurityRights> GetUserRights(Guid userGuid)
        {
            ECXSecurityAccess sec = new ECXSecurityAccess();
            string[] rights = Enum.GetNames(typeof(CDSecurityRights));
            float[] permission = new float[] { };
            try
            {
                permission = sec.HasRights(userGuid, rights, "");
            }
            catch (Exception ex)
            {
                ErrorHandler.WriteLogEntry(ex);
                ErrorHandler.RedirectToErrorPage("Communication with security server failed.");
            }

            List<CDSecurityRights> userRights = new List<CDSecurityRights>();
            if (permission.Count() == rights.Count())
            {
                for (int i = 0; i < permission.Count(); i++)
                {
                    if ((SecurityPermissions)permission[i] == SecurityPermissions.Grant || (SecurityPermissions)permission[i] == SecurityPermissions.GrantAllLocation)
                    {
                        userRights.Add((CDSecurityRights)Enum.Parse(typeof(CDSecurityRights), rights[i]));
                    }
                }
            }
            return userRights;
        }

        public static string GetRightDisplayName(CDSecurityRights right)
        {
            switch (right)
			{
				case CDSecurityRights.CDApproveWHRCancel:
					return "Approve WHR Cancel";
				case CDSecurityRights.CDCancelWHR:
					return "Cancel WHR";
				case CDSecurityRights.CDApprovePUNCancel:
					return "Approve PUN Cancel";
				case CDSecurityRights.CDCancelPUN:
					return "Cancel PUN";
				case CDSecurityRights.CDApproveWHREdit:
					return "Approve WHR Edit Request";
				case CDSecurityRights.CDPrepareTT:
					return "Prepare Title Transfer";
				case CDSecurityRights.CDTransferTitle:
					return "Transfer Title";
				//case CDSecurityRights.CDApproveWHR:
				//    return "Approve WHR";
				case CDSecurityRights.CDViewWHR:
					return "View WHR";
                case CDSecurityRights.CDNewAccount:
                    return "Add New Bank Account";
                case CDSecurityRights.CDOpenAccount:
                    return "Open/Activate New Bank Account";
                case CDSecurityRights.CDAppCloAcc:
                    return "Approve Bank Account Closure";
                case CDSecurityRights.CDAppSusAcc:
                    return "Approve Bank Account Suspension"; ;
                case CDSecurityRights.CDAppResAcc:
                    return "Approve Bank Account Resumption"; ;
                default:
                    return string.Empty;
            }
        }

        public static string GetUserName(Guid guid)
        {
            return new ECXSecurityAccess().GetUserName(guid);
        }
    }
}
