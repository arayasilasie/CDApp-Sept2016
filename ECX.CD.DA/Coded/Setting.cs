using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class Setting:SQLHelper
    {
        public string GetStringSettingValue(string key)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("Key", SqlDbType.VarChar).Value = key;

            return ExecuteStringSP("spGetSettingValue", command);
        }

        public int GetIntSettingValue(string key)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("Key", SqlDbType.VarChar).Value = key;

            return ExecuteIntSP("spGetSettingValue", command);
        }
    }
}
