using System;

namespace Data.Read.Customers.ReadModels
{
    public class CustomerDetails
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string CountryCode { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
