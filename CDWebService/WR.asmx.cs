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

namespace ECX.CD
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    [System.Web.Script.Services.ScriptService]
    public class WR : System.Web.Services.WebService
    {
        #region WHR
        //[WebMethod]
        //public List<CWarehouseReceiptForCNS> GetWarehouseRecieptsForCNS(List<int> warehouseRecieptIds)
        //{
        //    return new BL.WarehouseReciept().GetWarehouseRecieptsForCNS(warehouseRecieptIds);
        //}

        [WebMethod]
        public bool SaveWareHouseReciept(
            Guid GRNID, string GRNNumber, Guid CommodityGradeId, Guid WarehouseId,
            Guid BagTypeId, Guid VoucherId, Guid UnLoadingId, Guid ScalingId, Guid GradingId,
            Guid SamplingTicketId, DateTime DateDeposited, DateTime DateApproved, int GRNStatusId,
            double GrossWeight, double NetWeight, double OriginalQuantity, double CurrentQuantity,
            Guid DepositeTypeId, int Source, double NetWeightAdjusted, Guid UserId,
            DateTime CreatedTimeStamp, Guid ClientId, int NumberOfBags, int ProductionYear, Guid GRNTypeId)
        {
            return new BL.WarehouseReciept().SaveWareHouseReciept(
                GRNID, GRNNumber, CommodityGradeId, WarehouseId, BagTypeId, VoucherId, UnLoadingId, ScalingId,
                GradingId, SamplingTicketId, DateDeposited, DateApproved, GRNStatusId, 
                Math.Round(GrossWeight, 2, MidpointRounding.ToEven),
                Math.Round(NetWeight, 2, MidpointRounding.ToEven),
                (Math.Round(OriginalQuantity * 10000))/10000,
                (Math.Round(CurrentQuantity * 10000)) / 10000,
                DepositeTypeId, Source, NetWeightAdjusted, UserId, 
                CreatedTimeStamp, ClientId, NumberOfBags, ProductionYear, GRNTypeId);
        }
        
        //#region For Trading
        //[WebMethod]
        //public BE.WR.WarehouseRecieptDataTable GetWRByGuidId(Guid warehouseReceiptId)
        //{
        //    BE.WR.WarehouseRecieptDataTable ret = new ECX.CD.BE.WR.WarehouseRecieptDataTable();

        //    BE.WR.WarehouseRecieptRow row = (BE.WR.WarehouseRecieptRow)new BL.WarehouseReciept().GetWR(warehouseReceiptId);

        //    ret.AddWarehouseRecieptRow(
        //        row.Id, row.GRNID, row.GRNNumber, row.CommodityGradeId, row.WarehouseId, row.BagTypeId, row.VoucherId,
        //        row.UnLoadingId, row.ScalingId, row.GradingId, row.SamplingTicketId, row.DateDeposited, row.DateApproved,
        //        row.GRNStatus, row.WRStatusId, row.GrossWeight, row.NetWeight, row.OriginalQuantity, row.CurrentQuantity,
        //        row.DepositeTypeId, row.SourceType, row.NetWeightAdjusted, row.CreatedBy, row.CreatedTimeStamp,
        //        row.LastModifiedBy, row.LastModifiedTimeStamp, row.ClientId, row.ProductionYear);

        //    return ret;
        //}

        //[WebMethod]
        //public BE.WR.WarehouseRecieptDataTable GetWRByIntId(int warehouseReceiptId)
        //{
        //    BE.WR.WarehouseRecieptDataTable ret = new ECX.CD.BE.WR.WarehouseRecieptDataTable();

        //    BE.WR.WarehouseRecieptRow row = (BE.WR.WarehouseRecieptRow)new BL.WarehouseReciept().GetWR(warehouseReceiptId);

        //    ret.AddWarehouseRecieptRow(
        //        row.Id, row.GRNID, row.GRNNumber, row.CommodityGradeId, row.WarehouseId, row.BagTypeId, row.VoucherId,
        //        row.UnLoadingId, row.ScalingId, row.GradingId, row.SamplingTicketId, row.DateDeposited, row.DateApproved,
        //        row.GRNStatus, row.WRStatusId, row.GrossWeight, row.NetWeight, row.OriginalQuantity, row.CurrentQuantity,
        //        row.DepositeTypeId, row.SourceType, row.NetWeightAdjusted, row.CreatedBy, row.CreatedTimeStamp,
        //        row.LastModifiedBy, row.LastModifiedTimeStamp, row.ClientId, row.ProductionYear);

        //    return ret;
        //}

        //[WebMethod]
        //public BE.WR.WarehouseRecieptDataTable GetWRByWarehouse(Guid warehouseId)
        //{
        //    return (BE.WR.WarehouseRecieptDataTable)new BL.WarehouseReciept().GetWRByWarehouse(warehouseId);
        //}

        //[WebMethod]
        //public DataTable GetApprovedAndNotExpiredWRs(Guid warehouseId, Guid commodityGradeId, Guid clientId)
        //{
        //    return new BL.WarehouseReciept().GetApprovedAndNotExpiredWRs(warehouseId, commodityGradeId, clientId);
        //}

        //[WebMethod]
        //public bool DeductWRQuantity(Guid warehouseRecieptId, double quantity)
        //{
        //    return new BL.WarehouseReciept().DeductWRQuantity(warehouseRecieptId, quantity);
        //}

        //[WebMethod]
        //public bool AddWRQuantity(Guid warehouseRecieptId, double quantity)
        //{
        //    return new BL.WarehouseReciept().AddWRQuantity(warehouseRecieptId, quantity);
        //}

        //[WebMethod]
        //public List<int> GetAllPledgedNoSaleWRIds()
        //{
        //    return new BL.Pledge().GetAllPledgedNoSaleWRIds();
        //}

        //[WebMethod]
        //public List<int> GetAllPledgedSaleWRIds()
        //{
        //    return new BL.Pledge().GetAllPledgedNoSaleWRIds();
        //} 
        //#endregion

        #endregion

        #region WHR Cancel
        [WebMethod]
        public bool RequestWHRCancel(Guid gRNId, Guid userId, string remark, string trackingNumber)
        {
            return new BL.WarehouseReciept().RequestWHRCancel(gRNId, userId, remark, trackingNumber);
		}
        #endregion

        #region WHR Edit
        [WebMethod]
        public void RequestWHREdit(Guid gRNId, Guid requestedBy, string remark, string trackingNumber)
        {
            new BL.WarehouseReciept().RequestWHREdit(gRNId, requestedBy, remark, trackingNumber);
        }

        [WebMethod]
        public bool UpdateWHREditDetails(Guid Id, Guid EditedBy, DateTime DateEdited, String EditDetail)
        {
            return new BL.WarehouseReciept().UpdateWHREditDetails(Id, EditedBy, DateEdited, EditDetail);
        }

        #endregion

        #region PUN
        [WebMethod]
        public List<CPickUpNotice> GetPun()
        {
            List<CPickUpNotice> ret = new List<CPickUpNotice>();

			BE.PUN pun =new BL.PUN().GetPunForWHExport();
			BE.PUN punWHR;
			List<CWarehouseReciept> cwhrs;
			CWarehouseReciept cwhr;
			CPickUpNotice cpun;
			BL.WarehouseReciept whrBL = new ECX.CD.BL.WarehouseReciept();
			DataRow whrRow;
			CPickupNoticeAgent cpunAgent = new CPickupNoticeAgent();
			List<CPickupNoticeAgent> cpunAgents = new List<CPickupNoticeAgent>();

			foreach (BE.PUN.PickUpNoticeRow pUNRow in pun.PickUpNotice)
			{
				punWHR = new ECX.CD.BE.PUN();
				cwhrs = new List<CWarehouseReciept>();
				cpun = new CPickUpNotice();
				cpunAgent = new CPickupNoticeAgent();
				cpunAgents = new List<CPickupNoticeAgent>();

				punWHR.Merge(pun.PickUpNoticeWarehouseReciept.Select("PickupNoticeId='" + pUNRow.Id.ToString() + "'"));
				foreach (BE.PUN.PickUpNoticeWarehouseRecieptRow pUNWHRRow in punWHR.PickUpNoticeWarehouseReciept)
				{
					cwhr = new CWarehouseReciept();
					whrRow = whrBL.GetWR(pUNWHRRow.WarehouseRecieptId);

					//cwhr.Bags = whrRow.Bags;
					cwhr.BagType = new Guid(whrRow["BagTypeId"].ToString());
					cwhr.GRNID = new Guid(whrRow["Id"].ToString());
					cwhr.GRNNo = whrRow["GRNNumber"].ToString();
					cwhr.Id = whrBL.GetWRGuid(pUNWHRRow.WarehouseRecieptId);
					cwhr.PickupNoticeId = pUNRow.Id;
					cwhr.Quantity = Convert.ToDecimal(pUNWHRRow.Quantity);
					//cwhr.ShedId = new Guid(whrRow["ShedId"].ToString());
					cwhr.WarehouseRecieptId = Convert.ToInt32(whrRow["WarehouseRecieptId"]);
					cwhr.Weight = Convert.ToDecimal(whrRow["NetWeight"]);

					cpun.Quantity += cwhr.Quantity;
					cpun.Weight += cwhr.Weight;

					cwhrs.Add(cwhr);
				}

				cpunAgent.Id = pUNRow.Id;
				cpunAgent.PickupNoticeId = pUNRow.Id;
				cpunAgent.AgentName = pUNRow.AgentName;
				cpunAgent.NIDNumber = pUNRow.NIDNumber;
				cpunAgent.NIDType = pUNRow.NIDType;
				cpunAgent.Status = pUNRow.AgentStatusId;
                cpunAgent.AgentTel = pUNRow.AgentTel;

				cpunAgents.Add(cpunAgent);

				cpun.PickupNoticeId = pUNRow.Id;
				cpun.Status = pUNRow.PUNStatusId;
				cpun.ClientId = pUNRow.ClientId;
				cpun.CommodityGradeId = pUNRow.CommodityGradeId;
				cpun.ProductionYear = pUNRow.ProductionYear;
				cpun.WarehouseId = pUNRow.WarehouseId;
				cpun.ExpectedPickupDate = pUNRow.ExpectedPickupDate;
				cpun.ExpirationDate = pUNRow.ExpirationDate;
                cpun.MemberId = pUNRow.MemberId;
                cpun.RepId = pUNRow.RepId;

				cpun.WarehouseReciepts = cwhrs;
				cpun.PickupNoticeAgents = cpunAgents;
				ret.Add(cpun);
			}

            return ret;
        }

        [WebMethod]
        public bool AcknowledgePuns(List<Guid> punIds)
        {
            new BL.PUN().SetWHAsExported(punIds);
            return true;
        }

        [WebMethod]
        public bool UpdatePUNStatus(Guid PUNId, string pUNStatusName)
        {
            return new BL.PUN().UpdatePUNStatus(PUNId, pUNStatusName);
        }
        #endregion

        #region GIN
		//[WebMethod]
		//public bool InsertGIN(String GINNumber, Guid PickupNoticeId, Double GrossWeight, Double NetWeight, Double Quantity,
		//    DateTime DateIssued, Boolean SignedByClient, DateTime DateApproved, Guid ApprovedBy, String Remark, String Status)
		//{
		//    return new BL.GIN().InsertGIN(GINNumber, PickupNoticeId, GrossWeight, NetWeight, Quantity,
		//        DateIssued, SignedByClient, DateApproved, ApprovedBy, Remark, Status);
		//}

        [WebMethod]
        public bool SaveGIN(Guid Id, String GINNumber, Guid PickupNoticeId, Double GrossWeight, Double NetWeight, Double Quantity,
            DateTime DateIssued, Boolean SignedByClient, DateTime DateApproved, Guid ApprovedBy, String Remark, String Status)
        {
            return new BL.GIN().SaveGIN(Id, GINNumber, PickupNoticeId, GrossWeight, NetWeight, Quantity,
               DateIssued, SignedByClient, DateApproved, ApprovedBy, Remark, Status);
        }
        
        public void RequestGINEdit(Guid GINId, Guid RequestedBy, DateTime DateRequested)
        {
            new BL.GIN().RequestGINEdit(GINId, RequestedBy, DateRequested);
        }

        public void ApproveGINEditRequest(Guid Id, Guid ApprovedBy, DateTime DateApproved)
        {
            new BL.GIN().ApproveGINEditRequest(Id, ApprovedBy, DateApproved);
        }

        public bool UpdateGINEditDetails(Guid Id, Guid EditedBy, DateTime DateEdited, String EditDetail)
        {
            return new BL.GIN().UpdateGINEditDetails(Id, EditedBy, DateEdited, EditDetail);
        }

        public BE.GIN.GINRow GetGIN(Guid GINId)
        {
            return new BL.GIN().GetGIN(GINId);
        }
        #endregion
    }

	public class CPickupNoticeAgent
	{
		#region Member Variables

		private Guid id = Guid.Empty;
		private Guid pickupNoticeId = Guid.Empty;
		private String agentName = String.Empty;
		private int nIDType = 0;
		private String nIDNumber = String.Empty;
		private int status = 0;
        private String agentTel = String.Empty;
		
		#endregion

		#region Properties

		public Guid Id
		{
			get { return id; }
			set { id = value; }
		}

		public Guid PickupNoticeId
		{
			get { return pickupNoticeId; }
			set { pickupNoticeId = value; }
		}

		public String AgentName
		{
			get { return agentName; }
			set { agentName = value; }
		}

		public int NIDType
		{
			get { return nIDType; }
			set { nIDType = value; }
		}

		public String NIDNumber
		{
			get { return nIDNumber; }
			set { nIDNumber = value; }
		}

		public int Status
		{
			get { return status; }
			set { status = value; }
		}

        public String AgentTel
        {
            get { return agentTel; }
            set { agentTel = value; }
        }
		#endregion
	}

    public class CWarehouseReciept
    {
        #region Member Variables
		private Guid pickupNoticeId = Guid.Empty;
        private Guid id = Guid.Empty;
		private Int32 warehouseRecieptId = 0;
		private Guid gRNID = Guid.Empty;
        private String gRNNo = String.Empty;
		private Guid shedId = Guid.Empty;
		private Guid bagType = Guid.Empty;
		private Decimal quantity = 0;
		private Decimal weight = 0;
		private Int32 bags = 0;
        #endregion

        #region Properties

        public Guid Id
        {
            get { return this.id; }
            set
            {

                this.id = value;
            }
		}

		public Guid PickupNoticeId
		{
			get { return pickupNoticeId; }
			set { pickupNoticeId = value; }
		}

		public Int32 WarehouseRecieptId
        {
            get { return this.warehouseRecieptId; }
            set
            {

                this.warehouseRecieptId = value;
            }
		}

		public Guid GRNID
		{
			get { return gRNID; }
			set { gRNID = value; }
		}

        public String GRNNo
        {
            get { return this.gRNNo; }
            set
            {

                this.gRNNo= value;
            }
		}

		public Guid ShedId
		{
			get { return shedId; }
			set { shedId = value; }
		}

		public Guid BagType
		{
			get { return bagType; }
			set { bagType = value; }
		}

		public Decimal Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		public Decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		public Int32 Bags
		{
			get { return bags; }
			set { bags = value; }
		}

        #endregion
    }

    public class CPickUpNotice
    {
		#region Member Variables
		List<CWarehouseReciept> warehouseReciepts = new List<CWarehouseReciept>();
		List<CPickupNoticeAgent> pickupNoticeAgent = new List<CPickupNoticeAgent>();

		private Guid pickupNoticeId = Guid.NewGuid();
		private Guid clientId = Guid.Empty;
		private Guid warehouseId = Guid.Empty;
		private DateTime expirationDate = DateTime.Now;
		private DateTime expectedPickupDate = DateTime.Now;
		private Guid commodityGradeId = Guid.Empty;
		private int productionYear = 0;
		private Decimal quantity = 0;
		private Decimal weight = 0;
		private int status = 0;

        private Guid memberId = Guid.Empty;
        private string repId = string.Empty;

		#endregion

		#region Properties

		public List<CWarehouseReciept> WarehouseReciepts
		{
			get { return warehouseReciepts; }
			set { warehouseReciepts = value; }
		}

		public List<CPickupNoticeAgent> PickupNoticeAgents
		{
			get { return pickupNoticeAgent; }
			set { pickupNoticeAgent = value; }
		}

		public Guid PickupNoticeId
		{
			get { return pickupNoticeId; }
			set { pickupNoticeId = value; }
		}

		public Guid ClientId
		{
			get { return clientId; }
			set { clientId = value; }
		}

		public Guid WarehouseId
		{
			get { return warehouseId; }
			set { warehouseId = value; }
		}

		public DateTime ExpirationDate
		{
			get { return expirationDate; }
			set { expirationDate = value; }
		}

		public DateTime ExpectedPickupDate
		{
			get { return expectedPickupDate; }
			set { expectedPickupDate = value; }
		}

		public Guid CommodityGradeId
		{
			get { return commodityGradeId; }
			set { commodityGradeId = value; }
		}

		public int ProductionYear
		{
			get { return productionYear; }
			set { productionYear = value; }
		}

		public Decimal Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		public Decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		public int Status
		{
			get { return status; }
			set { status = value; }
        }
        
        public string RepId
        {
            get { return repId; }
            set { repId = value; }
        }

        public Guid MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }
		#endregion
    }
}