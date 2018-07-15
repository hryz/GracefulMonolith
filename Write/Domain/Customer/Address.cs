namespace Domain.Customer
{
    public class Address
    {
        public Address(
            string countryCode, 
            int zipCode,
            string city, 
            string street, 
            string house, 
            string apartment)
        {
            CountryCode = countryCode;
            ZipCode = zipCode;
            City = city;
            Street = street;
            House = house;
            Apartment = apartment;
        }

        public string CountryCode { get; }
        public int ZipCode { get; }
        public string City { get; }
        public string Street { get; }
        public string House { get; }
        public string Apartment { get; }
    }
}