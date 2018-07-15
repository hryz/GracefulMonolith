using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Write.Customers.Entities
{
    public class AddressEntity
    {
        public Guid Id { get; set; }
        public string CountryCode { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
    }
}
