using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ECX.CD.DA
{
    public class UnPledge : IFSQLHelper
    {
        public bool Insert(Guid upId, int whr, string clientIdNo, string memberIdNo, Guid bankId, string bankName, string bankBranchName, byte status, byte tempStatus, int requestNumber, string requestDate, Guid createdBy, DateTime createdDate)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@UnpledgeID", SqlDbType.UniqueIdentifier).Value = upId;
            command.Parameters.Add("@WRNo", SqlDbType.VarChar).Value = whr;
            command.Parameters.Add("@ClientIdNo", SqlDbType.VarChar).Value = clientIdNo;
            command.Parameters.Add("@MemberIdNo", SqlDbType.VarChar).Value = memberIdNo;
            command.Parameters.Add("@BankId", SqlDbType.UniqueIdentifier).Value = bankId;
            command.Parameters.Add("@Bank", SqlDbType.VarChar).Value = bankName;
            command.Parameters.Add("@BankBranch", SqlDbType.VarChar).Value = bankBranchName;
            command.Parameters.Add("@RequestNumber", SqlDbType.Int).Value = requestNumber;
            command.Parameters.Add("@RequestDate", SqlDbType.VarChar).Value = requestDate;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = status;
            command.Parameters.Add("@TempStatus", SqlDbType.TinyInt).Value = tempStatus;
            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = createdDate;

            return Convert.ToBoolean(ExecuteNonQuerySP("spInsertUnPledgeRequest", command));
        }

        public BE.IF.UP.UnpledgeDataTable GetUnPledgeRequest(Guid? bankId, List<byte> statuses)
        {
            return GetUnPledgeRequest(bankId, statuses, true);
        }
        public BE.IF.UP.UnpledgeDataTable GetUnPledgeRequest(Guid? bankId, List<byte> statuses, bool includeAuthorised)
        {
            SqlCommand command = new SqlCommand();

            string statusesList = DA.Utilities.AppendInString("Status", statuses);

            command.CommandText =
            " SELECT     * " +
            " FROM         tblUnpledge " +
            " WHERE     " + statusesList + " " +
            (includeAuthorised ? "" : " AND IsResponseAuthorised = 0 ") +
            ((bankId.HasValue && statusesList.Length > 0) ? string.Format(" AND BankId = '{0}'", bankId) : "");

            BE.IF.UP.UnpledgeDataTable ret = new ECX.CD.BE.IF.UP.UnpledgeDataTable();
            ret.Merge(ExecuteDT(command));

            return ret;
        }
        public ECX.CD.BE.IF.UP.UnpledgeRow GetUnPledgeRequest(Guid upRequestId)
        {
            string SQLQuery =
                " SELECT     * " +
                " FROM         tblUnpledge " +
                " WHERE     (UnpledgeID = @UnpledgeID) ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.AddWithValue("@UnpledgeID", upRequestId);

            BE.IF.UP.UnpledgeDataTable upTable = new ECX.CD.BE.IF.UP.UnpledgeDataTable();
            upTable.Merge(new IFSQLHelper().ExecuteDT(command));

            if (upTable.Rows.Count == 1)
                return upTable[0];
            else
                return null;
        }
        public BE.IF.UP.UnpledgeDataTable GetUnPledgeRequest(List<byte> statuses, bool includeAuthorised)
        {
            SqlCommand command = new SqlCommand();

            string statusesList = DA.Utilities.AppendInString("Status", statuses);

            command.CommandText =
            " SELECT     * " +
            " FROM         tblUnpledge " +
            " WHERE     " + statusesList + " " +
            (includeAuthorised ? "" : " AND IsResponseAuthorised = 0 ");

            BE.IF.UP.UnpledgeDataTable ret = new ECX.CD.BE.IF.UP.UnpledgeDataTable();
            ret.Merge(ExecuteDT(command));

            return ret;
        }

        public bool SaveUPTempStatus(Guid upRequestId, byte newStatus, string remark, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@UnpledgeID", SqlDbType.UniqueIdentifier).Value = upRequestId;
            command.Parameters.Add("@TempStatus", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = remark;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSaveUPTempStatus", command));
        }
        public bool SaveUPStatus(Guid upRequestId, byte newStatus, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@UnpledgeID", SqlDbType.UniqueIdentifier).Value = upRequestId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSaveUPStatus", command));
        }
        public bool SaveUPStatus(Guid upRequestId, byte newStatus, string remark, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@UnpledgeID", SqlDbType.UniqueIdentifier).Value = upRequestId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@Remark", SqlDbType.VarChar).Value = remark;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSaveUPStatusWithRemark", command));
        }
        public bool ConfirmUP(Guid upRequestId, byte newStatus, string remark, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@UnpledgeID", SqlDbType.UniqueIdentifier).Value = upRequestId;
            command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = remark;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spConfirmUP", command));
        }
        public bool SaveUPAuthorised(Guid upRequestId, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@UnpledgeID", SqlDbType.UniqueIdentifier).Value = upRequestId;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spAuthoriseUnpledge", command));
        }

        //public bool AuthoriseUPesponse(Guid upRequestId, byte newStatus, Guid updatedBy, DateTime updatedDateTime)
        //{
        //    SqlCommand command = new SqlCommand();

        //    command.Parameters.Add("@UnpledgeID", SqlDbType.UniqueIdentifier).Value = upRequestId;
        //    command.Parameters.Add("@Status", SqlDbType.TinyInt).Value = newStatus;
        //    command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
        //    command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

        //    return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spSaveUPStatus", command));
        //}
        //public bool RejectUPesponse(Guid upRequestId, byte newStatus, Guid updatedBy, DateTime updatedDateTime)
        //{
        //    SqlCommand command = new SqlCommand();

        //    command.Parameters.Add("@UnpledgeID", SqlDbType.UniqueIdentifier).Value = upRequestId;
        //    command.Parameters.Add("@TempStatus", SqlDbType.TinyInt).Value = newStatus;
        //    command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
        //    command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

        //    return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spResetUPRequest", command));
        //}

        public static bool SaveRejectionReason(Guid rejectionId, Guid requestId, int reasonId, Guid createdBy, DateTime dateCreated)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = rejectionId;
            command.Parameters.Add("@UnpledgeRequestId", SqlDbType.UniqueIdentifier).Value = requestId;
            command.Parameters.Add("@RejectionReasonCode", SqlDbType.Int).Value = reasonId;
            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier).Value = createdBy;
            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = dateCreated;

            return Convert.ToBoolean(new IFSQLHelper().ExecuteNonQuerySP("spInsertUPRejectionReason", command));
        }
        public static List<BE.RejectionReason> GetRejectionReasons(Guid upRequestId)
        {
            string SQLQuery =
                " SELECT tblRejectionReasons.Id, Name, Description, UnpledgeRequestId " +
                " FROM   tblRejectionReasons INNER JOIN " +
                "          tblUnpledgeRequestRejected ON tblRejectionReasons.Id = tblUnpledgeRequestRejected.RejectionReasonCode " +
                " WHERE  (tblUnpledgeRequestRejected.UnpledgeRequestId = @UnpledgeRequestId) " +
                " ORDER BY Id ";

            SqlCommand command = new SqlCommand(SQLQuery);
            command.Parameters.AddWithValue("@UnpledgeRequestId", upRequestId);

            DataTable table = new IFSQLHelper().ExecuteDT(command);
            List<BE.RejectionReason> reasons = new List<BE.RejectionReason>();

            foreach (DataRow row in table.Rows)
            {
                BE.RejectionReason reason = new BE.RejectionReason();

                reason.Id = (Convert.ToInt32(row["Id"]));
                reason.Name = row["Name"].ToString();
                reason.Description = row["Description"].ToString();
                reason.RequestGuid = (new Guid(row["UnpledgeRequestId"].ToString()));

                reasons.Add(reason);
            }
            return reasons;
        }

        //public DataTable SearchUP(int whrNoFrom, int whrNoTo, int grnNoFrom, int grnNoTo, List<Guid> bankBranchIds, string mcId, DateTime expiryDateFrom, DateTime expiryDateTo, byte status)
        //{
        //    string SQLCriteria = string.Empty;
        //    if (whrNoFrom == int.MinValue && whrNoTo == int.MaxValue)
        //    {
        //        SQLCriteria += " ((tblUnPledge.WRNo BETWEEN " + whrNoFrom + " AND " + whrNoTo + ") OR tblUnPledge.WRNo is null) AND ";
        //    }
        //    if (grnNoFrom == int.MinValue && grnNoTo == int.MaxValue)
        //    {
        //        SQLCriteria += " ((tblPledge.GRNNo BETWEEN " + grnNoFrom + " AND " + grnNoTo + ") OR tblPledge.GRNNo is null) AND ";
        //    }
        //    SQLCriteria += " ((tblPledge.ExpiryDate BETWEEN '" + expiryDateFrom.ToString("yyyy-MM-dd") + "' AND '" + expiryDateTo.ToString("yyyy-MM-dd") + "') OR tblPledge.ExpiryDate is null) ";
        //    if (mcId != string.Empty)
        //    {
        //        SQLCriteria += " AND ((tblPledge.MemberIdNo = '" + mcId + "' ) OR (tblPledge.ClientIdNo = '" + mcId + "' )) ";
        //    }
        //    if (bankBranchIds.Count > 0)
        //    {
        //        SQLCriteria += " AND " + ECX.CD.DA.Utilities.AppendInString("BankBranchId", bankBranchIds);
        //    }
        //    if (status > 0)
        //    {
        //        SQLCriteria += " AND tblUnPledge.Status = " + status;
        //    }

        //    string SQLQuery = string.Empty;
        //    SQLQuery += " SELECT tblUnPledge.UnpledgeID, tblUnPledge.WRNo, tblUnPledge.Status, tblUnPledge.TempStatus, tblUnPledge.BankBranchId, tblUnPledge.CreatedDate, tblUnPledge.CreatedBy  ";
        //    SQLQuery += " FROM tblPledge  ";
        //    SQLQuery += " 	Right outer JOIN tblUnPledge on tblUnPledge.WRNo = tblPledge.WHRNo ";
        //    SQLQuery += " WHERE " + SQLCriteria;

        //    BE.IF.UP.UnpledgeDataTable ret = new ECX.CD.BE.IF.UP.UnpledgeDataTable();
        //    ret.Merge(ExecuteDT(SQLQuery));
        //    return ret;
        //}

        public DataTable GetUnPledgeRequest(DateTime unpledgedDateFrom, DateTime unpledgedDateTo, byte status)
        {
            string SQLCriteria = string.Empty;
            SQLCriteria += " ((tblUnpledge.UpdatedDate BETWEEN '" + unpledgedDateFrom.ToString("yyyy-MM-dd") + "' AND '" + unpledgedDateTo.ToString("yyyy-MM-dd") + "')) ";
            if (status > 0)
            {
                SQLCriteria += " AND tblUnPledge.Status = " + status;
            }

            string SQLQuery = string.Empty;
            SQLQuery += " SELECT tblUnPledge.UnpledgeID, tblUnPledge.WRNo, tblUnPledge.Status, tblUnPledge.TempStatus, tblUnPledge.BankBranchId, tblUnPledge.CreatedDate, tblUnPledge.CreatedBy  ";
            SQLQuery += " FROM tblPledge  ";
            SQLQuery += " 	Right outer JOIN tblUnPledge on tblUnPledge.WRNo = tblPledge.WHRNo ";
            SQLQuery += " WHERE " + SQLCriteria;

            BE.IF.UP.UnpledgeDataTable ret = new ECX.CD.BE.IF.UP.UnpledgeDataTable();
            ret.Merge(ExecuteDT(SQLQuery));
            return ret;
        }

        public BE.IF.UP.UnpledgeDataTable SearchUP(Guid bankId, DateTime dtFrom, DateTime dtTo, byte status, bool onlyAuthorized)
        {
            string SQLCriteria = string.Empty;
            SQLCriteria += " ((tblUnPledge.AuthorizedDate BETWEEN '" + dtFrom.ToString() + "' AND '" + dtTo.ToString() + "') ";
            if (!onlyAuthorized)
            {
                SQLCriteria += "  OR tblUnPledge.AuthorizedDate is null) ";
            }
            if (bankId != Guid.Empty)
            {
                SQLCriteria += string.Format(" AND BankId = '{0}'", bankId);
            }
            if (status > 0)
            {
                SQLCriteria += " AND tblUnPledge.Status = " + status;
            }

            string SQLQuery = string.Empty;
            SQLQuery += " SELECT *  ";
            SQLQuery += " FROM tblUnPledge ";
            SQLQuery += " WHERE " + SQLCriteria;

            BE.IF.UP.UnpledgeDataTable ret = new ECX.CD.BE.IF.UP.UnpledgeDataTable();
            ret.Merge(ExecuteDT(SQLQuery));
            return ret;
        }

        public DataTable GetUnpledgedWhrs(DateTime dateFrom, DateTime dateTo, byte status)
        {
            string SQLCriteria = string.Empty;
            SQLCriteria += " ((AuthorizedDate BETWEEN '" + dateFrom.ToString() + "' AND '" + dateTo.ToString() + "')) ";
            SQLCriteria += " AND IsResponseAuthorised = 1 ";
            SQLCriteria += " AND Status = " + status;

            string SQLQuery = string.Empty;
            SQLQuery += " SELECT WRNo  ";
            SQLQuery += " FROM tblUnPledge ";
            SQLQuery += " WHERE " + SQLCriteria;
            
            DataTable tbl = ExecuteDT(SQLQuery);

            return tbl;
        }

        public bool UPRequestExists(int whrNo, string requestDate, bool authorized)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = "  SELECT Count(*)  ";
            command.CommandText += " FROM tblUnPledge ";
            command.CommandText += " WHERE ";
            command.CommandText += "   RequestDate = @RequestDate ";
            command.CommandText += "   AND IsResponseAuthorised = @IsResponseAuthorised ";
            command.CommandText += "   AND wrNo = @WRNo";

            command.Parameters.AddWithValue("RequestDate", requestDate);
            command.Parameters.AddWithValue("IsResponseAuthorised", authorized);
            command.Parameters.AddWithValue("WRNo", whrNo);

            if (ExecuteInt(command) > 0)
                return true;
            else
                return false;
        }

        public ECX.CD.BE.IF.UP.UnpledgeDataTable GetUnPledgeRequest(int whrId, byte status, bool onlyAuthorized)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText += " SELECT  * ";
            command.CommandText += " FROM    tblUnpledge ";
            command.CommandText += " WHERE   (Status = @Status) AND (WRNo = @WRNo) ";
            if (onlyAuthorized)
            {
                command.CommandText += " AND (IsResponseAuthorised = 1) ";
            }

            command.Parameters.AddWithValue("WRNo", whrId);
            command.Parameters.AddWithValue("Status", status);

            BE.IF.UP.UnpledgeDataTable ret = new ECX.CD.BE.IF.UP.UnpledgeDataTable();
            DataTable tbl = ExecuteDT(command);
            if (tbl.Rows.Count > 0)
            {
                ret.Merge(tbl);
            }

            return ret;
        }

    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    