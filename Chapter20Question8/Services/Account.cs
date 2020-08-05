using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Chapter20Question8.Interfaces;

namespace Chapter20Question8.Services
{
    internal abstract class Account
    {
        protected ICustomer customer;
        protected string accountNumber;
        protected decimal balance;
        protected DateTime dateOpened;

        protected void SetAccountNumber()
        {
            Random rand = new Random();
            StringBuilder acctnum = new StringBuilder();
            for (int i = 0; i < 10; i++)
                acctnum.Append(rand.Next(9));
            accountNumber = Convert.ToString(acctnum);
        }
        protected void SetDateOpened()
        {
            dateOpened = DateTime.Now;
        }
        public DateTime DateOpened
        {
            get
            { return dateOpened; }

        }
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public string Name
        {
            get
            {
                Console.WriteLine("trying to get account Name");
                return $"{customer.Name}";
            }
        }
        public int CustomerAge
        {
            get { return Convert.ToInt32(customer.Age); }

        }

        public abstract decimal Credit(decimal amt);
        public abstract string GetAccountInfo();
    }
}
