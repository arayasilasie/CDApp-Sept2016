using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ECX.CD.BL
{
    public enum TransactionTypes
    {
        EditWHR,
        CancelWHR,
        CancelPUN,
        ApproveWHR,
        ViewWHR,
        AddNewBankAccount,
        SuspendBankAccount,
        CloseBankAccount,
        ResumeBankAccount
    }

    public class Workflow
    {
        public bool OpenTransaction(TransactionTypes transactionType, Guid userId, string ojbectId)
        {
            ECXEngine.ECXEngine engine = new ECXEngine.ECXEngine();
            Guid transactionTypeGuid = GetTransactionTypeId(transactionType);
            string[] locationCodes = new string[] { };
            string transactionNo;

            ECXEngine.CMessage[] m = engine.OpenTransaction(transactionTypeGuid, userId, locationCodes, "", out transactionNo);

            SaveTransaction(transactionTypeGuid, ojbectId, transactionNo);

            return true;
        }

        public Guid GetTransactionTypeId(TransactionTypes transactionTypes)
        {
            switch (transactionTypes)
            {
                case TransactionTypes.AddNewBankAccount:
                    return Properties.Settings.Default.AddNewBankAccountTransType;
                case TransactionTypes.SuspendBankAccount:
                    return Properties.Settings.Default.SuspendBankAccountTransType;
                case TransactionTypes.CloseBankAccount:
                    return Properties.Settings.Default.CloseBankAccountTransType;
                case TransactionTypes.ResumeBankAccount:
                    return Properties.Settings.Default.ResumeBankAccountTransType;
                default:
                    return Guid.Empty;
            }
        }

        public void SaveTransaction(Guid transactionTypeId, string objectId, string transactionNumber)
        {
            new DA.Transaction().SaveTransaction(transactionTypeId, objectId, transactionNumber);
        }

        public bool StepCompleted(string objectId, Guid userId)
        {
            ECXEngine.ECXEngine engine = new ECXEngine.ECXEngine();

            string transactionNo = new DA.Transaction().GetTransactionNumber(objectId);
            ECXEngine.CMessage[] m = engine.Request(transactionNo, userId, new string[] { });

            if (m.Length > 0)
            {
                m[0].IsCompleted = true;

                engine.Response(transactionNo, m[0]);
                UnlockTask(transactionNo);

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
