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

namespace ECX.CD.Security
{
    /// <summary>
    /// Summary description for ErrorHandler
    /// </summary>
    public class ErrorHandler
    {
        public ErrorHandler()
        {

        }
        public static void RedirectToErrorPage(string errorDescription)
        {
            if (errorDescription.Length > 0)
            {
                HttpContext.Current.Response.Redirect("~/Pages/Error.aspx?err=" + errorDescription, false);
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Pages/Error.aspx", false);
            }
        }
        public static void RedirectToErrorPage(int errorCode)
        {
            if (errorCode > 0)
            {
                HttpContext.Current.Response.Redirect("~/Pages/Error.aspx?err=Code is " + errorCode.ToString(), false);
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Pages/Error.aspx", false);
            }
        }
        public static void RedirectToSessionExpiredPage()
        {
            HttpContext.Current.Response.Redirect("~/Pages/SessionExpired.aspx");
        }

        public static int WriteLogEntry(string exceptionType, string shortMessage, string fullMessage, string remark)
        {
            MainDataContextDataContext db = new MainDataContextDataContext();

            tblExceptionLog exception = new tblExceptionLog();
            exception.Id = Guid.NewGuid();
            exception.ExceptionDate = DateTime.Now;

            exception.ExceptionType = exceptionType;
            exception.ShortMessage = shortMessage;
            exception.FullMessage = fullMessage;
            exception.Remark = remark;
            try
            {
                exception.UserGuid = SecurityHelper.CurrentUserGuid;
                exception.UserName = SecurityHelper.CurrentUserName;
            }
            catch
            {
            }
            
            var id = db.spInsertException(
                Guid.NewGuid(), 
                DateTime.Now, 
                exceptionType, 
                shortMessage, 
                fullMessage, 
                SecurityHelper.CurrentUserName,
                SecurityHelper.CurrentUserGuid,
                remark);

            int idNo = -999;
            int.TryParse(id.ReturnValue.ToString(), out idNo);

            db.Dispose();
            
            return idNo;
        }
        public static int WriteLogEntry(string exceptionType, string shortMessage, string fullMessage)
        {
            return WriteLogEntry(exceptionType, shortMessage, fullMessage, null);
        }
        public static int WriteLogEntry(Exception ex)
        {
            return WriteLogEntry(ex.Source, ex.Message, ex.ToString(), null);
        }
        public static int WriteLogEntry(Exception exception, string remark)
        {
            return WriteLogEntry(exception.Source, exception.Message, exception.ToString(), remark);
        }
    }
}