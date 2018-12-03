using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECX.CD.DA;
using System.Data.SqlClient;
using System.Data;

namespace ECX.CD.BL 
{
    public class WHRPenality: SQLHelper
    {

        #region Public Properties
        public int WHR { get; set; }
        public Guid ID { get; set; }
        public int DaysPastExpiry { get; set; }
        public float TradeValue { get; set; }
        public float DailyPenalityFee { get; set; }
        public float TotalPenalityFee { get; set; }
        public float FinalAmount { get; set; }
        public DateTime DateOfProcessing { get; set; }
        public DateTime TradeDate { get; set; }
        //public float Quantity { get; set; }//????????
        public Guid UserID { get; set; }//UserBLL
        public Guid MemberID { get; set; }//UserBLL
        public Guid ClientID { get; set; }//UserBLL
        public string ClientIDNo { get; set; }
        #endregion

        #region Public Methods
        public void SubmitWHRPenality(string whrxml)
        {
            SqlCommand command = new SqlCommand();

            //command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
            //command.Parameters.Add("@WarehouseRecieptId", SqlDbType.UniqueIdentifier).Value = GetParentWHR(gRNID);
            //command.Parameters.Add("GRNId", SqlDbType.UniqueIdentifier).Value = gRNID;
            //command.Parameters.Add("@RequestedBy", SqlDbType.UniqueIdentifier).Value = RequestedBy;
            command.Parameters.Add("@whrxml", SqlDbType.NVarChar).Value = whrxml;

            Convert.ToBoolean(ExecuteNonQuerySP("spSubmitWHRPEN", command));

        }

        public DataTable getWHRbyWHRNo()
        {
            string commandText = "GetWHRForPenality";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientIDNO", SqlDbType.VarChar).Value = ClientIDNo;
            cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }

        public DataTable getWHRforReport()
        {
            string commandText = "GetWHRPENForReport";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientIDNO", SqlDbType.VarChar).Value = ClientIDNo;
            cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            cmd.Parameters.Add("@ProcessedDated", SqlDbType.Date).Value = DateOfProcessing;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }


        public bool approveWHRPen(string WHRAppXML)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@WHRAppXML", SqlDbType.NVarChar).Value = WHRAppXML;

           return Convert.ToBoolean(ExecuteNonQuerySP("spApproveWHRPEN", command));
        }
        public DataTable getWHRbyClientIDNo()
        {
            string commandText = "GetWHRForPenality";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientIDNO", SqlDbType.VarChar).Value = ClientIDNo;
            cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }

        public DataTable getWHRforApproval()
        {
            string commandText = "spGetUnapprovedWHRPen";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientIDNO", SqlDbType.VarChar).Value = ClientIDNo;
            cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }
        #endregion


        public object getWHRReportDetail(Guid ClientGuid)
        {
            string commandText = "spgetWHRReportDetail";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientID", SqlDbType.UniqueIdentifier).Value = ClientGuid;
            //cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }
    }
}
