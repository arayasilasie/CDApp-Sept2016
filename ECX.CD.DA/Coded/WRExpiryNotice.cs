using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class WRExpiryNotice 
    {
        /// <summary>
        /// Gets the list of warehouse receipts to be expired within the given days remaining.
        /// </summary>
        /// <param name="iLowerBound">the lower bound of the remaining days</param>
        /// <param name="iUpperBound">the upper bound of the remaining days</param>
        /// <returns>list of WHRs to be expired within the given number of days</returns>
        public static DataTable GetExpiredWHRs(int iLowerBound, int iUpperBound)
        {            
            SqlCommand cmd = new SqlCommand();//create sql command from the connection
            //prepare the sql statement to execute
            string sql = "SELECT Id, WarehouseRecieptId, CommodityGradeId, WarehouseId, " +
                "WRStatusId, CurrentQuantity, ClientId, ExpiryDate, DATEDIFF(day, GetDate(), ExpiryDate) AS [RemainingDays] " +
                "FROM  tblWarehouseReciept WHERE ((WRStatusId = 2) AND (CurrentQuantity > 0) " +
                "AND (DateDiff(day, GetDate(), ExpiryDate) BETWEEN @LowerBound AND @UpperBound));";
            //set the sql to the command
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            //set param values
            cmd.Parameters.AddWithValue("@LowerBound", iLowerBound);
            cmd.Parameters.AddWithValue("@UpperBound", iUpperBound);

            //create a data table to store records
            DataTable dt = new SQLHelper().ExecuteDT(cmd, "Expired WHR");

            //finally return the data table
            return dt;            
        }
    }
}
