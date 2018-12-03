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

namespace ECX.CD
{
    /// <summary>
    /// Summary description for SettingAccessor
    /// </summary>
    public class SettingAccessor
    {
        public SettingAccessor()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}