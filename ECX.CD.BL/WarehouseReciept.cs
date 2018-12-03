using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using System.Web;

namespace ECX.CD.BL
{
    public class WarehouseReciept
    {
        #region For trading service
        public DataTable GetWRByWarehouse(Guid warehouseId)
        {
            return new DA.WarehouseReciept().GetWRByWarehouse(warehouseId);
        }
        public bool DeductWRQuantity(Guid warehouseRecieptId, double quantity)
        {
            return new DA.WarehouseReciept().DeductWRQuantity(warehouseRecieptId, quantity);
        }
        public bool AddWRQuantity(Guid warehouseRecieptId, double quantity)
        {
            return new DA.WarehouseReciept().AddWRQuantity(warehouseRecieptId, quantity);
        }
        public DataTable GetApprovedAndNotExpiredWRsForTrading(Guid warehouseId, Guid commodityGradeId, Guid clientId)
        {
            BE.WR.WarehouseRecieptForTradeDataTable whrs = new ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable();
            BE.WR.WarehouseRecieptForTradeDataTable ret = new ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable();
            byte tradeSourceTypeId = new Lookup().GetLookupId("tblSourceType", "Trade");
            ECXLookup.ECXLookup lookUp = new ECX.CD.BL.ECXLookup.ECXLookup();

            whrs.Merge(new DA.WarehouseReciept().GetApprovedAndNotExpiredWRsForTrading(warehouseId, commodityGradeId, clientId));

            foreach (BE.WR.WarehouseRecieptForTradeRow whr in whrs)
            {
                if (whr.SourceType != tradeSourceTypeId ||
                    lookUp.GetCommodityGrade(Common.EnglishGuid, whr.CommodityGradeId).Retradable)
                {
                    ret.AddWarehouseRecieptForTradeRow(
                        whr.Id, whr.WarehouseRecieptId, whr.GRNID, whr.GRNNumber, whr.CommodityGradeId,
                        whr.WarehouseId, whr.BagTypeId, whr.DateDeposited,
                        whr.DateApproved, whr.GRNStatus, whr.WRStatusId, whr.GrossWeight,
                        whr.NetWeight, whr.OriginalQuantity, whr.TempQuantity, whr.CurrentQuantity, whr.DepositeTypeId,
                        whr.SourceType, whr.ClientId, whr.ExpiryDate, whr.ProductionYear);
                }
            }

            return ret;
        }
        public BE.WR.WarehouseRecieptForTradeRow GetWRForTrading(int warehouseRecieptId)
        {
            return new DA.WarehouseReciept().GetWRForTrading(warehouseRecieptId);
        }
        public DataRow GetWRForTrading(Guid wRId)
        {
            DataRow dr = new DA.WarehouseReciept().GetWRForTrading(wRId);
            return dr;
        }

        public BE.WR.WarehouseRecieptForTradeRow GetWRForTradingByGuid(Guid wrId )
        {
            return new DA.WarehouseReciept().GetWRForTradingByGuid(wrId);
        }
        
        public List<ECX.CD.BE.TradableWHR> GetTradableWHRs(Guid CommodityGradeId)
        {//Dictionary<Guid, int>
            return new DA.WarehouseReciept().GetTradableWHRs(CommodityGradeId);
        }
        #endregion

        public DataTable GetWHRHistory(int wHRId)
        {
            DataTable ret = new DataTable();

            ret.Merge(new DA.WarehouseReciept().GetWHRHistory(wHRId));
            ret.Merge(new DA.Pledge().GetPledgeHistory(wHRId));
            ret.Merge(new DA.LNS().GetLiftNoSaleHistory(wHRId));

            ret.DefaultView.Sort = "DateTime DESC";

            return ret;
        }

        public DataRow GetWR(Guid wRId)
        {
            return new DA.WarehouseReciept().GetWR(wRId);
        }

        public double GetTempQuantityt(int warehouseRecieptId)
        {
            return new DA.WarehouseReciept().GetTempQuantityt(warehouseRecieptId);
        }

        public int GetWarehouseRecieptId(Guid wRId)
        {
            return new DA.WarehouseReciept().GetWarehouseRecieptId(wRId);
        }

        public BE.WR.WarehouseRecieptRow GetWR(int warehouseRecieptId)
        {
            return new DA.WarehouseReciept().GetWR(warehouseRecieptId);
        }

