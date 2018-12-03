using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.BL
{
    public class PUN
	{
		public DataTable GetPUNForExtendExpiryApproval()
		{
			return new DA.PUN().GetPUNForExtendExpiryApproval();
        }

        public int GetPUNForExtendExpiryApprovalCount()
        {
            return new DA.PUN().GetPUNForExtendExpiryApprovalCount();
        }

        public bool ApprovePUNExtendExpiry(List<Guid> extendExpiryDateIds, Guid userId)
		{
            return new DA.PUN().ApprovePUNExtendExpiry(extendExpiryDateIds, userId);
		}

		public void RejectPUNExtendExpiry(List<Guid> pUNIds, Guid userId)
		{
			new DA.PUN().RejectPUNExtendExpiry(pUNIds, userId);
		}

		public void SaveExtendExpiryDateRequest(Dictionary<Guid, int> pickupNotices, Guid userId)
		{
			new DA.PUN().SaveExtendExpiryDateRequest(pickupNotices, userId);
		}

        public DataTable SearchPUNForCancel(
            string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
            string pUNIdFrom, string pUNIdTo, string expirationDateFrom, string expirationDateTo,
            string expectedPickupDateFrom, string expectedPickupDateTo, string pUNStatusId)
        {
            return new DA.PUN().SearchPUNForCancel(
                warehouseReceiptIDFrom, warehouseReceiptIDTo,
                pUNIdFrom, pUNIdTo, expirationDateFrom, expirationDateTo,
                expectedPickupDateFrom, expectedPickupDateTo, pUNStatusId);
		}

		public DataTable GetPUNForCancel()
		{
			return new DA.PUN().GetPUNForCancel();
		}

        public DataTable SearchPickUpNoticeForView(
            string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
            string pUNIdFrom, string pUNIdTo, string expirationDateFrom, string expirationDateTo,
            string expectedPickupDateFrom, string expectedPickupDateTo, string pUNStatusId,
            Guid clientId, Guid wareHouseId, string dateCreatedFrom, string dateCreatedTo,
            string tradeDateFrom, string tradeDateTo)
        {
            return new DA.PUN().SearchPickUpNoticeForView(
                warehouseReceiptIDFrom, warehouseReceiptIDTo,
                pUNIdFrom, pUNIdTo,
                expirationDateFrom, expirationDateTo,
                expectedPickupDateFrom, expectedPickupDateTo, pUNStatusId,
                clientId, wareHouseId, dateCreatedFrom, dateCreatedTo,
                tradeDateFrom, tradeDateTo);
        }

        public DataTable SearchPickUpNotice(
            string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
            string pUNIdFrom, string pUNIdTo, string expirationDateFrom, string expirationDateTo,
            string expectedPickupDateFrom, string expectedPickupDateTo, string pUNStatusId,
            Guid clientId, Guid wareHouseId, string dateCreatedFrom, string dateCreatedTo,
            string tradeDateFrom, string tradeDateTo)
        {
            return new DA.PUN().SearchPickUpNotice(
                warehouseReceiptIDFrom, warehouseReceiptIDTo,
                pUNIdFrom, pUNIdTo, 
                expirationDateFrom, expirationDateTo,
                expectedPickupDateFrom, expectedPickupDateTo, pUNStatusId,
                clientId, wareHouseId, dateCreatedFrom, dateCreatedTo,
                tradeDateFrom, tradeDateTo);
        }

        public DataTable SearchPUNForEdit(
            string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
            string pUNIdFrom, string pUNIdTo, string expirationDateFrom, string expirationDateTo,
            string expectedPickupDateFrom, string expectedPickupDateTo, string pUNStatusId,
            Guid clientId, Guid wareHouseId, string dateCreatedFrom, string dateCreatedTo,
            string tradeDateFrom, string tradeDateTo)
        {
            return new DA.PUN().SearchPUNForEdit(
                warehouseReceiptIDFrom, warehouseReceiptIDTo,
                pUNIdFrom, pUNIdTo, 
                expirationDateFrom, expirationDateTo,
                expectedPickupDateFrom, expectedPickupDateTo, pUNStatusId,
                clientId, wareHouseId, dateCreatedFrom, dateCreatedTo,
                tradeDateFrom, tradeDateTo);
        }

        public int TotalRecordCount(
            string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
            string pUNIdFrom, string pUNIdTo, string expirationDateFrom, string expirationDateTo,
            string expectedPickupDateFrom, string expectedPickupDateTo, string pUNStatusId)
        {
            return new DA.PUN().TotalRecordCount(
                warehouseReceiptIDFrom, warehouseReceiptIDTo,
                pUNIdFrom, pUNIdTo, expirationDateFrom, expirationDateTo,
                expectedPickupDateFrom, expectedPickupDateTo, pUNStatusId);
        }

        #region Create PUN
        public int CreatePUN(Guid Id, Guid MemberId, Guid ClientId, Guid CommodityGradeId, double Shortfall,
            DateTime ExpectedPickupDate, Guid WarehouseId, DateTime ExpirationDate, Byte PUNStatusId,
            String AgentName, Int32 NIDType, String NIDNumber, Int32 AgentStatusId, 
            String AgentTel, String RepId, Boolean Exported, Guid UserId, int ProductionYear, 
            BE.PUN.PickUpNoticeWarehouseRecieptDataTable punWHRs, 
            BE.PUN.PickupNoticeDriverDataTable punDrivers,
            string ConsignmentType, string SustainableCertification, string Woreda, decimal RawValue, decimal Cupvalue, decimal TotalValue,
            string WashingMillingStation, string TrailerPlateNumber, string PlateNumber, string SellerName, string Shade, bool isTracable, string GRNNumber)
        {
            return new DA.PUN().CreatePUN(
				Id, MemberId, ClientId, CommodityGradeId, Shortfall, ExpectedPickupDate, WarehouseId,
                ExpirationDate, PUNStatusId, AgentName, NIDType, NIDNumber, AgentStatusId, 
                AgentTel, RepId, Exported, UserId, ProductionYear,
                punWHRs, punDrivers,ConsignmentType, SustainableCertification, Woreda, RawValue, Cupvalue, TotalValue,
            WashingMillingStation, TrailerPlateNumber, PlateNumber, SellerName, Shade, isTracable, GRNNumber);
        }

        //public bool SavePUNWR(Boolean Selected, Int32 WarehouseRecieptId, Guid PickupNoticeId, 
        //    Double Quantity, DateTime DNReceivedDateTime, Guid UserId)
        //{
        //    return new DA.PUN().SavePUNWR(
        //        Selected, WarehouseRecieptId, PickupNoticeId, Quantity, DNReceivedDateTime, UserId);
        //}

        //public bool SavePUNDriver(
        //    Guid Id, Guid PickupNoticeId, String DriverName, String LicenseNumber, String PlateNumber,
        //    String TrailerPlateNumber, String Capacity, Guid UserId)
        //{
        //    return new DA.PUN().SavePickupNoticeDriver(
        //        Id, PickupNoticeId, DriverName, LicenseNumber, PlateNumber, TrailerPlateNumber, Capacity, UserId);
        //}

        //public void SavePUNDriver(BE.PUN.PickupNoticeDriverDataTable pUNDrivers, Guid UserId)
        //{
        //    foreach(BE.PUN.PickupNoticeDriverRow row in pUNDrivers)
        //        SavePUNDriver(
        //        row.Id, row.PickupNoticeId, row.DriverName, row.LicenseNumber, row.PlateNumber, 
        //        row.TrailerPlateNumber, row.Capacity, UserId);
        //}

        //public Guid InsertPUNDriver(Guid PickupNoticeId, String DriverName, String LicenseNumber, String PlateNumber, String TrailerPlateNumber, String Capacity, Guid CreatedBy, DateTime CreatedDate, Guid LastModifiedBy, DateTime LastModifiedTimeStamp)
        //{
        //    return new DA.PickupNoticeDriver().Insert(
        //        PickupNoticeId, DriverName, LicenseNumber, PlateNumber, TrailerPlateNumber,
        //        Capacity, CreatedBy, CreatedDate, LastModifiedBy, DateTime.Now);
        //}

        //public bool UpdatePUNDriver(Guid Id, Guid PickupNoticeId, String DriverName, String LicenseNumber, String PlateNumber, String TrailerPlateNumber, String Capacity, Guid CreatedBy, DateTime CreatedDate, Guid LastModifiedBy, DateTime LastModifiedTimeStamp)
        //{
        //    return new DA.PickupNoticeDriver().Update(
        //        Id, PickupNoticeId, DriverName, LicenseNumber, PlateNumber, TrailerPlateNumber,
        //        Capacity, CreatedBy, DateTime.Today, LastModifiedBy, DateTime.Now);
        //}
        #endregion

        public ECX.CD.BE.PUN.PickUpNoticeRow GetPickupNotice(Guid pUNId)
        {
            BE.PUN.PickUpNoticeDataTable pun = new ECX.CD.BE.PUN.PickUpNoticeDataTable();

            pun.Merge(new DA.PUN().GetPUN(pUNId));

            return pun[0];
        }

        public List<string> GetClientIdsForPUN(List<string> clientIds)
        {
            if (clientIds.Count == 0)
                return new List<string>();

            return new DA.PUN().GetClientIdsForPUN(clientIds);
        }

        public List<string> GetWarehouseIdsForPUN(List<Guid> clientIds)
        {
            return new DA.PUN().GetWarehouseIdsForPUN(clientIds);
        }

        public List<string> GetCommodityGradesIdsForPUN(List<Guid> clientIds)
        {
            return new DA.PUN().GetCommodityGradesIdsForPUN(clientIds);
        }

        public List<string> GetCommodityGradesIdsForPUN(Guid clientId)
        {
            return new DA.PUN().GetCommodityGradesIdsForPUN(clientId);
        }

		public List<int> GetProductionYearForPUN(List<Guid> clientIds)
        {
			return new DA.PUN().GetProductionYearForPUN(clientIds);
        }

        public BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPUNWRs(
            Guid pickupNoticeId, Guid warehouseId, Guid clientId, 
			Guid currentUser, int productionYear, Guid commodityGradeId)
        {
			return new DA.PUN().GetPickupNoticeWarehouseReciepts(
				pickupNoticeId, warehouseId, clientId, currentUser, productionYear, commodityGradeId);
        }

        public BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPUNWRs(Guid pUNId)
        {
            return new DA.PUN().GetPickupNoticeWarehouseReciepts(pUNId);
        }

        public BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPUNWRs(
            int warehouseReceiptId, Guid pickupNoticeId, Guid userId)
        {
            return new DA.PUN().GetPickupNoticeWarehouseReciepts(warehouseReceiptId, pickupNoticeId, userId);
        }

        public DataTable GetPickupNoticeDrivers(Guid pUNId)
        {
            return new DA.PUN().GetPickupNoticeDrivers(pUNId);
        }

        public string GetWarehouseRecieptIds(Guid pUNId)
        {
            return new DA.PUN().GetWarehouseRecieptIds(pUNId);
        }

        public string GetTradeDates(Guid pUNId)
        {
            return new DA.PUN().GetTradeDates(pUNId);
        }

        public void DeletePUNDriver(Guid id)
        {
            new DA.PUN().DeletePUNDriver(id);
        }

        public BE.PUN GetPunForWHExport()
        {
            BE.PUN ret = new ECX.CD.BE.PUN();
            List<Guid> punIds = new DA.PUN().GetPunForWHExport();

            foreach (Guid punId in punIds)
            {
				ret.PickUpNotice.Merge(new DA.PUN().GetPUN(punId));
				ret.PickupNoticeDriver.Merge(new DA.PUN().SelectPUNDriverByPickupNotice(punId));
				ret.PickUpNoticeWarehouseReciept.Merge(new DA.PUN().SelectPUNWRByPickupNotice(punId));
			}

            return ret;
        }

        public void SetWHAsExported(List<Guid> punIds)
        {
            new DA.PUN().SetWHAsExported(punIds);
        }

        public bool UpdatePUNStatus(Guid PUNId, string pUNStatusName)
        {
            return new DA.PUN().UpdatePUNStatus(PUNId, pUNStatusName);
        }

        public double GetInventoryBalance(Guid warehouseId, Guid commodityGradeId, int productionYear)
        {
            return 0;
            //return new DA.WarehouseReciept().GetInventoryBalance(warehouseId, commodityGradeId, productionYear);
            //float totalWHROriginalQuantity = new DA.WarehouseReciept().TotalWHROriginalQuantity(warehouseId, commodityGradeId, productionYear);
            //float totalPUNQuantity = new DA.PUN().TotalPUNQuantity(warehouseId, commodityGradeId, productionYear);

            //float ret = (totalWHROriginalQuantity - totalPUNQuantity);

            //return ret;
                
        }

        #region Edit PUN
        public bool SavePUNEditRequest(Guid userId, BE.PUN.PUNEditDataTable items)
        {
            return new DA.PUN().SavePUNEditRequest(userId, items);
        }

        public bool ApprovePUNEdit(Guid userId, List<Guid> pUNEditIds)
        {
            return new DA.PUN().ApprovePUNEdit(userId, pUNEditIds);
        }

        public bool RejectPUNEdit(Guid userId, List<Guid> pUNEditIds)
        {
            return new DA.PUN().RejectPUNEdit(userId, pUNEditIds);
        }

        public DataTable GetPUNForEditApproval()
        {
            return new DA.PUN().GetPUNForEditApproval();
        }

        public int GetPUNEditApprovalCount()
        {
            return new DA.PUN().GetPUNEditApprovalCount();
        }
        #endregion

        #region Cancel PUN
        public void RequestPUNCancel(Guid userId, List<Guid> pUNIds)
        {
            Guid id;

            foreach (Guid pUNId in pUNIds)
            {
                id = new DA.PUN().RequestPUNCancel(userId, pUNId);
                //new Workflow().OpenTransaction(TransactionTypes.CancelPUN, userId, id.ToString());
            }
        }

        public void ApprovePUNCancel(Guid userId, List<Guid> pUNCancelIds)
        {
            foreach (Guid pUNCancelId in pUNCancelIds)
            {
                //new Workflow().StepCompleted(pUNCancelId.ToString(), userId);
                new DA.PUN().ApprovePUNCancel(userId, pUNCancelId);
            }
        }

		public void RejectPUNCancel(Guid userId, List<Guid> pUNCancelIds)
        {
            foreach (Guid pUNCancelId in pUNCancelIds)
            {
                //new Workflow().StepCompleted(pUNCancelId.ToString(), userId);
                new DA.PUN().ApprovePUNCancel(userId, pUNCancelId);
            }
        }

        public DataTable GetPUNForPUNCancelApproval()
        {
            return new DA.PUN().GetPUNForPUNCancelApproval();
        }

        public DataTable GetPUNForCancel(string[] transactionNos)
        {
            return new DA.PUN().GetPUNForCancel(transactionNos);
        }

        public void CancelPUN(List<Guid> pUNCancelIdIds, Guid userId)
        {
            foreach (Guid pUNCancelIdId in pUNCancelIdIds)
            {
                new DA.PUN().CancelPUN(userId, pUNCancelIdId);
                new Workflow().StepCompleted(pUNCancelIdId.ToString(), userId);
            }
        }
        #endregion

		public int GetApprovePUNCancelCount()
		{
			return new DA.PUN().GetApprovePUNCancelCount();
		}

		public BE.PUN.ViewPUNBalanceDataTable SearchViewPUNBalance(
			string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
			string memberId, string clientId, bool remainingQtyGreaterThan0OrLessThan0)
		{
			BE.PUN.ViewPUNBalanceDataTable ret = new ECX.CD.BE.PUN.ViewPUNBalanceDataTable();
			ECXLookup.ECXLookup lookup = new ECX.CD.BL.ECXLookup.ECXLookup();
			DA.PUN punDA = new ECX.CD.DA.PUN();
			DA.WarehouseReciept whrDA = new ECX.CD.DA.WarehouseReciept();

			ECXMembership.MembershipEntities client = new ECXMembership.MemberShipLookUp().GetEntityByIdNo(memberId);
			if (client == null)
			{
				client = new ECXMembership.MemberShipLookUp().GetEntityByIdNo(clientId);
			}

			ret.Merge(new DA.PUN().SearchViewPUNBalance(warehouseReceiptIDFrom, warehouseReceiptIDTo, 
				((client == null)?Guid.Empty:client.UniqueIdentifier), remainingQtyGreaterThan0OrLessThan0));

			foreach (BE.PUN.ViewPUNBalanceRow row in ret)
			{
				row.WarehouseRecieptIds = punDA.GetWarehouseRecieptIds(row.Id);
				row.PUNQuantity = punDA.GetPUNQuantity(row.Id);
				row.GINQuantity = punDA.GetGINQuantity(row.Id);
				row.RemainingQuantity = whrDA.GetCommodityBalance(row.CommodityGradeId, row.WarehouseId);

				row.WarehouseName = lookup.GetWarehouse(Common.EnglishGuid, row.WarehouseId).Name;
				row.CommodityGradeName = lookup.GetCommodityGrade(Common.EnglishGuid, row.CommodityGradeId).Name;

				if (row.PUNQuantity != row.GINQuantity && remainingQtyGreaterThan0OrLessThan0)
					row.Delete();
			}

			ret.AcceptChanges();

			return ret;
		}

        internal BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPUNWHRDetail(int pledgedWHRID, DateTime withdrawalStartDate, DateTime withdrawalEndDate)
        {
            return new DA.PUN().GetPUNWHRDetail(pledgedWHRID, withdrawalStartDate, withdrawalEndDate);
        }
    }
}
