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
using System.DirectoryServices;

namespace ECX.CD.BL.Security
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
        CDApproveWHREdit,
		CDEditWHR,
        CDPrepareTT,
        CDTransferTitle,
		CDRequestPUNCancel,
		CDApprovePUNCancel,
		CDApproveWHR,
		CDRequestWHRCancel,
		CDApproveWHRCancel,
        CDCancelWHR,
        CDViewWHR,
        CDViewPUN,
        CDCreatePUN,
        CDCancelPUN,

        CDViewUP,
        CDConfirmUP,
        CDAuthoriseUP,

        CDViewForeclosure,
        CDConfirmForeclosure,
        CDAuthoriseForeclosure,

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
        CDViewPUNBalance

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
        public static string GetUserName(Guid guid)
        {
            return new ECX.CD.BL.ECXSecurity.ECXSecurityAccess().GetUserName(guid);
        }
    }
}