        public BE.WR.WarehouseRecieptRow GetWRByGRN(string gRNNumber)
        {
            return new DA.WarehouseReciept().GetWRByGRN(gRNNumber);
        }

        public Guid GetWRGuid(int warehouseRecieptId)
        {
            return new DA.WarehouseReciept().GetWRGuid(warehouseRecieptId);
        }

        public bool UpdateWR(
            Guid wrId, byte wRStatusId, string wrStatusName, DateTime expiryDate, Guid userId, string remark)
        {
            return new DA.WarehouseReciept().UpdateWR(wrId, wRStatusId, wrStatusName, expiryDate, DateTime.Now, userId, remark);
        }

        public DataTable SearchWR(
            string warehouseRecieptIdFrom, string warehouseRecieptIdTo,
            string gRNNumberFrom, string gRNNumberTo, string clientId, string wareHouseId,
            string wRStatusId, List<string> commodityGradeIds, string dateDepositedFrom,
            string dateDepositedTo, string expiryDateFrom, string expiryDateTo, byte sourceTypeId,
            int currentPage, int pageSize,int consType, out int totalRecordCount)
        {
            return new DA.WarehouseReciept().SearchWR(
                warehouseRecieptIdFrom, warehouseRecieptIdTo,
                gRNNumberFrom, gRNNumberTo, clientId,
                wareHouseId, wRStatusId, commodityGradeIds, dateDepositedFrom, dateDepositedTo,
                expiryDateFrom, expiryDateTo, sourceTypeId, currentPage,
                pageSize,consType, out totalRecordCount);
        }

        public DataTable GetWHRForApproval()
        {
            DataTable ret = new DataTable();
            ret.Merge(new DA.WarehouseReciept().GetWHRForApproval());
            ECXMembership.MemberShipLookUp memberShipLookUp = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
            ECXMembership.MembershipEntities memEntity;
            ECXLookup.CCommodityGrade commodityGrade = new ECX.CD.BL.ECXLookup.CCommodityGrade();
            ECXLookup.CWarehouse warehouse = new ECX.CD.BL.ECXLookup.CWarehouse();
            ECXLookup.ECXLookup eCXLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
            BL.Lookup lookupBl = new ECX.CD.BL.Lookup();
            ECXLookup.CBag bagType = new ECX.CD.BL.ECXLookup.CBag();

            //Get display values of fields from services
            foreach (DataRow row in ret.Rows)
            {
                memEntity = memberShipLookUp.GetEntityByGuid(new Guid(row["ClientGuid"].ToString()));

                row["ClientId"] = memEntity.StringIdNo;
                row["ClientName"] = memEntity.OrganizationName;

                commodityGrade = eCXLookup.GetCommodityGrade(Common.EnglishGuid, new Guid(row["CommodityGradeId"].ToString()));
                warehouse = eCXLookup.GetWarehouse(Common.EnglishGuid, new Guid(row["WarehouseId"].ToString()));

                row["CommodityGradeName"] = ((commodityGrade == null) ? "" : commodityGrade.Symbol);
                row["WRStatusName"] = lookupBl.GetLookupName("tblWarehouseRecieptStatus", Convert.ToByte(row["WRStatusId"]));
                row["WarehouseName"] = ((warehouse == null) ? "" : warehouse.Name);

                if (row["BagTypeId"] != null)
                {
                    bagType = eCXLookup.GetBag(Common.EnglishGuid, new Guid(row["BagTypeId"].ToString()));

                    row["BagTypeName"] = ((bagType == null) ? "" : bagType.Name);
                }
            }

            return ret;
        }

        public int GetWHRForApprovalCount()
        {
            return new DA.WarehouseReciept().GetWHRForApprovalCount();
        }

        public int GetApproveWHRCancelCount()
        {
            return new DA.WarehouseReciept().GetApproveWHRCancelCount();
        }

        public void ApproveWarehouseReciepts(Dictionary<int, Guid> wHRs, Guid approvedBy)
        {
            DA.Setting setting = new ECX.CD.DA.Setting();
            ECXLookup.ECXLookup ecxlookup = new ECX.CD.BL.ECXLookup.ECXLookup();
            double numberOfDays;

            foreach (KeyValuePair<int, Guid> whr in wHRs)
            {
                numberOfDays = ecxlookup.GetCommodityGradeWHRExpiryDate(whr.Value).Value;

                new DA.WarehouseReciept().ApproveWarehouseReciepts(whr.Key,
                    DateTime.Today.AddDays(numberOfDays),
                    approvedBy);

                AddWHRHistory(whr.Key, "Approve WHR", approvedBy, "");
            }
        }

