using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ECX.CD.DA
{
    public class Transaction:SQLHelper
    {
        public void SaveTransaction(Guid transactionTypeId, string objectId, string transactionNumber)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("TransactionTypeId", System.Data.SqlDbType.UniqueIdentifier).Value = transactionTypeId;
            command.Parameters.Add("ObjectId", System.Data.SqlDbType.VarChar).Value = objectId;
            command.Parameters.Add("TransactionNumber", System.Data.SqlDbType.VarChar).Value = transactionNumber;
            
            ExecuteNonQuerySP("spSaveTransaction", command);
        }

        public string GetTransactionNumber(string objectId)
        {
            SqlCommand command = new SqlCommand();
            
            command.CommandText = "Select TransactionNo From tblTransaction Where ObjectId = @ObjectId";

            command.Parameters.Add("ObjectId", System.Data.SqlDbType.VarChar).Value = objectId;

            return ExecuteString(command);
        }
    }
}
