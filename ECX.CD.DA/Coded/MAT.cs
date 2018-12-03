using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class MAT:SQLHelper
    {
        public bool SaveMAT(BE.MATT.MembersAllowedToTradeDataTable mats)
        {
            List<SqlCommand> commands = new List<SqlCommand>();
            SqlCommand command;

            foreach (BE.MATT.MembersAllowedToTradeRow mat in mats)
            {
                command = new SqlCommand();

                command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = mat.Id;
                command.Parameters.Add("@Session", SqlDbType.VarChar).Value = mat.Session;
                command.Parameters.Add("@TradeDate", SqlDbType.VarChar).Value = mat.TradeDate;
                command.Parameters.Add("@MemberId", SqlDbType.VarChar).Value = mat.MemberId;
                command.Parameters.Add("@MemberName", SqlDbType.VarChar).Value = mat.MemberName;
                command.Parameters.Add("@RepName", SqlDbType.VarChar).Value = mat.RepName;
                command.Parameters.Add("@Token", SqlDbType.VarChar).Value = mat.Token;
                command.Parameters.Add("@Checked", SqlDbType.VarChar).Value = mat.Checked;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spSaveMembersAllowedToTrade";
                commands.Add(command);
            }

            return ExecuteTransaction(commands);
        }

        public BE.MATT.MembersAllowedToTradeDataTable SearchMAT(
            string session, DateTime dateFrom, DateTime dateTo)
        {
            BE.MATT.MembersAllowedToTradeDataTable ret = new ECX.CD.BE.MATT.MembersAllowedToTradeDataTable();
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select *, Cast('00000000-0000-0000-0000-000000000000' As UniqueIdentifier) As MemberGuid " +
                "From   tblMembersAllowedToTrade " +
                "Where  Session Like @Session + '%' And " +
                        "TradeDate >= @TradeDateFrom And " +
                        "TradeDate <= @TradeDateTo ";

            command.Parameters.Add("@Session", SqlDbType.VarChar).Value = session;
            command.Parameters.Add("@TradeDateFrom", SqlDbType.DateTime).Value = dateFrom;
            command.Parameters.Add("@TradeDateTo", SqlDbType.DateTime).Value = dateTo;

            ret.Merge(ExecuteDT(command));
            return ret;
        }

        public bool MATAvailable(
            string session, DateTime dateFrom, DateTime dateTo)
        {
            SqlCommand command = new SqlCommand();

            command.CommandText =
                "Select Count(*) " +
                "From   tblMembersAllowedToTrade " +
                "Where  Session Like @Session + '%' And " +
                        "TradeDate >= @TradeDateFrom And " +
                        "TradeDate <= @TradeDateTo";

            command.Parameters.Add("@Session", SqlDbType.VarChar).Value = session;
            command.Parameters.Add("@TradeDateFrom", SqlDbType.DateTime).Value = dateFrom;
            command.Parameters.Add("@TradeDateTo", SqlDbType.DateTime).Value = dateTo;

            return ExecuteBoolean(command);
        }

        public List<Guid> GetClientIds(List<Guid> cgIds)
        {
            string filter = "";
            List<Guid> ret = new List<Guid>();
            SqlCommand command = new SqlCommand();
            DataTable dt;
            ECXLookup.ECXLookup elu = new ECX.CD.DA.ECXLookup.ECXLookup();
            List<Guid> membersWithPayinBalance = GetMembersWithPayInBalance();

            if (cgIds.Count == 0)
                return ret;

            #region Deposit
            filter = "'" + cgIds[0].ToString() + "'";
            for (int i = 1; i < cgIds.Count; i++)
            {
                filter += ", '" + cgIds[i].ToString() + "'";
            }

            command.CommandText =
                "Select Distinct ClientId " +
                "From tblWarehouseReciept " +
                "Where CommodityGradeId In(" + filter + ") And " +
                    "(TempQuantity > 0) AND  " +
                    "(SourceType In (Select Id From tblSourceType Where Name <> 'Trade')) And " +
                    "(WRStatusId = (Select Id From tblWarehouseRecieptStatus Where Name = 'Approved'))";

            dt = ExecuteDT(command);
            foreach (DataRow row in dt.Rows)
            {
                if(!ret.Contains(new Guid(row[0].ToString())))
                    ret.Add(new Guid(row[0].ToString()));
            }
            #endregion

            #region Trade
            if (elu.GetCommodityGrade(Common.EnglishGuid, cgIds[0]).CanWithdraw)
                filter = "'" + cgIds[0].ToString() + "'";
            for (int i = 1; i < cgIds.Count; i++)
            {
                //TODO:
                if(elu.GetCommodityGrade(Common.EnglishGuid, cgIds[i]).CanWithdraw)
                    if(filter != "")
                        filter += ", '" + cgIds[i].ToString() + "'";
                    else
                        filter += "'" + cgIds[i].ToString() + "'";
            }

            command = new SqlCommand();
            command.CommandText =
                "Select Distinct ClientId " +
                "From tblWarehouseReciept " +
                "Where CommodityGradeId In(" + filter + ") And " +
                    "(TempQuantity > 0) AND  " +
                "(SourceType = (Select Id From tblSourceType Where Name = 'Trade')) And " +
                    "(WRStatusId = (Select Id From tblWarehouseRecieptStatus Where Name = 'Approved'))";

            dt = ExecuteDT(command);
            foreach (DataRow row in dt.Rows)
            {
                if (!ret.Contains(new Guid(row[0].ToString())))
                    ret.Add(new Guid(row[0].ToString()));
            }
            #endregion

            foreach (Guid member in membersWithPayinBalance)
            {
                if (!ret.Contains(member))
                    ret.Add(member);
            }

            return ret;
        }

        public List<Guid> GetMembersWithPayInBalance()
        {
            SqlCommand command = new SqlCommand();
            List<Guid> ret = new List<Guid>();
            DataTable dt;

            command.CommandText =
                "SELECT DISTINCT tblBankAccount.MemberID " +
                "FROM   tblBankAccount INNER JOIN " +
                        "tblBankAccountTypes ON tblBankAccount.AccountTypeID = tblBankAccountTypes.ID " +
                "WHERE  (tblBankAccountTypes.TransactionType = 'I')  And (tblBankAccount.Balance > 0)";
            dt = ExecuteDT(command);

            foreach (DataRow row in dt.Rows)
            {
                if(!ret.Contains(new Guid(row[0].ToString())))
                    ret.Add(new Guid(row[0].ToString()));
            }

            return ret;
        }

        public DataTable GetMAT(List<Guid> mATIds)
        {
            SqlCommand command = new SqlCommand();
            string fb = Utilities.AppendInString("Id", mATIds);

            command.CommandText =
                "Select * " +
                "From tblMembersAllowedToTrade " +
                ((fb == "")?"":"Where " + fb);

            return ExecuteDT(command);
        }
    }
}