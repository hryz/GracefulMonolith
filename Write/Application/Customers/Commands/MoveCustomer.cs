using System;
using Application.Abstract;
using MediatR;

namespace Application.Customers.Commands
{
    public class MoveCustomer : ICommand<Unit>
    {
        public MoveCustomer(
            Guid customerId,
            string countryCode, 
            int zipCode,
            string city, 
            string street, 
            string house, 
            string apartment)
        {
            CustomerId = customerId;
            CountryCode = countryCode;
            ZipCode = zipCode;
            City = city;
            Street = street;
            House = house;
            Apartment = apartment;
        }

        public Guid CustomerId { get; }

        public string CountryCode { get; }
        public int ZipCode { get; }
        public string City { get; }
        public string Street { get; }
        public string House { get; }
        public string Apartment { get; }
    }
}
