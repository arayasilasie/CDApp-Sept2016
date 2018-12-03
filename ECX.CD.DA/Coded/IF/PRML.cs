using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ECX.CD.DA
{
    public class PRML : IFSQLHelper
    {
        public System.Data.DataTable SearchPRML(int whrNoFrom, int whrNoTo, int grnNoFrom, int grnNoTo, List<Guid> bankBranchIds, string mcId, DateTime expiryDateFrom, DateTime expiryDateTo, byte status)
        {
            //TODO: finilize the Search method

            string SQLCriteria = string.Empty;
            if (whrNoFrom != int.MinValue || whrNoTo != int.MaxValue)
            {
                SQLCriteria += " ((tblPRML.WHRNo BETWEEN " + whrNoFrom + " AND " + whrNoTo + ") OR tblPRML.WHRNo is null) AND ";
            }
            if (grnNoFrom != int.MinValue && grnNoTo != int.MaxValue)
            {
                SQLCriteria += " ((tblPRML.WHRNo BETWEEN " + grnNoFrom + " AND " + grnNoTo + ") OR tblPRML.WHRNo is null) AND ";
            }
            SQLCriteria += " ((tblPRML.ExpiryDate BETWEEN '" + expiryDateFrom.ToString("yyyy-MM-dd") + "' AND '" + expiryDateTo.ToString("yyyy-MM-dd") + "') OR tblPRML.ExpiryDate is null) ";
            if (mcId != string.Empty)
            {
                SQLCriteria += " AND ((tblPRML.ECXMemberId = '" + mcId + "' ) OR (tblPRML.ECXClientId = '" + mcId + "' )) ";
            }
            if (bankBranchIds.Count > 0)
            {
                SQLCriteria += " AND " + ECX.CD.DA.Utilities.AppendInString("BankBranchId", bankBranchIds);
            }
            if (status > 0)
            {
                SQLCriteria += " AND Status = " + status;
            }

            string SQLQuery = string.Empty;
            SQLQuery += " SELECT * ";
            SQLQuery += " FROM tblPRML  ";
            SQLQuery += " WHERE " + SQLCriteria;

            BE.IF.PRML.PRMLDataTable ret = new ECX.CD.BE.IF.PRML.PRMLDataTable();
            ret.Merge(ExecuteDT(SQLQuery));
            return ret;
        }
        public DataTable SearchPRML(List<Guid> bankBranchIds, DateTime authorizedDateFrom, DateTime authorizedDateTo, byte status, bool onlyAuthorized)
        {
            string SQLCriteria = string.Empty;
            SQLCriteria += " ((tblPRML.AuthorizedDate BETWEEN '" + authorizedDateFrom.ToString("yyyy-MM-dd") + "' AND '" + authorizedDateTo.ToString() + "')";

            if (onlyAuthorized)
            {
                SQLCriteria += ") ";
            }
            else
            {
                SQLCriteria += "OR tblPRML.AuthorizedDate is null) ";
            }


            if (bankBranchIds.Count > 0)
            {
                SQLCriteria += " AND " + ECX.CD.DA.Utilities.AppendInString("BankBranchId", bankBranchIds);
            }
            if (status > 0)
            {
                SQLCriteria += " AND Status = " + status;
            }

            string SQLQuery = string.Empty;
            SQLQuery += " SELECT * ";
            SQLQuery += " FROM tblPRML  ";
            SQLQuery += " WHERE " + SQLCriteria;
            SQLQuery += " ORDER BY CreatedDate, TypeId ";

            BE.IF.PRML.PRMLDataTable ret = new ECX.CD.BE.IF.PRML.PRMLDataTable();
            ret.Merge(ExecuteDT(SQLQuery));
            return ret;
        }
        public DataTable SearchEmptyPRML(Guid? bankId, DateTime authorizedDateFrom, DateTime authorizedDateTo, byte status, bool onlyAuthorized)
        {
            string SQLCriteria = string.Empty;
            SQLCriteria += " ((AuthorizedDate BETWEEN '" + authorizedDateFrom.ToString("yyyy-MM-dd") + "' AND '" + authorizedDateTo.ToString() + "')";

            if (onlyAuthorized)
            {
                SQLCriteria += ") ";
            }
            else
            {
                SQLCriteria += "OR AuthorizedDate is null) ";
            }


            if (bankId.HasValue)
            {
                SQLCriteria += " AND BankId = '" + bankId.Value.ToString() + "'";
            }
            if (status > 0)
            {
                SQLCriteria += " AND Status = " + status;
            }

            string SQLQuery = string.Empty;
            SQLQuery += " SELECT * ";
            SQLQuery += " FROM tblEmptyPRML  ";
            SQLQuery += " WHERE " + SQLCriteria;

            BE.IF.PRML.EmptyPRMLDataTable ret = new ECX.CD.BE.IF.PRML.EmptyPRMLDataTable();
            ret.Merge(ExecuteDT(SQLQuery));
            return ret;
        }

        public ECX.CD.BE.IF.PRML.PRMLDataTable GetPRML(List<Guid> bankBranches, List<byte> statuses)
        {
           
            return GetPRML(bankBranches, statuses, true);
        }
        public ECX.CD.BE.IF.PRML.PRMLDataTable GetPRML(List<Guid> bankBranches, List<byte> statuses, bool includeAuthorised)
        {
            SqlCommand command = new SqlCommand();

            if (bankBranches.Count == 0)
            {
                throw new InvalidOperationException("Bank branches should be specified.");
            }

            string banksList = DA.Utilities.AppendInString("BankBranchId", bankBranches);
            string statusesList = DA.Utilities.AppendInString("Status", statuses);

            command.CommandText =
            " SELECT  * " +
            " FROM    tblPRML " +
            " WHERE   " + statusesList + " " +
            (includeAuthorised ? "" : " AND IsResponseAuthorised = 0 ") +
            ((banksList.Trim().Length > 0 && statusesList.Length > 0) ? " AND " + banksList : banksList);

            BE.IF.PRML.PRMLDataTable ret = new ECX.CD.BE.IF.PRML.PRMLDataTable();
            ret.Merge(ExecuteDT(command));

            return ret;
        }
        public ECX.CD.BE.IF.PRML.PRMLRow GetPRML(Guid PRMLId)
        {
            string SQLQuery =
                " SELECT     * " +
                " FROM         tblPRML " +
                " WHERE     (ID = @ID) ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.AddWithValue("@ID", PRMLId);

            BE.IF.PRML.PRMLDataTable prmlTable = new ECX.CD.BE.IF.PRML.PRMLDataTable();
            prmlTable.Merge(new IFSQLHelper().ExecuteDT(command));

            if (prmlTable.Rows.Count == 1)
                return prmlTable[0];
            else
                return null;
        }
        public ECX.CD.BE.IF.PRML.PRMLDataTable GetPRML(List<Guid> prmlIds)
        {
            SqlCommand command = new SqlCommand();

            if (prmlIds.Count == 0)
            {
                throw new InvalidOperationException("PRML Ids should be specified.");
            }

            string ids = DA.Utilities.AppendInString("ID", prmlIds);

            command.CommandText =
            " SELECT  * " +
            " FROM    tblPRML " +
            " WHERE   " + ids +
            " ORDER BY  (SELECT Section FROM tblPRMLType WHERE (Id = tblPRML.TypeId)), " +
            "           (SELECT Name FROM tblPRMLType WHERE (Id = tblPRML.TypeId)), WHRNO ";

            BE.IF.PRML.PRMLDataTable ret = new ECX.CD.BE.IF.PRML.PRMLDataTable();
            ret.Merge(ExecuteDT(command));

            return ret;
        }

        public bool SavePRMLTempStatus(Guid prmlId, byte newStatus, string remark, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = prmlId;
            command.Parameters.Add("@TempStatus", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = remark;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSavePRMLTempStatus", command));
        }
        public bool SavePRMLStatus(Guid prmlId, byte newStatus, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = prmlId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSavePRMLStatus", command));
        }
        public bool SavePRMLStatus(Guid prmlId, byte newStatus, string remark, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = prmlId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = remark;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSavePRMLStatusWithRemark", command));
        }
        public bool SavePRMLAuthorised(Guid prmlId, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = prmlId;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spAuthorisePRML", command));
        }
        public bool ConfirmPRML(Guid prmlId, byte newStatus, string remark, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = prmlId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = remark;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spConfirmPRML", command));
        }

        public BE.IF.PRML.PRMLTypeRow GetPRMLType(int prmlTypeId)
        {
            BE.IF.PRML.PRMLTypeDataTable table = new ECX.CD.BE.IF.PRML.PRMLTypeDataTable();

            table.Merge(ExecuteDT("SELECT * FROM tblPRMLType WHERE Id = " + prmlTypeId));

            if (table.Rows.Count > 0)
            {
                return (BE.IF.PRML.PRMLTypeRow)(table.Rows[0]);
            }
            else
            {
                throw new Exception("PRML Type not found.");
            }
        }

        public bool Insert(Guid prmlId, int typeId, Guid bankBranchId, int whrId, string clientId, string memberid,
            string organizationName, string commodityGradeSymbol, float originalLots, float currentLots,
            DateTime expiryDate, byte status, byte tempStatus, Guid createdBy, DateTime createdDate,
            DateTime? eventDate, double? eventLots, double? tradePrice, double? payoutPrice)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("ID", SqlDbType.UniqueIdentifier).Value = prmlId;
            command.Parameters.Add("@TypeId", SqlDbType.Int).Value = typeId;
            command.Parameters.Add("@BankBranchId", SqlDbType.UniqueIdentifier).Value = bankBranchId;
            command.Parameters.Add("@WHRNo", SqlDbType.Int).Value = whrId;
            command.Parameters.Add("@ECXClientId", SqlDbType.VarChar).Value = clientId;
            command.Parameters.Add("@ECXMemberId", SqlDbType.VarChar).Value = memberid;
            command.Parameters.Add("@OrganizationName", SqlDbType.VarChar).Value = organizationName;
            command.Parameters.Add("@CommodityGradeSymbol", SqlDbType.VarChar).Value = commodityGradeSymbol;
            command.Parameters.Add("@OriginalLots", SqlDbType.Decimal).Value = originalLots;
            command.Parameters.Add("@CurrentLots", SqlDbType.Decimal).Value = currentLots;
            command.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = expiryDate;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = status;
            command.Parameters.Add("@TempStatus", SqlDbType.TinyInt).Value = tempStatus;
            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = createdDate;

            command.Parameters.Add("@EventDate", SqlDbType.DateTime).Value = eventDate;
            command.Parameters.Add("@EventLots", SqlDbType.Decimal).Value = eventLots;
            command.Parameters.Add("@TradePrice", SqlDbType.Decimal).Value = tradePrice;
            command.Parameters.Add("@PayoutValue", SqlDbType.Decimal).Value = payoutPrice;

            return Convert.ToBoolean(ExecuteNonQuerySP("spInsertPRML", command));
        }
        public bool Insert(Guid prmlId, int typeId, Guid bankBranchId, int whrId, string clientId, string memberid,
            string organizationName, string commodityGradeSymbol, float originalLots, float currentLots,
            DateTime expiryDate, byte status, byte tempStatus, Guid createdBy, DateTime createdDate)
        {
            return Insert(prmlId, typeId, bankBranchId, whrId, clientId, memberid, organizationName, commodityGradeSymbol,
                originalLots, currentLots, expiryDate, status, tempStatus, createdBy, createdDate, null, null, null, null);
        }

        public int GetPRMLCount(int whrId, int prmlTypeId, bool authorised)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
            " SELECT     * " +
            " FROM         tblPRML " +
            " WHERE     (WHRNO = @WHRNO) AND (TypeId = @TypeId) AND (IsResponseAuthorised = @IsResponseAuthorised)";

            command.Parameters.AddWithValue("@WHRNO", whrId);
            command.Parameters.AddWithValue("@TypeId", prmlTypeId);
            command.Parameters.AddWithValue("@IsResponseAuthorised", authorised);

            DataTable tbl = ExecuteDT(command);

            return tbl.Rows.Count;
        }

        public void ClearNonAuthorizedPRML()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
            " DELETE tblPRML " +
            " WHERE  IsResponseAuthorised = @IsResponseAuthorised";

            command.Parameters.AddWithValue("@IsResponseAuthorised", false);

            ExecuteNonQuery(command);
        }
        public void ClearNonAuthorizedEmptyPRML()
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
            " DELETE tblEmptyPRML " +
            " WHERE  IsResponseAuthorised = @IsResponseAuthorised";

            command.Parameters.AddWithValue("@IsResponseAuthorised", false);

            ExecuteNonQuery(command);
        }

        public bool UnAuthorizedReportExists(List<Guid> bankBranchIds)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
            " SELECT COUNT(*) " +
            " FROM   tblPRML " +
            " WHERE  (IsResponseAuthorised = @IsResponseAuthorised) ";
            if (bankBranchIds.Count > 0)
            {
                command.CommandText += " AND " + ECX.CD.DA.Utilities.AppendInString("BankBranchId", bankBranchIds);
            }

            command.Parameters.Add("IsResponseAuthorised", SqlDbType.Bit).Value = false;

            int count = ExecuteInt(command);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UnAuthorizedEmptyReportExists(Guid bankId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
            " SELECT COUNT(*) " +
            " FROM   tblEmptyPRML " +
            " WHERE  (BankId = @BankId) AND (IsResponseAuthorised = @IsResponseAuthorised)";

            command.Parameters.Add("BankId", SqlDbType.UniqueIdentifier).Value = bankId;
            command.Parameters.Add("IsResponseAuthorised", SqlDbType.Bit).Value = false;

            int count = ExecuteInt(command);

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveEmptyPRML(Guid id, Guid bankId, byte status, Guid createdBy, DateTime createdDatetime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("ID", SqlDbType.UniqueIdentifier).Value = id;
            command.Parameters.Add("BankId", SqlDbType.UniqueIdentifier).Value = bankId;
            command.Parameters.Add("Status", SqlDbType.TinyInt).Value = status;
            command.Parameters.Add("CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
            command.Parameters.Add("CreatedDate", SqlDbType.DateTime).Value = createdDatetime;

            return Convert.ToBoolean(ExecuteNonQuerySP("spInsertEmptyPRML", command));
        }

        public ECX.CD.BE.IF.PRML.EmptyPRMLRow GetEmptyPRML(Guid emptyPRMLId)
        {
            string SQLQuery =
                " SELECT     * " +
                " FROM         tblEmptyPRML " +
                " WHERE     (ID = @ID) ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.AddWithValue("@ID", emptyPRMLId);

            BE.IF.PRML.EmptyPRMLDataTable prmlTable = new ECX.CD.BE.IF.PRML.EmptyPRMLDataTable();
            prmlTable.Merge(new IFSQLHelper().ExecuteDT(command));

            if (prmlTable.Rows.Count == 1)
                return prmlTable[0];
            else
                return null;
        }

        public bool ConfirmEmptyPRML(Guid emptyPRMLId, byte statusCode, Guid confirmedBy, DateTime confirmedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = emptyPRMLId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = statusCode;
            command.Parameters.Add("@ConfirmedBy", SqlDbType.UniqueIdentifier).Value = confirmedBy;
            command.Parameters.Add("@ConfirmedDate", SqlDbType.DateTime).Value = confirmedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spConfirmEmptyPRML", command));
        }

        public bool AutorizeEmptyPRML(Guid emptyPRMLId, Guid autorizedBy, DateTime autorizeDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = emptyPRMLId;
            command.Parameters.Add("@AuthorizedBy", SqlDbType.UniqueIdentifier).Value = autorizedBy;
            command.Parameters.Add("@AuthorizedDate", SqlDbType.DateTime).Value = autorizeDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spAuthorizeEmptyPRML", command));
        }

        public DataTable GetEmptyPRML(Guid bankId, byte statusCode, bool includeAuthorised)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
            command.CommandText += " SELECT  * ";
            command.CommandText += " FROM    tblEmptyPRML ";
            command.CommandText += " WHERE   BankId = @BankId AND Status = @Status ";
            if (!includeAuthorised)
            {
                command.CommandText += " AND IsResponseAuthorised = 0 ";
            }
            command.Parameters.AddWithValue("BankId", bankId);
            command.Parameters.AddWithValue("Status", statusCode);

            BE.IF.PRML.EmptyPRMLDataTable ret = new ECX.CD.BE.IF.PRML.EmptyPRMLDataTable();
            ret.Merge(ExecuteDT(command));

            return ret;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          