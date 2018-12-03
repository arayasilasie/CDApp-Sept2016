using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class WR:SQLHelper
    {
        public DataTable SearchWR()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "Select * From tblWarehouseReciept";
            return ExecuteDT(command);
        }

        public void InactivateWR(Guid id)
        {

        }
    }
}
