using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class Validation:IFSQLHelper
    {
		//public bool GRNBelongsToMember(int gRNNumber)
		//{
		//    SqlCommand command = new SqlCommand();

		//    command.CommandText =
		//        "SELECT	ClientId, GRNNumber " +
		//        "FROM   tblWarehouseReciept " +
		//        "WHERE  GRNNumber = @GRNNumber)";

		//    command.Parameters.Add("@GRNNumber", SqlDbType.VarChar).Value = GRNNumber;

		//    ExecuteString(command);
		//}
    }
}