        public void CloseWarehouseReciepts(List<int> warehouseRecieptIds, Guid userId)
        {
            new DA.WarehouseReciept().CloseWarehouseReciepts(warehouseRecieptIds, userId);
        }

        #region ExtendExpiryDate
        public void SaveExtendExpiryDateRequest(Dictionary<Guid, int> warehouseRecieptIds, Guid userId)
        {
            new DA.WarehouseReciept().SaveExtendExpiryDateRequest(warehouseRecieptIds, userId);
        }

        public int GetApproveExtendExpiryDateCount()
        {
            return new DA.WarehouseReciept().GetApproveExtendExpiryDateCount();
        }

        public DataTable SearchWRForExtendExpiryRequest(
            string warehouseRecieptIdFrom, string warehouseRecieptIdTo,
            string gRNNumberFrom, string gRNNumberTo, string clientId, string wareHouseId,
            List<string> commodityGradeIds, string dateDepositedFrom,
            string dateDepositedTo, string expiryDateFrom, string expiryDateTo,
            int currentPage, int pageSize, out int totalRecordCount)
        {
            return new DA.WarehouseReciept().SearchWRForExtendExpiryRequest(
                warehouseRecieptIdFrom, warehouseRecieptIdTo,
                gRNNumberFrom, gRNNumberTo, clientId,
                wareHouseId, commodityGradeIds, dateDepositedFrom, dateDepositedTo,
                expiryDateFrom, expiryDateTo, currentPage, pageSize, out totalRecordCount);
        }

        public DataTable GetWHRForExtendExpiryApproval()
        {
            DataTable dt = new DA.WarehouseReciept().GetWHRForExtendExpiryApproval();

            foreach (DataRow row in dt.Rows)
            {
                if (!row.IsNull("ClientGuid"))
                {
                    Guid clientGuid = new Guid(row["ClientGuid"].ToString());
                    if (BL.IFLookup.IsClientGuid(clientGuid))
                    {
                        ECXMembership.Client client = BL.IFLookup.GetClientByClientGuid(clientGuid);

                        row["ClientName"] = client.Name;
                        row["ClientId"] = client.IdNo;
                    }
                    else if (BL.IFLookup.IsMemberGuid(clientGuid))
                    {
                        ECXMembership.Member member = BL.IFLookup.GetMemberByMemberGuid(clientGuid);

                        row["ClientName"] = member.Name;
                        row["ClientId"] = member.IdNo;
                    }
                }
                if (!row.IsNull("CommodityGradeId"))
                {
                    Guid cGradeId = new Guid(row["CommodityGradeId"].ToString());
                    ECXLookup.CCommodityGrade cGrade = new ECXLookup.ECXLookup().GetCommodityGrade(Common.EnglishGuid, cGradeId);
                    if (cGrade != null)
                    {
                        row["CommodityGradeName"] = cGrade.Name;
                    }
                }
                if (!row.IsNull("WarehouseId"))
                {
                    Guid warehouseId = new Guid(row["WarehouseId"].ToString());
                    ECXLookup.CWarehouse warehouse = new ECXLookup.ECXLookup().GetWarehouse(Common.EnglishGuid, warehouseId);
                    if (warehouse != null)
                    {
                        row["WarehouseName"] = warehouse.Name;
                    }
                }
                if (!row.IsNull("WRStatusId"))
                {
                    row["WRStatusName"] = new Lookup().GetLookupName("tblWarehouseRecieptStatus", Convert.ToByte(row["WRStatusId"]));
                }
            }

            return dt;
        }

        public void ApproveExtendExpiry(List<Guid> extendExpiryDateIds, Guid userId)
        {
            new DA.WarehouseReciept().ApproveExtendExpiry(extendExpiryDateIds, userId);
        }

        public void RejectWHRExtendExpiry(List<Guid> extendExpiryDateIds, Guid userId)
        {
            new DA.WarehouseReciept().RejectWHRExtendExpiry(extendExpiryDateIds, userId);
        }

        #endregion

