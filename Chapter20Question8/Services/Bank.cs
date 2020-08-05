using System;
using System.Collections.Generic;
using System.Text;
using Chapter20Question8.Helpers;
using Chapter20Question8.Interfaces;

namespace Chapter20Question8.Services
{
    class Bank
    {
        public List<string> bankAccountList = new List<string>();
        public Dictionary<string, IAccount> bankDatabase = new Dictionary<string, IAccount>();
        static long savingsAccountCount = 0;
        static long studentAccountCount = 0;
        static long currentAccountCount = 0;
        static long LoanAccountCount = 0;
        private decimal bankCurrentBalance = 100000000;
        internal string Name = "";

        public Bank(string name)
        {
            Name = name;
        }
        internal void AddNewAccount(IAccount bankAcct, bool isCashier = true)
        {
            //Add new accounts to bank object
            bankAccountList.Add(bankAcct.AccountNumber);
            bankDatabase.Add(bankAcct.AccountNumber, bankAcct);

            if (bankAcct is DepositAccount depositAcct)
            {
                bankCurrentBalance = bankCurrentBalance + bankAcct.Balance;
                switch ((int)depositAcct.GetAccountType())
                {
                    case 0:
                        studentAccountCount++;
                        break;
                    case 1000:
                        savingsAccountCount++;
                        break;
                    case 10000:
                        currentAccountCount++;
                        break;
                }

            }
            else
            //new loan account make withdrawals from bank:
            {
                bankCurrentBalance = bankCurrentBalance - bankAcct.Balance;
                LoanAccountCount++;
            }
            if (isCashier)
                Notification.NewAccount(bankAcct);
        }
        internal void Summary()
        {
            Console.WriteLine($"Bank Name: {Name}\n" +
                $"savingsAccountCount: {savingsAccountCount}  studentAccountCount:{studentAccountCount}\n" +
            $"currentAccountCount: {currentAccountCount}  " +
           $"LoanAccountCount: {LoanAccountCount}\n" +
           $"bankCurrentBalance: {bankCurrentBalance}");
        }

        internal decimal AddToAccount(string AcctNumber, decimal amt)
        {
            decimal newBalance = 0;
            IAccount acct = bankDatabase[AcctNumber];
            newBalance = acct.Credit(amt);
            Notification.Credit(bankDatabase[AcctNumber], amt);
            return newBalance;
        }

        internal decimal WithdrawFromAccount(string AcctNumber, decimal amt)
        {
            IAccount acct = bankDatabase[AcctNumber];
            //Loan Accounts can't be withdrawsn from
            if (acct is LoanAccount)
            {
                Exception e = new Exception("Loan Account Exception: Loan Accounts can't be withdrawsn from");
                throw e;
            }
            else
            {

                DepositAccount acctDeposit = (DepositAccount)acct;
                decimal newBalance = acctDeposit.Debit(amt);
                Notification.Debit(acctDeposit, amt);
                return newBalance;
            }

        }

        internal bool TransferCash(IAccount sender, IAccount receiver, decimal amt)
        {
            decimal senderBalance = this.WithdrawFromAccount(sender.AccountNumber, amt);
            Notification.Debit((DepositAccount)sender, amt);

            decimal receiverBalance = this.AddToAccount(receiver.AccountNumber, amt);
            Notification.Credit((DepositAccount)receiver, amt, sender);
            return true;
        }

    }
}
