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
using ECX.DataAccess;

public class PUN:PUNExtension
{
    public PUN()
    {

    }

    public void PrintPUN(List<Guid> selectedPUNIds)
    {
        if (selectedPUNIds.Count > 0)
        {
            System.Web.HttpContext.Current.Session["PUNIDList"] = selectedPUNIds;
            System.Web.HttpContext.Current.Response.Redirect("~/Reports/PUNViewer.aspx");
        }
    }

    public static DataTable GetPUNList(int PUNId, int PUNId2, int WHRId, int WHRId2, int Status, string ClientId, Guid WarehouseId, DateTime ExpirationDate, DateTime ExpirationDate2, DateTime PickupDate, DateTime PickupDate2, DateTime CreatedDate, DateTime CreatedDate2, DateTime TradeDate, DateTime TradeDate2)
    {
        return SQLHelper.getDataTable(ConnectionString, "GetPUNs", PUNId, PUNId2, WHRId, WHRId2, Status, ClientId, WarehouseId, ExpirationDate, ExpirationDate2, PickupDate, PickupDate2, CreatedDate, CreatedDate2, TradeDate, TradeDate2);
    }
}