        public bool SaveWareHouseReciept(
            Guid GRNID, string GRNNumber, Guid CommodityGradeId, Guid WarehouseId,
            Guid BagTypeId, Guid VoucherId, Guid UnLoadingId, Guid ScalingId, Guid GradingId,
            Guid SamplingTicketId, DateTime DateDeposited, DateTime DateApproved, int GRNStatusId,
            double GrossWeight, double NetWeight, double OriginalQuantity, double CurrentQuantity,
            Guid DepositeTypeId, int Source, double NetWeightAdjusted, Guid UserId,
            DateTime CreatedTimeStamp, Guid ClientId, int NumberOfBags, int ProductionYear, Guid GRNTypeId)
        {
            //new Workflow().OpenTransaction(TransactionTypes.ApproveWHR, UserId, GRNID.ToString());

            return new DA.WarehouseReciept().SaveWareHouseReciept(
                GRNID, GRNNumber, CommodityGradeId, WarehouseId, BagTypeId, VoucherId, UnLoadingId, ScalingId,
                GradingId, SamplingTicketId, DateDeposited, DateApproved, GRNStatusId, GrossWeight, NetWeight,
                OriginalQuantity, CurrentQuantity, DepositeTypeId, Source, NetWeightAdjusted, UserId,
                CreatedTimeStamp, ClientId, NumberOfBags, ProductionYear, GRNTypeId);
        }

        #region WHR Edit
        public DataTable GetWHRForEditRequestApproval(string[] transactionNos)
        {
            return new DA.WarehouseReciept().GetWHRForEditRequestApproval(transactionNos);
        }

        public void RequestWHREdit(Guid gRNID, Guid requestedBy, string remark, string trackingNumber)
        {
            new DA.WarehouseReciept().RequestWHREdit(gRNID, requestedBy, remark, trackingNumber);
        }

        //public void RequestWHREdit(Guid gRNId, Guid RequestedBy)
        //{
        //    new DA.WarehouseReciept().RequestWHREdit(new DA.WarehouseReciept().GetParentWHR(gRNId), gRNId, RequestedBy, DateTime.Now);
        //}

        //public void RequestWHREdit(List<Guid> warehouseReceiptIds, Guid RequestedBy)
        //{
        //    foreach (Guid warehouseReceiptId in warehouseReceiptIds)
        //        RequestWHREdit(warehouseReceiptId, RequestedBy);
        //}

        public void ApproveWHREdit(List<Guid> wHREditIds, Guid ApprovedBy)
        {
            DA.WarehouseReciept whrDA = new ECX.CD.DA.WarehouseReciept();

            foreach (Guid wHREditId in wHREditIds)
            {
                //TODO:Consume the ff service
                //if (warehouse.EditWHR(whrDA.GetWHRIdByCancelWHRId(wHRCancelId), whrDA.GetWHREditTrackingNumber(wHREditId)))
                new DA.WarehouseReciept().ApproveWHREdit(whrDA.GetGRNIdByEditWHRId(wHREditId), ApprovedBy, DateTime.Now);
            }
        }

        public void RejectWHREdit(List<Guid> wHREditIds, Guid userId)
        {
            foreach (Guid wHREditId in wHREditIds)
            {
                //TODO:Consume the ff service
                //if (warehouse.RejectEditWHR(whrDA.GetWHRIdByCancelWHRId(wHREditId), whrDA.GetWHREditTrackingNumber(wHREditId)))
                new DA.WarehouseReciept().RejectWHREdit(userId, wHREditId);
            }
        }

        //public void ApproveWHREdit(Guid wHREditId, Guid ApprovedBy)
        //{
        //    DA.WarehouseReciept whrDA = new ECX.CD.DA.WarehouseReciept();

        //    foreach (Guid wHREditId in wHREditIds)
        //    {
        //        //TODO:Consume the ff service
        //        //if (warehouse.ApproveEditWHR())
        //            new DA.WarehouseReciept().ApproveWHREdit(whrDA.GetWHRIdByEditWHRId(wHREditId), ApprovedBy, DateTime.Now);
        //    }
        //}

        public bool UpdateWHREditDetails(Guid Id, Guid EditedBy, DateTime DateEdited, String EditDetail)
        {
            return new DA.WarehouseReciept().UpdateWHREditDetails(Id, EditedBy, DateEdited, EditDetail);
        }
        #endregion

        #region Cancel WHR
        public bool IsSourceTypeTrade(List<Guid> wHRIds)
        {
            return new DA.WarehouseReciept().IsSourceTypeTrade(wHRIds);
        }

