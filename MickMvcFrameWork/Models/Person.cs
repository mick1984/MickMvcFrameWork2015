using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MickUserFrameWork.Models
{
    public class Person
    {
        public string ID
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public Address HomeAddress
        {
            get;
            set;
        }

        public Person()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.HomeAddress = new Address();
            this.ID = string.Empty;
        }
    }

    public class Address
    {
        public string AddressValue
        {
            get;set;
        }

        public Address()
        {
            this.AddressValue = string.Empty;
        }
    }

    public class Person2
    {
        public string ID
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
    }
}