using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.DA
{
    public class Lookup:SQLHelper
    {
        public byte GetLookupId(string tableName, string recordName)
        {
            string SQLQuery;

            SQLQuery = "Select Id From [" + tableName + "] Where Name = '" + recordName + "'";

            return Convert.ToByte(ExecuteString(SQLQuery));
        }

        public string GetLookupName(string tableName, byte id)
        {
            string SQLQuery;

            SQLQuery = "Select Name From [" + tableName + "] Where Id = '" + id + "'";

            return ExecuteString(SQLQuery);
        }

        public string GetLookupName2(string tableName, byte id)
        {
            string SQLQuery;

            SQLQuery = "Select [Description] From [" + tableName + "] Where Id = '" + id + "'";

            return ExecuteStringUsingConn2(SQLQuery);
        }

        public DataTable SelectAll(string tableName)
        {
            return ExecuteDT("Select Id, Name From [" + tableName + "]");
        }


        /*********************Extended*************************/
        public DataTable GetAllCommodityGroups()
        {
            DataTable dt = ExecuteDT("Select * from vwCommodityGroups");
            return dt;
        }


        //**** tg for Woreda
        public string GetWoredaLookupName(Guid guid)
        {
            string SQLQuery;

            SQLQuery = "Select [Description] From clLocations Where ID = '" + guid + "'";

            return ExecuteStringUsingConn3(SQLQuery);
        }
        public string GetConsignmentStatusName(Int32 st)
        {
            string SQLQuery;

            SQLQuery = "Select [Description] From tblConsignmentType Where ID = '" + st + "'";

            return ExecuteStringUsingConn3(SQLQuery);
        }
        public string GetSellerClientId(string grnno)
        {
            string SQLQuery;

            SQLQuery = "Select ClientId From tblWarehouseReciept Where SourceType=1 AND GRNNumber = '" + grnno + "'";

            return ExecuteString(SQLQuery);
        }

        public DataTable GetAllWarehouse()
        {
            DataTable dt = ExecuteDT("Select * from clWarehouses");
            return dt;
        }
    }
}