        public void RequestWHRCancel(Guid userId, List<Guid> wHRIds, string remark)
        {
            Guid id;

            foreach (Guid wHRId in wHRIds)
            {
                id = new DA.WarehouseReciept().RequestWHRCancel(userId, wHRId, remark);
                //new Workflow().OpenTransaction(TransactionTypes.CancelWHR, userId, id.ToString());
            }
        }

        public bool RequestWHRCancel(Guid gRNId, Guid userId, string remark, string trackingNumber)
        {
            return new DA.WarehouseReciept().RequestWHRCancel(gRNId, userId, remark, trackingNumber);
        }

        public void ApproveWHRCancel(Guid userId, List<Guid> wHRCancelIds)
        {
            Warehouse.ECXGRNWR.GRNWRSync warehouse = new ECX.CD.BL.Warehouse.ECXGRNWR.GRNWRSync();
            DA.WarehouseReciept whrDA = new ECX.CD.DA.WarehouseReciept();

            foreach (Guid wHRCancelId in wHRCancelIds)
            {
                if (whrDA.IsWHRCancelRequestedFromCD(wHRCancelId))
                {
                    if (warehouse.CancelGRN(whrDA.GetGRNIdByCancelWHRId(wHRCancelId), whrDA.GetWHRCancelTrackingNumber(wHRCancelId), ECX.CD.BL.Warehouse.ECXGRNWR.RequestforApprovedGRNCancelationStatus.Cancelled))
                        new DA.WarehouseReciept().ApproveWHRCancel(userId, whrDA.GetGRNIdByCancelWHRId(wHRCancelId));
                }
                else
                {
                    new DA.WarehouseReciept().ApproveWHRCancel(userId, wHRCancelId);
                }
            }
        }

        public void RejectWHRCancel(Guid userId, List<Guid> wHRCancelIds)
        {
            Warehouse.ECXGRNWR.GRNWRSync warehouse = new ECX.CD.BL.Warehouse.ECXGRNWR.GRNWRSync();
            DA.WarehouseReciept whrDA = new ECX.CD.DA.WarehouseReciept();

            foreach (Guid wHRCancelId in wHRCancelIds)
            {
                //TODO:Consume the ff service
                if (warehouse.CancelGRNCancellationRequest(whrDA.GetWHRCancelTrackingNumber(wHRCancelId)))
                    //if (warehouse.RejectCancelWHR(whrDA.GetWHRIdByCancelWHRId(wHRCancelId), whrDA.GetWHRCancelTrackingNumber(wHRCancelId)))
                    new DA.WarehouseReciept().RejectWHRCancel(userId, wHRCancelId);
            }
        }

        public DataTable GetWHRForWHRCancelApproval()
        {
            DataTable ret = new DA.WarehouseReciept().GetWHRForWHRCancelApproval();

            ECXMembership.MemberShipLookUp memberShipLookUp = new ECX.CD.BL.ECXMembership.MemberShipLookUp();
            ECXMembership.MembershipEntities memEntity;

            ECXLookup.ECXLookup eCXLookup = new ECX.CD.BL.ECXLookup.ECXLookup();
            BL.Lookup lookupBl = new ECX.CD.BL.Lookup();

            foreach (DataRow row in ret.Rows)
            {
                memEntity = memberShipLookUp.GetEntityByGuid(new Guid(row["ClientGuid"].ToString()));

                if (memEntity != null)
                {
                    row["ClientId"] = memEntity.StringIdNo;
                    row["ClientName"] = memEntity.OrganizationName;
                }
                ECXLookup.CCommodityGrade cGrade = eCXLookup.GetCommodityGrade(Common.EnglishGuid, new Guid(row["CommodityGradeId"].ToString()));
                if (cGrade != null)
                    row["CommodityGradeName"] = cGrade.Symbol;
                row["WRStatusName"] = lookupBl.GetLookupName("tblWarehouseRecieptStatus", Convert.ToByte(row["WRStatusId"]));

                ECXLookup.CWarehouse cWarehouse = eCXLookup.GetWarehouse(Common.EnglishGuid, new Guid(row["WarehouseId"].ToString()));
                if (cWarehouse != null)
                    row["WarehouseName"] = cWarehouse.Name;
            }

            return ret;

        }

