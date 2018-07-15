using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstract;
using AutoMapper;
using Data.Write.Abstract;
using Data.Write.Customers.Entities;
using Domain.Customer;
using Microsoft.EntityFrameworkCore;

namespace Data.Write.Customers.Repositories
{
    public class CustomerRepository : IRepository<Customer, Guid>
    {
        private readonly CustomerDataContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(CustomerDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Customer> Get(Guid id, CancellationToken token)
        {
            var customer = await _context.Customers
                .Include(x => x.Address)
                .Include(x => x.Contact)
                .FirstOrDefaultAsync(x => x.Id == id, token);

            if (customer == null)
            {
                throw new DataException("Customer was not found by Id");
            }

            var address = new Address(
                customer.Address.CountryCode,
                customer.Address.ZipCode,
                customer.Address.City,
                customer.Address.Street,
                customer.Address.House,
                customer.Address.Apartment);

            var contact = new Contact(
                customer.Contact.Title,
                customer.Contact.FirstName,
                customer.Contact.MiddleName,
                customer.Contact.LastName);

            return new Customer(
                customer.Id, 
                address, 
                contact, 
                customer.BirthDate, 
                customer.RegisteredOn, 
                customer.Enabled);
        }

        public async Task<Guid> Create(Customer aggregate, CancellationToken token)
        {
            var contactEntity = _mapper.Map<Contact, ContactEntity>(aggregate.Contact);
            var addressEntity = _mapper.Map<Address, AddressEntity>(aggregate.Address);
            var customer = _mapper.Map<Customer, CustomerEntity>(aggregate);

            customer.AddressId = addressEntity.Id = Guid.NewGuid();
            customer.ContactId = contactEntity.Id = Guid.NewGuid();

            await _context.Addresses.AddAsync(addressEntity, token);
            await _context.Contacts.AddAsync(contactEntity, token);
            await _context.Customers.AddAsync(customer, token);

            await _context.SaveChangesAsync(token);
            return aggregate.Id;
        }

        public async Task Update(Customer aggregate, CancellationToken token)
        {
            var customer = await _context.Customers
                .Include(x => x.Address)
                .Include(x => x.Contact)
                .FirstOrDefaultAsync(x => x.Id == aggregate.Id, token);

            if (customer == null)
            {
                throw new DataException("Customer was not found by Id");
            }

            _mapper.Map(aggregate, customer);
            _mapper.Map(aggregate.Address, customer.Address);
            _mapper.Map(aggregate.Contact, customer.Contact);

            await _context.SaveChangesAsync(token);
        }

        public async Task Delete(Guid id, CancellationToken token)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id, token);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync(token);
        }
    }
}
