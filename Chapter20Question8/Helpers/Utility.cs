using System;
using System.Collections.Generic;
using System.Text;
using Chapter20Question8.Services;

namespace Chapter20Question8.Helpers
{
    class Utility
    {

        public static DepositAccountType GetDepositAccountType(String accountType)
        {
            if (accountType.ToLower().Trim() == "savings")
            {
                return DepositAccountType.Savings;
            }
            else if (accountType.ToLower().Trim() == "student")
            {
                return DepositAccountType.Student;
            }
            else if (accountType.ToLower().Trim() == "current")
            {
                return DepositAccountType.Current;
            }
            else
            {
                throw new ArgumentException($"{accountType.ToUpper()} is not a valid Deposit account Type");
            }
        }


        internal static Decimal GetDecimal(string input)
        {
            try
            {
                return Convert.ToDecimal(input);
            }
            catch
            {
                throw new ArgumentException("Invalid Start Balance amount");
            }
        }

        internal static DateTime GetBirthday(string dob)
        {
            Exception e = new Exception($"{dob} Invalid Date String Argument");
            try
            {
                int age = DateTime.Now.Year - Convert.ToDateTime(dob).Year;
                if (age < 0)
                    throw e;
                else
                    return Convert.ToDateTime(dob);
            }
            catch
            {

                throw e;
            }
        }

        internal static bool IsValidStartBalance(DepositAccountType accountType, decimal startBalance)
        {
            bool isValid = false;
            switch ((int)accountType)
            {
                case 0://students
                    if (startBalance < 0)
                        isValid = false;
                    else
                        isValid = true;
                    break;
                case 1000:// savings
                    if (startBalance < 1000)
                        isValid = false;
                    else
                        isValid = true;
                    break;
                case 10000: //current
                    if (startBalance < 10000)
                        isValid = false;
                    else
                        isValid = true;
                    break;

            }
            return isValid;
        }
    }
}
