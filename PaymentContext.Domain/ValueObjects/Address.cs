using PaymentContext.Domain.ValueObjects.Contract;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string numer, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Numer = numer;
            Neighborhood = neighborhood;
            City = city;
            this.state = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new CreateAddressContract(this));
        }

        public string Street { get; set; }
        public string Numer { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

    }
}
