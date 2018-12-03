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

/// <summary>
/// Summary description for IFLookup
/// </summary>
public class IFLookup
{
    public IFLookup()
    {        
    }

    public static string GetMC(Guid mcGuid)
    {
        return mcGuid.ToString().Substring(0,4);
    }
}
