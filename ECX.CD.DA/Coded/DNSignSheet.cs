using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ECX.CD.DA
{
    public class DNSignSheet
    {
        /// <summary>
        /// Gets the list of warehouse receipt records on a given trade date.
        /// </summary>
        /// <param name="dtTrade">the date when the trade is carried out</param>
        /// <returns>data set of warehouse receipt records</returns>
        public static DataSet GetWarehouseReceipt(DateTime dtTrade)
        {
            SqlCommand command = new SqlCommand();//create command
            //prepare the SQL statement to get the warehouse records
            command.CommandText = "SELECT tblWarehouseReciept.WarehouseRecieptId, tblWarehouseReciept.CommodityGradeId, tblWarehouseReciept.ClientId, tblWarehouseReciept.TradeDate, NumberOfBags , MemberName  " + 
                "FROM tblWarehouseReciept " +
                "inner join dbo.tblDNSnapshot on tblWarehouseReciept.WarehouseRecieptId =  tblDNSnapshot.WHRID " +
                "WHERE (CONVERT(DATETIME, CONVERT(varchar, tblWarehouseReciept.TradeDate, 101)) = @TradeDate) order by tblWarehouseReciept.WarehouseRecieptId desc";
            command.Parameters.AddWithValue("@TradeDate", dtTrade);//add the trade date parameter to filter warehouse receipt

            //create the data set to return the resultset
            DataSet ds = new DataSet("WarehouseReceipt");

            DataTable dt = new SQLHelper().ExecuteDT(command);
            ds.Tables.Add(dt);

            //return the dataset
            return ds;

        }//GetWarehouseReceipt

    }
}
