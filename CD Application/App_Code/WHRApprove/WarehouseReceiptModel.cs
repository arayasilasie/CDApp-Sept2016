using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using ECX.DataAccess;
public class CDBaseModel
{
    public static string ConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["dbCentralDepositoryConnectionString"].ConnectionString;
        }
    }
    
}

/// <summary>
/// Summary description for WarehouseReceiptModel
/// </summary>
public class WarehouseReceiptModel : CDBaseModel
{
    public Guid ID { get; set; }
    public int WHRID { get; set; }
    public string ClientIDNo { get; set; }
    public string ClientName { get; set; }
    public string GRNNo { get; set; }
    public string Symbol { get; set; }
    public Guid CommodityID { get; set; }
    public Guid CommodityClassID { get; set; }
    public int CommodityGroupIID { get; set; }
    public float LotSizeInBag { get; set; }
    public int DaysToExpire { get; set; }
    public string Warehouse { get; set; }
    public int ProductionYear { get; set; }
    public double Quantity { get; set; }
    public double Weight { get; set; }
    public int BagTypeID { get; set; }
    public string BagType { get; set; }
    public int NumberOfBags { get; set; }
    public bool IsClient { get; private set; }
    public bool IsCoffee { get; set; }
    public DateTime CreatedTimeStamp { get; set; }
    public DateTime DateApproved { get; set; }
    public string DateApprovedString { get; set; }
  
    public string DateExpired { get; set; }
    public decimal OriginalQuantity { get; set; }
    public decimal CurrentQuantity { get; set; }
    public int ConsignmentType
    {
        get;
        set;
    }
    public DateTime ExpiryDate
    {
        get
        {
            return DateTime.Today.AddDays(DaysToExpire);
        }
    }
    public string Status { get; set; }
    public string WHRStatus { get; set; }
    public double WeightDev
    {
        get;
        private set;
    }

    public string Reason { get; set; }

    public DateTime LicenseExpiryDate { get; set; }

    public string ErrorMessage
    {
        get
        {
            string message = string.Empty;
            if (!IsActive)
                message += "Status;";
            //if (!GoodTolerance)
            //    message += "Weight;";
            if (!ValidBagType)
                message += "BagType;";
            if (!HasMCA)
                message += "License/Agreement;";
            return message;
        }
    }

    public bool HasMCA { get; private set; }
    public bool ValidBagType
    {
        get;
        private set;

    }
    public bool GoodTolerance
    {
        get { return WeightDev < 4; }
    }
    public bool IsActive { get { return Status.ToLower() == "active"; } }


    public bool Checked
    {
        get;
        set;
    }
    public string Remark { get; set; }
    private WarehouseReceiptModel()
    {

    }
    private static Dictionary<int, Dictionary<int, BagTypeModel>> indexedBagTypes;
    private static List<MemberClientModel> activeClientList;

    public static List<WarehouseReceiptModel> GetReportList(DateTime fromDate, DateTime toDate, bool approvedList )
    {
       
        string spName = "getApprovedWHR";
        if(approvedList)
            spName = "getApprovedWHR";
        else
             spName = "getRejectedWHR";

        List<WarehouseReceiptModel> lst = new List<WarehouseReceiptModel>();
        DataTable dt = new DataTable();
        ECX.DataAccess.SQLHelper.PopulateTable(ConnectionString, dt, spName, fromDate, toDate);
        foreach (DataRow dr in dt.Rows)
        {
            WarehouseReceiptModel b = new WarehouseReceiptModel();
            ECX.DataAccess.Common.DataRow2Object(dr, b);
            lst.Add(b);
        }
        return lst;
    }

   
    public static List<WarehouseReceiptModel> GetData()
    {
        GetBagTypes();
        activeClientList = MemberClientModel.GetData();
        string spName = "spGetNewWarehouseReceipts";
        return PopulateList(spName);
        
    }

    private static void GetBagTypes()
    {
        List<BagTypeModel> bagTypes = BagTypeModel.GetData();
        indexedBagTypes = new Dictionary<int, Dictionary<int, BagTypeModel>>();
        var v = from bg in bagTypes
                orderby bg.BagTypeID
                select bg;
        Dictionary<int,BagTypeModel> dic;
        foreach (BagTypeModel bg in v)
        {
            if (indexedBagTypes.ContainsKey(bg.BagTypeID))
                dic = indexedBagTypes[bg.BagTypeID];
            else
            {
                dic = new Dictionary<int, BagTypeModel>();
                indexedBagTypes.Add(bg.BagTypeID,dic);
            }
            if (!dic.ContainsKey(bg.CommodityGroupIID))
                dic.Add(bg.CommodityGroupIID, bg);
        }
    }

