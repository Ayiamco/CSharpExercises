using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter20Question8.Interfaces;
using Chapter20Question8.Services;

namespace Chapter20Question8.Helpers
{
    static class Notification
    {

        internal static void NewAccount(IAccount acct)
        {
            if (acct is DepositAccount)
            {
                Console.WriteLine($"\n\t\tNotification: New Deposit Account creation");
                Console.WriteLine(acct.GetAccountInfo());
                Console.WriteLine("----------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"\n\t\tNotification: New Loan Account created");
                Console.WriteLine(acct.GetAccountInfo());
                Console.WriteLine("----------------------------------------------------------------");
            }
        }
        internal static void Debit(DepositAccount acct, decimal amt)
        {
            string last4digits = "";
            for (int i = 6; i < acct.AccountNumber.Length; i++)
                last4digits += acct.AccountNumber[i];

            Console.WriteLine($"\n\t\tNotification: Cash Transfer/Withdrawal from account ");
            Console.WriteLine($"Name: {acct.Name} , Acct Num:...{last4digits}");
            Console.WriteLine($"New Balance: {acct.Balance}, Date: {DateTime.Now}");
            Console.WriteLine("----------------------------------------------------------------");
        }

        internal static void Credit(IAccount acct, decimal amt, params IAccount[] sender)
        {
            string last4digits = "";
            for (int i = 6; i < acct.AccountNumber.Length; i++)
                last4digits += acct.AccountNumber[i];
            if (sender.Count() > 0)
            {
                Console.WriteLine($"Notification: Cash Deposit/recipient of {amt} " +
                   $"from {sender[0].Name} ");
                Console.WriteLine($"Name: {acct.Name} , Acct Num:...{last4digits}");
                Console.WriteLine($"New Balance: {acct.Balance}, Date: {DateTime.Now}");
                Console.WriteLine("______________________________________________________________\n");
            }
            else
            {
                Console.WriteLine($"Notification Simulation: Cash Deposit/recipient of {amt} ");
                Console.WriteLine($"Name: {acct.Name} , Acct Num:...{last4digits}");
                Console.WriteLine($"New Balance: {acct.Balance}, Date: {DateTime.Now}");
                Console.WriteLine("______________________________________________________________\n");
            }
        }





    }
}
