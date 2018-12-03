//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Collections;

//namespace ECX.CD.DA
//{
//    public class PickUpNoticeAgent : SQLHelper
//    {
//        public PickUpNoticeAgent()
//        {

//        }

//        public DataTable SelectByPK(Guid Id)
//        {
//            string SQLQuery = "Select * From [tblPickUpNoticeAgent] Where [Id]=@Id ";

//            SqlCommand command = new SqlCommand(SQLQuery);
//            AddCommandPrametersPrimaryKeys(command, Id);

//            return ExecuteDT(command, "tblPickUpNoticeAgent");
//        }

//        public DataTable SelectByPickupNotice(Guid PickupNoticeId)
//        {
//            string SQLQuery = "Select * From [tblPickUpNoticeAgent] Where [PickupNoticeId]=@PickupNoticeId ";

//            SqlCommand command = new SqlCommand(SQLQuery);
//            command.Parameters.Add("@PickupNoticeId", SqlDbType.BigInt).Value = PickupNoticeId;

//            return ExecuteDT(command);
//        }

//        public DataTable SelectAll()
//        {
//            return ExecuteDT("Select * From [tblPickUpNoticeAgent]", "tblPickUpNoticeAgent");
//        }

//        public bool Insert(Guid PickupNoticeId, String AgentName, Int32 NIDType, String NIDNumber, Int32 Status, Int32 CreatedBy, DateTime CreatedDate, Int32 UpdatedBy, DateTime UpdatedDate)
//        {
//            string SQLQuery = "Insert Into [tblPickUpNoticeAgent] ( Id, PickupNoticeId, AgentName, NIDType, NIDNumber, Status, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate ) Values	(NewId(), @PickupNoticeId, @AgentName, @NIDType, @NIDNumber, @Status, @CreatedBy, @CreatedDate, @UpdatedBy, @UpdatedDate)";

//            SqlCommand command = new SqlCommand(SQLQuery);
//            AddCommandPrameters(command, PickupNoticeId, AgentName, NIDType, NIDNumber, Status, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate);

//            return Convert.ToBoolean(ExecuteNonQuery(command));
//        }

//        //public bool Insert(BE.PUN.PickUpNoticeAgentRow item)
//        //{
//        //    return Insert(item.PickupNoticeId, item.AgentName, item.NIDType, item.NIDNumber, item.Status, item.CreatedBy, item.CreatedDate, item.UpdatedBy, item.UpdatedDate);
//        //}

//        public bool Update(Guid Id, Guid PickupNoticeId, String AgentName, Int32 NIDType, String NIDNumber, Int32 Status, Int32 CreatedBy, DateTime CreatedDate, Int32 UpdatedBy, DateTime UpdatedDate)
//        {
//            string SQLQuery = "Update [tblPickUpNoticeAgent] Set [Id]=@Id, [PickupNoticeId]=@PickupNoticeId, [AgentName]=@AgentName, [NIDType]=@NIDType, [NIDNumber]=@NIDNumber, [Status]=@Status, [CreatedBy]=@CreatedBy, [CreatedDate]=@CreatedDate, [UpdatedBy]=@UpdatedBy, [UpdatedDate]=@UpdatedDate Where [Id]=@Id ";

//            SqlCommand command = new SqlCommand(SQLQuery);
//            AddCommandPrameters(command, Id, PickupNoticeId, AgentName, NIDType, NIDNumber, Status, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate);

//            return Convert.ToBoolean(ExecuteNonQuery(command));
//        }

//        public bool Save(BE.PUN.PickUpNoticeAgentDataTable items)
//        {

//            foreach (BE.PUN.PickUpNoticeAgentRow item in items)
//            {
//                if (item.RowState == DataRowState.Added)
//                {
//                    Insert(item);
//                }
//                else if (item.RowState == DataRowState.Modified)
//                {
//                    Update(item);
//                }
//                else if (item.RowState == DataRowState.Deleted)
//                {
//                    Delete(item);
//                }
//            }

//            return true;
//        }

//        public bool Update(BE.PUN.PickUpNoticeAgentRow item)
//        {
//            return Update(item.Id, item.PickupNoticeId, item.AgentName, item.NIDType, item.NIDNumber, item.Status, item.CreatedBy, item.CreatedDate, item.UpdatedBy, item.UpdatedDate);
//        }

//        public bool Delete(BE.PUN.PickUpNoticeAgentRow item)
//        {
//            string SQLQuery = "DELETE From [tblPickUpNoticeAgent] Where [Id]=@Id ";

//            SqlCommand command = new SqlCommand(SQLQuery);
//            AddCommandPrametersPrimaryKeys(command, item.Id);

//            return Convert.ToBoolean(ExecuteNonQuery(command));
//        }

//        private void AddCommandPrameters(SqlCommand command, Guid Id, Guid PickupNoticeId, String AgentName, Int32 NIDType, String NIDNumber, Int32 Status, Int32 CreatedBy, DateTime CreatedDate, Int32 UpdatedBy, DateTime UpdatedDate)
//        {
//            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
//            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
//            command.Parameters.Add("@AgentName", SqlDbType.NVarChar).Value = AgentName;
//            command.Parameters.Add("@NIDType", SqlDbType.Int).Value = NIDType;
//            command.Parameters.Add("@NIDNumber", SqlDbType.NVarChar).Value = NIDNumber;
//            command.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
//            command.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = CreatedBy;
//            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate;
//            command.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
//            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = UpdatedDate;

//        }

//        private void AddCommandPrameters(SqlCommand command, Guid PickupNoticeId, String AgentName, Int32 NIDType, String NIDNumber, Int32 Status, Int32 CreatedBy, DateTime CreatedDate, Int32 UpdatedBy, DateTime UpdatedDate)
//        {
//            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
//            command.Parameters.Add("@AgentName", SqlDbType.NVarChar).Value = AgentName;
//            command.Parameters.Add("@NIDType", SqlDbType.Int).Value = NIDType;
//            command.Parameters.Add("@NIDNumber", SqlDbType.NVarChar).Value = NIDNumber;
//            command.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
//            command.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = CreatedBy;
//            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = CreatedDate;
//            command.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
//            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = UpdatedDate;

//        }

//        private void AddCommandPrametersPrimaryKeys(SqlCommand command, Guid Id)
//        {
//            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;

//        }
//    }
//}