    private static bool  IsClientActive( string IdNo, Guid commodityClassID, Guid commodityID)
    {       
            return activeClientList.Exists(m => m.IDNo == IdNo &&
                    (m.CommodityID == commodityClassID ||
                     m.CommodityID == commodityID));
        
    }
    
    private static DataTable GetMemberClientStatus()
    {
        DataTable dt = new System.Data.DataTable();
        //spGetWarehouseReceiptClientStatus

        return dt;
    }
   
    public static List<WarehouseReceiptModel> GetRejected()
    {

        string spName = "spGetNonApprovedWarehouseReceipts";
        return PopulateList(spName);
    }

    private static List<WarehouseReceiptModel> PopulateList(string spName)
    {
        List<WarehouseReceiptModel> lst = new List<WarehouseReceiptModel>();
        DataTable dt = new DataTable();
        ECX.DataAccess.SQLHelper.PopulateTable(ConnectionString, dt, spName);
       

        foreach (DataRow dr in dt.Rows)
        { 
            WarehouseReceiptModel b = new WarehouseReceiptModel();
            try
            {
               
                ECX.DataAccess.Common.DataRow2Object(dr, b);
                BagTypeModel bg;
                //if (b.GRNNo == "10626754")
                //{
                //    string xxxc = "";


                //}
                try
                {
                    b.ValidBagType = indexedBagTypes.ContainsKey(b.BagTypeID);
                }
                catch
                {
                    b.ValidBagType = false;
                }
                
                if (b.ValidBagType)
                {
                    //if (b.ClientIDNo == "C1117059")
                    //{
                        bg = indexedBagTypes[b.BagTypeID][b.CommodityGroupIID];
                        double calcWeight = b.Quantity * b.LotSizeInBag * (b.IsCoffee ? bg.Capacity : 1);
                        b.WeightDev = Math.Abs(b.Weight - calcWeight) * 100 / b.Weight;
                        b.HasMCA = IsClientActive(b.ClientIDNo, b.CommodityClassID, b.CommodityID);
                        b.NumberOfBags = Convert.ToInt16(dr["NumberOfBags"].ToString());
                  // }
                }
                else
                {
                    b.WeightDev = 10;
                    b.HasMCA = false;
                }
                

            }
            catch
            { 
                //b.Status = "error";
            }
            finally
            {
               
                lst.Add(b);
               
            }
        }
        return lst;
    }


    public static List<WarehouseReceiptModel> GetWarehouseReceipts(string GRNNo)
    {
        List<WarehouseReceiptModel> lst = new List<WarehouseReceiptModel>();

        GetBagTypes();
        activeClientList = MemberClientModel.GetData();


        DataTable dt = SQLHelper.getDataTable(ConnectionString, "GetWarehouseReceipts", GRNNo);
        foreach (DataRow dr in dt.Rows)
        {
            WarehouseReceiptModel b = new WarehouseReceiptModel();
            ECX.DataAccess.Common.DataRow2Object(dr, b);
            BagTypeModel bg;
          
            b.ValidBagType = indexedBagTypes.ContainsKey(b.BagTypeID);
            if (b.ValidBagType && indexedBagTypes[b.BagTypeID].ContainsKey(b.CommodityGroupIID))
            {
                bg = indexedBagTypes[b.BagTypeID][b.CommodityGroupIID];
                double calcWeight = b.Quantity * b.LotSizeInBag * (b.IsCoffee ? bg.Capacity : 1);
                b.WeightDev = Math.Abs(b.Weight - calcWeight) * 100 / b.Weight;
                b.HasMCA = IsClientActive(b.ClientIDNo, b.CommodityClassID, b.CommodityID);
            }
            lst.Add(b);
        }
        return lst;

    }

    public static DataTable GetWarehouseReceipt(int WHRNo)
    {
        return SQLHelper.getDataTable(ConnectionString, "GetWarehouseReceipt", WHRNo);
    }


    public static void HoldWHR(int WHRNo, int PreviousStatus, string Reason, Guid CreatedBy, DateTime CreatedTimeStamp, string HoldBy)
    {
        SQLHelper.execNonQuery(ConnectionString, "HoldWHR", WHRNo, PreviousStatus, Reason, CreatedBy, CreatedTimeStamp, HoldBy);
    }

    public static DataTable GetHoldWHR(int WHRNo)
    {
        return SQLHelper.getDataTable(ConnectionString, "GetHoldWHR", WHRNo);
    }

