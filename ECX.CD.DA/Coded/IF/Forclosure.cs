using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ECX.CD.DA
{
    public class Foreclosure : IFSQLHelper
    {
        public System.Data.DataTable Search(int whrNoFrom, int whrNoTo, int grnNoFrom, int grnNoTo, Guid bankId, string mcId, DateTime expiryDateFrom, DateTime expiryDateTo, byte status)
        {
            //TODO: finilize the Search method

            string SQLCriteria = string.Empty;
            if (whrNoFrom != int.MinValue || whrNoTo != int.MaxValue)
            {
                SQLCriteria += " ((tblForeclosure.WHRNo BETWEEN " + whrNoFrom + " AND " + whrNoTo + ") OR tblForeclosure.WHRNo is null) AND ";
            }
            //if (grnNoFrom != int.MinValue && grnNoTo != int.MaxValue)
            //{
            //    SQLCriteria += " ((tblForeclosure.WHRNo BETWEEN " + grnNoFrom + " AND " + grnNoTo + ") OR tblForeclosure.WHRNo is null) AND ";
            //}
            //SQLCriteria += " ((tblPRML.ExpiryDate BETWEEN '" + expiryDateFrom.ToString("yyyy-MM-dd") + "' AND '" + expiryDateTo.ToString("yyyy-MM-dd") + "') OR tblForeclosure.ExpiryDate is null) ";
            if (mcId != string.Empty)
            {
                SQLCriteria += (SQLCriteria.Length > 0 ? " AND " : "") + " ((tblForeclosure.ECXMemberId = '" + mcId + "' ) OR (tblForeclosure.ECXClientId = '" + mcId + "' )) ";
            }
            if (bankId != Guid.Empty)
            {
                SQLCriteria += (SQLCriteria.Length > 0 ? " AND " : "") + "  BankId = '" + bankId + "' ";
            }
            if (status > 0)
            {
                SQLCriteria += (SQLCriteria.Length > 0 ? " AND " : "") + "  StatusId = " + status;
            }

            string SQLQuery = string.Empty;
            SQLQuery += " SELECT * ";
            SQLQuery += " FROM tblForeclosure  ";
            if (SQLCriteria.Length > 0)
            {
                SQLQuery += " WHERE " + SQLCriteria;
            }

            BE.IF.FR.ForeclosureDataTable ret = new ECX.CD.BE.IF.FR.ForeclosureDataTable();
            ret.Merge(ExecuteDT(SQLQuery));
            return ret;
        }
        public BE.IF.FR.ForeclosureDataTable GetRequest(List<Guid> bankBranches, List<byte> statuses)
        {
            return GetRequest(bankBranches, statuses, true);
        }
        public ECX.CD.BE.IF.FR.ForeclosureRow GetRequest(Guid foreclosureRequestId)
        {
            string SQLQuery =
                " SELECT     Id, WHRNO, ECXClientID, ECXMemberID, OrganizationName, BankId, BankBranchName, StatusId, TempStatusId, Remark, CreatedBy, CreatedDate, UpdatedDate, UpdatedBy " +
                " FROM         tblForeclosure " +
                " WHERE     (ID = @ID) ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.AddWithValue("@ID", foreclosureRequestId);

            BE.IF.FR.ForeclosureDataTable frTable = new ECX.CD.BE.IF.FR.ForeclosureDataTable();
            frTable.Merge(new IFSQLHelper().ExecuteDT(command));

            if (frTable.Rows.Count == 1)
                return frTable[0];
            else
                return null;
        }
        public BE.IF.FR.ForeclosureDataTable GetRequest(List<Guid> bankBranches, List<byte> statuses, bool includeAuthorised)
        {
            SqlCommand command = new SqlCommand();

            if (bankBranches.Count == 0)
            {
                throw new InvalidOperationException("Bank branches should be specified.");
            }

            string banksList = DA.Utilities.AppendInString("BankBranchId", bankBranches);
            string statusesList = DA.Utilities.AppendInString("StatusId", statuses);

            command.CommandText =
            " SELECT     Id, WHRNO, ECXClientID, ECXMemberID, OrganizationName, BankId, BankBranchName, StatusId, TempStatusId, Remark, CreatedBy, CreatedDate, UpdatedDate, UpdatedBy " +
            " FROM         tblForeclosure " +
            " WHERE     " + statusesList + " " +
            (includeAuthorised ? "" : " AND IsResponseAuthorised = 0 ") +
            ((banksList.Trim().Length > 0 && statusesList.Length > 0) ? " AND " + banksList : banksList);

            BE.IF.FR.ForeclosureDataTable ret = new ECX.CD.BE.IF.FR.ForeclosureDataTable();
            ret.Merge(ExecuteDT(command));

            return ret;
        }
        public BE.IF.FR.ForeclosureDataTable GetRequest(List<byte> statuses, bool includeAuthorised)
        {
            SqlCommand command = new SqlCommand();

            string statusesList = DA.Utilities.AppendInString("StatusId", statuses);

            command.CommandText =
            " SELECT     Id, WHRNO, ECXClientID, ECXMemberID, OrganizationName, BankId, BankBranchName, StatusId, TempStatusId, Remark, CreatedBy, CreatedDate, UpdatedDate, UpdatedBy " +
            " FROM         tblForeclosure " +
            " WHERE     " + statusesList + " " +
            (includeAuthorised ? "" : " AND IsResponseAuthorised = 0 ");

            BE.IF.FR.ForeclosureDataTable ret = new ECX.CD.BE.IF.FR.ForeclosureDataTable();
            ret.Merge(ExecuteDT(command));

            return ret;
        }
        public bool SaveTempStatus(Guid frId, byte newStatus, string remark, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = frId;
            command.Parameters.Add("@TempStatus", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = remark;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSaveForeclosureTempStatus", command));
        }
        public bool SaveStatus(Guid frId, byte newStatus, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = frId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSaveForeclosureStatus", command));
        }
        public bool SaveForeclosureAuthorised(Guid frId, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = frId;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spAuthoriseForeclosure", command));
        }

        public bool Confirm(Guid foreclosureRequestId, byte newStatus, string remark, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = foreclosureRequestId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = remark;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spConfirmForeclosure", command));
        }

        public static List<BE.RejectionReason> GetRejectionReasons(Guid frId)
        {
            string SQLQuery =
                " SELECT tblRejectionReasons.Id, tblRejectionReasons.Name, tblRejectionReasons.Description, tblForeclosureRejection.ForclosureRequestId AS RequestId " +
                " FROM   tblForeclosureRejection INNER JOIN " +
                "      tblRejectionReasons ON tblForeclosureRejection.RejectionReasonCode = tblRejectionReasons.Id " +
                " WHERE   tblForeclosureRejection.ForclosureRequestId = @RequestId " +
                " ORDER BY tblRejectionReasons.Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.AddWithValue("@RequestId", frId);

            DataTable table = new IFSQLHelper().ExecuteDT(command);
            List<BE.RejectionReason> reasons = new List<BE.RejectionReason>();

            foreach (DataRow row in table.Rows)
            {
                BE.RejectionReason reason = new BE.RejectionReason();

                reason.Id = (Convert.ToInt32(row["Id"]));
                reason.Name = row["Name"].ToString();
                reason.Description = row["Description"].ToString();
                reason.RequestGuid = (new Guid(row["RequestId"].ToString()));

                reasons.Add(reason);
            }
            return reasons;
        }

        public bool Insert(Guid frId, int whrNo, string clientId, string memberId, string organizationName, Guid bankId, Guid bankBranchId, string bankBranchName, byte status, byte tempStatus, Guid createdBy, DateTime createdDate)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("ID", SqlDbType.UniqueIdentifier).Value = frId;
            command.Parameters.Add("@WHRNo", SqlDbType.Int).Value = whrNo;

            command.Parameters.Add("@ECXClientID", SqlDbType.VarChar).Value = clientId;
            command.Parameters.Add("@ECXMemberID", SqlDbType.VarChar).Value = memberId;
            command.Parameters.Add("@OrganizationName", SqlDbType.VarChar).Value = organizationName;

            command.Parameters.Add("@BankId", SqlDbType.UniqueIdentifier).Value = bankId;
            command.Parameters.Add("@BankBranchId", SqlDbType.UniqueIdentifier).Value = bankBranchId;
            command.Parameters.Add("@BankBranchName", SqlDbType.VarChar).Value = bankBranchName;

            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = status;
            command.Parameters.Add("@TempStatus", SqlDbType.TinyInt).Value = status;
            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = createdDate;

            return Convert.ToBoolean(ExecuteNonQuerySP("spInsertForeclosureRequest", command));
        }
        public static bool SaveRejectionReason(Guid rejectionId, Guid requestId, int reasonId, Guid createdBy, DateTime dateCreated)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = rejectionId;
            command.Parameters.Add("@ForclosureRequestId", SqlDbType.UniqueIdentifier).Value = requestId;
            command.Parameters.Add("@RejectionReasonCode", SqlDbType.Int).Value = reasonId;
            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = dateCreated;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spInsertForeclosureRejectionReason", command));
        }

    }
}