        public void CancelWHR(List<Guid> wHRCancelIdIds, Guid userId)
        {
            foreach (Guid wHRCancelIdId in wHRCancelIdIds)
            {
                new DA.WarehouseReciept().CancelWHR(userId, wHRCancelIdId);
            }
        }

        public bool CancelWHR(Guid wHRCancelIdId, Guid userId)
        {
            return new DA.WarehouseReciept().CancelWHR(userId, wHRCancelIdId);
        }
        #endregion

        #region Validations

        #endregion

        public DataTable GetPendingWHRs()
        {
            DataTable ret = new DA.WarehouseReciept().GetPendingWHRs();
            ECXMembership.MembershipEntities entity;
            ECXMembership.MemberShipLookUp lookup = new ECX.CD.BL.ECXMembership.MemberShipLookUp();

            foreach (DataRow row in ret.Rows)
            {
                entity = lookup.GetEntityByGuid(new Guid(row["ClientId"].ToString()));
                if (entity != null)
                {
                    row["BuyerClient"] = entity.IsMember;
                    row["BuyerName"] = entity.OrganizationName;
                }
                else
                {
                    row["BuyerClient"] = true;
                    row["BuyerName"] = "N/A";
                }
            }

            return ret;
        }

        public List<Guid> GetOwnerWHRApprovalRange(DateTime approvalDateFrom, DateTime approvalDateTo)
        {
            DataTable tbl = new DA.WarehouseReciept().GetOwnerWHRApprovalRange(approvalDateFrom, approvalDateTo);

            List<Guid> list = new List<Guid>();
            foreach (DataRow row in tbl.Rows)
            {
                list.Add(new Guid(row["ClientId"].ToString()));
            }
            return list;
        }

        public bool ResetStatusToNew(Guid warehouseReceiptId)
        {
            return new DA.WarehouseReciept().ResetStatusToNew(warehouseReceiptId);
        }

        public void AddWHRHistory(int warehouseReceiptId, string status, Guid userId, string remark)
        {
            new DA.WarehouseReciept().AddWHRHistory(warehouseReceiptId, status, userId, remark);
        }

        public DateTime GetTradeDate(Guid wHRId)
        {
            return new DA.WarehouseReciept().GetTradeDate(wHRId);
        }

        //Elias Getachew
        //march 21 2012
        //To make PUN expiration start from date of TT.
        public DateTime GetTitleTransferDate(Guid wHRId)
        {
            return new DA.WarehouseReciept().GetTradedWRTitleTransferDate(wHRId);
        }

        public DateTime GetPUNExpirationdateFromDN(Guid WHRid)
        {
            return new DA.WarehouseReciept().GetPUNExpirationdateFromDN(WHRid);
        }
        
        public DateTime GetPUNExpirationdateFromDNbyPunID(Guid punID)
        {
            return new DA.WarehouseReciept().GetPUNExpirationdateFromDNbyPunID(punID);
        }

        //esa--- Jan 9 2014  --PUN Create
        public DateTime GetPUNExpirationdateFromDNbyWHRNum(int WHRNum)
        {
            return new DA.WarehouseReciept().GetPUNExpirationdateFromDNbyWHRNum(WHRNum);
        }

        public bool IsWHRPledged(int warehouseReceiptId)
        {
            return new DA.Pledge().AlreadyPledged(warehouseReceiptId);
        }

        public BE.WR.ApprovedAndNewWHRsDataTable GetApprovedAndNewWHRs()
        {
            BE.WR.ApprovedAndNewWHRsDataTable ret = new ECX.CD.BE.WR.ApprovedAndNewWHRsDataTable();

            ret.Merge(new DA.WarehouseReciept().GetApprovedAndNewWHRs());

            return ret;
        }

        /*************************************************************************/

        public DataTable GetTradableWarehouseReceipts(Guid? commodityId = null)
        {
            return new DA.WarehouseReciept().GetTradableWarehouseReceipts(commodityId);
        }




        /******************tg May 22/2017************************/
        public DataTable GetUnsoldOnTruckWarehouseRecipts()
        {
            return new DA.WarehouseReciept().GetUnsoldOnTruckWarehouseRecipts();
        }
        public int UpdateUnsoldOnTruckWarehouseRecipts(List<ECX.CD.DA.Hold> lst, string remark)
        {
            return new DA.WarehouseReciept().UpdateUnsoldOnTruckWarehouseRecipts(lst, remark);
        }
    }
}