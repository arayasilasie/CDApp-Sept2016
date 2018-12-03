using System;
using System.Data;
using System.Data.SqlClient;
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

/// <summary>
/// Summary description for ExtensionRequest
/// </summary>
/// 
public class ExtensionRequest
{
    #region Properties and Methods

    public Guid ID { get; set; }
    public string ExtensionFor { get; set; }
    public int PUNID { get; set; }
    public int WHRNo { get; set; }
    public double Quantity { get; set; }
    public string ReasonForExtenstion { get; set; }
    public string MemberIDNo { get; set; }
    public string MemberName { get; set; }
    public string ClientIDNo { get; set; }
    public string ClientName { get; set; }
    public DateTime TradeDate { get; set; }
    public Guid CommodityGradeID { get; set; }
    public string Symbol { get; set; }
    public DateTime DateRequested { get; set; }
    public DateTime LastExpiryDate{get;set;}
    public Guid WarehouseID { get; set; }
    public string WarehouseName { get; set; }
    public string RepName { get; set; }
    public string RepId { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedTimeStamp { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime LastModifiedTimeStamp { get; set; }   
    public Guid MemberID { get; set; } 
    public string RecievedBy { get; set; }
    public int SendTo { get; set; }
    public string GRNNumber { get; set; }
    public int Status { get; set; }

    #endregion

    public ExtensionRequest()
    {

        //
        // TODO: Add constructor logic here
        //
    }
    
    public void GetPUNforExtension(int PUNID)
    {
        SqlParameter [] paramList= new SqlParameter[1];
        SqlParameter param = new SqlParameter("PUNID",  SqlDbType.Int);
        param.Value = PUNID;
        paramList[0] = param;

        DataRow row = SQLHelper.getDataRow(CDBaseModel.ConnectionString, "GetPUNForExtension", PUNID);
        if (row != null)
        {
            this.PUNID = (int)row["PUNId"];
            this.WarehouseID = new Guid(row["WarehouseId"].ToString());
            this.WarehouseName = row["WarehouseName"].ToString();
            this.MemberIDNo = row["MemberIDNo"].ToString();
            this.MemberName = row["MemberName"].ToString();           
            this.MemberIDNo = row["MemberIDNo"].ToString();           
            this.ClientIDNo = row["ClientIDNo"].ToString();
            this.ClientName = row["ClientName"].ToString();
            this.CommodityGradeID = new Guid(row["CommodityGradeID"].ToString());
            this.Symbol = row["Symbol"].ToString();
            this.LastExpiryDate =(DateTime)row["LastExpiryDate"];
           
            this.WarehouseName = row["WarehouseName"].ToString();
            this.RepId = row["RepId"].ToString();
            this.RepName = row["RepName"].ToString();

            this.WHRNo = (int)row["WHRNo"];
            this.TradeDate = (DateTime)row["TradeDate"];
            this.Quantity=float.Parse(row["Quantity"].ToString());
        }
       // return row;
    }

    /// <summary>
    ///  it gets PickupNotic or WareHouse Recipt by WHRNo for Extending Expiry date request
    /// </summary>
    /// <param name="_WHRNo"></param> WareHouse Reciet No.
    /// <param name="spName"></param>
    /// <returns></returns>
    public static ExtensionRequest GetPUNforExtensions(int _WHRNo, string spName)
    {
        DataRow dr = null;
        dr = SQLHelper.getDataRow(CDBaseModel.ConnectionString, spName, _WHRNo);
        if (dr != null)
        {
            ExtensionRequest req = new ExtensionRequest();
            ECX.DataAccess.Common.DataRow2Object(dr, req);
            return req;
        }
        return null;
    }
    
    /// <summary>
    ///   it gets PickupNotic or WareHouse Recipt by WHRNo for Extending Expiry date request
    /// </summary>
    /// <param name="_WHRNo"></param>
    /// <param name="IsPUN"></param>
    /// <returns></returns>
    public static ExtensionRequest GetPUNforExtensions(int _WHRNo, bool IsPUN)
    {
        DataRow dr = null;

        if (IsPUN)
            dr = SQLHelper.getDataRow(CDBaseModel.ConnectionString, "GetPUNforExtensions", _WHRNo);
        else
            dr = SQLHelper.getDataRow(CDBaseModel.ConnectionString, "GetWHRForExtension", _WHRNo);

        if (dr != null)
        {
            ExtensionRequest req = new ExtensionRequest();
            ECX.DataAccess.Common.DataRow2Object(dr, req);
            return req;
        }
        return null;
    }
       
    /// <summary>
    ///  saves Extension Request data
    /// </summary>
    /// <returns></returns>
    public  object  InsertExtensionRequest()
    {
        return  SQLHelper.SaveAndReturn(CDBaseModel.ConnectionString, "AddExtensionRequest", this);
    }

    /// <summary>
    /// it gets all ExtensionRequest that are on process...
    /// </summary>
    /// <returns></returns>
    public static List<ExtensionRequest> GetExtensionRequestList()
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRequestPendingList");

        List<ExtensionRequest> reqList = new List<ExtensionRequest>();

        foreach (DataRow dr in dtbl.Rows)
        {
            ExtensionRequest req = new ExtensionRequest();
            ECX.DataAccess.Common.DataRow2Object(dr, req);
            reqList.Add(req);
        }


        return reqList;
    }
      
    ///// <summary>
    ///// 
    ///// </summary>
    ///// <returns></returns>
    //public static DataTable GetExtensionRequests()
    //{
    //    DataTable dtbl =
    //        SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRequestPendingList");

    //    return dtbl;
    //}

    /// <summary>
    ///  it gets all ExtensionRequest that are on process..
    /// </summary>
    /// <returns></returns>
    public static DataTable GetExtensionRequestPending()
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRequestPendingList");

        return dtbl;
    }

