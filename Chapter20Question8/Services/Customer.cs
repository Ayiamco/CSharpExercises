using System;
using System.Collections.Generic;
using System.Text;
using Chapter20Question8.Interfaces;

namespace Chapter20Question8.Services
{
    abstract public class Customer : ICustomer
    {
        public virtual string Age { get; set; }
        public virtual string Name { get; }
        public virtual string Address { get; }

        public abstract string GetCustomerInfo();
    }
}
