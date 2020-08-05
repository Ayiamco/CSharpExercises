using System;
using System.Collections.Generic;
using System.Text;
using Chapter20Question8.Helpers;

namespace Chapter20Question8.Services
{
    class CompanyCustomer : Customer
    {
        internal string industry;
        internal string name;
        private DateTime dateFounded;
        internal CompanyStatus status;
        private string regNo;
        private string address;
        internal CompanyCustomer(string industry, string name, string dateFounded, string regNo, string address, CompanyStatus status)
        {
            this.industry = industry;
            this.name = name;
            Age = dateFounded;
            this.status = status;
            Address = address;
            this.regNo = regNo;
        }


        internal new string Age
        {
            get
            {
                return Convert.ToString(DateTime.Now.Year - dateFounded.Year);
            }
            set
            {
                this.dateFounded = Utility.GetBirthday(value);
            }
        }

        internal new string Name { get { return name; } }
        internal new string Address { get { return address; } set { address = value; } }

        public override string GetCustomerInfo()
        {

            return $"Name: {name}, Founded: {Age} , Industry: {industry}\n" +
                $"Registration Num: {regNo}, Status: {status} , Address: {Address}";

        }
    }

    internal enum CompanyStatus
    {
        Private, Public, Person, Invalid
    }
}
