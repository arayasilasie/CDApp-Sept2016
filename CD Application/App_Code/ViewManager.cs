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
using System.Web.SessionState;

public class ViewManager
{
    public ViewManager()
    {

    }

    #region ShowPages

    public static void ShowPUNDetail(HttpSessionState session, Page page)
    {
        ShowNonModalPopupPage(session, page, "../Pages/PUNDetail.aspx", 870, 500);
    }

    public static void ShowGIN(HttpSessionState session, Page page)
    {
        ShowNonModalPopupPage(session, page, "../Pages/GIN.aspx", 600, 400);
	}

	public static void ShowWRDetail(HttpSessionState session, Page page, int whrNo)
	{
		session.Add("WRId", new ECX.CD.BL.WarehouseReciept().GetWRGuid(whrNo));
		
		page.Response.Redirect("../Pages/WRDetail.aspx");		
	}

	public static void ShowWRDetail(HttpSessionState session, Page page, Guid whrId)
	{
		session.Add("WRId", whrId);

		ShowNonModalPopupPage(session, page, "../Pages/WRDetail.aspx", 870, 500);
	}

	public static void ShowWRHistory(HttpSessionState session, Page page, int whrId)
	{
		session.Add("WRId", whrId);

		ShowNonModalPopupPage(session, page, "../Pages/WHRHistory.aspx", 870, 500);
	}

	public static void ShowWRDetail(HttpSessionState session, Page page)
	{
		ShowNonModalPopupPage(session, page, "../Pages/WRDetail.aspx", 870, 500);
	}

    public static void ShowNonModalPopupPage(HttpSessionState session, Page page, string pageUrl, int pageWidth, int pageHeight)
    {
		string script =
			"<script language=\"\"javascript\"\">window.open('" + pageUrl +
			"', 'win2','height=" + pageHeight + ",width=" + pageWidth.ToString() +
			", resizable=yes,scrollbars=yes');</script>";

        page.RegisterStartupScript("JavaScript", script);
	}

    public static void ShowModalPage(HttpSessionState session, Page page, string pageUrl, int pageWidth, int pageHeight)
    {
        string script = "<script language=\"\"javascript\"\">window.open('" + pageUrl +
            "', null,'height=" + pageHeight + ",width=" + pageWidth.ToString() + "');</script>";

        page.RegisterStartupScript("JavaScript", script);
    }

    #endregion
}