    /// <summary>
    /// it gets all ExtensionRequest that are on process.. per user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static DataTable GetExtensionRequestPending(Guid userId)
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRequestPendingsByUser", userId);

        return dtbl;
    }

    public static DataTable GetExtensionRequestPending(int userType)
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRequestPendingsByUser", userType);

        return dtbl;
    }

    public static DataTable GetExtRequestResponsePending(int userType)
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRequest_ResponseByStaus", userType);

        return dtbl;
    }
    //public static DataTable GetExtRequestResponsePending(int userType)
    //{
    //    DataTable dtbl =
    //        SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRequest_ResponseByUser", userType);

    //    return dtbl;
    //}

    /// <summary>
    /// it gets all ExtensionRequest that are on process.. per user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static DataTable GetExtensionRequestProcessedList()//Guid userId)
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetRequestProcessedList");//, userId);

        return dtbl;
    }

    /// <summary>
    /// Gets ExtensionRequestList acourding to searching creatria
    /// </summary>
    /// <param name="ExtensionFor"></param>
    /// <param name="ClientIDNo"></param>
    /// <param name="WHRNo"></param>
    /// <param name="DateRequestedStart"></param>
    /// <param name="DateRequestedEnd"></param>
    /// <param name="IsPending"></param>
    /// <returns></returns>
    public static DataTable GetExtensionRequestList(string ExtensionFor, int WHRNo, 
        string ClientIDNo, string MemberIDNo, DateTime RequestDateFrom, DateTime RequestDateTo, bool IsPending)
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetExtensionRequestList",
             ExtensionFor, WHRNo, ClientIDNo,MemberIDNo, RequestDateFrom, RequestDateTo, IsPending);

        return dtbl;
    }

	
    public static DataTable GetExtensionRequestSearchList(string ExtensionFor, int WHRNo,
       string ClientIDNo, string MemberIDNo, DateTime RequestDateFrom, DateTime RequestDateTo,
        bool IsPending, int ResponseTypeID,DateTime DateOutFrom,DateTime DateOutTo )
    {
        DataTable dtbl =
            SQLHelper.getDataTable(CDBaseModel.ConnectionString, "GetExtensionRequestSearchList",
             ExtensionFor, WHRNo, ClientIDNo, MemberIDNo, RequestDateFrom, RequestDateTo, IsPending,
             ResponseTypeID, DateOutFrom, DateOutTo);

        return dtbl;
    }
   
    public int InsertExtensionRequests()
    {
        // elias remove
        //return SQLHelper.SaveAndReturns(CDBaseModel.ConnectionString, "AddExtensionRequest", this);
        return 1;
    }

}
