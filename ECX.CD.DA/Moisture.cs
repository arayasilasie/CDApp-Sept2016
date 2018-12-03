using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class Moisture:SQLHelper
    {
        public double GetLossAmount(Guid commodityGradeId)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText = 
                "SELECT Amount " +
                "FROM   tblMoistureLoss " +
                "WHERE  (CommodityGradeId = @CommodityGradeId)";

            command.Parameters.Add("CommodityGradeId", SqlDbType.UniqueIdentifier).Value = commodityGradeId;

            return ExecuteDouble(command);
        }
    }
}