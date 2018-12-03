using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ECX.CD.DA.IF
{
    public class WHR
    {
        public static bool SaveWHRStatus(int whrNo, byte currentStatus, byte newStatus, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@WRNo", SqlDbType.Int).Value = whrNo;
            command.Parameters.Add("@CurrentStatus", SqlDbType.TinyInt).Value = currentStatus;
            command.Parameters.Add("@NewStatus", SqlDbType.TinyInt).Value = newStatus;
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            int recordsAffected = new IFSQLHelper().ExecuteIntSP("spUpdateWHRStatus", command);

            if (recordsAffected == 1)
                return true;
            else
                return false;
        }
        public static bool SaveWHRStatus(int whrNo, byte currentStatus, byte newStatus, double? quantityOnUnpledge, Guid updatedBy, DateTime updatedDateTime)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@WRNo", SqlDbType.Int).Value = whrNo;
            command.Parameters.Add("@CurrentStatus", SqlDbType.TinyInt).Value = currentStatus;
            command.Parameters.Add("@NewStatus", SqlDbType.TinyInt).Value = newStatus;
            if (quantityOnUnpledge.HasValue)
            {
                command.Parameters.Add("@QuantityOnUnpledge", SqlDbType.Float).Value = quantityOnUnpledge.Value;
            }
            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier).Value = updatedBy;
            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = updatedDateTime;

            int recordsAffected = new IFSQLHelper().ExecuteIntSP("spUpdateWHRStatus", command);

            if (recordsAffected == 1)
                return true;
            else
                return false;
        }
        public static byte GetWHRStatus(int whrNo)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@WRNo", SqlDbType.Int).Value = whrNo;

            return (byte)new IFSQLHelper().ExecuteIntSP("spGetWHRStatus", command);
        }
        public static float GetQuantityOnUnpledge(int whrNo)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT QuantityOnUnpledge FROM tblWHR WHERE WRNO = " + whrNo;

            float quantity = new IFSQLHelper().ExecuteFloat(command);

            return quantity;
        }

        public static List<int> GetWHRs(byte status)
        {
            string commandText = "SELECT WRNO FROM tblWHR WHERE Status = " + status;

            DataTable dt = new IFSQLHelper().ExecuteDT(commandText);

            List<int> whrs = new List<int>();
            foreach (DataRow row in dt.Rows)
            {
                whrs.Add(Convert.ToInt32(row["WRNO"].ToString()));
            }
            return whrs;
        }
    }
}
