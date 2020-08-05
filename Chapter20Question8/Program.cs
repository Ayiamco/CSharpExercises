using System;
using System.Collections.Generic;
using Chapter20Question8.Helpers;
using Chapter20Question8.Interfaces;
using Chapter20Question8.Services;

namespace Chapter20Question8
{
    class Program
    {
        static void Main(string[] args)
        {

            Bank myBank = new Bank("Access bank");
            List<IAccount> accts = CreateDummyAccounts();
            foreach (IAccount acct in accts)
            {
                myBank.AddNewAccount(acct, isCashier: false);
            }
            Console.WriteLine($"\t\t Hi, Welcome To { myBank.Name}");
            Console.WriteLine("\t\t##########################################");
            Console.WriteLine($"\n\t\tAccounts in bank:");
            List<string> keyList = new List<string>(myBank.bankAccountList);
            foreach (string acct in keyList)
            {
                Console.WriteLine(myBank.bankDatabase[acct].GetAccountInfo());
                Console.WriteLine("-----------------------------------------------------------------------");
            }
            Cashier.StartWork(myBank);
            ICustomer cust11 = new PersonCustomer("Mr", "Emma", "Okon", "04/04/1995", Gender.Female, "10 dhckbjkhk");
            ICustomer cust1 = new PersonCustomer("Prof Mrs", "Joy", "Okon", "04/04/1995", Gender.Male, "10 djkhk");
            ICustomer cust2 = new PersonCustomer("Engr ", "David", "Ubong", "04/04/1995", Gender.Female, "12 djkhk");
            ICustomer cust3 = new CompanyCustomer("Real Estate", "Tenece", "10/10/1990", "12347", "Enugu", CompanyStatus.Public);
            ICustomer cust4 = new CompanyCustomer("Tech", "Genesys", "10/10/2010", "12347", "Enugu", CompanyStatus.Private);

            //Dictionary<ICustomer, int> newDict = new Dictionary<ICustomer, int>(5);
            //newDict.Add(cust11,1);
            //newDict.Add(cust1,2);
            //newDict.Add(cust2,3);
            //newDict.Add(cust3,4);
            //newDict.Add(cust4,5);
            





        }

        static List<IAccount> CreateDummyAccounts()
        {

            ICustomer cust11 = new PersonCustomer("Mr", "Emma", "Okon", "04/04/1995", Gender.Female, "10 dhckbjkhk");
            ICustomer cust1 = new PersonCustomer("Prof Mrs", "Joy", "Okon", "04/04/1995", Gender.Male, "10 djkhk");
            ICustomer cust2 = new PersonCustomer("Engr ", "David", "Ubong", "04/04/1995", Gender.Female, "12 djkhk");
            ICustomer cust3 = new CompanyCustomer("Real Estate", "Tenece", "10/10/1990", "12347", "Enugu", CompanyStatus.Public);
            ICustomer cust4 = new CompanyCustomer("Tech", "Genesys", "10/10/2010", "12347", "Enugu", CompanyStatus.Private);


            DepositAccount new1 = new DepositAccount(cust1, DepositAccountType.Student, startBalance: 1000);
            DepositAccount new2 = new DepositAccount(cust2, DepositAccountType.Savings, startBalance: 15000);
            DepositAccount new3 = new DepositAccount(cust3, DepositAccountType.Current, startBalance: 100000);
            LoanAccount new4 = new LoanAccount(cust4, 506400, 20);
            DepositAccount new9 = new DepositAccount(cust11, DepositAccountType.Savings, startBalance: 15000);

            List<IAccount> bankaccts = new List<IAccount>() { new1, new2, new3, new4, new9 };
            return bankaccts;
        }
    }


}