    public static void ReleaseWHR(int WHRNo, Guid LastModifiedBy, DateTime LastModifiedTimeStamp, string RealsedBy)
    {
        SQLHelper.execNonQuery(ConnectionString, "ReleaseWHR", WHRNo, LastModifiedBy, LastModifiedTimeStamp, RealsedBy);
    }

    public static void CancelWHRForGRNCancellation(string GRNNo, Guid CreatedBy, DateTime CreatedTimeStamp)
    {
        SQLHelper.execNonQuery(ConnectionString, "CancelWHRForGRNCancellation", GRNNo, CreatedBy, CreatedTimeStamp);
    }

    private static string GetXMLForm(List<WarehouseReceiptModel> lst)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        string xml = "<warehouseReceiptInfo> ";
        xml += "<ID>@@1</ID> ";
        xml += "<WHRID>@@2</WHRID> ";
        xml += "<InvalidStatus>@@3</InvalidStatus> ";
        xml += "<InvalidWeight>@@4 </InvalidWeight>  ";
        xml += "<InvalidBagType>@@5</InvalidBagType>  ";
        xml += "<InvalidMembership>@@6</InvalidMembership>  ";
        xml += "<Remark>@@7</Remark>  ";
        xml += "<DaysToExpire>@@8</DaysToExpire>  ";
        xml += "</warehouseReceiptInfo>  ";
        sb.Append("<warehouseReceipts> ");
        foreach (WarehouseReceiptModel ob in lst)
        {
            if (!ob.Checked) continue;
            string s = xml.Replace("@@1", ob.ID.ToString());
            s = s.Replace("@@2", ob.WHRID.ToString());
            s = s.Replace("@@3", (ob.IsActive ? "0" : "1"));
            s = s.Replace("@@4", (ob.GoodTolerance ? "0" : "0"));
            s = s.Replace("@@5", (ob.ValidBagType ? "0" : "1"));
            s = s.Replace("@@6", (ob.HasMCA ? "0" : "1"));
            s = s.Replace("@@7", ob.Remark);
            s = s.Replace("@@8", ob.DaysToExpire.ToString());
            sb.Append(s);

        }
        sb.Append("");
        sb.Append("</warehouseReceipts>");
        return sb.ToString();
    }

    public static void Approve(List<WarehouseReceiptModel> lst , Guid userId)
    {

        string xml = GetXMLForm(lst);
        ECX.DataAccess.SQLHelper.ExecuteSP(ConnectionString, "spApproveWHR", xml, userId);


    }

    public static void ApproveRejected(List<WarehouseReceiptModel> lst, Guid userId)
    {

        string xml = GetXMLForm(lst);
        ECX.DataAccess.SQLHelper.ExecuteSP(ConnectionString, "spApproveRejectedWHR", xml, userId);


    }
    


    public static DataTable GetWHRStatusList()
    {
        DataTable dtbl =
            SQLHelper.getDataTable(ConnectionString, "GetWHRStatusList");
        return dtbl;
    }
    
}
public class MemberClientModel:CDBaseModel
{
    public Guid ClientID { get; set; }
    public string IDNo { get; set; }
    public string FullName { get; set; }
    public Guid MemberID {get;set;}
    public Guid CommodityID { get; set; }

    public static List<MemberClientModel> GetData()
    {
        string spName = "spGetWarehouseReceiptClientStatus";
        List<MemberClientModel> lst = new List<MemberClientModel>();
        DataTable dt = new DataTable();
        ECX.DataAccess.SQLHelper.PopulateTable(ConnectionString, dt, spName);
        foreach (DataRow dr in dt.Rows)
        {
                MemberClientModel b = new MemberClientModel();
                ECX.DataAccess.Common.DataRow2Object(dr, b);
                lst.Add(b);
        }
        return lst;
    }
   

    //
}
public class BagTypeModel:CDBaseModel
{
    public int BagTypeID {get;set;}
    public int CommodityGroupIID {get;set;}
    public double Capacity {get;set;}

   public static List<BagTypeModel>   GetData()
    {
        string spName = "getBagTypes";
        List<BagTypeModel> lst = new List<BagTypeModel>();
        DataTable dt = new DataTable();
        ECX.DataAccess.SQLHelper.PopulateTable(ConnectionString,dt,spName);
       foreach(DataRow dr in dt.Rows)
       {
           BagTypeModel b = new BagTypeModel();
           ECX.DataAccess.Common.DataRow2Object(dr,b);
           lst.Add(b);
       }
        return lst;
    }
}

