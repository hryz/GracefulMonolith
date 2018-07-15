using Data.Write.Customers.Entities;
using Domain.Customer;

namespace Data.Write.Customers.Mappers
{
    public class CustomerMapper : AutoMapper.Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerEntity>()
                .ForMember(x => x.Address, x => x.Ignore())
                .ForMember(x => x.Contact, x => x.Ignore());

            CreateMap<Address, AddressEntity>();
            CreateMap<Contact, ContactEntity>();
        }
    }
}
