//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Collections;
//using System.Collections.Generic;

//namespace ECX.CD.DA
//{
//    public partial class tblPickUpNotice : SQLHelper
//    {
//        public tblPickUpNotice()
//        {

//        }

//        public DataTable SelectByPK(Guid Id)
//        {
//            SqlCommand command = new SqlCommand();

//            AddCommandPrametersPrimaryKeys(command, Id);

//            return ExecuteDTSP("spSelectPickUpNoticeByPK", command);
//        }

//        public DataTable SelectByPUNStatus(Byte PUNStatusId)
//        {
//            SqlCommand command = new SqlCommand();

//            command.Parameters.Add("@PUNStatusId", SqlDbType.BigInt).Value = PUNStatusId;

//            return ExecuteDTSP("spSelectPickUpNoticeByPUNStatus", command);
//        }

//        public DataTable SelectAll()
//        {
//            SqlCommand command = new SqlCommand();
			
//            return ExecuteDT("Select * From tblPickUpNotice");
//        }

//        public bool Save(
//            Guid Id, Int32 PUNId, Guid ClientId, Guid CommodityGradeId, Int32 ProductionYear, 
//            Guid WarehouseId, DateTime ExpirationDate, Byte PUNStatusId, String AgentName, 
//            String AgentTel, Int32 NIDType, String NIDNumber, Int32 AgentStatusId, 
//            Double Shortfall, DateTime ExpectedPickupDate, Boolean ExportedToWH, Boolean Exported)
//        {
//            SqlCommand command = new SqlCommand();

//            AddCommandPrameters(command, Id, PUNId, ClientId, CommodityGradeId, ProductionYear, WarehouseId, ExpirationDate, PUNStatusId, AgentName, AgentTel, NIDType, NIDNumber, AgentStatusId, Shortfall, ExpectedPickupDate, ExportedToWH, Exported);

//            return Convert.ToBoolean(ExecuteNonQuerySP("spSavetblPickUpNotice", command));
//        }

//        public bool Save(BE.PUN.tblPickUpNoticeDataTable items)
//        {
//            foreach (BE.PUN.tblPickUpNoticeRow item in items)
//            {
//                Save(item.Id, item.PUNId, item.ClientId, item.CommodityGradeId, item.ProductionYear, item.WarehouseId, item.ExpirationDate, item.PUNStatusId, item.AgentName, item.AgentTel, item.NIDType, item.NIDNumber, item.AgentStatusId, item.Shortfall, item.ExpectedPickupDate, item.ExportedToWH, item.Exported);
//            }

//            return true;
//        }

//        public bool Delete(Guid Id)
//        {
//            string SQLQuery = "DELETE From [tblPickUpNotice] Where [Id]=@Id ";

//            SqlCommand command = new SqlCommand(SQLQuery);
//            AddCommandPrametersPrimaryKeys(command, Id);

//            return Convert.ToBoolean(ExecuteNonQuery(command));
//        }

//        public void Delete(BE.PUN.tblPickUpNoticeDataTable items)
//        {
//            foreach (BE.PUN.tblPickUpNoticeRow item in items)
//            {
//                Delete(item.Id);
//            }
//        }

//        private void AddCommandPrameters(
//            SqlCommand command, Guid Id, Int32 PUNId, Guid ClientId, Guid CommodityGradeId, Int32 ProductionYear, 
//            Guid WarehouseId, DateTime ExpirationDate, Byte PUNStatusId, String AgentName, String AgentTel, 
//            Int32 NIDType, String NIDNumber, Int32 AgentStatusId, Double Shortfall, DateTime ExpectedPickupDate, 
//            Boolean ExportedToWH, Boolean Exported)
//        {
//            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
//            command.Parameters.Add("@PUNId", SqlDbType.Int).Value = PUNId;
//            command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = ClientId;
//            command.Parameters.Add("@CommodityGradeId", SqlDbType.UniqueIdentifier).Value = CommodityGradeId;
//            command.Parameters.Add("@ProductionYear", SqlDbType.Int).Value = ProductionYear;
//            command.Parameters.Add("@WarehouseId", SqlDbType.UniqueIdentifier).Value = WarehouseId;
//            command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
//            command.Parameters.Add("@PUNStatusId", SqlDbType.TinyInt).Value = PUNStatusId;
//            command.Parameters.Add("@AgentName", SqlDbType.NVarChar).Value = AgentName;
//            command.Parameters.Add("@AgentTel", SqlDbType.VarChar).Value = AgentTel;
//            command.Parameters.Add("@NIDType", SqlDbType.Int).Value = NIDType;
//            command.Parameters.Add("@NIDNumber", SqlDbType.NVarChar).Value = NIDNumber;
//            command.Parameters.Add("@AgentStatusId", SqlDbType.Int).Value = AgentStatusId;
//            command.Parameters.Add("@Shortfall", SqlDbType.Float).Value = Shortfall;
//            command.Parameters.Add("@ExpectedPickupDate", SqlDbType.DateTime).Value = ExpectedPickupDate;
//            command.Parameters.Add("@ExportedToWH", SqlDbType.Bit).Value = ExportedToWH;
//            command.Parameters.Add("@Exported", SqlDbType.Bit).Value = Exported;
//        }

//        private void AddCommandPrametersPrimaryKeys(SqlCommand command, Guid Id)
//        {
//            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;

//        }
//    }
//}