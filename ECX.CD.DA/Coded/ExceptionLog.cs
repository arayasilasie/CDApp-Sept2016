using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{

    public class ExceptionLog
    {
        public static BE.Exception.ExceptionLogDataTable GetList()
        {
            string commandText = "SELECT * FROM tblExceptionLog";

            BE.Exception.ExceptionLogDataTable tbl = new ECX.CD.BE.Exception.ExceptionLogDataTable();

            DataTable dt = new SQLHelper().ExecuteDT(commandText);

            if (dt.Rows.Count >0)
            {
                tbl.Merge(dt);
            }

            return tbl;
        }
        public static BE.Exception.ExceptionLogRow GetException(Guid exceptionId)
        {
            string commandText = "SELECT * FROM tblExceptionLog WHERE Id = '" + exceptionId.ToString() + "'";
            SqlCommand command = new SqlCommand(commandText);

            //command.Parameters.AddWithValue("@Id", exceptionId);

            BE.Exception.ExceptionLogDataTable tbl = new ECX.CD.BE.Exception.ExceptionLogDataTable();

            DataTable dt = new SQLHelper().ExecuteDT(commandText);

            if (dt.Rows.Count > 0)
            {
                tbl.Merge(dt);
            }
            else
            {
                throw new InvalidOperationException("Requested record does not exist.");
            }

            return (BE.Exception.ExceptionLogRow)tbl.Rows[0];
        }
    }
}
