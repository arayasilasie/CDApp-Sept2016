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

public class UrlFactory
{
	public UrlFactory()
	{
		
	}

	public static string GetUrl(string pageName)
	{
		switch (pageName)
		{
			case Pages.Inbox:
				return "~/Pages/Inbox.aspx";
			default:
				return "";
		}
	}
}
