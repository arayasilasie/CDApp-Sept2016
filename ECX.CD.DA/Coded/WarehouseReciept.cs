using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public partial class WarehouseReciept : SQLHelper
    {
        #region For trading service
        public DataRow GetWRForTrading(Guid wRId)
        {
            string SQLQuery = "Select * From [tblWarehouseReciept] Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wRId;

            return ExecuteDT(command).Rows[0];
        }

        public CD.BE.WR.WarehouseRecieptForTradeRow GetWRForTradingByGuid(Guid wRId)
        {
            CD.BE.WR.WarehouseRecieptForTradeDataTable ret = new CD.BE.WR.WarehouseRecieptForTradeDataTable();

            string SQLQuery = "Select * From [tblWarehouseReciept] Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wRId;

            try
            {
                ret.Merge(ExecuteDT(command));
            }
            catch (Exception ex)
            {

            }

            return (ret.Count > 0) ? ret[0] : null;
        }

        public BE.WR.WarehouseRecieptForTradeRow GetWRForTrading(int warehouseRecieptId)
        {
            SqlCommand command = new SqlCommand();
            BE.WR.WarehouseRecieptForTradeDataTable ret = new ECX.CD.BE.WR.WarehouseRecieptForTradeDataTable();

            command.CommandText =
                "Select top 1 * " +
                "From [tblWarehouseReciept] " +
                "Where [WarehouseRecieptId]=@WarehouseRecieptId ";

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

            try
            {
                ret.Merge(ExecuteDT(command));
            }
            catch (Exception ex)
            {

            }

            return (ret.Count > 0) ? ret[0] : null;
        }

        public DataTable GetWRByWarehouse(Guid warehouseId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select * From [tblWarehouseReciept] Where [WarehouseId]=@Id ";

            command.Parameters.AddWithValue("@WarehouseId", warehouseId);

            return ExecuteDT(command);
        }

        public bool DeductWRQuantity(Guid warehouseRecieptId, double quantity)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Update [tblWarehouseReciept] " +
                "Set    TempQuantity = TempQuantity - @Quantity " +
                "Where  [Id]=@Id ";

            command.Parameters.AddWithValue("@Id", warehouseRecieptId);
            command.Parameters.AddWithValue("Quantity", quantity);

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        public bool AddWRQuantity(Guid warehouseRecieptId, double quantity)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Update [tblWarehouseReciept] " +
                "Set    TempQuantity = TempQuantity + @Quantity " +
                "Where  [Id]=@Id ";

            command.Parameters.AddWithValue("@Id", warehouseRecieptId);
            command.Parameters.AddWithValue("Quantity", quantity);

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        public DataTable GetApprovedAndNotExpiredWRsForTrading(Guid warehouseId, Guid commodityGradeId, Guid clientId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT tblWarehouseReciept.* " +
                "FROM   tblWarehouseReciept INNER JOIN " +
                        "tblWarehouseRecieptStatus ON tblWarehouseReciept.WRStatusId = tblWarehouseRecieptStatus.Id " +
                "WHERE  (tblWarehouseRecieptStatus.Name = 'Approved') AND " +
                        "(tblWarehouseReciept.ExpiryDate >= @Today) AND " +
                        "(tblWarehouseReciept.WarehouseId = @WarehouseId) AND " +
                        "(tblWarehouseReciept.CommodityGradeId = @CommodityGradeId) AND " +
                        "(tblWarehouseReciept.ClientId = @ClientId)";

            command.Parameters.AddWithValue("Today", DateTime.Today);
            command.Parameters.AddWithValue("WarehouseId", warehouseId);
            command.Parameters.AddWithValue("CommodityGradeId", commodityGradeId);
            command.Parameters.AddWithValue("ClientId", clientId);

            return ExecuteDT(command);
        }

        public List<ECX.CD.BE.TradableWHR> GetTradableWHRs(Guid CommodityGradeId)
        {//Dictionary<Guid, int>
            SqlCommand com = new SqlCommand();
            //Dictionary<Guid, int> ret = new Dictionary<Guid, int>();
            List<ECX.CD.BE.TradableWHR> whrs = new List<ECX.CD.BE.TradableWHR>();

            com.CommandText =
                "SELECT Distinct tblWarehouseReciept.WarehouseId, tblWarehouseReciept.ProductionYear " +
                "FROM	tblWarehouseReciept INNER JOIN " +
                        "tblWarehouseRecieptStatus ON tblWarehouseReciept.WRStatusId = tblWarehouseRecieptStatus.Id " +
                "WHERE	(tblWarehouseRecieptStatus.Name = 'Approved') And " +
                        "(tblWarehouseReciept.CommodityGradeId = @CommodityGradeId) And " +
                        "(tblWarehouseReciept.TempQuantity > 0)";

            com.Parameters.AddWithValue("CommodityGradeId", CommodityGradeId);

            DataTable dt = ExecuteDT(com);

            foreach (DataRow dr in dt.Rows)
                whrs.Add(new ECX.CD.BE.TradableWHR()
                {
                    WarehouseId = new Guid(dr[0].ToString()),
                    ProductionYear = Convert.ToInt32(dr[1])
                });
            //ret.Add(new Guid(dr[0].ToString()), Convert.ToInt32(dr[1]));

            return whrs;
        }

        #endregion


        public double GetInventoryBalance(Guid warehouseId, Guid commodityGradeId, int productionYear)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "spGetInventoryBalance";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("WarehouseId", SqlDbType.UniqueIdentifier).Value = warehouseId;
            command.Parameters.Add("CommodityGradeId", SqlDbType.UniqueIdentifier).Value = commodityGradeId;
            command.Parameters.Add("ProductionYear", SqlDbType.Int).Value = productionYear;

            return ExecuteDouble(command);
        }

        /// <returns>
        /// Total Original Quantity On WHR
        /// From Deposite (Excluding Child WHR/ Trade) And
        /// Status Approved/Closed/New
        /// </returns>
        public float TotalWHROriginalQuantity(Guid WarehouseId, Guid CommodityGradeId, int productionYear)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT  Sum(tblWarehouseReciept.OriginalQuantity) AS TotalOriginalQuantity " +
                "FROM    tblWarehouseReciept INNER JOIN " +
                    "tblWarehouseRecieptStatus ON tblWarehouseReciept.WRStatusId = tblWarehouseRecieptStatus.Id INNER JOIN " +
                    "tblSourceType ON tblWarehouseReciept.SourceType = tblSourceType.Id " +
                "WHERE   (tblWarehouseReciept.CommodityGradeId = @CommodityGradeId) AND " +
                    "(tblWarehouseReciept.WarehouseId = @WarehouseId) And " +
                    "(ProductionYear=@ProductionYear) And " +
                    "(tblWarehouseRecieptStatus.Name <> 'Cancelled') And " +
                    "((tblSourceType.Name <> 'Trade') OR (tblWarehouseRecieptStatus.Name = 'Approved') OR (tblWarehouseRecieptStatus.Name = 'Closed')) ";

            command.Parameters.Add("WarehouseId", SqlDbType.UniqueIdentifier).Value = WarehouseId;
            command.Parameters.Add("CommodityGradeId", SqlDbType.UniqueIdentifier).Value = CommodityGradeId;
            command.Parameters.Add("ProductionYear", SqlDbType.Int).Value = productionYear;

            return ExecuteFloat(command);
        }

        public DataTable SearchWR(
            string warehouseRecieptIdFrom, string warehouseRecieptIdTo,
            string gRNNumberFrom, string gRNNumberTo, string clientId, string wareHouseId,
            string wRStatusId, List<string> commodityGradeIds, string dateDepositedFrom,
            string dateDepositedTo, string expiryDateFrom, string expiryDateTo, byte sourceTypeId,
            int currentPage, int pageSize, int consType, out int totalRecordCount)
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
            whereClause += (dateDepositedFrom == "") ? "" : "DateDeposited >= @DateDepositedFrom And ";
            whereClause += (dateDepositedTo == "") ? "" : "DateDeposited <= @DateDepositedTo And ";
            whereClause += (expiryDateFrom == "") ? "" : "ExpiryDate >= @ExpiryDateFrom And ";
            whereClause += (expiryDateTo == "") ? "" : "ExpiryDate <= @ExpiryDateTo And ";
            whereClause += (sourceTypeId == 255) ? "" : "SourceType = @SourceType And ";
            whereClause += (consType == 0) ? "" : "ConsignmentType = @consType And ";
            whereClause += Utilities.AppendInString("CommodityGradeId", commodityGradeIds);

            if (whereClause != "" && whereClause.Substring(whereClause.Length - 4, 3) == "And")
                whereClause = whereClause.Remove(whereClause.Length - 4, 4);

            whereClause = (whereClause == "") ? "" : "Where " + whereClause;

            if (warehouseRecieptIdFrom != "")
                command.Parameters.Add("@WarehouseRecieptIdFrom", SqlDbType.Int).Value = int.Parse(warehouseRecieptIdFrom);
            if (warehouseRecieptIdTo != "")
                command.Parameters.Add("@WarehouseRecieptIdTo", SqlDbType.Int).Value = int.Parse(warehouseRecieptIdTo);
            if (gRNNumberFrom != "")
                command.Parameters.Add("@GRNNumberFrom", SqlDbType.VarChar).Value = gRNNumberFrom;
            if (gRNNumberTo != "")
                command.Parameters.Add("@GRNNumberTo", SqlDbType.VarChar).Value = gRNNumberTo;
            if (clientId != "")
                command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = new Guid(clientId);
            if (wareHouseId != "")
                command.Parameters.Add("@WareHouseId", SqlDbType.UniqueIdentifier).Value = new Guid(wareHouseId);
            if (wRStatusId != "")
                command.Parameters.Add("@WRStatusId", SqlDbType.TinyInt).Value = Convert.ToByte(wRStatusId);
            if (dateDepositedFrom != "")
                command.Parameters.Add("@DateDepositedFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(dateDepositedFrom);
            if (dateDepositedTo != "")
                command.Parameters.Add("@DateDepositedTo", SqlDbType.DateTime).Value = Convert.ToDateTime(dateDepositedTo).AddDays(1);
            if (expiryDateFrom != "")
                command.Parameters.Add("@ExpiryDateFrom", SqlDbType.DateTime).Value = Convert.ToDateTime(expiryDateFrom);
            if (expiryDateTo != "")
                command.Parameters.Add("@ExpiryDateTo", SqlDbType.DateTime).Value = Convert.ToDateTime(expiryDateTo);
            if (sourceTypeId != 255)
                command.Parameters.Add("@SourceType", SqlDbType.TinyInt).Value = sourceTypeId;
            if (consType != 0)
                command.Parameters.Add("@consType", SqlDbType.TinyInt).Value = consType;

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
                "ExpiryDate, WarehouseId, '' As WarehouseName, CreatedTimeStamp, ProductionYear, Row_Number() Over(Order By WarehouseRecieptId) As RowNumber " +
            "From tblWarehouseReciept " + whereClause + ") " +
            "Select Id, WarehouseRecieptId, ClientGuid, ClientId, " +
                "ClientName, GRNNumber, CommodityGradeId , CommodityGradeName, OriginalQuantity, " +
                "CurrentQuantity, NetWeight, WRStatusId, WRStatusName, ExpiryDate, WarehouseId, WarehouseName, CreatedTimeStamp, ProductionYear " +
            "From WR " +
            "Where RowNumber Between (@CurrentPage * @PageSize) And ((@CurrentPage + 1) * @PageSize)";

            return ExecuteDT(command);
        }

        public DataTable SearchWRForExtendExpiryRequest(
            string warehouseRecieptIdFrom, string warehouseRecieptIdTo,
            string gRNNumberFrom, string gRNNumberTo, string clientId, string wareHouseId,
            List<string> commodityGradeIds, string dateDepositedFrom,
            string dateDepositedTo, string expiryDateFrom, string expiryDateTo,
            int currentPage, int pageSize, out int totalRecordCount)
        {
            SqlCommand command = new SqlCommand();
            string whereClause = "";

            whereClause += "WRStatusId = @ApprovedWRStatusId And ";
            whereClause += (warehouseRecieptIdFrom == "") ? "" : "WarehouseRecieptId >= @WarehouseRecieptIdFrom And ";
            whereClause += (warehouseRecieptIdTo == "") ? "" : "WarehouseRecieptId <= @WarehouseRecieptIdTo And ";
            whereClause += (gRNNumberFrom == "") ? "" : "GRNNumber >= @GRNNumberFrom And ";
            whereClause += (gRNNumberTo == "") ? "" : "GRNNumber <= @GRNNumberTo And ";
            whereClause += (clientId == "") ? "" : "ClientId = @ClientId And ";
            whereClause += (wareHouseId == "") ? "" : "WareHouseId = @WareHouseId And ";
            whereClause += (dateDepositedFrom == "") ? "" : "DateDeposited >= @DateDepositedFrom And ";
            whereClause += (dateDepositedTo == "") ? "" : "DateDeposited <= @DateDepositedTo And ";
            whereClause += (expiryDateFrom == "") ? "" : "ExpiryDate >= @ExpiryDateFrom And ";
            whereClause += (expiryDateTo == "") ? "" : "ExpiryDate <= @ExpiryDateTo And ";
            whereClause += Utilities.AppendInString("CommodityGradeId", commodityGradeIds);

            if (whereClause != "" && whereClause.Substring(whereClause.Length - 4, 3) == "And")
                whereClause = whereClause.Remove(whereClause.Length - 4, 4);

            whereClause = (whereClause == "") ? "" : "Where " + whereClause;

            if (warehouseRecieptIdFrom != "")
                command.Parameters.Add("@WarehouseRecieptIdFrom", SqlDbType.Int).Value = int.Parse(warehouseRecieptIdFrom);
            if (warehouseRecieptIdTo != "")
                command.Parameters.Add("@WarehouseRecieptIdTo", SqlDbType.Int).Value = int.Parse(warehouseRecieptIdTo);
            if (gRNNumberFrom != "")
                command.Parameters.Add("@GRNNumberFrom", SqlDbType.VarChar).Value = gRNNumberFrom;
            if (gRNNumberTo != "")
                command.Parameters.Add("@GRNNumberTo", SqlDbType.VarChar).Value = gRNNumberTo;
            if (clientId != "")
                command.Parameters.Add("@ClientId", SqlDbType.UniqueIdentifier).Value = new Guid(clientId);
            if (wareHouseId != "")
                command.Parameters.Add("@WareHouseId", SqlDbType.UniqueIdentifier).Value = new Guid(wareHouseId);
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
            command.Parameters.Add("@ApprovedWRStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");

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

        public DataTable GetWHRForExtendExpiryApproval()
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ApprovedWRStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "Approved");

            command.CommandText =
            "SELECT	tblExtendExpiryDate.Id, tblWarehouseReciept.WarehouseRecieptId, tblWarehouseReciept.ClientId AS ClientGuid, " +
                    "'' AS ClientId, '' AS ClientName, tblWarehouseReciept.GRNNumber, tblWarehouseReciept.CommodityGradeId, " +
                    "'' AS CommodityGradeName, tblWarehouseReciept.OriginalQuantity, tblWarehouseReciept.WRStatusId, " +
                    "'' AS WRStatusName, tblWarehouseReciept.ExpiryDate, tblWarehouseReciept.WarehouseId, '' AS WarehouseName, tblExtendExpiryDate.NumberOfDays, tblWarehouseReciept.Id AS WHRGuid " +
            "FROM    tblWarehouseReciept INNER JOIN " +
                    "tblExtendExpiryDate ON tblWarehouseReciept.Id = tblExtendExpiryDate.WHRId INNER JOIN " +
                    "tblExtendExpiryDateStatus ON tblExtendExpiryDate.Status = tblExtendExpiryDateStatus.Id " +
            "WHERE   (tblExtendExpiryDateStatus.Name = 'New')";

            return ExecuteDT(command);
        }

        public bool ApproveExtendExpiry(List<Guid> extendExpiryDateIds, Guid userId)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlCommand command = new SqlCommand();

            foreach (Guid extendExpiryDateId in extendExpiryDateIds)
            {
                command = new SqlCommand();
                command.CommandText = "spApproveExtendExpiryDate";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = extendExpiryDateId;
                command.Parameters.Add("UserId", SqlDbType.UniqueIdentifier).Value = userId;

                commands.Add(command);
            }

            return ExecuteTransaction(commands);
        }

        public bool RejectWHRExtendExpiry(List<Guid> extendExpiryDateIds, Guid userId)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlCommand command = new SqlCommand();

            foreach (Guid extendExpiryDateId in extendExpiryDateIds)
            {
                command.CommandText = "spRejectExtendExpiryDate";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = extendExpiryDateId;
                command.Parameters.Add("UserId", SqlDbType.UniqueIdentifier).Value = userId;

                commands.Add(command);
            }

            return ExecuteTransaction(commands);
        }

        public DataTable GetWHRForApproval()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Id, WarehouseRecieptId, ClientId As ClientGuid, '' As ClientId, " +
                "'' As ClientName, GRNNumber, CommodityGradeId , '' As CommodityGradeName, " +
                "OriginalQuantity, CurrentQuantity, NetWeight, WRStatusId, '' As WRStatusName, " +
                "WarehouseId , '' As WarehouseName, CreatedTimeStamp, ProductionYear, BagTypeId, '' As BagTypeName " +
                "From tblWarehouseReciept " +
                "Where WRStatusId = " + new Lookup().GetLookupId("tblWarehouseRecieptStatus", "New");

            return ExecuteDT(command);
        }

        public int GetApproveWHRCancelCount()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT Count(tblWHRCancel.Id) " +
                "FROM   tblWHRCancel INNER JOIN " +
                       "tblWHRCancelStatus ON tblWHRCancel.Status = tblWHRCancelStatus.Id " +
                "WHERE  (tblWHRCancelStatus.Name = 'New')";

            return ExecuteInt(command);
        }

        public int GetApproveExtendExpiryDateCount()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT Count(tblExtendExpiryDate.Id) " +
                "FROM   tblExtendExpiryDate INNER JOIN " +
                       "tblExtendExpiryDateStatus ON tblExtendExpiryDate.Status = tblExtendExpiryDateStatus.Id " +
                "WHERE  (tblExtendExpiryDateStatus.Name = 'New')";

            return ExecuteInt(command);
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
                "From tblWarehouseReciept " +
                "Where WarehouseRecieptId = @WarehouseRecieptId ";

            command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

            return ExecuteGuid(command);
        }

        public Guid GetWHRCommodityGradeId(int warehouseRecieptId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select CommodityGradeId " +
                "From tblWarehouseReciept " +
                "Where WarehouseRecieptId = @WarehouseRecieptId ";

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

        public int GetWarehouseRecieptId(Guid wRId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select WarehouseRecieptId From [tblWarehouseReciept] Where [Id]=@Id ";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wRId;

            return ExecuteInt(command);
        }

        public BE.WR.WarehouseRecieptRow GetWR(int warehouseRecieptId)
        {
            SqlCommand command = new SqlCommand();
            BE.WR.WarehouseRecieptDataTable ret = new ECX.CD.BE.WR.WarehouseRecieptDataTable();

            command.CommandText =
                "Select top 1 * " +
                "From [tblWarehouseReciept] " +
                "Where [WarehouseRecieptId]=@WarehouseRecieptId ";

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

            try
            {
                ret.Merge(ExecuteDT(command));
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }

            return (ret.Count > 0) ? ret[0] : null;
        }


        public double GetTempQuantityt(int warehouseRecieptId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select TempQuantity " +
                "From tblWarehouseReciept " +
                "Where WarehouseRecieptId = @WarehouseRecieptId ";

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

            return ExecuteDouble(command);
        }

        public BE.WR.ViewWarehouseRecieptRow GetViewWR(int warehouseRecieptId)
        {
            SqlCommand command = new SqlCommand();
            BE.WR.ViewWarehouseRecieptDataTable ret = new ECX.CD.BE.WR.ViewWarehouseRecieptDataTable();

            command.CommandText =
                "Select Id, WarehouseRecieptId, ClientId As ClientGuid, '' As ClientId, " +
                    "'' As ClientName, GRNNumber, CommodityGradeId , '' As CommodityGradeName, " +
                    "OriginalQuantity, TempQuantity As CurrentQuantity, NetWeight, WRStatusId, " +
                    "'' As WRStatusName, ExpiryDate, WarehouseId " +
                "From tblWarehouseReciept " +
                "Where WarehouseRecieptId = @WarehouseRecieptId ";

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

            ret.Merge(ExecuteDT(command));

            if (ret.Count > 0)
            {
                return ret[0];
            }
            else
            {
                return null;
            }
        }

        public BE.WR.ViewWarehouseRecieptRow GetViewWRByGRN(int gRNNumber)
        {
            SqlCommand command = new SqlCommand();
            BE.WR.ViewWarehouseRecieptDataTable ret = new ECX.CD.BE.WR.ViewWarehouseRecieptDataTable();

            command.CommandText =
                "Select Id, WarehouseRecieptId, ClientId As ClientGuid, '' As ClientId, " +
                    "'' As ClientName, GRNNumber, CommodityGradeId , '' As CommodityGradeName, " +
                    "OriginalQuantity, TempQuantity As CurrentQuantity, NetWeight, WRStatusId, " +
                    "'' As WRStatusName, ExpiryDate, WarehouseId " +
                "From tblWarehouseReciept " +
                "Where [GRNNumber]=@GRNNumber "; ;

            command.Parameters.Add("@GRNNumber", SqlDbType.VarChar).Value = gRNNumber.ToString();

            ret.Merge(ExecuteDT(command));

            return (ret.Count > 0) ? ret[0] : null;
        }

        public BE.WR.WarehouseRecieptRow GetWRByGRN(string gRNNumber)
        {
            SqlCommand command = new SqlCommand();
            BE.WR.WarehouseRecieptDataTable ret = new ECX.CD.BE.WR.WarehouseRecieptDataTable();

            command.CommandText =
                "Select * From [tblWarehouseReciept] " +
                "Where [GRNNumber]=@GRNNumber ";

            command.Parameters.Add("@GRNNumber", SqlDbType.VarChar).Value = gRNNumber;

            ret.Merge(ExecuteDT(command));

            return (ret.Count > 0) ? ret[0] : null;
        }

        public Guid GetWRGuid(int warehouseRecieptId)
        {
            string SQLQuery = "Select Id From [tblWarehouseReciept] Where [WarehouseRecieptId]=@WarehouseRecieptId ";

            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.Int).Value = warehouseRecieptId;

            return ExecuteGuid(command);
        }

        public Guid GetGRNGuid(Guid wHRId)
        {
            string SQLQuery = "Select GRNID From [tblWarehouseReciept] Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wHRId;

            return ExecuteGuid(command);
        }

        public bool UpdateWR(
            Guid wRId, byte wRStatusId, string wrStatusName,
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

        public byte GetCurrentWRStatus(Guid wRId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                   "Select	WRStatusId " +
                   "From	[tblWarehouseReciept] " +
                   "Where	[Id]=@Id ";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wRId;

            return Convert.ToByte(ExecuteScalar(command).ToString());
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
            command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateTime.Now;
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

        /// <summary>
        /// warehouseRecieptIds is <WarehouseRecieptId, NumberOfDays>
        /// </summary>
        public void SaveExtendExpiryDateRequest(Dictionary<Guid, int> warehouseReciepts, Guid userId)
        {
            SqlCommand command;

            foreach (KeyValuePair<Guid, int> warehouseReciept in warehouseReciepts)
            {
                command = new SqlCommand();

                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                command.Parameters.Add("@WHRId", SqlDbType.UniqueIdentifier).Value = warehouseReciept.Key;
                command.Parameters.Add("@RequestedBy", SqlDbType.UniqueIdentifier).Value = userId;
                command.Parameters.Add("@DateRequested", SqlDbType.DateTime).Value = DateTime.Today;
                command.Parameters.Add("@NumberOfDays", SqlDbType.Int).Value = warehouseReciept.Value;

                ExecuteNonQueryStoredProcedure("spSaveExtendExpiryDate", command);
            }
        }

        //02-16-2012
        //Elias Getachew
        //To accomodate moisture loss.
        // if commodity is sesame
        public bool SaveWareHouseReciept(
            Guid GRNID, string GRNNumber, Guid CommodityGradeId, Guid WarehouseId,
            Guid BagTypeId, Guid VoucherId, Guid UnLoadingId, Guid ScalingId, Guid GradingId,
            Guid SamplingTicketId, DateTime DateDeposited, DateTime DateApproved, int GRNStatusId,
            double GrossWeight, double NetWeight, double OriginalQuantity, double CurrentQuantity,
            Guid DepositeTypeId, int Source, double NetWeightAdjusted, Guid UserId,
            DateTime CreatedTimeStamp, Guid ClientId, int NumberOfBags, int ProductionYear, Guid GRNTypeId)
        {
            SqlCommand command = new SqlCommand();

            //02-16-2012
            //Elias Getachew
            //To accomodate moisture loss.
            // if commodity is sesame
            double WeightBeforeMoisture = NetWeight;
            double lossAmount = 0;
            ECXLookup.ECXLookup ecxlookup = new ECXLookup.ECXLookup();
            ECXLookup.CCommodityGrade CG = ecxlookup.GetCommodityGrade(Common.EnglishGuid, CommodityGradeId);
            ECXLookup.CCommodityClass CC = ecxlookup.GetCommodityClass(Common.EnglishGuid, CG.CommodityClassUniqueIdentifier);
            bool DeductMLA = false;
            //sesame
            if (CC.CommodityUniqueIdentifier.ToString().ToLower() == "d97fd8c1-8916-4e3d-89e2-bd50d556a32f".ToLower())
            {
                //TODO:GET FROM WEBSERVICE 
                lossAmount = 0.0015;
                DeductMLA = true;
                //try
                //{

                //    lossAmount = (double)CG.MLA;
                //}
                //catch
                //{
                //    lossAmount = 0;
                //}
            }//coffee
            else if (CC.CommodityUniqueIdentifier.ToString().ToLower() == "71604275-df23-4449-9dae-36501b14cc3b".ToLower())
            {
                DeductMLA = true;
                lossAmount = 0.00176;
            }
            else
            {
                lossAmount = 0;
                DeductMLA = false;
            }

            double netWeightLoss = 0;
            if (DeductMLA)
            {
                netWeightLoss = NetWeight - (lossAmount * NetWeight);

            }
            else
            {
                netWeightLoss = NetWeight;
            }


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
            //command.Parameters.Add("@DateApproved", SqlDbType.DateTime).Value = DateApproved;
            command.Parameters.Add("@GRNStatus", SqlDbType.Int).Value = GRNStatusId;
            //TODO ask abera on the look up
            command.Parameters.Add("@WRStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "New");//1
            command.Parameters.Add("@GrossWeight", SqlDbType.Float).Value = GrossWeight;
            //02-16-2012
            //Elias Getachew
            //MLA
            command.Parameters.Add("@NetWeight", SqlDbType.Float).Value = netWeightLoss;
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
            //02-16-2012
            //Elias Getachew
            //MLA
            command.Parameters.Add("@WeightBeforeMoisture", SqlDbType.Float).Value = WeightBeforeMoisture;

            return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("tblWarehouseReciept_Insert", command));

        }

        #region WHR Edit
        public string GetWHREditTrackingNumber(Guid editWHRId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select TrackingNumber From tblEditWHR Where Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = editWHRId;

            return ExecuteString(command);
        }

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

        //public Guid RequestWHREdit(Guid warehouseReceiptId, Guid RequestedBy)
        //{
        //    SqlCommand command = new SqlCommand();
        //    Guid id = Guid.NewGuid();

        //    command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
        //    command.Parameters.Add("@WarehouseRecieptId", SqlDbType.UniqueIdentifier).Value = warehouseReceiptId;
        //    command.Parameters.Add("GRNId", SqlDbType.UniqueIdentifier).Value = GetGRNGuid(warehouseReceiptId);
        //    command.Parameters.Add("@RequestedBy", SqlDbType.UniqueIdentifier).Value = RequestedBy;
        //    command.Parameters.Add("@DateRequested", SqlDbType.DateTime).Value = DateTime.Now;

        //    ExecuteNonQuerySP("spRequestWHREdit", command);

        //    return id;
        //}

        public bool RequestWHREdit(Guid gRNID, Guid RequestedBy, string remark, string trackingNumber)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.UniqueIdentifier).Value = GetParentWHR(gRNID);
            command.Parameters.Add("GRNId", SqlDbType.UniqueIdentifier).Value = gRNID;
            command.Parameters.Add("@RequestedBy", SqlDbType.UniqueIdentifier).Value = RequestedBy;
            command.Parameters.Add("@DateRequested", SqlDbType.DateTime).Value = DateTime.Now;

            return Convert.ToBoolean(ExecuteNonQuerySP("spRequestWHREdit", command));
        }

        public Guid GetGRNIdByCancelWHRId(Guid cancelWHRId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select GRNId From tblWHRCancel Where Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = cancelWHRId;

            return ExecuteGuid(command);
        }

        public Guid GetGRNIdByEditWHRId(Guid editWHRId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select GRNId From tblWHREdit Where Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = editWHRId;

            return ExecuteGuid(command);
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

        public bool RejectWHREdit(Guid userId, Guid wHREditId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = wHREditId;

            return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("spRejectWHREdit", command));
        }
        #endregion

        #region Cancel WHR
        public string GetWHRCancelTrackingNumber(Guid cancelWHRId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select TrackingNumber From tblWHRCancel Where Id = @Id";

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = cancelWHRId;

            return ExecuteString(command);
        }

        public DataTable GetWHRForWHRCancelApproval()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT tblWHRCancel.Id, tblWarehouseReciept.WarehouseRecieptId, tblWarehouseReciept.ClientId AS ClientGuid, " +
                    "'' AS ClientId, '' AS ClientName, tblWarehouseReciept.GRNNumber, tblWarehouseReciept.CommodityGradeId, " +
                    "'' AS CommodityGradeName, tblWarehouseReciept.CurrentQuantity, tblWarehouseReciept.NetWeight, " +
                    "tblWarehouseReciept.WRStatusId, tblWarehouseRecieptStatus.Name AS WRStatusName, tblWarehouseReciept.ExpiryDate, " +
                    "tblWarehouseReciept.WarehouseId, '' As WarehouseName " +
                "FROM   tblWarehouseReciept INNER JOIN " +
                    "tblWHRCancel ON tblWarehouseReciept.Id = tblWHRCancel.WHRId INNER JOIN " +
                    "tblWarehouseRecieptStatus ON tblWarehouseReciept.WRStatusId = tblWarehouseRecieptStatus.Id INNER JOIN " +
                    "tblWHRCancelStatus ON tblWHRCancel.Status = tblWHRCancelStatus.Id " +
                "Where tblWHRCancelStatus.Name = 'New' " +
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

        public bool IsSourceTypeTrade(List<Guid> wHRIds)
        {
            SqlCommand command = new SqlCommand();
            string inString = Utilities.AppendInString("Id", wHRIds);

            command.CommandText =
                "If Exists( Select * From tblWarehouseReciept " +
                           "Where	tblWarehouseReciept.SourceType != (Select Id From tblSourceType Where [Name] = 'Trade') " +
                           ((inString == "") ? "" : " And " + inString) +
                          ") " +
                    "Select 0 " +
                "Else " +
                    "Select 1";

            return ExecuteBoolean(command);
        }

        public bool IsSourceTypeTrade(Guid wHRId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "If Exists( Select * From tblWarehouseReciept " +
                           "Where	tblWarehouseReciept.SourceType != (Select Id From tblSourceType Where [Name] = 'Trade') And " +
                                                                            " Id = @Id " +
                          ") " +
                    "Select 0 " +
                "Else " +
                    "Select 1";

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = wHRId;

            return ExecuteBoolean(command);
        }

        public bool IsWHRCancelRequestedFromCD(Guid wHRCancelId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select WHRId From tblWHRCancel " +
                "Where	Id = @Id";
            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = wHRCancelId;

            if (IsSourceTypeTrade(ExecuteGuid(command)))
                return true;
            else
                return false;
        }

        /// <returns>WHRCancelId</returns>
        public Guid RequestWHRCancel(Guid userId, Guid wHRId, string remark)
        {
            SqlCommand command = new SqlCommand();
            Guid id = Guid.NewGuid();

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = id;
            command.Parameters.Add("WHRId", SqlDbType.UniqueIdentifier).Value = wHRId;
            command.Parameters.Add("GRNId", SqlDbType.UniqueIdentifier).Value = GetGRNGuid(wHRId);
            command.Parameters.Add("RequestedBy", SqlDbType.UniqueIdentifier).Value = userId;
            command.Parameters.Add("Remark", SqlDbType.VarChar).Value = remark;

            ExecuteNonQueryStoredProcedure("spRequestWHRCancel", command);

            return id;
        }

        public bool RequestWHRCancel(Guid gRNId, Guid userId, string remark, string trackingNumber)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
            command.Parameters.Add("WHRId", SqlDbType.UniqueIdentifier).Value = GetParentWHR(gRNId);
            command.Parameters.Add("GRNId", SqlDbType.UniqueIdentifier).Value = gRNId;
            command.Parameters.Add("RequestedBy", SqlDbType.UniqueIdentifier).Value = userId;
            command.Parameters.Add("TrackingNumber", SqlDbType.VarChar).Value = trackingNumber;
            command.Parameters.Add("Remark", SqlDbType.VarChar).Value = remark;

            return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("spRequestWHRCancel", command));
        }

        public bool ApproveWHRCancel(Guid userId, Guid wHRCancelId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = wHRCancelId;
            command.Parameters.Add("ApprovedBy", SqlDbType.UniqueIdentifier).Value = userId;
            command.Parameters.Add("ApprovedStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWHRCancelStatus", "Approved");

            return Convert.ToBoolean(ExecuteNonQueryStoredProcedure("spApproveWHRCancel", command));
        }

        public void RejectWHRCancel(Guid userId, Guid wHRCancelId)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("Id", SqlDbType.UniqueIdentifier).Value = wHRCancelId;
            command.Parameters.Add("RejectedBy", SqlDbType.UniqueIdentifier).Value = userId;
            command.Parameters.Add("RejectedDate", SqlDbType.DateTime).Value = DateTime.Now;

            ExecuteNonQueryStoredProcedure("spRejectWHRCancel", command);
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

        public static bool SuspendWHR(int whrNo, Guid userGuid, DateTime dateTime)
        {
            return true;
        }

        public static bool ResumeWHR(int whrNo, Guid userGuid, DateTime dateTime)
        {
            return true;
        }

        public double GetCommodityBalance(Guid commodityGradeId, Guid warehouseId)
        {
            SqlCommand command = new SqlCommand();
            double originalQty = 0;
            double issuedQty = 0;

            command.CommandText =
                "SELECT	SUM(OriginalQuantity) " +
                "FROM   tblWarehouseReciept " +
                "GROUP	BY CommodityGradeId, WarehouseId " +
                "HAVING (WarehouseId = @WarehouseId) AND (CommodityGradeId = @CommodityGradeId)";

            command.Parameters.Add("WarehouseId", SqlDbType.UniqueIdentifier).Value = warehouseId;
            command.Parameters.Add("CommodityGradeId", SqlDbType.UniqueIdentifier).Value = commodityGradeId;
            originalQty = ExecuteDouble(command);

            command = new SqlCommand();
            command.CommandText =
                "SELECT	SUM(tblGIN.Quantity) " +
                "FROM   tblGIN INNER JOIN " +
                        "tblPickUpNotice ON tblGIN.PickupNoticeId = tblPickUpNotice.Id " +
                "GROUP BY tblPickUpNotice.CommodityGradeId, tblPickUpNotice.WarehouseId " +
                "HAVING (tblPickUpNotice.CommodityGradeId = @CommodityGradeId) AND " +
                        "(tblPickUpNotice.WarehouseId = @WarehouseId)";

            command.Parameters.Add("WarehouseId", SqlDbType.UniqueIdentifier).Value = warehouseId;
            command.Parameters.Add("CommodityGradeId", SqlDbType.UniqueIdentifier).Value = commodityGradeId;
            issuedQty = ExecuteDouble(command);

            return originalQty - issuedQty;
        }

        public DataTable GetPendingWHRs()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT	Id, ClientId, Cast(0 As Bit) As BuyerClient, '' As BuyerName , " +
                        "WarehouseRecieptId, OriginalQuantity As Quantity " +
                "FROM	tblWarehouseReciept " +
                "Where	WRStatusId = (Select Id From tblWarehouseRecieptStatus Where [Name] = 'Pending')";

            return ExecuteDT(command);
        }

        public DataTable GetWHRHistory(int wHRId)
        {
            SqlCommand command = new SqlCommand();
            DataTable ret = new DataTable();

            #region History
            command.CommandText =
                "SELECT Status, DateTime, UserId, '' As UserName, " +
                    "Cast(0 As Float) As Quantity, '' As BankName, '' As BankBranchName,  " +
                    "'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount, Remark  " +
                "FROM   tblWHRHistory  " +
                "Where	WHRId = @WHRId ";
            command.Parameters.Add("WHRId", SqlDbType.Int).Value = wHRId;
            ret.Merge(ExecuteDT(command));
            #endregion

            #region Creation History
            command = new SqlCommand();
            command.CommandText =
                "SELECT	'New' As Status, CreatedTimeStamp As DateTime, CreatedBy As UserId, '' As UserName, " +
                    "OriginalQuantity As Quantity, '' As BankName, '' As BankBranchName, " +
                    "'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount, '' As Remark " +
                "FROM	tblWarehouseReciept " +
                "Where	WarehouseRecieptId = @WarehouseRecieptId";
            command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = wHRId;
            ret.Merge(ExecuteDT(command));
            #endregion

            #region Approval History
            //command = new SqlCommand();
            //command.CommandText =
            //    "SELECT	'Approved' As Status, DateApproved As DateTime, ApprovedBy As UserId, '' As UserName, " +
            //        "OriginalQuantity As Quantity, '' As BankName, '' As BankBranchName, " +
            //        "'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount, '' As Remark " +
            //    "FROM	tblWarehouseReciept " +
            //    "Where	WarehouseRecieptId = @WarehouseRecieptId And WRStatusId = (Select Id From tblWarehouseRecieptStatus Where [Name] = 'Approved' )";
            //command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = wHRId;
            //ret.Merge(ExecuteDT(command));
            #endregion

            #region Approval History
            command = new SqlCommand();
            command.CommandText =
                "SELECT	'Closed' As Status, DateClosed As DateTime, ClosedBy As UserId, '' As UserName, " +
                    "Cast(0 As Float) As Quantity, '' As BankName, '' As BankBranchName, " +
                    "'' As LoanAccount,  '' As TradeId, '' As TradePrice, '' As SettlementAmount, '' As Remark " +
                "FROM	tblWarehouseReciept " +
                "Where	WarehouseRecieptId = @WarehouseRecieptId And WRStatusId = (Select Id From tblWarehouseRecieptStatus Where [Name] = 'Closed' )";
            command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = wHRId;
            ret.Merge(ExecuteDT(command));
            #endregion

            #region Edit History
            command = new SqlCommand();
            command.CommandText =
                "SELECT	'Edited' AS Status, DateApproved DateTime, ApprovedBy As UserId, '' AS UserName, " +
                        "CAST(0 AS Float) AS Quantity, '' AS BankName, '' AS BankBranchName, " +
                        "'' AS LoanAccount, '' AS TradeId, '' AS TradePrice, '' AS SettlementAmount, Remark " +
                "FROM    tblWHREdit";
            command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = wHRId;
            ret.Merge(ExecuteDT(command));
            #endregion

            #region Cancellation History
            command = new SqlCommand();
            command.CommandText =
                "SELECT	'Cancelled' AS Status, DateApproved DateTime, ApprovedBy As UserId, '' AS UserName, " +
                        "CAST(0 AS Float) AS Quantity, '' AS BankName, '' AS BankBranchName, " +
                        "'' AS LoanAccount, '' AS TradeId, '' AS TradePrice, '' AS SettlementAmount, Remark " +
                "FROM    tblWHRCancel";
            command.Parameters.Add("WarehouseRecieptId", SqlDbType.Int).Value = wHRId;
            ret.Merge(ExecuteDT(command));
            #endregion

            return ret;
        }

        public Guid GetParentWHR(Guid gRNId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Id From tblWarehouseReciept Where GRNID = @GRNID And SourceType In (Select Id From tblSourceType Where [Name] <> 'Trade')";

            command.Parameters.Add("GRNID", SqlDbType.UniqueIdentifier).Value = gRNId;

            return ExecuteGuid(command);
        }

        public DataTable GetOwnerWHRApprovalRange(DateTime approvalDateFrom, DateTime approvalDateTo)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "SELECT	DISTINCT ClientId " +
                "FROM	tblWarehouseReciept " +
                "Where	DateApproved BETWEEN '" + approvalDateFrom.ToString("yyyy-MM-dd hh:mm:ss") + "' AND '" + approvalDateTo.ToString("yyyy-MM-dd hh:mm:ss") + "' AND (WRStatusId = 2 OR WRStatusId = 6)";

            return ExecuteDT(command);
        }

        public bool ResetStatusToNew(Guid warehouseReceiptId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Update [tblWarehouseReciept] " +
                "Set WRStatusId = @NewWRStatusId, ApprovedBy=NULL, DateApproved = NULL, ExpiryDate = NULL " +
                "Where [Id]=@WarehouseRecieptId ";

            command.Parameters.Add("@WarehouseRecieptId", SqlDbType.UniqueIdentifier).Value = warehouseReceiptId;
            command.Parameters.Add("@NewWRStatusId", SqlDbType.TinyInt).Value = new Lookup().GetLookupId("tblWarehouseRecieptStatus", "New");

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        public bool AddWHRHistory(int warehouseReceiptId, string status, Guid userId, string remark)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Insert Into tblWHRHistory " +
                "(WHRId, Status, UserId, Remark) " +
                "Values(@WHRId, @Status, @UserId, @Remark) ";

            command.Parameters.Add("@WHRId", SqlDbType.Int).Value = warehouseReceiptId;
            command.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
            command.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = remark;

            return Convert.ToBoolean(ExecuteNonQuery(command));
        }

        public DateTime GetTradeDate(Guid wHRId)
        {


            string SQLQuery = "Select TradeDate From [tblWarehouseReciept] Where [Id]=@Id ";

            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wHRId;

            return Convert.ToDateTime(ExecuteScalar(command));


        }

        //Elias Getachew
        //march 21 2012
        //To make PUN expiration start from date of TT.
        public DateTime GetTradedWRTitleTransferDate(Guid wHRId)
        {
            string SQLQuery = "Select DateApproved From [tblWarehouseReciept] Where [Id]=@Id and SourceType=2 ";

            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wHRId;

            return Convert.ToDateTime(ExecuteScalar(command));

        }
        public DateTime GetPUNExpirationdateFromDN(Guid wHRId)
        {
            string SQLQuery = "SELECT     tblDNSnapshot.LastPickupDate AS DNLastPUN  ";
            SQLQuery += " FROM         tblPickUpNotice INNER JOIN ";
            SQLQuery += " tblPickUpNoticeWarehouseReciept ON tblPickUpNotice.Id = tblPickUpNoticeWarehouseReciept.PickupNoticeId INNER JOIN ";
            SQLQuery += " tblDNSnapshot ON tblPickUpNoticeWarehouseReciept.WarehouseRecieptId = tblDNSnapshot.WHRID ";
            SQLQuery += " where tblDNSnapshot.WHRID = @Id"; //and SourceType=2 ";


            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = wHRId;

            return Convert.ToDateTime(ExecuteScalar(command));




        }
        public DateTime GetPUNExpirationdateFromDNbyPunID(Guid punID)
        {
            string SQLQuery = "SELECT     tblDNSnapshot.LastPickupDate AS DNLastPUN  ";
            SQLQuery += " FROM         tblPickUpNotice INNER JOIN ";
            SQLQuery += " tblPickUpNoticeWarehouseReciept ON tblPickUpNotice.Id = tblPickUpNoticeWarehouseReciept.PickupNoticeId INNER JOIN ";
            SQLQuery += " tblDNSnapshot ON tblPickUpNoticeWarehouseReciept.WarehouseRecieptId = tblDNSnapshot.WHRID ";
            SQLQuery += " where  tblPickUpNotice.Id='" + punID + "' ";


            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = punID;

            return Convert.ToDateTime(ExecuteScalar(command));
        }


        //esa--s JAN 09 2014  --PUN Create
        public DateTime GetPUNExpirationdateFromDNbyWHRNum(int WHRNum)
        {
            string SQLQuery = "SELECT tblDNSnapshot.LastPickupDate AS DNLastPUN  ";
            SQLQuery += " FROM         tblDNSnapshot ";
            SQLQuery += " where  tblDNSnapshot.WHRID='" + WHRNum + "' ";


            SqlCommand command = new SqlCommand(SQLQuery);

            command.Parameters.Add("@WHRID", SqlDbType.Int).Value = WHRNum;

            return Convert.ToDateTime(ExecuteScalar(command));
        }

        public DataTable GetApprovedAndNewWHRs()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "Select * From vwApprovedAndNewWHRs";

            return ExecuteDT(command);
        }

        public DataTable GetTradableWarehouseReceipts(Guid? commodityId = null)
        {
            //Change to this to avoide using lookups query at cd DB
            //DataTable dt2 = new ECX.CD.DA.Lookup().GetAllCommodityGroups(); 

            string commandText = "GetTradableWarehouseReceipt";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@CommodityId", SqlDbType.UniqueIdentifier, 50).Value = commodityId;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;

        }


        /*****************tg May 22/2017******************************/
        public DataTable GetUnsoldOnTruckWarehouseRecipts()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "select tblWarehouseReciept.*,clCommoditySymbols.Symbol as CommodityGradeName,clMemberClients.FullName as ClientName, " +
                                   "clMemberClients.IDNo as ClientIDNo,tblWarehouseRecieptStatus.Name as WRStatusName,dbo.clWarehouses.Description as WarehouseName " +
                                    "from tblWarehouseReciept INNER JOIN " +
                                    "dbo.clWarehouses ON dbo.tblWarehouseReciept.WarehouseId = dbo.clWarehouses.ID INNER JOIN " +
                                    "dbo.clCommoditySymbols ON dbo.tblWarehouseReciept.CommodityGradeId = dbo.clCommoditySymbols.ID INNER JOIN " +
                                    "dbo.clMemberClients ON dbo.tblWarehouseReciept.ClientId = dbo.clMemberClients.ID " +
                                    "inner join tblWarehouseRecieptStatus on tblWarehouseRecieptStatus.Id=tblWarehouseReciept.WRStatusId " +
                                    "where ConsignmentType=1 and DATEDIFF(day,convert(date, getdate()),convert(date,ExpiryDate)) <= -1 and WRStatusId=2 and TempQuantity > 0 and CurrentQuantity > 0 and SourceType = 1 ";
            return ExecuteDT(command);
        }
        public int UpdateUnsoldOnTruckWarehouseRecipts(List<Hold> lst, string remark)
        {
            SqlCommand command = new SqlCommand();
            List<int> lstWHR = new List<int>();
            foreach (Hold h in lst)
            {
                SqlCommand comm = new SqlCommand("INSERT INTO [dbo].[tblWHRHold] ([ID],[WHRNo],[PreviousStatus],[Reason],[CreatedBy],[CreatedTimeStamp],[HoldBy]) " +
                                        "VALUES (@ID,@WHRNo,@PreviousStatus,@Reason ,@CreatedBy, @CreatedTimeStamp,@HoldBy);");

                comm.Parameters.AddWithValue("@ID", h.ID);
                comm.Parameters.AddWithValue("@WHRNo", h.WHRNo);
                comm.Parameters.AddWithValue("@PreviousStatus", h.PreviousStatus);
                comm.Parameters.AddWithValue("@Reason", h.Reason);
                comm.Parameters.AddWithValue("@CreatedBy", h.CreatedBy);
                comm.Parameters.AddWithValue("@CreatedTimeStamp", h.CreatedTimeStamp);
                comm.Parameters.AddWithValue("@HoldBy", h.HoldBy);

                lstWHR.Add(Convert.ToInt32(h.WHRNo));

                command = comm;
            }
            string st = "(" + String.Join(",", lstWHR.ConvertAll(x => x.ToString()).ToArray()) + ")";
            command.CommandText += "Update tblWarehouseReciept SET WRStatusId = 7 , Remark = '" + remark + "' Where WarehouseRecieptId in " + st;
            return ExecuteNonQuery(command);
        }
    }
    public class Hold
    {
        public Guid ID { get; set; }
        public Int32 WHRNo { get; set; }
        public int PreviousStatus { get; set; }
        public string Reason { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public string HoldBy { get; set; }
    }
}