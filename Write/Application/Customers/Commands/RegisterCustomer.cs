using System;
using Application.Abstract;

namespace Application.Customers.Commands
{
    public class RegisterCustomer : ICommand<Guid>
    {
        public RegisterCustomer(
            string title, 
            string firstName, 
            string middleName, 
            string lastName, 
            string countryCode, 
            int zipCode,
            string city, 
            string street, 
            string house, 
            string apartment, 
            DateTime birthDate)
        {
            Title = title;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            CountryCode = countryCode;
            ZipCode = zipCode;
            City = city;
            Street = street;
            House = house;
            Apartment = apartment;
            BirthDate = birthDate;
        }

        public string Title { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        public string CountryCode { get; }
        public int ZipCode { get; }
        public string City { get; }
        public string Street { get; }
        public string House { get; }
        public string Apartment { get; }

        public DateTime BirthDate { get; }
    }
}
