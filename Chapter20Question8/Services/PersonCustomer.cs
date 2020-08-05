using System;
using System.Collections.Generic;
using System.Text;
using Chapter20Question8.Helpers;
using Chapter20Question8.Interfaces;

namespace Chapter20Question8.Services
{
    public class PersonCustomer : Customer, ICustomer
    {
        private string title;
        private string firstName;
        private string lastName;
        private DateTime dob;
        private Gender gender;
        private string address;
        internal PersonCustomer(string title, string firstName, string lastName, string dob, Gender gender, string address)
        {
            this.title = title;
            this.firstName = firstName;
            this.lastName = lastName;
            Age = dob;
            this.gender = gender;
            this.address = address;

        }


        public override string Age
        {
            get
            {
                return Convert.ToString(DateTime.Now.Year - dob.Year);
            }
            set
            {
                this.dob = Convert.ToDateTime(Utility.GetBirthday(value));
            }
        }

        public override string Name
        {
            get
            {
                return $"{title} {firstName} {lastName}";
            }


        }

        internal new string Address { get { return address; } }

        public override string GetCustomerInfo()
        {

            return $"Name: {title} {Name}, Age: {Age}";

        }


    }
    internal enum Gender
    {
        Male, Female, NonBinary
    }
}
