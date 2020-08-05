using System;
using System.Collections.Generic;
using System.Text;
using Chapter20Question8.Interfaces;

namespace Chapter20Question8.Services
{
    class LoanAccount : Account, IAccount
    {
        //Loan accounts have no payment during the first 3 months if held by individuals
        //and during the first 2 months if held by a company.
        //Companies have a minimum amount they can borrow , personal account do not


        internal enum InterestRate
        {
            Personal = 9, PrivateCompany = 11, PublicCompany = 13
        }
        static decimal publicCompanyMin = 0;
        static decimal privateCompanyMin = 0;
        internal decimal initialBalance;
        internal int duration;


        internal LoanAccount(ICustomer customer, decimal loanAmt, int duration)
        {

            SetDateOpened();
            SetAccountNumber();
            this.customer = customer;
            Balance = loanAmt;
            initialBalance = loanAmt;
            this.duration = duration > 3 ? duration : throw new ArgumentException("Loan duration is less than 3 months");
        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (customer is CompanyCustomer companyCustomer)
                {
                    if (companyCustomer.status is CompanyStatus.Private && value >= privateCompanyMin)
                        this.balance = value + (((int)InterestRate.PrivateCompany) * initialBalance) / (duration - 3);
                    else if (companyCustomer.status is CompanyStatus.Public && value >= publicCompanyMin)
                        this.balance = value + (((int)InterestRate.PublicCompany * initialBalance) / (duration - 3));
                    else
                        throw new ArgumentException($"loan amount of {value} is less" +
                            $" than minimum required for " + companyCustomer.status + "company account");
                }
                else
                {
                    balance = value + (((int)InterestRate.Personal) * initialBalance) / (duration - 3);
                }
            }
        }
        public override decimal Credit(decimal amt)
        {
            this.balance = this.balance - amt;
            return balance;
        }

        public override string GetAccountInfo()
        {
            if (customer is CompanyCustomer compCust)
            {
                return $" Name: {compCust.Name},  Loan Amount: {initialBalance},  DateOpened:{dateOpened}\n " +
             $"Remaining Loan Balance: {balance }, " +
             $" Account Number: { accountNumber},  Industry:{compCust.industry}";
            }
            else
            {
                return $" Name: {customer.Name},  Loan Amount: {initialBalance},  DateOpened:{dateOpened}\n " +
             $"Remaining Loan Balance: {balance }, " +
             $" Account Number: { accountNumber}";
            }

        }

        internal decimal GetMonthlyPayment()
        {
            //Individuals get 3 months moratarium period while companies get 2 months
            if (customer is PersonCustomer)
            {
                decimal monthlyPayment = (((int)InterestRate.Personal) * initialBalance) / (duration - 3);
                return monthlyPayment;
            }

            else
            {
                if (customer is CompanyCustomer companyCustomer)
                {
                    if (companyCustomer.status == CompanyStatus.Private)
                        return (((int)InterestRate.PrivateCompany) * initialBalance) / (duration - 2);
                    else
                        return (((int)InterestRate.PublicCompany) * initialBalance) / (duration - 2);
                }
                else
                {
                    Exception e = new Exception("Something very odd happened!!!");
                    throw e;
                }
            }
        }


    }
}
