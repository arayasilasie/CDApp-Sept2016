using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class PUN : SQLHelper
    {
        #region Extend Expiry
        public DataTable GetPUNForExtendExpiryApproval()
		{
			SqlCommand command = new SqlCommand();

			command.Parameters.Add("@ApprovedWRStatusId", SqlDbType.TinyInt).Value = 
				new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");

			command.CommandText =
            "SELECT	tblExtendPUNExpiryDate.Id, tblPickUpNotice.PUNId, tblPickUpNotice.WarehouseId, " +
					"'' AS WarehouseName, '' AS WarehouseRecieptIds, tblPickUpNotice.ExpirationDate, " + 
					"tblPickUpNotice.AgentName, tblPickUpNotice.NIDNumber, tblPUNStatus.Name AS PUNStatusName, " +
					"tblExtendPUNExpiryDate.NumberOfDays " +
			"FROM    tblPickUpNotice INNER JOIN " +
					"tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id INNER JOIN " +
					"tblExtendPUNExpiryDate ON tblPickUpNotice.Id = tblExtendPUNExpiryDate.PUNId INNER JOIN " +
					"tblExtendExpiryDateStatus ON tblExtendPUNExpiryDate.Status = tblExtendExpiryDateStatus.Id " +
            "WHERE   (tblExtendExpiryDateStatus.Name = 'New') ";

			return ExecuteDT(command);
        }

        public int GetPUNForExtendExpiryApprovalCount()
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ApprovedWRStatusId", SqlDbType.TinyInt).Value =
                new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");

            command.CommandText =
            "SELECT	tblPickUpNotice.Id, tblPickUpNotice.PUNId, tblPickUpNotice.WarehouseId, " +
                    "'' AS WarehouseName, '' AS WarehouseRecieptIds, tblPickUpNotice.ExpirationDate, " +
                    "tblPickUpNotice.AgentName, tblPickUpNotice.NIDNumber, tblPUNStatus.Name AS PUNStatusName, " +
                    "tblExtendPUNExpiryDate.NumberOfDays " +
            "FROM    tblPickUpNotice INNER JOIN " +
                    "tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id INNER JOIN " +
                    "tblExtendPUNExpiryDate ON tblPickUpNotice.Id = tblExtendPUNExpiryDate.PUNId INNER JOIN " +
                    "tblExtendExpiryDateStatus ON tblExtendPUNExpiryDate.Status = tblExtendExpiryDateStatus.Id " +
            "WHERE   (tblExtendExpiryDateStatus.Name = 'New') ";

            return ExecuteDT(command).Rows.Count;
        }

		public bool ApprovePUNExtendExpiry(List<Guid> extendExpiryDateIds, Guid userId)
		{
			List<SqlCommand> commands = new List<SqlCommand>();
			SqlCommand command = new SqlCommand();

			foreach (Guid extendExpiryDateId in extendExpiryDateIds)
			{
				command.CommandText = "spApproveExtendPUNExpiryDate";
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = extendExpiryDateId;
				command.Parameters.Add("UserId", SqlDbType.UniqueIdentifier).Value = userId;

                commands.AddRange(DeductMoistureLoss(extendExpiryDateId));
                
				commands.Add(command);
			}

            if (new GINDetail.GINDetail().ExtendPUN(GetExpiredPUNExtension(extendExpiryDateIds), userId, DateTime.Now))
                return ExecuteTransaction(commands);
            else
                return false;
		}

        public GINDetail.CExpiredPUNExtension[] GetExpiredPUNExtension(List<Guid> extendExpiryDateIds)
        {
            List<GINDetail.CExpiredPUNExtension> ret = new List<ECX.CD.DA.GINDetail.CExpiredPUNExtension>();
            GINDetail.CExpiredPUNExtension epe;
            DataTable items;
            string filter = Utilities.AppendInString("Id", extendExpiryDateIds);
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT	PUNId, NumberofDays " +
                "FROM    tblExtendPUNExpiryDate " +
                ((filter == "")?"":"WHERE " + filter);
            items = ExecuteDT(command);

            foreach (DataRow item in items.Rows)
            {
                epe = new ECX.CD.DA.GINDetail.CExpiredPUNExtension();
                epe.PickupNoticeId = new Guid(item["PUNId"].ToString());
                epe.NoOfDays = Convert.ToInt32(item["NumberofDays"]);

                ret.Add(epe);
            }

            return ret.ToArray<GINDetail.CExpiredPUNExtension>();
        }

        public List<SqlCommand> DeductMoistureLoss(Guid extendPUNExpiryId)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlCommand command = new SqlCommand();
            DataTable items;

            command.CommandText =
                "SELECT	tblPickUpNoticeWarehouseReciept.WarehouseRecieptId, " +
		                "tblPickUpNoticeWarehouseReciept.PickupNoticeId,  " +
                        "tblPickUpNoticeWarehouseReciept.Weight,  " +
		                "tblPickUpNotice.ExpirationDate,  " +
		                "tblWarehouseReciept.CommodityGradeId " +
                "FROM    tblPickUpNoticeWarehouseReciept INNER JOIN " +
                        "tblPickUpNotice ON tblPickUpNoticeWarehouseReciept.PickupNoticeId = tblPickUpNotice.Id INNER JOIN " +
                        "tblExtendPUNExpiryDate ON tblPickUpNotice.Id = tblExtendPUNExpiryDate.PUNId INNER JOIN " +
                        "tblWarehouseReciept ON tblPickUpNoticeWarehouseReciept.WarehouseRecieptId = tblWarehouseReciept.WarehouseRecieptId " +
                "WHERE   (tblExtendPUNExpiryDate.Id = @ExtendPUNExpiryDateId)";

            command.Parameters.Add("ExtendPUNExpiryDateId", SqlDbType.UniqueIdentifier).Value = extendPUNExpiryId;
            items = ExecuteDT(command);

            foreach (DataRow item in items.Rows)
            {
                command.CommandText =
                    "Update	tblPickUpNoticeWarehouseReciept " +
                    "Set	Weight = Weight * (1 - @MoistureLossFactore) * @NumberofDays";

                command.Parameters.Add("MoistureLossFactore", SqlDbType.Float).Value = new Moisture().GetLossAmount(new Guid(item["CommodityGradeId"].ToString()));
                command.Parameters.Add("NumberofDays", SqlDbType.Float).Value = DateTime.Today.Subtract(Convert.ToDateTime(item["ExpirationDate"])).Days;

                commands.Add(command);
            }

            return commands;
        }

		public bool RejectPUNExtendExpiry(List<Guid> extendExpiryDateIds, Guid userId)
		{
			List<SqlCommand> commands = new List<SqlCommand>();
			SqlCommand command = new SqlCommand();

			foreach (Guid extendExpiryDateId in extendExpiryDateIds)
			{
				command.CommandText = "spRejectExtendPUNExpiryDate";
				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = extendExpiryDateId;
				command.Parameters.Add("UserId", SqlDbType.UniqueIdentifier).Value = userId;

				commands.Add(command);
			}

			return ExecuteTransaction(commands);
		}

		/// <summary>
		/// warehouseRecieptIds is <WarehouseRecieptId, NumberOfDays>
		/// </summary>
		public void SaveExtendExpiryDateRequest(Dictionary<Guid, int> pickupNotices, Guid userId)
		{
			SqlCommand command;

			foreach (KeyValuePair<Guid, int> pickupNotice in pickupNotices)
			{
				command = new SqlCommand();

				command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
				command.Parameters.Add("@PUNId", SqlDbType.UniqueIdentifier).Value = pickupNotice.Key;
				command.Parameters.Add("@RequestedBy", SqlDbType.UniqueIdentifier).Value = userId;
				command.Parameters.Add("@DateRequested", SqlDbType.DateTime).Value = DateTime.Today;
				command.Parameters.Add("@NumberOfDays", SqlDbType.Int).Value = pickupNotice.Value;

				ExecuteNonQueryStoredProcedure("spSaveExtendPUNExpiryDate", command);
			}
        }
        #endregion

        /// <returns>
        /// Total PUN Quantity
        /// But Status Not Cancelled
        /// </returns>
		public float TotalPUNQuantity(Guid WarehouseId, Guid CommodityGradeId, int productionYear)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT  SUM(tblPickUpNoticeWarehouseReciept.Quantity) AS TotalQuantityOnPUN " +
                "FROM    tblPickUpNoticeWarehouseReciept INNER JOIN " +
                        "tblPickUpNotice ON tblPickUpNoticeWarehouseReciept.PickupNoticeId = tblPickUpNotice.Id INNER JOIN " +
                        "tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id " +
				"WHERE   (tblPickUpNotice.CommodityGradeId = @CommodityGradeId) AND (tblPickUpNotice.WarehouseId = @WarehouseId) And (ProductionYear = @ProductionYear) " +
                "GROUP BY tblPUNStatus.Name " +
                "HAVING  (tblPUNStatus.Name <> 'Cancelled')";

            command.Parameters.Add("WarehouseId", SqlDbType.UniqueIdentifier).Value = WarehouseId;
            command.Parameters.Add("CommodityGradeId", SqlDbType.UniqueIdentifier).Value = CommodityGradeId;
			command.Parameters.Add("ProductionYear", SqlDbType.Int).Value = productionYear;

            return ExecuteFloat(command);
        }

        public DataTable GetPUN(Guid PUNId)
        {
            string SQLQuery = "Select * From [tblPickUpNotice] Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = PUNId;

            return ExecuteDT(command, "PickUpNotice");
        }

        public DataTable SearchPickUpNotice(
            string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
            string pUNIdFrom, string pUNIdTo, string expirationDateFrom, string expirationDateTo,
            string expectedPickupDateFrom, string expectedPickupDateTo, string pUNStatusId,
            Guid clientId, Guid wareHouseId, string dateCreatedFrom, string dateCreatedTo,
            string tradeDateFrom, string tradeDateTo)
        {
            string whereClause = "";
            SqlCommand command = new SqlCommand();
            string wHRWhereClause = "";

            wHRWhereClause += (warehouseReceiptIDFrom == "") ? "" : "WarehouseRecieptId >= @WarehouseReceiptIDFrom And ";
            wHRWhereClause += (warehouseReceiptIDTo == "") ? "" : "WarehouseRecieptId <= @WarehouseReceiptIDTo And ";

            if (wHRWhereClause.EndsWith(" And "))
                wHRWhereClause = wHRWhereClause.Remove(wHRWhereClause.Length - 5, 4);
            if (wHRWhereClause != "")
            {
                wHRWhereClause =
                    "tblPickUpNotice.Id In (Select PickupNoticeId " +
                    "From tblPickUpNoticeWarehouseReciept " +
                    "Where " + wHRWhereClause + ") And ";
            }

            whereClause = wHRWhereClause;
            whereClause += (pUNIdFrom == "") ? "" : "PUNId >= @PUNIdFrom And ";
            whereClause += (pUNIdTo == "") ? "" : "PUNId <= @PUNIdTo And ";
            whereClause += (expirationDateFrom == "") ? "" : "ExpirationDate >= @ExpirationDateFrom And ";
            whereClause += (expirationDateTo == "") ? "" : "ExpirationDate <= @ExpirationDateTo And ";
            whereClause += (expectedPickupDateFrom == "") ? "" : "ExpectedPickupDate >= @ExpectedPickupDateFrom And ";
            whereClause += (expectedPickupDateTo == "") ? "" : "ExpectedPickupDate <= @ExpectedPickupDateTo And ";
            whereClause += (clientId == Guid.Empty) ? "" : "ClientId = @ClientId And ";
            whereClause += (wareHouseId == Guid.Empty) ? "" : "WarehouseId = @WarehouseId And ";
            whereClause += (dateCreatedFrom == "") ? "" : "CreatedTimestamp >= @CreatedTimestampFrom And ";
            whereClause += (dateCreatedTo == "") ? "" : "CreatedTimestamp <= @CreatedTimestampTo And ";
            whereClause += (pUNStatusId == "") ? "" : "PUNStatusId = @PUNStatusId And ";

            if (whereClause.EndsWith(" And "))
            {
                whereClause = whereClause.Remove(whereClause.Length - 5, 4);
            }
            whereClause = (whereClause == "") ? "" : "Where " + whereClause;

            command.CommandText =
                "SELECT tblPickUpNotice.Id, tblPickUpNotice.PUNId, tblPickUpNotice.WarehouseId, " +
                    "'' As WarehouseName, '' As WarehouseRecieptIds, tblPickUpNotice.ExpirationDate, " +
                    "tblPickUpNotice.AgentName, tblPickUpNotice.AgentTel, tblPickUpNotice.NIDNumber, " +
                    "tblPUNStatus.Name As PUNStatusName, " +
                    "ClientId As ClientGuid, '' As ClientId, '' As ClientName, CommodityGradeId, '' As Symbol, CreatedTimestamp " +
                "FROM   tblPickUpNotice INNER JOIN " +
                    "tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id " +
                whereClause + " " +
                "Order By tblPickUpNotice.PUNId";

            if (!string.IsNullOrEmpty(warehouseReceiptIDFrom)) command.Parameters.Add("WarehouseReceiptIDFrom", SqlDbType.Int).Value = warehouseReceiptIDFrom;
            if (!string.IsNullOrEmpty(warehouseReceiptIDTo)) command.Parameters.Add("WarehouseReceiptIDTo", SqlDbType.Int).Value = warehouseReceiptIDTo;
            if (!string.IsNullOrEmpty(pUNIdFrom)) command.Parameters.Add("PUNIdFrom", SqlDbType.Int).Value = pUNIdFrom;
            if (!string.IsNullOrEmpty(pUNIdTo)) command.Parameters.Add("PUNIdTo", SqlDbType.Int).Value = pUNIdTo;
            if (!string.IsNullOrEmpty(expirationDateFrom)) command.Parameters.Add("ExpirationDateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(expirationDateFrom);
            if (!string.IsNullOrEmpty(expirationDateTo)) command.Parameters.Add("ExpirationDateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(expirationDateTo);
            if (!string.IsNullOrEmpty(expectedPickupDateFrom)) command.Parameters.Add("ExpectedPickupDateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(expectedPickupDateFrom);
            if (!string.IsNullOrEmpty(expectedPickupDateTo)) command.Parameters.Add("ExpectedPickupDateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(expectedPickupDateTo);
            if (!string.IsNullOrEmpty(dateCreatedFrom)) command.Parameters.Add("CreatedTimestampFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(dateCreatedFrom);
            if (!string.IsNullOrEmpty(dateCreatedTo)) command.Parameters.Add("CreatedTimestampTo", SqlDbType.DateTime).Value = Convert.ToDateTime(dateCreatedTo);
            if (clientId != Guid.Empty) command.Parameters.Add("ClientId", SqlDbType.UniqueIdentifier).Value = clientId;
            if (wareHouseId != Guid.Empty) command.Parameters.Add("WarehouseId", SqlDbType.UniqueIdentifier).Value = wareHouseId;
            if (!string.IsNullOrEmpty(pUNStatusId)) command.Parameters.Add("PUNStatusId", SqlDbType.TinyInt).Value = pUNStatusId;

            return ExecuteDT(command);
        }

        public DataTable SearchPUNForCancel(
            string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
            string pUNIdFrom, string pUNIdTo, string expirationDateFrom, string expirationDateTo,
            string expectedPickupDateFrom, string expectedPickupDateTo, string pUNStatusId)
        {
            string whereClause = "";
            SqlCommand command = new SqlCommand();
            string wHRWhereClause = "";

            wHRWhereClause += (warehouseReceiptIDFrom == "") ? "" : "WarehouseRecieptId >= @WarehouseReceiptIDFrom And ";
            wHRWhereClause += (warehouseReceiptIDTo == "") ? "" : "WarehouseRecieptId <= @WarehouseReceiptIDTo And ";

            if (wHRWhereClause.EndsWith(" And "))
                wHRWhereClause = wHRWhereClause.Remove(wHRWhereClause.Length - 5, 4);
            if (wHRWhereClause != "")
            {
                wHRWhereClause =
                    "tblPickUpNotice.Id In (Select PickupNoticeId " +
                    "From tblPickUpNoticeWarehouseReciept " +
                    "Where " + wHRWhereClause + ") And ";
            }

            whereClause = wHRWhereClause;
            whereClause += (pUNIdFrom == "") ? "" : "PUNId >= @PUNIdFrom And ";
            whereClause += (pUNIdTo == "") ? "" : "PUNId <= @PUNIdTo And ";
            whereClause += (expirationDateFrom == "") ? "" : "ExpirationDate >= @ExpirationDateFrom And ";
            whereClause += (expirationDateTo == "") ? "" : "ExpirationDate <= @ExpirationDateTo And ";
            whereClause += (expectedPickupDateFrom == "") ? "" : "ExpectedPickupDate >= @ExpectedPickupDateFrom And ";
            whereClause += (expectedPickupDateTo == "") ? "" : "ExpectedPickupDate <= @ExpectedPickupDateTo And ";
            whereClause += (pUNStatusId == "") ? "" : "PUNStatusId = @PUNStatusId And ";

            if (whereClause.EndsWith(" And "))
            {
                whereClause = whereClause.Remove(whereClause.Length - 5, 4);
            }
            whereClause = (whereClause == "") ? "" : "Where " + whereClause;

            command.CommandText =
                "SELECT tblPickUpNotice.Id, tblPickUpNotice.PUNId, tblPickUpNotice.WarehouseId, " +
                    "'' As WarehouseName, '' As WarehouseRecieptIds, tblPickUpNotice.ExpirationDate, " +
                    "tblPickUpNotice.AgentName, tblPickUpNotice.NIDNumber, tblPUNStatus.Name As PUNStatusName " +
                "FROM   tblPickUpNotice INNER JOIN " +
                    "tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id " +
                whereClause + " " +
                "Order By tblPickUpNotice.PUNId";

            Utilities.AddCommandParameters(new DBParameter[]{
                new DBParameter("WarehouseReceiptIDFrom", SqlDbType.Int, warehouseReceiptIDFrom),
                new DBParameter("WarehouseReceiptIDTo", SqlDbType.Int, warehouseReceiptIDFrom),
                new DBParameter("PUNIdFrom", SqlDbType.Int, pUNIdFrom),
                new DBParameter("PUNIdTo", SqlDbType.Int, pUNIdFrom),
                new DBParameter("ExpirationDateFrom", SqlDbType.DateTime, expirationDateFrom),
                new DBParameter("ExpirationDateTo", SqlDbType.DateTime, expirationDateTo),
                new DBParameter("ExpectedPickupDateFrom", SqlDbType.Date, expectedPickupDateFrom),
                new DBParameter("ExpectedPickupDateTo", SqlDbType.Date, expectedPickupDateTo),
                new DBParameter("PUNStatusId", SqlDbType.TinyInt, pUNStatusId)}, command);

            return ExecuteDT(command);
        }

		public DataTable GetPUNForCancel()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT tblPickUpNotice.Id, tblPickUpNotice.PUNId, tblPickUpNotice.WarehouseId, " +
                    "'' As WarehouseName, '' As WarehouseRecieptIds, tblPickUpNotice.ExpirationDate, " +
                    "tblPickUpNotice.AgentName, tblPickUpNotice.NIDNumber, tblPUNStatus.Name As PUNStatusName " +
                "FROM   tblPickUpNotice INNER JOIN " +
                    "tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id " +
				"Where	tblPickUpNotice.PUNStatusId = (Select Id From tblPUNStatus Where [Name] = 'New')" +
                "Order By tblPickUpNotice.PUNId";

            return ExecuteDT(command);
        }

        public int TotalRecordCount(
            string warehouseReceiptIDFrom, string warehouseReceiptIDTo,
            string pUNIdFrom, string pUNIdTo, string expirationDateFrom, string expirationDateTo,
            string expectedPickupDateFrom, string expectedPickupDateTo, string pUNStatusId)
        {
            string whereClause = "";
            SqlCommand command = new SqlCommand();
            string wHRWhereClause = "";

            wHRWhereClause += (warehouseReceiptIDFrom == "") ? "" : "WarehouseRecieptId >= @WarehouseReceiptIDFrom And ";
            wHRWhereClause += (warehouseReceiptIDTo == "") ? "" : "WarehouseRecieptId <= @WarehouseReceiptIDTo ";

            if (wHRWhereClause.EndsWith(" And "))
                wHRWhereClause = wHRWhereClause.Remove(wHRWhereClause.Length - 5, 4);
            if (wHRWhereClause != "")
                wHRWhereClause =
                    "Id In (Select PickupNoticeId " +
                    "From tblPickUpNoticeWarehouseReciept " +
                    "Where " + wHRWhereClause + ") And ";

            whereClause = wHRWhereClause;
            whereClause += (pUNIdFrom == "") ? "" : "PUNId >= @PUNIdFrom And ";
            whereClause += (pUNIdTo == "") ? "" : "PUNId <= @PUNIdTo And ";
            whereClause += (expirationDateFrom == "") ? "" : "ExpirationDate >= @ExpirationDateFrom And ";
            whereClause += (expirationDateTo == "") ? "" : "ExpirationDate <= @ExpirationDateTo And ";
            whereClause += (expectedPickupDateFrom == "") ? "" : "ExpectedPickupDate >= @ExpectedPickupDateFrom And ";
            whereClause += (expectedPickupDateTo == "") ? "" : "ExpectedPickupDate <= @ExpectedPickupDateTo And ";
            whereClause += (pUNStatusId == "") ? "" : "PUNStatusId = @PUNStatusId And ";

            if (whereClause.EndsWith(" And "))
                whereClause = whereClause.Remove(whereClause.Length - 5, 4);

            whereClause = (whereClause == "") ? "" : "Where " + whereClause;

            command.CommandText =
                "Select Count(*) " +
                "From [tblPickUpNotice] " +
                whereClause;

            Utilities.AddCommandParameters(new DBParameter[]{
                new DBParameter("WarehouseReceiptIDFrom", SqlDbType.Int, warehouseReceiptIDFrom),
                new DBParameter("WarehouseReceiptIDTo", SqlDbType.Int, warehouseReceiptIDFrom),
                new DBParameter("PUNIdFrom", SqlDbType.Int, pUNIdFrom),
                new DBParameter("PUNIdTo", SqlDbType.Int, pUNIdFrom),
                new DBParameter("ExpirationDateFrom", SqlDbType.DateTime, expirationDateFrom),
                new DBParameter("ExpirationDateTo", SqlDbType.DateTime, expirationDateTo),
                new DBParameter("ExpectedPickupDateFrom", SqlDbType.DateTime, expectedPickupDateFrom),
                new DBParameter("ExpectedPickupDateTo", SqlDbType.DateTime, expectedPickupDateTo),
                new DBParameter("PUNStatusId", SqlDbType.TinyInt, pUNStatusId)}, command);

            return ExecuteInt(command);
        }

        public List<string> GetClientIdsForPUN(List<string> clientIds)
        {
            SqlCommand command = new SqlCommand();
            DataTable items = new DataTable();
            List<string> ret = new List<string>();

            string whereClause = Utilities.AppendInString("ClientId", clientIds);
            whereClause = (whereClause == "") ? "" : " And " + whereClause;

            command.CommandText =
                "SELECT Distinct ClientId " +
                "FROM   tblWarehouseReciept " +
                "WHERE  (CurrentQuantity > 0) AND (SourceType = 2) " + whereClause;

            items = ExecuteDT(command);
            foreach (DataRow row in items.Rows)
            {
                ret.Add(row[0].ToString());
            }

            return ret;
        }

        public List<string> GetWarehouseIdsForPUN(List<Guid> clientIds)
        {
            SqlCommand command = new SqlCommand();
            DataTable items = new DataTable();
            List<string> ret = new List<string>();

            string whereClause = Utilities.AppendInString("ClientId", clientIds);
            whereClause = (whereClause == "") ? "" : " And " + whereClause;

            command.CommandText =
                "SELECT Distinct WarehouseId " +
                "FROM   tblWarehouseReciept " +
                "WHERE  (CurrentQuantity > 0) AND (SourceType = "+new Lookup().GetLookupId("tblSourceType", "Trade").ToString()+") " + whereClause;

            items = ExecuteDT(command);
            foreach (DataRow row in items.Rows)
            {
                ret.Add(row[0].ToString());
            }

            return ret;
        }

        public List<string> GetCommodityGradesIdsForPUN(List<Guid> clientIds)
        {
            SqlCommand command = new SqlCommand();
            DataTable items = new DataTable();
            List<string> ret = new List<string>();

            string whereClause = Utilities.AppendInString("ClientId", clientIds);
            whereClause = (whereClause == "") ? "" : " And " + whereClause;

            command.CommandText =
                "SELECT Distinct CommodityGradeId " +
                "FROM   tblWarehouseReciept " +
                "WHERE  (CurrentQuantity > 0) AND (SourceType = 2) " + whereClause;

            items = ExecuteDT(command);
            foreach (DataRow row in items.Rows)
            {
                ret.Add(row[0].ToString());
            }

            return ret;
        }

        public List<string> GetCommodityGradesIdsForPUN(Guid clientId)
        {
            SqlCommand command = new SqlCommand();
            DataTable items = new DataTable();
            List<string> ret = new List<string>();

            command.CommandText =
                "SELECT Distinct CommodityGradeId " +
                "FROM   tblWarehouseReciept " +
                "WHERE  (CurrentQuantity > 0) AND (SourceType = @SourceTypeStatusId) And (ClientId = @ClientId) And (WRStatusId = @ApprovedWRStatusId)";

            command.Parameters.Add("ClientId", SqlDbType.UniqueIdentifier).Value = clientId;
            command.Parameters.Add("ApprovedWRStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");
            command.Parameters.Add("SourceTypeStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblSourceType", "Trade");

            items = ExecuteDT(command);
            foreach (DataRow row in items.Rows)
            {
                ret.Add(row[0].ToString());
            }

            return ret;
        }

		public List<int> GetProductionYearForPUN(List<Guid> clientIds)
        {
            SqlCommand command = new SqlCommand();
            DataTable items = new DataTable();
			List<int> ret = new List<int>();

            string whereClause = Utilities.AppendInString("ClientId", clientIds);
            whereClause = (whereClause == "") ? "" : " And " + whereClause;

            command.CommandText =
				"SELECT Distinct ProductionYear " +
                "FROM   tblWarehouseReciept " +
                "WHERE  (CurrentQuantity > 0) AND (SourceType = 2) " + whereClause;

            items = ExecuteDT(command);
            foreach (DataRow row in items.Rows)
            {
                if (string.IsNullOrEmpty(row[0].ToString()))
                    continue;

                ret.Add( ((row[0] == null)?0:Convert.ToInt32(row[0])));
            }

            return ret;
        }

        public BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPickupNoticeWarehouseReciepts(
			Guid pickupNoticeId, Guid warehouseId, Guid clientId, 
			Guid userId, int productionYear, Guid commodityGradeId)
        {
            SqlCommand command = new SqlCommand();
            DataTable items = new DataTable();
            BE.PUN.PickUpNoticeWarehouseRecieptDataTable ret = new ECX.CD.BE.PUN.PickUpNoticeWarehouseRecieptDataTable();
			ECXLookup.ECXLookup eCXLookup = new ECX.CD.DA.ECXLookup.ECXLookup();

            if (!PickupNoticeExits(pickupNoticeId))
            {
                command.CommandText =
                    "SELECT Distinct Cast(0 AS bit) As Selected, WarehouseRecieptId, OriginalQuantity, NetWeight As Weight, " +
                        "TempQuantity As QuantityRemaining, " +
                        "TempQuantity As QuantityWithdrawn, " +
                        "Cast('" + pickupNoticeId.ToString() + "' As UniqueIdentifier) As PickupNoticeId, " +
                        "Cast(0 As float) As Shortfall, " +
                        "GetDate() As DNReceivedDateTime, '' As TradeDate, " +
                        "Cast('" + userId.ToString() + "' As UniqueIdentifier) As CreatedBy " +
                    "FROM   tblWarehouseReciept " +
                    "WHERE  WarehouseId = @WarehouseId And " +
                        //"TempQuantity = OriginalQuantity And " +
						"ClientId = @ClientId And " +
						"CurrentQuantity > 0 And " +
						"ProductionYear = @ProductionYear And " +
						"CommodityGradeId = @CommodityGradeId And " +
						//TODO:what if SourceType is manual
						"((@CanWithdraw = 1) Or (SourceType = (Select Id From tblSourceType Where [Name] = 'Trade')))";

                command.Parameters.Add("@WarehouseId", SqlDbType.UniqueIdentifier).Value = warehouseId;
                command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = clientId;
				command.Parameters.Add("@ProductionYear", SqlDbType.Int).Value = productionYear;
				command.Parameters.Add("@CommodityGradeId", SqlDbType.UniqueIdentifier).Value = commodityGradeId;
				command.Parameters.Add("@CanWithdraw", SqlDbType.Bit).Value = 
					eCXLookup.GetCommodityGrade(Utilities.EnglishGuid, commodityGradeId).CanWithdraw;

                ret.Merge(ExecuteDT(command));
            }
            else
            {
                command.CommandText =
                    "SELECT  Cast(1 AS bit) As Selected, tblPickUpNoticeWarehouseReciept.WarehouseRecieptId, tblPickUpNoticeWarehouseReciept.Weight, " +
                            "tblPickUpNoticeWarehouseReciept.Quantity As QuantityWithdrawn, " +
							"tblPickUpNoticeWarehouseReciept.PickupNoticeId, " +
							"Cast(0 As float) As Shortfall, " +
							"tblPickUpNoticeWarehouseReciept.DNReceivedDateTime, '' As TradeDate, " +
                            "(tblWarehouseReciept.CurrentQuantity + tblPickUpNoticeWarehouseReciept.Quantity) As QuantityRemaining, " +
                            "tblWarehouseReciept.OriginalQuantity " +
                    "FROM	tblPickUpNoticeWarehouseReciept INNER JOIN " +
                            "tblWarehouseReciept ON tblPickUpNoticeWarehouseReciept.WarehouseRecieptId = tblWarehouseReciept.WarehouseRecieptId " +
                    "WHERE   (tblPickUpNoticeWarehouseReciept.PickupNoticeId = @PickupNoticeId)";

                command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = pickupNoticeId;

                ret.Merge(ExecuteDT(command));
            }

            return ret;
        }

        public BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPickupNoticeWarehouseReciepts(Guid pickupNoticeId)
        {
            SqlCommand command = new SqlCommand();
            DataTable items = new DataTable();
            BE.PUN.PickUpNoticeWarehouseRecieptDataTable ret = new ECX.CD.BE.PUN.PickUpNoticeWarehouseRecieptDataTable();
            ECXLookup.ECXLookup eCXLookup = new ECX.CD.DA.ECXLookup.ECXLookup();

            command.CommandText =
                "SELECT  Cast(1 AS bit) As Selected, tblPickUpNoticeWarehouseReciept.WarehouseRecieptId, " +
                        "tblPickUpNoticeWarehouseReciept.Weight, " +
                        "tblPickUpNoticeWarehouseReciept.Quantity As QuantityWithdrawn, " +
                        "tblPickUpNoticeWarehouseReciept.PickupNoticeId, " +
                        "Cast(0 As float) As Shortfall, " +
                        "tblPickUpNoticeWarehouseReciept.DNReceivedDateTime, '' As TradeDate, " +
                        "(tblWarehouseReciept.CurrentQuantity + tblPickUpNoticeWarehouseReciept.Quantity) As QuantityRemaining, " +
                        "tblWarehouseReciept.OriginalQuantity " +
                "FROM	tblPickUpNoticeWarehouseReciept INNER JOIN " +
                        "tblWarehouseReciept ON tblPickUpNoticeWarehouseReciept.WarehouseRecieptId = tblWarehouseReciept.WarehouseRecieptId " +
                "WHERE   (tblPickUpNoticeWarehouseReciept.PickupNoticeId = @PickupNoticeId)";

            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = pickupNoticeId;

            ret.Merge(ExecuteDT(command));

            return ret;
        }

        public BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPickupNoticeWarehouseReciepts(
            int warehouseReceiptId, Guid pickupNoticeId, Guid userId)
        {
            SqlCommand command = new SqlCommand();
            DataTable items = new DataTable();
            BE.PUN.PickUpNoticeWarehouseRecieptDataTable ret = new ECX.CD.BE.PUN.PickUpNoticeWarehouseRecieptDataTable();
            ECXLookup.ECXLookup eCXLookup = new ECX.CD.DA.ECXLookup.ECXLookup();
            Guid commodityGradeId = new WarehouseReciept().GetWHRCommodityGradeId(warehouseReceiptId);

            command.CommandText =
                "SELECT Distinct Cast(0 AS bit) As Selected, WarehouseRecieptId, OriginalQuantity, NetWeight As Weight, " +
                    "TempQuantity As QuantityRemaining, " +
                    "TempQuantity As QuantityWithdrawn, " +
                    "Cast('" + pickupNoticeId.ToString() + "' As UniqueIdentifier) As PickupNoticeId, " +
                    "Cast(0 As float) As Shortfall, " +
                    "GetDate() As DNReceivedDateTime, '' As TradeDate, " +
                    "Cast('" + userId.ToString() + "' As UniqueIdentifier) As CreatedBy " +
                "FROM   tblWarehouseReciept " +
                "WHERE  WarehouseRecieptId = @WarehouseReceiptId And " +
                    "CurrentQuantity > 0 And " +
                    "((@CanWithdraw = 1) Or (SourceType = (Select Id From tblSourceType Where [Name] = 'Trade')))";

            command.Parameters.Add("@WarehouseReceiptId", SqlDbType.Int).Value = warehouseReceiptId;
            command.Parameters.Add("@CanWithdraw", SqlDbType.Bit).Value =
                eCXLookup.GetCommodityGrade(Utilities.EnglishGuid, commodityGradeId).CanWithdraw;

            ret.Merge(ExecuteDT(command));

            return ret;
        }

        #region CreatePUN
        /// <returns>returns the PUNId</returns>
		public Int32 CreatePUN(Guid Id, Guid MemberId, Guid ClientId, Guid CommodityGradeId, double Shortfall,
            DateTime ExpectedPickupDate, Guid WarehouseId, DateTime ExpirationDate, Byte PUNStatusId,
            String AgentName, Int32 NIDType, String NIDNumber, Int32 AgentStatusId, 
            String AgentTel, String RepId, Boolean Exported, Guid UserId, int ProductionYear,
            BE.PUN.PickUpNoticeWarehouseRecieptDataTable punWHRs, 
            BE.PUN.PickupNoticeDriverDataTable punDrivers)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
			command.Parameters.Add("@MemberId", SqlDbType.UniqueIdentifier).Value = MemberId;
            command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = ClientId;
            command.Parameters.Add("@CommodityGradeId", SqlDbType.UniqueIdentifier).Value = CommodityGradeId;
            command.Parameters.Add("@Shortfall", SqlDbType.Float).Value = Shortfall;
            command.Parameters.Add("@ExpectedPickupDate", SqlDbType.DateTime).Value = ExpectedPickupDate;
            command.Parameters.Add("@WarehouseId", SqlDbType.UniqueIdentifier).Value = WarehouseId;
            command.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = ExpirationDate;
            command.Parameters.Add("@PUNStatusId", SqlDbType.TinyInt).Value = PUNStatusId;
            command.Parameters.Add("@AgentName", SqlDbType.NVarChar).Value = AgentName;
            command.Parameters.Add("@NIDType", SqlDbType.Int).Value = NIDType;
            command.Parameters.Add("@NIDNumber", SqlDbType.NVarChar).Value = NIDNumber;
            command.Parameters.Add("@AgentStatusId", SqlDbType.Int).Value = AgentStatusId;
            command.Parameters.Add("@AgentTel", SqlDbType.NVarChar).Value = AgentTel;
            command.Parameters.Add("@RepId", SqlDbType.NVarChar).Value = RepId;
            command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;
			command.Parameters.Add("@ProductionYear", SqlDbType.Int).Value = ProductionYear;
            command.CommandText = "spSavePickUpNotice";
            command.CommandType = CommandType.StoredProcedure;

            commands.Add(command);

            foreach (BE.PUN.PickUpNoticeWarehouseRecieptRow row in punWHRs)
            {
                commands.Add(SavePUNWR(
                    row.WarehouseRecieptId, row.PickupNoticeId, row.Quantity, row.Weight, 
                    row.DNReceivedDateTime, row.CreatedBy));
            }

            foreach(BE.PUN.PickupNoticeDriverRow row in punDrivers)
            {
                commands.Add(SavePickupNoticeDriver(row.Id, row.PickupNoticeId,
                    row.DriverName, row.LicenseNumber, row.PlateNumber, 
                    row.TrailerPlateNumber, row.Capacity, row.CreatedBy));
            }

            if(ExecuteTransaction(commands))
            //ExecuteNonQueryStoredProcedure("spSavePickUpNotice", command);
                return GetPUNId(Id);
            else
                return -1;
        }

        public SqlCommand SavePUNWR(Int32 WarehouseRecieptId, Guid PickupNoticeId,
            Double Quantity, Double Weight, DateTime DNReceivedDateTime, Guid UserId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = WarehouseRecieptId;
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
            command.Parameters.Add("@Quantity", SqlDbType.Float).Value = Quantity;
            command.Parameters.Add("@Weight", SqlDbType.Float).Value = Weight;
            command.Parameters.Add("@DNReceivedDateTime", SqlDbType.DateTime).Value = DNReceivedDateTime;
            command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;

            command.CommandText = "spSavePUNWR";
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public SqlCommand SavePickupNoticeDriver(
            Guid Id, Guid PickupNoticeId, string DriverName, string LicenseNumber,
            string PlateNumber, string TrailerPlateNumber, string Capacity, Guid UserId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
            command.Parameters.Add("@DriverName", SqlDbType.NVarChar).Value = DriverName;
            command.Parameters.Add("@LicenseNumber", SqlDbType.NVarChar).Value = LicenseNumber;
            command.Parameters.Add("@PlateNumber", SqlDbType.NVarChar).Value = PlateNumber;
            command.Parameters.Add("@TrailerPlateNumber", SqlDbType.NVarChar).Value = TrailerPlateNumber;
            command.Parameters.Add("@Capacity", SqlDbType.VarChar).Value = Capacity;
            command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;

            command.CommandText = "spSavePUNDriver";
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }
        #endregion

        #region PUN WR
        public SqlCommand SavePUNWR(Boolean Selected, Int32 WarehouseRecieptId, Guid PickupNoticeId,
            Double Quantity, Double Weight, DateTime DNReceivedDateTime, Guid UserId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Selected", SqlDbType.Bit).Value = Selected;
            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = WarehouseRecieptId;
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
            command.Parameters.Add("@Quantity", SqlDbType.Float).Value = Quantity;
            command.Parameters.Add("@Weight", SqlDbType.Float).Value = Weight;
            command.Parameters.Add("@DNReceivedDateTime", SqlDbType.DateTime).Value = DNReceivedDateTime;
            command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;
            command.CommandText = "spSavePUNWR";

            return command;
        }

        public DataTable SelectPUNWRByPickupNotice(Guid PickupNoticeId)
        {
            string SQLQuery = "Select * From [tblPickUpNoticeWarehouseReciept] Where PickupNoticeId = @PickupNoticeId ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;

            return ExecuteDT(command, "tblPickUpNoticeWarehouseReciept");
        }

        #endregion

        #region PUN Driver

        public DataTable SelectPUNDriverByPickupNotice(Guid PickupNoticeId)
        {
            string SQLQuery = "Select * From [tblPickupNoticeDriver] Where [PickupNoticeId]=@PickupNoticeId ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;

            return ExecuteDT(command, "tblPickupNoticeDriver");
        }

        #endregion

        public Int32 GetPUNId(Guid Id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT PUNId " +
                "FROM   tblPickUpNotice " +
                "WHERE  Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;

            return Convert.ToInt32(ExecuteScalar(command));
        }

        public List<Guid> GetPunForWHExport()
        {
            List<Guid> ret = new List<Guid>();
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT Id " +
                "FROM   tblPickUpNotice " +
                "WHERE  ExportedToWH = 0";

            DataTable tbl = ExecuteDT(command);

            foreach (DataRow row in tbl.Rows)
            {
                ret.Add(new Guid(row[0].ToString()));
            }

            return ret;
        }

        public void SetWHAsExported(List<Guid> punIds)
        {
            SqlCommand command = new SqlCommand();

            if (punIds.Count == 0)
                return;

            string where = Utilities.AppendInString("Id", punIds);

            command.CommandText =
                "Update tblPickUpNotice " +
                "Set    ExportedToWH = 1 " +
                "Where " + where;

            ExecuteNonQuery(command);
        }

        public bool PUNWRExits(Int32 warehouseRecieptId, Guid pickupNoticeId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT Count(*) " +
                "FROM   tblPickUpNoticeWarehouseReciept  " +
                "WHERE  WarehouseRecieptId = @WarehouseRecieptId And PickupNoticeId = @PickupNoticeId";

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;
            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = pickupNoticeId;

            return Convert.ToBoolean(ExecuteScalar(command));
        }

        public bool PickupNoticeExits(Guid id)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT Count(*) " +
                "FROM   tblPickupNotice " +
                "WHERE  Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;

            return Convert.ToBoolean(ExecuteScalar(command));
        }

        //public DataTable GetPickupNoticeWarehouseReciepts(Guid pUNId)
        //{
        //    SqlCommand command = new SqlCommand();

        //    command.CommandText =
        //        "SELECT * " +
        //        "FROM   tblPickUpNoticeWarehouseReciept " +
        //        "WHERE  (PickupNoticeId = @PickupNoticeId)";

        //    command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = pUNId;

        //    return ExecuteDT(command);
        //}

        public DataTable GetPickupNoticeDrivers(Guid pUNId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT * " +
                "FROM   tblPickUpNoticeDriver " +
                "WHERE  (PickupNoticeId = @PickupNoticeId)";

            command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = pUNId;

            return ExecuteDT(command);
        }

        public string GetWarehouseRecieptIds(Guid pUNId)
        {
            SqlCommand command = new SqlCommand();
            DataTable items;
            string ret = "";
            int count;

            command.CommandText =
                "SELECT WarehouseRecieptId " +
                "FROM   tblPickUpNoticeWarehouseReciept " +
                "WHERE  (PickupNoticeId = @PUNId)";

            command.Parameters.Add("@PUNId", SqlDbType.UniqueIdentifier).Value = pUNId;

            items = ExecuteDT(command);
            count = items.Rows.Count;
            if (count == 0)
                return ret;

            ret += items.Rows[0][0].ToString();
            for (int i = 1; i < count; i++)
            {
                ret += "," + items.Rows[i][0].ToString();
            }

            return ret;
        }

        public string GetTradeDates(Guid pUNId)
        {
            SqlCommand command = new SqlCommand();
            DataTable items;
            string ret = "";
            int count;

            command.CommandText =
                "SELECT tblWarehouseReciept.TradeDate " +
                "FROM   tblPickUpNoticeWarehouseReciept INNER JOIN " +
                       "tblWarehouseReciept ON tblPickUpNoticeWarehouseReciept.WarehouseRecieptId = tblWarehouseReciept.WarehouseRecieptId " +
                "WHERE  (tblPickUpNoticeWarehouseReciept.PickupNoticeId = @PUNId)";

            command.Parameters.Add("@PUNId", SqlDbType.UniqueIdentifier).Value = pUNId;

            items = ExecuteDT(command);
            count = items.Rows.Count;
            if (count == 0)
                return ret;

            ret += items.Rows[0][0].ToString();
            for (int i = 1; i < count; i++)
            {
                ret += "," + items.Rows[i][0].ToString();
            }

            return ret;
        }

        //public bool SavePickupNoticeDriver(
        //    Guid Id, Guid PickupNoticeId, string DriverName, string LicenseNumber,
        //    string PlateNumber, string TrailerPlateNumber, string Capacity, Guid UserId)
        //{
        //    SqlCommand command = new SqlCommand();

        //    command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Id;
        //    command.Parameters.Add("@PickupNoticeId", SqlDbType.UniqueIdentifier).Value = PickupNoticeId;
        //    command.Parameters.Add("@DriverName", SqlDbType.NVarChar).Value = DriverName;
        //    command.Parameters.Add("@LicenseNumber", SqlDbType.NVarChar).Value = LicenseNumber;
        //    command.Parameters.Add("@PlateNumber", SqlDbType.NVarChar).Value = PlateNumber;
        //    command.Parameters.Add("@TrailerPlateNumber", SqlDbType.NVarChar).Value = TrailerPlateNumber;
        //    command.Parameters.Add("@Capacity", SqlDbType.VarChar).Value = Capacity;
        //    command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;

        //    return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("spSavePUNDriver", command));
        //}

        public void DeletePUNDriver(Guid id)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;

            ExecuteNonQueryStoredProcedure("spDeletePUNDriver", command);
        }

        public bool UpdatePUNStatus(Guid PUNId, string pUNStatusName)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = PUNId;
            command.Parameters.Add("@PUNStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblPUNStatus", pUNStatusName);

            return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("spUpdatePUNStatus", command));
        }

		#region Cancel PUN

		public DataTable GetPUNForPUNCancelApproval()
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
                "SELECT  tblPUNCancel.Id, tblPickUpNotice.PUNId, tblPickUpNotice.WarehouseId, " +
                    "'' As WarehouseName, '' As WarehouseRecieptIds, tblPickUpNotice.ExpirationDate, " +
                    "tblPickUpNotice.AgentName, tblPickUpNotice.NIDNumber, tblPUNStatus.Name As PUNStatusName " +
                "FROM   tblPickUpNotice INNER JOIN " +
                    "tblPUNCancel ON tblPickUpNotice.Id = tblPUNCancel.PUNId INNER JOIN " +
					"tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id INNER JOIN " +
					"tblPUNCancelStatus ON tblPUNCancel.Status = tblPUNCancelStatus.Id " +
				"Where tblPUNCancelStatus.Name = 'New' " +
                "Order By tblPickUpNotice.PUNId";

			return ExecuteDT(command);
        }

        public DataTable GetPUNForCancel(string[] transactionNos)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT  tblPUNCancel.Id, tblPickUpNotice.PUNId, tblPickUpNotice.WarehouseId, " +
                    "'' As WarehouseName, '' As WarehouseRecieptIds, tblPickUpNotice.ExpirationDate, " +
                    "tblPickUpNotice.AgentName, tblPickUpNotice.NIDNumber, tblPUNStatus.Name As PUNStatusName " +
                "FROM   tblPickUpNotice INNER JOIN " +
                    "tblPUNCancel ON tblPickUpNotice.Id = tblPUNCancel.PUNId INNER JOIN " +
                    "tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id " +
                "Where tblPUNCancel.Id In ( " +
                    "Select ObjectId " +
                    "From tblTransaction " +
                    "Where " +
                    Utilities.AppendInString("TransactionNO", transactionNos) + ") " +
                "Order By tblPickUpNotice.PUNId";

            return ExecuteDT(command);

            //SqlCommand command = new SqlCommand();

            //command.CommandText =
            //    "Select Id, WarehouseRecieptId, ClientId As ClientGuid, '' As ClientId, " +
            //        "'' As ClientName, GRNNumber, CommodityGradeId , '' As CommodityGradeName, " +
            //        "CurrentQuantity, NetWeight, WRStatusId, '' As WRStatusName, ExpiryDate " +
            //    "From tblWarehouseReciept " +
            //    "Where WRStatusId = " + new Lookup().GetLookupId("tblWarehouseRecieptStatus", "New") +
            //        " And Id In(Select WarehouseRecieptId From tblWHREdit Where Status = 1)";

            //return ExecuteDT(command);
        }

        /// <returns>The PUNCancelId</returns>
        public Guid RequestPUNCancel(Guid userId, Guid pUNId)
        {
            SqlCommand command = new SqlCommand();
            Guid id = Guid.NewGuid();

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;
            command.Parameters.Add("PUNId", SqlDbType.UniqueIdentifier).Value = pUNId;
            command.Parameters.Add("RequestedBy", SqlDbType.UniqueIdentifier).Value = userId;

            ExecuteNonQueryStoredProcedure("spRequestPUNCancel", command);

            return id;
        }

        public void ApprovePUNCancel(Guid userId, Guid pUNCancelId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = pUNCancelId;
            command.Parameters.Add("ApprovedBy", SqlDbType.UniqueIdentifier).Value = userId;
            command.Parameters.Add("ApprovedStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblPUNCancelStatus", "Approved");

            ExecuteNonQueryStoredProcedure("spApprovePUNCancel", command);
        }

		public void RejectPUNCancel(Guid userId, Guid pUNCancelId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = pUNCancelId;
            command.Parameters.Add("ApprovedBy", SqlDbType.UniqueIdentifier).Value = userId;

            ExecuteNonQueryStoredProcedure("spRejectPUNCancel", command);
        }

        public void CancelPUN(Guid userId, Guid pUNCancelIdId)
        {
            SqlCommand command;

            command = new SqlCommand();

            command.Parameters.Add("PUNCancelId", SqlDbType.UniqueIdentifier).Value = pUNCancelIdId;
            command.Parameters.Add("CancelledBy", SqlDbType.UniqueIdentifier).Value = userId;
			command.Parameters.Add("@CancelledPUNStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblPUNStatus", "Cancelled");

            ExecuteNonQueryStoredProcedure("spCancelPUN", command);
        }
        #endregion

		public int GetApprovePUNCancelCount()
		{
			SqlCommand command = new SqlCommand();

			command.CommandText = 
				"SELECT	COUNT(tblPUNCancel.Id) " +
				"FROM    tblPUNCancel INNER JOIN " +
						"tblPUNCancelStatus ON tblPUNCancel.Status = tblPUNCancelStatus.Id " +
				"WHERE   (tblPUNCancelStatus.Name = 'New')";

            return ExecuteInt(command);
		}

		public DataTable SearchViewPUNBalance(
			string warehouseReceiptIDFrom, string warehouseReceiptIDTo, Guid clientId, bool remainingQtyGreaterThan0OrLessThan0)
		{
			string whereClause = "";
			SqlCommand command = new SqlCommand();
			string wHRWhereClause = "";

			wHRWhereClause += (warehouseReceiptIDFrom == "") ? "" : "WarehouseRecieptId >= @WarehouseReceiptIDFrom And ";
			wHRWhereClause += (warehouseReceiptIDTo == "") ? "" : "WarehouseRecieptId <= @WarehouseReceiptIDTo And ";
			wHRWhereClause += (clientId == Guid.Empty) ? "" : "ClientId = @ClientId ";

			if (whereClause.EndsWith(" And "))
			{
				whereClause = whereClause.Remove(whereClause.Length - 5, 4);
			}
			whereClause = (whereClause == "") ? "" : "Where " + whereClause;

			command.CommandText =
				"SELECT tblPickUpNotice.Id, tblPickUpNotice.PUNId, '' As WarehouseRecieptIds, " +
					"Cast(0 As float) As PUNQuantity, Cast(0 As float) As GINQuantity, " +
					"Cast(0 As float) As RemainingQuantity, WarehouseId, '' As WarehouseName, " +
					"CommodityGradeId, '' As CommodityGradeName " +
				"FROM   tblPickUpNotice INNER JOIN " +
					"tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id " +
				whereClause + " " +
				"Order By tblPickUpNotice.PUNId";

			command.Parameters.AddWithValue("WarehouseReceiptIDFrom", warehouseReceiptIDFrom);
			command.Parameters.AddWithValue("WarehouseReceiptIDTo", warehouseReceiptIDFrom);
			command.Parameters.AddWithValue("ClientId", clientId);

			//command.Parameters.Add("WarehouseReceiptIDFrom", SqlDbType.Int).Value = warehouseReceiptIDFrom;
			//command.Parameters.Add("WarehouseReceiptIDTo", SqlDbType.Int).Value = warehouseReceiptIDFrom;
			//command.Parameters.Add("ClientId", SqlDbType.UniqueIdentifier).Value = clientId;

			return ExecuteDT(command);
		}

		public double GetPUNQuantity(Guid punId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"SELECT	SUM(Quantity) " +
				"FROM   tblPickUpNoticeWarehouseReciept " +
				"GROUP	BY PickupNoticeId " +
				"HAVING (PickupNoticeId = @PickupNoticeId)";

			command.Parameters.Add("PickupNoticeId", SqlDbType.UniqueIdentifier).Value = punId;

			return ExecuteDouble(command);
		}

		public double GetGINQuantity(Guid punId)
		{
			SqlCommand command = new SqlCommand();

			command.CommandText =
				"SELECT	SUM(Quantity) " +
				"FROM   tblGIN " +
				"GROUP	BY PickupNoticeId " +
				"HAVING (PickupNoticeId = @PickupNoticeId)";

			command.Parameters.Add("PickupNoticeId", SqlDbType.UniqueIdentifier).Value = punId;

			return ExecuteDouble(command);
        }

        #region Edit PUN
        public DataTable GetPUNForEditApproval()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT  tblPUNEdit.Id, tblPickUpNotice.PUNId, tblPickUpNotice.Id As PickUpNoticeId, tblPickUpNotice.WarehouseId, '' AS WarehouseName, " +
                        "'' AS WarehouseRecieptIds, tblPickUpNotice.ExpirationDate, tblPickUpNotice.AgentName, tblPickUpNotice.AgentTel," + 
		                "tblPUNEdit.AgentName As NewAgentName, " + 
		                "tblPUNEdit.NIDNumber As NewNIDNumber, " + 
		                "tblPUNEdit.AgentTel As NewAgentTel,  " +
		                "tblPickUpNotice.NIDNumber, tblPUNStatus.Name AS PUNStatusName, tblPUNEditStatus.Name " +
                "FROM    tblPickUpNotice INNER JOIN " +
                        "tblPUNStatus ON tblPickUpNotice.PUNStatusId = tblPUNStatus.Id INNER JOIN " +
                        "tblPUNEdit ON tblPickUpNotice.Id = tblPUNEdit.PUNId INNER JOIN " +
                        "tblPUNEditStatus ON tblPUNEdit.Status = tblPUNEditStatus.Id " +
                "WHERE   (tblPUNEditStatus.Name = 'New') " +
                "ORDER BY tblPickUpNotice.PUNId";

            return ExecuteDT(command);
        }

        public int GetPUNEditApprovalCount()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT  Count(*) " +
                "FROM    tblPUNEdit " +
                "WHERE   Status = (Select Id From tblPUNEditStatus Where [Name] = 'New') ";

            return ExecuteInt(command);
        }

        public bool SavePUNEditRequest(Guid userId, ECX.CD.BE.PUN.PUNEditDataTable items)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlCommand command;

            foreach (BE.PUN.PUNEditRow item in items)
            {
                command = new SqlCommand();

                command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = item.Id;
                command.Parameters.Add("PUNId", SqlDbType.UniqueIdentifier).Value = item.PUNId;
                command.Parameters.Add("AgentName", SqlDbType.VarChar).Value = item.AgentName;
                command.Parameters.Add("AgentTel", SqlDbType.VarChar).Value = item.AgentTel;
                command.Parameters.Add("NIDNumber", SqlDbType.VarChar).Value = item.NIDNumber;
                command.Parameters.Add("NIDType", SqlDbType.VarChar).Value = item.NIDType;
                command.Parameters.Add("RequestedBy", SqlDbType.UniqueIdentifier).Value = userId;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spRequestPUNEdit";

                commands.Add(command);
            }

            return ExecuteTransaction(commands);
        }

        public bool ApprovePUNEdit(Guid userId, List<Guid> pUNEditIds)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlCommand command;

            foreach (Guid pUNEditId in pUNEditIds)
            {
                command = new SqlCommand();
                command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = pUNEditId;
                command.Parameters.Add("ApprovedBy", SqlDbType.UniqueIdentifier).Value = userId;
                command.Parameters.Add("ApprovedStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblPUNEditStatus", "Approved");

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spApprovePUNEdit";
                commands.Add(command);
            }

            return ExecuteTransaction(commands);
        }

        public bool RejectPUNEdit(Guid userId, List<Guid> pUNEditIds)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlCommand command;

            foreach (Guid pUNEditId in pUNEditIds)
            {
                command = new SqlCommand();

                command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = pUNEditId;
                command.Parameters.Add("RejectdBy", SqlDbType.UniqueIdentifier).Value = userId;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spRejectPUNEdit";
                commands.Add(command);
            }

            return ExecuteTransaction(commands);
        }
        #endregion

        public BE.PUN.PickUpNoticeWarehouseRecieptDataTable GetPUNWHRDetail(int whrID, DateTime startDate, DateTime endDate)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT	* " +
                "FROM	tblPickUpNoticeWarehouseReciept " +
                "WHERE	DNReceivedDateTime BETWEEN @StartDate AND @EndDate " +
                "       AND WarehouseRecieptId = @WHRID ";

            command.Parameters.Add("StartDate", SqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("EndDate", SqlDbType.DateTime).Value = endDate;
            command.Parameters.Add("WHRID", SqlDbType.Int).Value = whrID;

            BE.PUN.PickUpNoticeWarehouseRecieptDataTable tbl = new ECX.CD.BE.PUN.PickUpNoticeWarehouseRecieptDataTable();
            tbl.Merge(ExecuteDT(command));

            return tbl;
        }
    }
}