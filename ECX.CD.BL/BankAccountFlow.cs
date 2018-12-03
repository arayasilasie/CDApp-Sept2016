using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECX.CD.BL.ECXEngine;

namespace ECX.CD.BL
{
    class BankAccountFlow
    {
        public static bool CanOpenTransaction(TransactionTypes transactionType, Guid bankAccountID)
        {
            return !new DA.BankAccount().IsTransactionOpen(new Workflow().GetTransactionTypeId(transactionType), bankAccountID);
        }
        public static bool SaveTransaction(Guid transactionType, Guid bankAccountID, string transactionNumber)
        {
            return new DA.BankAccount().SaveTransaction(transactionType, bankAccountID, transactionNumber);
        }
        public static bool SaveMemberTransaction(TransactionTypes transactionType, Guid memberId, string transactionNumber)
        {
            Guid transactionTypeId = new Workflow().GetTransactionTypeId(transactionType);
            return new DA.BankAccount().SaveMemberTransaction(transactionTypeId, memberId, transactionNumber);
        }
        public static bool OpenTransaction(TransactionTypes transactionType, out string transactionNo, Guid UserGuid)
        {
            ECXEngine.ECXEngine engine = new ECXEngine.ECXEngine();
            Guid transactionTypeGuid = new Workflow().GetTransactionTypeId(transactionType);
            string[] locationCodes = new string[] { };

            CMessage[] m = engine.OpenTransaction(transactionTypeGuid, UserGuid, locationCodes, "", out transactionNo);
            return true;
        }
        public static bool StepCompleted(string transactionNumber, Guid userGuid)
        {
            ECXEngine.ECXEngine engine = new ECXEngine.ECXEngine();
            if (transactionNumber == null)
            {
                return false;
            }
            string[] locationCodes = new string[] { };
            CMessage[] m = engine.Request(transactionNumber, userGuid, locationCodes);
            if (m.Length > 0)
            {
                m[0].IsCompleted = true;
                engine.Response(transactionNumber, m[0]);
                UnlockTask(transactionNumber);
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool UnlockTask(string transNo)
        {
            ECXEngine.ECXEngine engine = new ECXEngine.ECXEngine();
            if (transNo == null)
            {
                return false;
            }
            engine.UnlockTask(transNo);

            return true;
        }


    }
}
