using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public partial class WarehouseReciept : SQLHelper
    {
        /// <returns>
        /// Total Original Quantity On WHR
        /// From Deposite (Excluding Child WHR/ Trade) And
        /// Status Approved/Closed/New
        /// </returns>
        public float TotalWHROriginalQuantity(Guid WarehouseId, Guid CommodityGradeId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT  SUM(tblWarehouseReciept.OriginalQuantity) AS TotalOriginalQuantity " +
                "FROM    tblWarehouseReciept INNER JOIN " +
                        "tblWarehouseRecieptStatus ON tblWarehouseReciept.WRStatusId = tblWarehouseRecieptStatus.Id INNER JOIN " +
                        "tblSourceType ON tblWarehouseReciept.SourceType = tblSourceType.Id " +
                "WHERE   (tblWarehouseReciept.CommodityGradeId = @CommodityGradeId) AND (tblWarehouseReciept.WarehouseId = @WarehouseId) " +
                "GROUP BY tblWarehouseRecieptStatus.Name, tblSourceType.Name " +
                "HAVING  (tblWarehouseRecieptStatus.Name = 'New') AND " +
                        "(tblWarehouseRecieptStatus.Name <> 'Cancelled') And " +
		                "((tblSourceType.Name = 'Manual') OR " +
                        "(tblWarehouseRecieptStatus.Name = 'Approved') OR " +
                        "(tblWarehouseRecieptStatus.Name = 'Closed'))";

            command.Parameters.Add("WarehouseId", SqlDbType.UniqueIdentifier).Value = WarehouseId;
            command.Parameters.Add("CommodityGradeId", SqlDbType.UniqueIdentifier).Value = CommodityGradeId;

            return ExecuteFloat(command);
        }

        public DataTable SearchWR(
            string warehouseRecieptIdFrom, string warehouseRecieptIdTo,
            string gRNNumberFrom, string gRNNumberTo, string clientId, string wareHouseId,
            string wRStatusId, List<string> commodityGradeIds, string dateDepositedFrom,
            string dateDepositedTo, string expiryDateFrom, string expiryDateTo,
            int currentPage, int pageSize, out int totalRecordCount)
        {
            SqlCommand command = new SqlCommand();
            string whereClause = "";

            whereClause += (warehouseRecieptIdFrom == "") ? "" : "WarehouseRecieptId >= @WarehouseRecieptIdFrom And ";
            whereClause += (warehouseRecieptIdTo == "") ? "" : "WarehouseRecieptId <= @WarehouseRecieptIdTo And ";
            whereClause += (gRNNumberFrom == "") ? "" : "GRNNumber >= @GRNNumberFrom And ";
            whereClause += (gRNNumberTo == "") ? "" : "GRNNumber <= @GRNNumberTo And ";
            whereClause += (clientId == "") ? "" : "ClientId = @ClientId And ";
            whereClause += (wareHouseId == "") ? "" : "WareHouseId = @WareHouseId And ";
            whereClause += (wRStatusId == "") ? "" : "WRStatusId = @WRStatusId And ";
            whereClause += (dateDepositedFrom == "") ? "" : "DateDepositedFrom >= @DateDepositedFrom And ";
            whereClause += (dateDepositedTo == "") ? "" : "DateDepositedTo <= @DateDepositedTo And ";
            whereClause += (expiryDateFrom == "") ? "" : "ExpiryDateFrom >= @ExpiryDateFrom And ";
            whereClause += (expiryDateTo == "") ? "" : "ExpiryDateTo <= @ExpiryDateTo And ";
            whereClause += Utilities.AppendInString("CommodityGradeId", commodityGradeIds);

            if (whereClause != "" && whereClause.Substring(whereClause.Length - 4, 3) == "And")
                whereClause = whereClause.Remove(whereClause.Length - 4, 4);

            whereClause = (whereClause == "") ? "" : "Where " + whereClause;

            if (warehouseRecieptIdFrom != "")
                command.Parameters.Add("@WarehouseRecieptIdFrom", SqlDbType.Int).Value = int.Parse(warehouseRecieptIdFrom);
            if (warehouseRecieptIdTo != "")
                command.Parameters.Add("@WarehouseRecieptIdTo", SqlDbType.Int).Value = int.Parse(warehouseRecieptIdTo);
            if (gRNNumberFrom != "")
                command.Parameters.Add("@GRNNumberFrom", SqlDbType.Int).Value = int.Parse(gRNNumberFrom);
            if (gRNNumberTo != "")
                command.Parameters.Add("@GRNNumberTo", SqlDbType.Int).Value = int.Parse(gRNNumberTo);
            if (clientId != "")
                command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = new Guid(clientId);
            if (wareHouseId != "")
                command.Parameters.Add("@WareHouseId", SqlDbType.UniqueIdentifier).Value = new Guid(wareHouseId);
            if (wRStatusId != "")
                command.Parameters.Add("@WRStatusId", SqlDbType.TinyInt).Value = Convert.ToByte(wRStatusId);
            if (dateDepositedFrom != "")
                command.Parameters.Add("@DateDepositedFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(dateDepositedFrom);
            if (dateDepositedTo != "")
                command.Parameters.Add("@DateDepositedTo", SqlDbType.DateTime).Value = Convert.ToDateTime(dateDepositedTo);
            if (expiryDateFrom != "")
                command.Parameters.Add("@ExpiryDateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(expiryDateFrom);
            if (expiryDateTo != "")
                command.Parameters.Add("@ExpiryDateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(expiryDateTo);

            command.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            command.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

            command.CommandText =
                "Select Count(Id) " +
                "From tblWarehouseReciept " +
                whereClause;

            totalRecordCount = ExecuteInt(command);

            command.CommandText =
            "With WR As " +
            "(Select Id, WarehouseRecieptId, ClientId As ClientGuid, '' As ClientId, " +
                "'' As ClientName, GRNNumber, CommodityGradeId , '' As CommodityGradeName, " +
                "OriginalQuantity, CurrentQuantity, NetWeight, WRStatusId, '' As WRStatusName, " +
                "ExpiryDate, WarehouseId, '' As WarehouseName, Row_Number() Over(Order By WarehouseRecieptId) As RowNumber " +
            "From tblWarehouseReciept " + whereClause + ") " +
            "Select Id, WarehouseRecieptId, ClientGuid, ClientId, " +
                "ClientName, GRNNumber, CommodityGradeId , CommodityGradeName, OriginalQuantity, " +
                "CurrentQuantity, NetWeight, WRStatusId, WRStatusName, ExpiryDate, WarehouseId, WarehouseName " +
            "From WR " +
            "Where RowNumber Between (@CurrentPage * @PageSize) And ((@CurrentPage + 1) * @PageSize)";

            return ExecuteDT(command);
        }

        public DataTable GetWHRForApproval()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Id, WarehouseRecieptId, ClientId As ClientGuid, '' As ClientId, " +
                "'' As ClientName, GRNNumber, CommodityGradeId , '' As CommodityGradeName, " +
				"OriginalQuantity, CurrentQuantity, NetWeight, WRStatusId, '' As WRStatusName, ExpiryDate, WarehouseId " +
                "From tblWarehouseReciept " +
                "Where WRStatusId = " + new Lookup().GetLookupId("tblWarehouseRecieptStatus", "New");

            return ExecuteDT(command);
        }

        public int GetWHRForApprovalCount()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Count(Id) " +
                "From tblWarehouseReciept " +
                "Where WRStatusId = " + new Lookup().GetLookupId("tblWarehouseRecieptStatus", "New");

            return ExecuteInt(command);
        }

        public Guid GetWHRGuid(int warehouseRecieptId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Id " +
                "From WarehouseRecieptId = @WarehouseRecieptId ";

            command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

            return ExecuteGuid(command);
        }

        public void InactivateWR(Guid id)
        {

        }

        public DataTable SelectByPK(int WarehouseRecieptId)
        {
            string SQLQuery = "Select * From [tblWarehouseReciept] Where [WarehouseRecieptId]=@WarehouseRecieptId ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = WarehouseRecieptId;

            return ExecuteDT(command, "tblWarehouseReciept");
        }

        public DataRow GetWR(Guid wRId)
        {
            string SQLQuery = "Select * From [tblWarehouseReciept] Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wRId;

            return ExecuteDT(command).Rows[0];
		}

		public DataRow GetWR(int warehouseRecieptId)
		{
			string SQLQuery = "Select * From [tblWarehouseReciept] Where [WarehouseRecieptId]=@WarehouseRecieptId ";

			SqlCommand command = new SqlCommand(SQLQuery);

			command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

			return ExecuteDT(command).Rows[0];
		}

		public Guid GetWRGuid(int warehouseRecieptId)
		{
			string SQLQuery = "Select Id From [tblWarehouseReciept] Where [WarehouseRecieptId]=@WarehouseRecieptId ";

			SqlCommand command = new SqlCommand(SQLQuery);

			command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

			return ExecuteGuid(command);
		}

        public bool UpdateWR(
            Guid wRId, Guid wRStatusId, string wrStatusName,
            DateTime expiryDate, DateTime dateApproved, Guid userId, string remark)
        {
            SqlCommand command;
            string SQLQuery;

            if (wrStatusName == "Approved" && wRStatusId != GetCurrentWRStatus(wRId))
            {
                SQLQuery =
                    "Update [tblWarehouseReciept] " +
                        "Set WRStatusId = @WRStatusId, ApprovedBy=@ApprovedBy, Remark = @Remark, DateApproved = @DateApproved " +
                    "Where [Id]=@Id ";

                command = new SqlCommand(SQLQuery);

                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wRId;
                command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = dateApproved;
                command.Parameters.Add("@ApprovedBy", SqlDbType.UniqueIdentifier).Value = userId;
                command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = dateApproved;
                command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = remark;

                Convert.ToBoolean(ExecuteNonQuery(command));
            }

            return false;
        }

        public Guid GetCurrentWRStatus(Guid wRId)
        {
            string SQLQuery =
                   "Select WRStatusId " +
                   "From [tblWarehouseReciept] " +
                   "Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wRId;

            return new Guid(ExecuteScalar(command).ToString());
        }

        public bool CloseWarehouseReciepts(List<int> warehouseRecieptIds, Guid userId)
        {
            SqlCommand command;
            string SQLQuery;
            byte closedWRStatusId = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Closed");

            foreach (int warehouseRecieptId in warehouseRecieptIds)
            {
                SQLQuery =
                    "Update [tblWarehouseReciept] " +
                        "Set WRStatusId = @ClosedWRStatusId, LastModifiedBy=@UserId, LastModifiedTimeStamp = Getdate() " +
                    "Where [WarehouseRecieptId]=@WarehouseRecieptId ";

                command = new SqlCommand(SQLQuery);

                command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;
                command.Parameters.Add("@ClosedWRStatusId", SqlDbType.TinyInt).Value = closedWRStatusId;
                command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = "Status was set to approved.";

                Convert.ToBoolean(ExecuteNonQuery(command));
            }

            return true;
        }

        public bool ApproveWarehouseReciepts(int warehouseRecieptId, DateTime expiryDate, Guid approvedby)
        {
            SqlCommand command;
            string SQLQuery;
            byte approvedWRStatusId = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");

            SQLQuery =
                "Update [tblWarehouseReciept] " +
                    "Set WRStatusId = @ApprovedWRStatusId, ApprovedBy=@ApprovedBy, DateApproved = @DateApproved, ExpiryDate = @ExpiryDate " +
                "Where [WarehouseRecieptId]=@WarehouseRecieptId ";

            command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;
            command.Parameters.Add("@ApprovedWRStatusId", SqlDbType.TinyInt).Value = approvedWRStatusId;
            command.Parameters.Add("@ApprovedBy", SqlDbType.UniqueIdentifier).Value = approvedby;
            command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateTime.Today;
            command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = "Status was set to approved.";
            command.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = expiryDate;

            Convert.ToBoolean(ExecuteNonQuery(command));

            return true;
        }

        public bool CancelWarehousehouseReciept(Guid Id)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Id;

            return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("tblWarehouseReciept_Cancel", command));
        }

        public bool CancelWarehouseReciepts(List<int> warehouseRecieptIds, Guid userId)
        {
            SqlCommand command;
            string SQLQuery;
            byte cancelledWRStatusId = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Cancelled");

            foreach (int warehouseRecieptId in warehouseRecieptIds)
            {
                SQLQuery =
                    "Update [tblWarehouseReciept] " +
                        "Set WRStatusId = @CancelledWRStatusId, LastModifiedBy=@UserId, LastModifiedTimeStamp = Getdate() " +
                    "Where [WarehouseRecieptId]=@WarehouseRecieptId ";

                command = new SqlCommand(SQLQuery);

                command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;
                command.Parameters.Add("@CancelledWRStatusId", SqlDbType.TinyInt).Value = cancelledWRStatusId;
                command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = "Status was set to approved.";

                Convert.ToBoolean(ExecuteNonQuery(command));
            }

            return true;
        }

        public void ExtendExpiryDate(List<int> warehouseRecieptIds, int numberOfDays, Guid userId)
        {
            SqlCommand command;

            foreach (int warehouseRecieptId in warehouseRecieptIds)
            {
                command = new SqlCommand();

                command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;
                command.Parameters.Add("@NumberOfDays", SqlDbType.Int).Value = numberOfDays;
                command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;

                ExecuteNonQueryStoredProcedure("spExtendWRExpiryDate", command);
            }
        }

        public bool SaveWareHouseReciept(
            Guid GRNID, string GRNNumber, Guid CommodityGradeId, Guid WarehouseId,
            Guid BagTypeId, Guid VoucherId, Guid UnLoadingId, Guid ScalingId, Guid GradingId,
            Guid SamplingTicketId, DateTime DateDeposited, DateTime DateApproved, int GRNStatusId,
            double GrossWeight, double NetWeight, double OriginalQuantity, double CurrentQuantity,
            Guid DepositeTypeId, int Source, double NetWeightAdjusted, Guid UserId, 
            DateTime CreatedTimeStamp, Guid ClientId, int NumberOfBags, int ProductionYear, Guid GRNTypeId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@GRNID", SqlDbType.UniqueIdentifier).Value = GRNID;
            command.Parameters.Add("@GRNNumber", SqlDbType.VarChar).Value = GRNNumber;
            command.Parameters.Add("@CommodityGradeId", SqlDbType.UniqueIdentifier).Value = CommodityGradeId;
            command.Parameters.Add("@WarehouseId", SqlDbType.UniqueIdentifier).Value = WarehouseId;
            command.Parameters.Add("@BagTypeId", SqlDbType.UniqueIdentifier).Value = BagTypeId;
            command.Parameters.Add("@VoucherId", SqlDbType.UniqueIdentifier).Value = VoucherId;
            command.Parameters.Add("@UnLoadingId", SqlDbType.UniqueIdentifier).Value = UnLoadingId;
            command.Parameters.Add("@ScalingId", SqlDbType.UniqueIdentifier).Value = ScalingId;
            command.Parameters.Add("@GradingId", SqlDbType.UniqueIdentifier).Value = GradingId;
            command.Parameters.Add("@SamplingTicketId", SqlDbType.UniqueIdentifier).Value = SamplingTicketId;
            command.Parameters.Add("@DateDeposited", SqlDbType.DateTime).Value = DateDeposited;
            command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateApproved;
            command.Parameters.Add("@GRNStatus", SqlDbType.Int).Value = GRNStatusId;
            //TODO ask abera on the look up
            command.Parameters.Add("@WRStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "New");//1
            command.Parameters.Add("@GrossWeight", SqlDbType.Float).Value = GrossWeight;
            command.Parameters.Add("@NetWeight", SqlDbType.Float).Value = NetWeight;
            command.Parameters.Add("@OriginalQuantity", SqlDbType.Float).Value = OriginalQuantity;
            command.Parameters.Add("@CurrentQuantity", SqlDbType.Float).Value = CurrentQuantity;
            command.Parameters.Add("@DepositeTypeId", SqlDbType.UniqueIdentifier).Value = DepositeTypeId;
            command.Parameters.Add("@Source", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblSourceType", "Manual");
            command.Parameters.Add("@NetWeightAdjusted", SqlDbType.Float).Value = NetWeightAdjusted;
            command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;
            command.Parameters.Add("@CreatedTimeStamp", SqlDbType.DateTime).Value = CreatedTimeStamp;
            command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = ClientId;
            command.Parameters.Add("@NumberOfBags", SqlDbType.Int).Value = NumberOfBags;
            command.Parameters.Add("@ProductionYear", SqlDbType.Int).Value = ProductionYear;
            command.Parameters.Add("@GRNTypeId", SqlDbType.UniqueIdentifier).Value = GRNTypeId;

            return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("tblWarehouseReciept_Insert", command));

        }

		#region WHR Edit

		public DataTable GetWHRForEditRequestApproval(string[] transactionNos)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"Select Id, WarehouseRecieptId, ClientId As ClientGuid, '' As ClientId, " +
					"'' As ClientName, GRNNumber, CommodityGradeId , '' As CommodityGradeName, " +
					"CurrentQuantity, NetWeight, WRStatusId, '' As WRStatusName, ExpiryDate " +
				"From tblWarehouseReciept " +
				"Where WRStatusId = " + new Lookup().GetLookupId("tblWarehouseRecieptStatus", "New") +
					" And Id In(Select WarehouseRecieptId From tblWHREdit Where Status = 1)";

			return ExecuteDT(command);
		}

        public Guid RequestWHREdit(Guid warehouseReceiptId, Guid RequestedBy, DateTime DateRequested)
        {
			SqlCommand command = new SqlCommand();
			Guid id = Guid.NewGuid();

			command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.UniqueIdentifier).Value = warehouseReceiptId;
            command.Parameters.Add("@RequestedBy", SqlDbType.UniqueIdentifier).Value = RequestedBy;
            command.Parameters.Add("@DateRequested", SqlDbType.DateTime).Value = DateRequested;

            ExecuteNonQuerySP("spRequestWHREdit", command);

			return id;
        }

        public bool ApproveWHREdit(Guid Id, Guid ApprovedBy, DateTime DateApproved)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            command.Parameters.Add("@ApprovedBy", SqlDbType.UniqueIdentifier).Value = ApprovedBy;
            command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateApproved;

            return Convert.ToBoolean(ExecuteNonQuerySP("spApproveWHREdit", command));
        }

        public bool UpdateWHREditDetails(Guid Id, Guid EditedBy, DateTime DateEdited, String EditDetail)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            command.Parameters.Add("@EditedBy", SqlDbType.UniqueIdentifier).Value = EditedBy;
            command.Parameters.Add("@DateEdited", SqlDbType.DateTime).Value = DateEdited;
            command.Parameters.Add("@EditDetail", SqlDbType.VarChar).Value = EditDetail;

            return Convert.ToBoolean(ExecuteNonQuerySP("spUpdateWHREditDetails", command));
        }

        #endregion

		#region Cancel WHR

		public DataTable GetWHRForWHRCancelApproval(string[] transactionNos)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"SELECT tblWHRCancel.Id, tblWarehouseReciept.WarehouseRecieptId, tblWarehouseReciept.ClientId AS ClientGuid, " +
					"'' AS ClientId, '' AS ClientName, tblWarehouseReciept.GRNNumber, tblWarehouseReciept.CommodityGradeId, " +
					"'' AS CommodityGradeName, tblWarehouseReciept.CurrentQuantity, tblWarehouseReciept.NetWeight, " +
					"tblWarehouseReciept.WRStatusId, tblWarehouseRecieptStatus.Name AS WRStatusName, tblWarehouseReciept.ExpiryDate " +
				"FROM   tblWarehouseReciept INNER JOIN " +
					"tblWHRCancel ON tblWarehouseReciept.Id = tblWHRCancel.WHRId INNER JOIN " +
					"tblWarehouseRecieptStatus ON tblWarehouseReciept.WRStatusId = tblWarehouseRecieptStatus.Id " +
				"Where tblWHRCancel.Id In (" +
					"Select ObjectId " +
					"From tblTransaction " +
					"Where " +
					Utilities.AppendInString("TransactionNO", transactionNos) + ") " +
				"Order By tblWarehouseReciept.WarehouseRecieptId";

			return ExecuteDT(command);
		}

		//public DataTable GetWHRForWHRCancel(string[] transactionNos)
		//{
		//    SqlCommand command = new SqlCommand();

		//    command.CommandText =
		//        "SELECT tblWHRCancel.Id, tblWarehouseReciept.WarehouseRecieptId, tblWarehouseReciept.ClientId AS ClientGuid, " +
		//            "'' AS ClientId, '' AS ClientName, tblWarehouseReciept.GRNNumber, tblWarehouseReciept.CommodityGradeId, " +
		//            "'' AS CommodityGradeName, tblWarehouseReciept.CurrentQuantity, tblWarehouseReciept.NetWeight, " +
		//            "tblWarehouseReciept.WRStatusId, tblWarehouseRecieptStatus.Name AS WRStatusName, tblWarehouseReciept.ExpiryDate " +
		//        "FROM   tblWarehouseReciept INNER JOIN " +
		//            "tblWHRCancel ON tblWarehouseReciept.Id = tblWHRCancel.WHRId INNER JOIN " +
		//            "tblWarehouseRecieptStatus ON tblWarehouseReciept.WRStatusId = tblWarehouseRecieptStatus.Id " +
		//        "Where tblWHRCancel.Id In (" +
		//            "Select ObjectId " +
		//            "From tblTransaction " +
		//            "Where " +
		//            Utilities.AppendInString("TransactionNO", transactionNos) + ") " +
		//        "Order By tblWarehouseReciept.WarehouseRecieptId";

		//    return ExecuteDT(command);
		//}

		/// <returns>WHRCancelId</returns>
		public Guid RequestWHRCancel(Guid userId, Guid wHRId)
		{
			SqlCommand command = new SqlCommand();
			Guid id = Guid.NewGuid();

			command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;
			command.Parameters.Add("WHRId", SqlDbType.UniqueIdentifier).Value = wHRId;
			command.Parameters.Add("RequestedBy", SqlDbType.UniqueIdentifier).Value = userId;

			ExecuteNonQueryStoredProcedure("spRequestWHRCancel", command);

			return id;
		}

		public void ApproveWHRCancel(Guid userId, Guid wHRCancelId)
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = wHRCancelId;
			command.Parameters.Add("ApprovedBy", SqlDbType.UniqueIdentifier).Value = userId;
			command.Parameters.Add("ApprovedStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWHRCancelStatus", "Approved");

			ExecuteNonQueryStoredProcedure("spApproveWHRCancel", command);
		}

		public bool CancelWHR(Guid userId, Guid wHRCancelIdId)
		{
			SqlCommand command;

			command = new SqlCommand();

			command.Parameters.Add("WHRCancelId", SqlDbType.UniqueIdentifier).Value = wHRCancelIdId;
			command.Parameters.Add("CancelledBy", SqlDbType.UniqueIdentifier).Value = userId;
			command.Parameters.Add("CancelledWHRStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Cancelled");

			return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("spCancelWHR", command));
		}
		#endregion
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        