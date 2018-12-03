using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ECX.CD.DA
{
    public class BankAccount : SQLHelper
    {
        public ECX.CD.BE.BankAccount.tblBankAccountDataTable GetBankAccounts(Guid memberGuid)
        {
            string commandText = " SELECT ID, Status, AccountTypeID, Balance, BankBranchID " +
                                " FROM   tblBankAccount " +
                                " WHERE  (MemberID = @MemberID) ";

            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@MemberID", memberGuid);

            ECX.CD.BE.BankAccount.tblBankAccountDataTable list = new ECX.CD.BE.BankAccount.tblBankAccountDataTable();
            list.Merge(ExecuteDT(command));

            return list;
        }
        public static DataTable GetBankAccountsView(Guid memberGuid)
        {
            string commandText = "SELECT     ClientId, '' as ClientIDNO, '' as ClientName, tblBankAccountTypes.Name AS AccountType, BankBranchId, '' as Bank, '' as BankBranch, AccountNumber, tblBankAccount.Balance   " +
                                "FROM         tblBankAccount INNER JOIN   " +
                                "                      tblBankAccountTypes ON tblBankAccount.AccountTypeID = tblBankAccountTypes.ID   " +
                                "WHERE     (tblBankAccount.Status = 1) AND (tblBankAccountTypes.Status = 1) AND (tblBankAccountTypes.TransactionType = 'I') AND MemberID = @MemberID   " +
                                "ORDER BY ClientId, tblBankAccountTypes.Name DESC ";

            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@MemberID", memberGuid);

            DataTable list = new DataTable();
            list.Merge(new SQLHelper().ExecuteDT(command));

            return list;
        }

        public bool IsTransactionOpen(Guid transactionType, Guid bankAccountID)
        {
            string commandText = " SELECT COUNT(*) " +
                                " FROM   tblBankAccountTransaction " +
                                " WHERE  (TransactionTypeId = @TransactionTypeId) AND (BankAccountId = @BankAccountId) AND IsClosed = 0";

            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@TransactionTypeId", transactionType);
            command.Parameters.AddWithValue("@BankAccountId", bankAccountID);

            int result = ExecuteInt(command);

            //if the record does not exist it is assumed to be closed.
            return (result > 0);
        }

        public bool SaveTransaction(Guid transactionType, Guid bankAccountID, string transactionNo)
        {
            string commandText = "spBankAccountTransaction_Insert";
            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@TransactionTypeId", transactionType);
            command.Parameters.AddWithValue("@BankAccountId", bankAccountID);
            command.Parameters.AddWithValue("@TransactionNo", transactionNo);

            int recordsAffected = ExecuteNonQuerySP(commandText, command);

            //if the record does not exist it is assumed to be closed.
            if (recordsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveMemberTransaction(Guid transactionType, Guid memberId, string transactionNumber)
        {
            string commandText = "spMemberTransaction_Insert";
            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@TransactionTypeId", transactionType);
            command.Parameters.AddWithValue("@MemberId", memberId);
            command.Parameters.AddWithValue("@TransactionNo", transactionNumber);
            command.Parameters.AddWithValue("@MembershipTransactionNo", "");

            int recordsAffected = ExecuteIntSP(commandText, command);

            if (recordsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AccountExists(Guid memberId, Guid accountTypeId, byte statusId)
        {
            string commandText = " SELECT Count(*) ";
            commandText += "       FROM   tblBankAccount ";
            commandText += "       WHERE  (MemberID = @MemberID) AND (AccountTypeID = @AccountTypeID) AND (Status = @Status) ";

            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@MemberID", memberId);
            command.Parameters.AddWithValue("@AccountTypeID", accountTypeId);
            command.Parameters.AddWithValue("@Status", statusId);

            object result = ExecuteScalar(command);

            if (result == null)
            {
                return false;
            }
            else
            {
                if (Convert.ToInt32(result) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool ClientAccountExists(Guid clientId, byte statusId)
        {
            string commandText = " SELECT Count(*) ";
            commandText += "       FROM   tblBankAccount ";
            commandText += "       WHERE  (ClientId = @ClientId) AND (Status = @Status) ";

            SqlCommand command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@ClientId", clientId);
            command.Parameters.AddWithValue("@Status", statusId);

            object result = ExecuteScalar(command);

            if (result == null)
            {
                return false;
            }
            else
            {
                if (Convert.ToInt32(result) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
