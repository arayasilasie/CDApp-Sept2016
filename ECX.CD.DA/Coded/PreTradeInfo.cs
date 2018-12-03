using System;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class PreTradeInfo
    {
        public static DataTable GetPreTradeInfo()
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new SQLHelper().ExecuteDTSP("spGetPreTradeinfo", command);
            return dt;

        }
        public static DataTable GetOrigin(Guid commoditygradeid)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@commodityGradeId", SqlDbType.UniqueIdentifier).Value = commoditygradeid;
            DataTable dt = new SQLHelper().ExecuteDTSP("spGetOrigin", command);
            return dt;
        }
        public static DataTable GetOrigin_New()
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new SQLHelper().ExecuteDTSP("spGetOrigin", command);
            return dt;
        }
        public static DataTable GetSession(Guid commoditygradeid)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@commodityGradeId", SqlDbType.UniqueIdentifier).Value = commoditygradeid;
            DataTable dt = new SQLHelper().ExecuteDTSP("spGetSession", command);
            return dt;
        }
        public static DataTable GetSession_New()
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new SQLHelper().ExecuteDTSP("spGetSession", command);
            return dt;
        }
        public static DataTable GetMoistureContent(int grnnumber)
        {
            SqlCommand command = new SqlCommand();
            command.Parameters.Add("@GRNNo", SqlDbType.VarChar).Value = grnnumber;
            DataTable dt = new SQLHelper().ExecuteDTSP("GetMoistContentByGRNNo", command);
            return dt;
        }
        public static DataTable GetMoistureContent_New()
        {
            SqlCommand command = new SqlCommand();
            DataTable dt = new SQLHelper().ExecuteDTSP("GetMoistContentByGRNNo", command);
            return dt;
        }
    }
}
