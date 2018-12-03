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

public enum GRNStatus
{
    New = 0, Approved = 1, Cancelled = 2, Closed = 3
}

public enum WRStatus
{ Pending = 0, Approved = 1, Cancelled = 2 }

public enum Navigation
{
    None,
    First,
    Next,
    Previous,
    Last
}
