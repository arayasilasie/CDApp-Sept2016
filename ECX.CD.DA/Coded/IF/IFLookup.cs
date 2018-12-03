using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ECX.CD.DA
{
    public class IFLookup:IFSQLHelper
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

        public DataTable SelectAll(string tableName)
        {
            return ExecuteDT("Select Id, Name From [" + tableName + "]");
        }
    }
}
