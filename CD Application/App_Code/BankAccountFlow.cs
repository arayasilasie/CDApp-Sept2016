using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ECX.CD.WorkFlow;

namespace ECX.CD.WorkFlow
{

    /// <summary>
    /// Summary description for BankAccountFlow
    /// </summary>
    public class BankAccountFlow
    {
        public BankAccountFlow()
        {
        }

        public static Guid GetBankAccountID(string transactionNo)
        {
            MainDataContextDataContext db = new MainDataContextDataContext();

            var trans = from transactions in db.tblBankAccountTransactions
                        where transactions.TransactionNo == transactionNo
                        select transactions.BankAccountId;

            return trans.FirstOrDefault();
        }
        public static string GetTransactionNo(TransactionTypes transactionType, Guid bankAccountID, bool openTransactionOnly)
        {
            MainDataContextDataContext db = new MainDataContextDataContext();

            var trans = from transactions in db.tblBankAccountTransactions
                        where transactions.BankAccountId == bankAccountID &&
                                transactions.TransactionTypeId == WorkFlow.GetTransactionTypeId(transactionType) &&
                                transactions.IsClosed != openTransactionOnly
                        select transactions.TransactionNo;

            return trans.FirstOrDefault();
        }
        public static bool CanOpenTransaction(TransactionTypes transactionType, Guid bankAccountID)
        {
            MainDataContextDataContext db = new MainDataContextDataContext();

            var trans = from transactions in db.tblBankAccountTransactions
                        where transactions.BankAccountId == bankAccountID &&
                        transactions.TransactionTypeId == WorkFlow.GetTransactionTypeId(transactionType) &&
                        transactions.IsClosed == false
                        select transactions;

            if (trans.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CloseLocalTransaction(string transactionNo)
        {
            MainDataContextDataContext db = new MainDataContextDataContext();

            var bat = from trans in db.tblBankAccountTransactions
                      where trans.TransactionNo == transactionNo
                      select trans;

            if (bat.Count() > 0)
            {
                bat.First().IsClosed = true;

                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
