using System;
using System.Collections.Generic;
using Chapter20Question8.Services;
using Chapter20Question8.Interfaces;

namespace Chapter20Question8.Helpers

{
    public static class Cashier
    {
        static ICustomer cust11 = new PersonCustomer("Mr", "Emma", "Okon", "04/04/1995", Gender.Female, "10 dhckbjkhk");
        static ICustomer cust3 = new CompanyCustomer("Real Estate", "Tenece", "10/10/1990", "12347", "Enugu", CompanyStatus.Public);

        private static CompanyStatus GetCustomerType()
        {
            Console.WriteLine("\nWhat best describes You: \n1.Single Individual\n2.Private Company\n3.Public Company ");
            Console.Write("Reply 1,2 or 3: ");
            string customerClass = Console.ReadLine();
            CompanyStatus var_ = customerClass == "1" ? CompanyStatus.Person :
                customerClass == "2" ? CompanyStatus.Private :
                customerClass == "3" ? CompanyStatus.Public :
                CompanyStatus.Invalid;
            return var_;
        }
        private static ICustomer GenerateNewCustomer(CompanyStatus customerStatus)
        {
            List<string> title = new List<string>() { "Chief", "Prof", "Barr.", "Engr.", "Pastor", "Chef" };
            List<string> name = new List<string>() { "Ayo", "Okon", "Ike", "Chima", "Vera", "Bliss" };
            List<string> company = new List<string>() { "Dangote Ltd", "Facebook Inc.", "IBM Corp.", "Ayiam Ltd", "Andela Comms.", "Ayo Farms Ltd" };
            List<string> industry = new List<string>() {"Finance","Education","Real Estate",
                "Chemicals","Construction","Commuinications" };
            List<string> date = new List<string>() { "04/10/1989", "06/09/1955", "01/03/1964", "01/10/1960", "06/02/1981", "01/03/1990" };
            List<Gender> gender = new List<Gender>() {Gender.Male,Gender.Female, Gender.Male,
                Gender.Female,Gender.Male, Gender.Female };
            Random rand = new Random();
            if (customerStatus == CompanyStatus.Person)
                return new PersonCustomer(title[rand.Next(6)], name[rand.Next(6)],
                    name[rand.Next(6)], date[rand.Next(6)], gender[rand.Next(6)], "Nigeria");
            else if (customerStatus == CompanyStatus.Private || customerStatus == CompanyStatus.Public)
                return new CompanyCustomer(industry[rand.Next(6)], company[rand.Next(6)],
                    date[rand.Next(6)], "12345", "Nigeria", customerStatus);
            else
                throw new ArgumentException("Invalid Selection");
        }


        internal static void CreateAccount(Bank mybank)
        {
            Console.WriteLine("\nSelect Account type:\n1. Loan Account,  2.Deposit Account");
            Console.Write("Your Reply: ");
            string option = Console.ReadLine();
            ICustomer newCustomer; decimal startAmt;
            switch (Convert.ToInt32(option))
            {
                case 1:
                    Console.Write("Enter Amount: ");
                    startAmt = Utility.GetDecimal(Console.ReadLine());
                    Console.WriteLine("Enter Loan Duration (greater than 3): ");
                    int duration = Convert.ToInt32(Console.ReadLine());
                    newCustomer = GenerateNewCustomer(GetCustomerType());
                    LoanAccount acct = new LoanAccount(newCustomer, startAmt, duration);
                    mybank.AddNewAccount(acct);
                    break;
                case 2:
                    Console.Write("Enter Amount: ");
                    startAmt = Utility.GetDecimal(Console.ReadLine());
                    Console.Write("Choose your Deposit Account Type\n Reply with Student,Savings or Current:  ");
                    DepositAccountType acctType = Utility.GetDepositAccountType(Console.ReadLine());
                    newCustomer = GenerateNewCustomer(GetCustomerType());
                    DepositAccount acctDep = new DepositAccount(newCustomer, acctType, startBalance: startAmt);
                    mybank.AddNewAccount(acctDep);
                    break;
                default:
                    throw new ArgumentException("Invalid Account type entered.");

            }
        }

        internal static void StartWork(Bank mybank)
        {

            while (true)
            {

                Console.WriteLine($"\n\nWelcome to {mybank.Name}, How can I help you? ");
                Console.WriteLine("Choose your option:");
                Console.WriteLine("1. Create New Dummy Account");
                Console.WriteLine("2. Withdraw from account");
                Console.WriteLine("3. Send money to Another Account");
                Console.WriteLine("4. Deposit money ");
                Console.WriteLine("5. Check Account Info ");
                Console.Write("Enter your option: ");
                int option;
                while (true)
                {
                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option > 5 || option < 1)
                        {
                            Console.WriteLine("Error: Enter a valid option");
                            continue;
                        }
                        break;
                    }
                    catch { Console.WriteLine("Error: Enter a valid option"); }

                }
                decimal amt;
                switch (option)
                {
                    case 1:
                        Cashier.CreateAccount(mybank);
                        break;
                    case 2:
                        Console.Write("Enter Account number:");
                        string acctNum = Console.ReadLine();
                        Console.Write("Enter Amount:");
                        amt = Utility.GetDecimal(Console.ReadLine());
                        mybank.WithdrawFromAccount(acctNum, amt);
                        break;
                    case 3:
                        Console.Write("Enter Sender Account Number:");
                        string senderAcctNum = Console.ReadLine();
                        Console.Write("Enter Reciever Account Number:");
                        string receiverAcctNum = Console.ReadLine();
                        Console.Write("Enter Amount:");
                        amt = Utility.GetDecimal(Console.ReadLine());
                        mybank.TransferCash(mybank.bankDatabase[senderAcctNum], mybank.bankDatabase[receiverAcctNum], amt);
                        break;
                    case 4:
                        Console.Write("Enter Account number:");
                        string acctNum1 = Console.ReadLine();
                        Console.Write("Enter Amount:");
                        amt = Utility.GetDecimal(Console.ReadLine());
                        mybank.AddToAccount(acctNum1, amt);
                        break;
                    case 5:
                        Console.WriteLine("Enter Account Number: ");
                        mybank.bankDatabase[Console.ReadLine()].GetAccountInfo();
                        break;
                }
                string reply;
                while (true)
                {
                    Console.Write("Do you want to continue(Y/N): ");
                    reply = Console.ReadLine();
                    if (reply.ToLower() == "y" || reply.ToLower() == "n")
                    {
                        break;
                    }

                    else { Console.WriteLine("Error: please enter Y/N"); }
                }
                if (reply.ToLower() == "n")
                    break;


            }
            mybank.Summary();
        }

    }
}
