using System;
using System.Collections.Generic;
using System.Text;
using Chapter20Question8.Helpers;
using Chapter20Question8.Interfaces;

namespace Chapter20Question8.Services
{
    class DepositAccount : Account, IAccount
    {
        // 
        DateTime LastWithdrawalDate;

        DepositAccountType type;
        internal DepositAccount(ICustomer customer, DepositAccountType type, decimal startBalance = 0)
        {
            if (customer is CompanyCustomer && type == DepositAccountType.Student)
            {
                Exception e = new Exception("Company Account Cannot Open a Student Account");
                throw e;
            }
            else
            {
                if (Utility.IsValidStartBalance(type, startBalance))
                {
                    Balance = startBalance;
                    this.type = type;
                    SetDateOpened();
                    SetAccountNumber();
                    this.customer = customer;
                }
                else
                {
                    Exception e = new Exception($"Invalid StartBalance: {startBalance} is less than {type} account " +
                        $"minimum balance of {(int)type}");
                    throw e;
                }

            }
        }

        //
        // Summary:
        //     Gets the number of characters in the current System.String object.
        //
        // Returns:
        //     The number of characters in the current string.
        internal DepositAccountType GetAccountType()
        {

            return this.type;
        }

        public override string GetAccountInfo()
        {
            if (customer is CompanyCustomer compCust)
            {
                string return_string = $" Name: {compCust.Name},  Account Type: {type},  DateOpened:{dateOpened}\n" +
                $"Balance: {balance}, Account Number: { accountNumber} Industry:{compCust.industry}";
                return return_string;
            }
            else
            {
                string return_string = $" Name: {customer.Name},  Account Type: {type},  DateOpened:{dateOpened}\n" +
                $"Balance: {balance}, Account Number: { accountNumber}";
                return return_string;
            }


        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < (int)this.type)
                {
                    throw new ArgumentException($"Start Balance  of {value} is less than minimum required for " + type + " account");
                }
                else
                {
                    balance = value;
                }
            }
        }

        public decimal Debit(decimal amt)
        {//remove money from account
            if (amt < balance - (decimal)this.GetAccountType())
            {
                balance = balance - amt;
                LastWithdrawalDate = DateTime.Now;
                return balance;
            }
            else
            {
                Exception e = new Exception($"Insufficient Fund Error: \nBalance: {balance} ," +
                    $" Withdrawable Balance{balance - (decimal)this.GetAccountType()} ");
                throw e;
            }
        }

        public override decimal Credit(decimal amt)
        {//Add money to account
            if (amt > 100000 && this.type == DepositAccountType.Savings)
            {
                Console.WriteLine($"{type} account cannot take amount upto {amt} Naira.");
                Console.WriteLine($"Please open a {DepositAccountType.Current} acount");
                return balance;
            }
            else if (amt > 50000 && this.type == DepositAccountType.Student)
            {
                Console.WriteLine($"{type} account cannot take amount upto {amt} Naira.");
                if (amt > 100000 && this.type == DepositAccountType.Savings)
                {
                    Console.WriteLine($"Please open a {DepositAccountType.Current} acount");
                }
                else
                {
                    Console.WriteLine($"Please open a {DepositAccountType.Savings} or {DepositAccountType.Current} acount");
                }
                return balance;
            }
            else
            {
                balance = balance + amt;
                return balance;
            }
        }


    }
    public enum DepositAccountType
    {
        Student = 0, Savings = 1000, Current = 10000
    }
}

