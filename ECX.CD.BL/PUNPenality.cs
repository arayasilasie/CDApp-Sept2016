using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using ECX.CD.DA;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.BL
{
    public class PUNPenality : SQLHelper
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
        public void SavePUNPenality(string PUNxml)
        {
            SqlCommand command = new SqlCommand();

            //command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
            //command.Parameters.Add("@WarehouseRecieptId", SqlDbType.UniqueIdentifier).Value = GetParentWHR(gRNID);
            //command.Parameters.Add("GRNId", SqlDbType.UniqueIdentifier).Value = gRNID;
            //command.Parameters.Add("@RequestedBy", SqlDbType.UniqueIdentifier).Value = RequestedBy;
            command.Parameters.Add("@PUNxml", SqlDbType.NVarChar).Value = PUNxml;

            Convert.ToBoolean(ExecuteNonQuerySP("spSavepunpen", command));
        }

        public DataTable getPUNbyWHRNo()
        {
            string commandText = "GetPUNForPenality";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientIDNO", SqlDbType.VarChar).Value = ClientIDNo;
            cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }
        public DataTable getPUNbyClientIDNo()
        {
            string commandText = "GetPUNForPenality";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientIDNO", SqlDbType.VarChar).Value = ClientIDNo;
            cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }

        public DataTable getPUNforApproval()
        {

            string commandText = "spGetUnapprovedPunPen";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientIDNO", SqlDbType.VarChar).Value = ClientIDNo;
            cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }
        public bool approvePUNPen(string XMLPUNApp)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@XMLPUNApp", SqlDbType.NVarChar).Value = XMLPUNApp;

            return Convert.ToBoolean(ExecuteNonQuerySP("spApprovePUNPEN", command));
        }
        #endregion

        public object getPUNReportDetail(Guid Clientguid)
        {
            string commandText = "spgetPUNReportDetail";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientID", SqlDbType.UniqueIdentifier).Value = Clientguid;
            //cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }

        public DataTable GetPUNPENForReport()
        {
            string commandText = "GetPUNPENForReport";
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@ClientIDNO", SqlDbType.VarChar).Value = ClientIDNo;
            cmd.Parameters.Add("@WHRNo", SqlDbType.Int).Value = WHR;
            cmd.Parameters.Add("@ProcessedDated", SqlDbType.Date).Value = DateOfProcessing;
            DataTable dt = ExecuteDTSP(commandText, cmd);
            return dt;
        }
    }
}
