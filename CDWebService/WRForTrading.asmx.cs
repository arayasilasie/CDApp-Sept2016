using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;

namespace CDWebService
{
    /// <summary>
    /// Summary description for WRForTrading
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class WRForTrading : System.Web.Services.WebService
    {
        [WebMethod]
        public List<ECX.CD.BE.TradableWHR> GetTradableWHRs(Guid CommodityGradeId)
        {
            List<ECX.CD.BE.TradableWHR> ret = new List<ECX.CD.BE.TradableWHR>();
            //Dictionary<Guid, int> twhrs = new ECX.CD.BL.WarehouseReciept().GetTradableWHRs(CommodityGradeId);
            ret = new ECX.CD.BL.WarehouseReciept().GetTradableWHRs(CommodityGradeId);
            //foreach (KeyValuePair<Guid, int> kvp in twhrs)
            //    ret.Add(new ECX.CD.BE.TradableWHR() { ProductionYear = kvp.Value, WarehouseId = kvp.Key });

            return ret;
        }

        [WebMethod]
        public ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable GetWRByGuidId(Guid warehouseReceiptId)
        {
            ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable ret = new ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable();

            ECX.CD.BE.WR.WarehouseRecieptForTradeRow row = (ECX.CD.BE.WR.WarehouseRecieptForTradeRow)new ECX.CD.BL.WarehouseReciept().GetWRForTradingByGuid(warehouseReceiptId);
            
            ret.AddWarehouseRecieptForTradeRow(
                row.Id, row.WarehouseRecieptId, row.GRNID, row.GRNNumber, row.CommodityGradeId, row.WarehouseId, row.BagTypeId, row.DateDeposited, row.DateApproved,
                row.GRNStatus, row.WRStatusId, row.GrossWeight, row.NetWeight, row.TempQuantity, row.OriginalQuantity, row.CurrentQuantity,
                row.DepositeTypeId, row.SourceType, row.ClientId, row.ExpiryDate, row.ProductionYear);

            return ret;
        }

        [WebMethod]
        public ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable GetWRByIntId(int warehouseReceiptId)
        {
            ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable ret = new ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable();

            ECX.CD.BE.WR.WarehouseRecieptForTradeRow row = (ECX.CD.BE.WR.WarehouseRecieptForTradeRow)new ECX.CD.BL.WarehouseReciept().GetWRForTrading(warehouseReceiptId);

            ret.AddWarehouseRecieptForTradeRow(
                row.Id, row.WarehouseRecieptId, row.GRNID, row.GRNNumber, row.CommodityGradeId, row.WarehouseId, row.BagTypeId, row.DateDeposited, row.DateApproved,
                row.GRNStatus, row.WRStatusId, row.GrossWeight, row.NetWeight, row.OriginalQuantity, row.TempQuantity, row.CurrentQuantity, 
                row.DepositeTypeId, row.SourceType, row.ClientId, row.ExpiryDate, row.ProductionYear);

            return ret;
        }

        [WebMethod]
        public ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable GetWRByWarehouse(Guid warehouseId)
        {
            return (ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable)new ECX.CD.BL.WarehouseReciept().GetWRByWarehouse(warehouseId);
        }

        [WebMethod]
        public ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable GetApprovedAndNotExpiredWRs(Guid warehouseId, Guid commodityGradeId, Guid clientId)
        {
            return (ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable)new ECX.CD.BL.WarehouseReciept().GetApprovedAndNotExpiredWRsForTrading(warehouseId, commodityGradeId, clientId);
        }

        [WebMethod]
        public bool DeductWRQuantity(Guid warehouseRecieptId, double quantity)
        {
            return new ECX.CD.BL.WarehouseReciept().DeductWRQuantity(warehouseRecieptId, quantity);
        }

        [WebMethod]
        public bool AddWRQuantity(Guid warehouseRecieptId, double quantity)
        {
            return new ECX.CD.BL.WarehouseReciept().AddWRQuantity(warehouseRecieptId, quantity);
        }

        [WebMethod]
        public List<int> GetAllPledgedNoSaleWRIds()
        {
            return new ECX.CD.BL.Pledge().GetAllPledgedNoSaleWRIds();
        }

        [WebMethod]
        public List<int> GetAllPledgedSaleWRIds()
        {
            return new ECX.CD.BL.Pledge().GetAllPledgedSaleWRIds();
        } 
    }
}
