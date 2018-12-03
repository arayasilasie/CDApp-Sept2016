using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECX.CD.BL.Security;
using System.Data;
using ECX.CD.BL.ECXLookup;

namespace ECX.CD.BL
{
    public class BankAccount
    {

        public static bool ClientHasOpenAccounts(Guid clientGuid)
        {
            byte openAccountStatusCode = new Lookup().GetLookupId("tblBankAccountStatus", "Open");

            DA.BankAccount account = new ECX.CD.DA.BankAccount();

            return account.ClientAccountExists(clientGuid, openAccountStatusCode);
        }
        public static DataTable GetBankAccountsView(Guid memberGuid)
        {
            DataTable tblBankAccount = ECX.CD.DA.BankAccount.GetBankAccountsView(memberGuid);
            ECXMembership.MemberShipLookUp membershipLookup = new ECXMembership.MemberShipLookUp();
            ECXLookup.ECXLookup lookup = new ECXLookup.ECXLookup();


            foreach (DataRow row in tblBankAccount.Rows)
            {
                if (row["ClientId"] is Guid)
                {
                    Guid clientId = new Guid(row["ClientId"].ToString());
                    
                    ECXMembership.Client client = new ECXMembership.MemberShipLookUp().GetClient(clientId);

                    row["ClientName"] = client.Name;
                    row["ClientIDNO"] = client.IdNo;
                }
                else
                {
                    row["ClientName"] = "-";
                }

                if (row["BankBranchId"] is Guid)
                {
                    Guid bankBranchId = new Guid(row["BankBranchId"].ToString());
                    CBankBranch bankBranch = lookup.GetBankBranch(Common.EnglishGuid, bankBranchId);

                    row["BankBranch"] = bankBranch.Name;
                    row["Bank"] = lookup.GetBank(Common.EnglishGuid, bankBranch.BankUniqueIdentifier).BankShortName;
                }
            }

            tblBankAccount.TableName = "tblBankAccounts";            
            DataView tblBankAccountView = tblBankAccount.AsDataView();
            tblBankAccountView.Sort = "ClientName, Bank";
            tblBankAccount = tblBankAccountView.ToTable();

            return tblBankAccount;
        }
        public static bool StartClosureTransaction(Guid memberGuid, Guid userGuid)
        {
            if (memberGuid != Guid.Empty)
            {
                //get bank accounts for the member
                BE.BankAccount.tblBankAccountDataTable bankAccounts = new ECX.CD.DA.BankAccount().GetBankAccounts(memberGuid);
                byte bankAccountClosedStatusCode = new DA.Lookup().GetLookupId("tblBankAccountStatus", "Closed");

                //for each bank account 
                //  check if transaction can be opnened
                //  open transaction
                foreach (BE.BankAccount.tblBankAccountRow row in bankAccounts)
                {
                    if (row.Status != bankAccountClosedStatusCode)
                    {
                        if (BankAccountFlow.CanOpenTransaction(TransactionTypes.CloseBankAccount, row.ID))
                        {
                            string bankAccountStatus = new DA.Lookup().GetLookupName("tblBankAccountStatus", row.Status);
                            string oldValue = "BankAccountID = " + row.ID.ToString() + "; " + "Status = " + bankAccountStatus;
                            string newValue = "BankAccountID = " + row.ID.ToString() + "; " + "Status = " + "Closed";
                            AuditTrail at = new AuditTrail(AuditTrailModules.CDRequestAccountClosure, oldValue, newValue, userGuid);

                            if (at.Save())
                            {
                                if (BankAccount.RequestBankAccountClosure(row.ID, userGuid))
                                {
                                    at.Commit();
                                }
                                else
                                {
                                    at.RollBack();
                                    throw new InvalidOperationException("Bank account closure request not started.");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("Audit trail saving failed.");
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        static bool RequestBankAccountClosure(Guid bankAccountID, Guid userGuid)
        {
            bool done = false;
            string transactionNo = "";

            using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
            {
                if (ECX.CD.BL.BankAccountFlow.OpenTransaction(ECX.CD.BL.TransactionTypes.CloseBankAccount, out transactionNo, userGuid))
                {
                    if (ECX.CD.BL.BankAccountFlow.StepCompleted(transactionNo, userGuid))
                    {
                        Guid transactionTypeId = new ECX.CD.BL.Workflow().GetTransactionTypeId(ECX.CD.BL.TransactionTypes.CloseBankAccount);
                        BankAccountFlow.SaveTransaction(transactionTypeId, bankAccountID, transactionNo);

                        done = true;
                        scope.Complete();
                    }
                }
            }
            return done;
        }

        public static bool StartSuspensionTransaction(Guid memberGuid, Guid userGuid)
        {
            if (memberGuid != Guid.Empty)
            {
                //get bank accounts for the member
                BE.BankAccount.tblBankAccountDataTable bankAccounts = new ECX.CD.DA.BankAccount().GetBankAccounts(memberGuid);

                //for each bank account 
                //  check if transaction can be opnened
                //  open transaction
                foreach (BE.BankAccount.tblBankAccountRow row in bankAccounts)
                {
                    byte bankAccountClosedStatusCode = new DA.Lookup().GetLookupId("tblBankAccountStatus", "Closed");

                    if (row.Status != bankAccountClosedStatusCode)
                    {
                        if (BankAccountFlow.CanOpenTransaction(TransactionTypes.SuspendBankAccount, row.ID))
                        {
                            string bankAccountStatus = new DA.Lookup().GetLookupName("tblBankAccountStatus", row.Status);
                            string oldValue = "BankAccountID = " + row.ID.ToString() + "; " + "Status = " + bankAccountStatus;
                            string newValue = "BankAccountID = " + row.ID.ToString() + "; " + "Status = " + "Closed";
                            AuditTrail at = new AuditTrail(AuditTrailModules.CDRequestAccountSuspension, oldValue, newValue);

                            if (at.Save())
                            {
                                if (BankAccount.RequestBankAccountSuspension(row.ID, userGuid))
                                {
                                    at.Commit();
                                }
                                else
                                {
                                    at.RollBack();
                                    throw new InvalidOperationException("Bank account suspension request not started.");
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException("Audit trail saving failed.");
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        static bool RequestBankAccountSuspension(Guid bankAccountID, Guid userGuid)
        {
            bool done = false;
            string transactionNo = "";

            using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
            {
                if (ECX.CD.BL.BankAccountFlow.OpenTransaction(ECX.CD.BL.TransactionTypes.SuspendBankAccount, out transactionNo, userGuid))
                {
                    if (ECX.CD.BL.BankAccountFlow.StepCompleted(transactionNo, userGuid))
                    {
                        Guid transactionTypeId = new ECX.CD.BL.Workflow().GetTransactionTypeId(ECX.CD.BL.TransactionTypes.SuspendBankAccount);
                        BankAccountFlow.SaveTransaction(transactionTypeId, bankAccountID, transactionNo);

                        done = true;
                        scope.Complete();
                    }
                }
            }
            return done;
        }

        public static void StartAddAccountTransaction(Guid memberGuid, Guid userGuid)
        {
            if (memberGuid == Guid.Empty)
            {
                throw new InvalidOperationException("Member Guid cannot be empty");
            }
            else
            {
                string transNo = null;
                BankAccountFlow.OpenTransaction(TransactionTypes.AddNewBankAccount, out transNo, userGuid);
                BankAccountFlow.StepCompleted(transNo, userGuid);
                BankAccountFlow.SaveMemberTransaction(TransactionTypes.AddNewBankAccount, memberGuid, transNo);
            }
        }

        public static bool HasClearingAccounts(Guid memberGuid)
        {
            if (memberGuid == Guid.Empty)
            {
                throw new InvalidOperationException("Member Guid cannot be empty");
            }
            else
            {
                byte openAccountStatusCode = new Lookup().GetLookupId("tblBankAccountStatus", "Open");

                DA.BankAccount account = new ECX.CD.DA.BankAccount();

                bool clearingPayInExists = account.AccountExists(memberGuid, Properties.Settings.Default.ClearingPayInGuid, openAccountStatusCode);
                bool clearingPayOutExists = account.AccountExists(memberGuid, Properties.Settings.Default.ClearingPayOutGuid, openAccountStatusCode);

                if (clearingPayInExists && clearingPayOutExists)
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
