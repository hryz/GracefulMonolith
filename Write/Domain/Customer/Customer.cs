using System;
using Domain.Abstract;

namespace Domain.Customer
{
    public class Customer : IAggregate<Guid>
    {
        public Customer(
            Contact contact, 
            DateTime birthDate, 
            Address address)
        {
            //public constructor for App layer

            Id = Guid.NewGuid();
            
            Contact = contact ?? throw new DomainException("Contact info is mandatory");
            Address = address ?? throw new DomainException("Address is mandatory");
            BirthDate = birthDate != DateTime.MinValue 
                ? birthDate 
                : throw new DomainException("Birth date is mandatory");
            RegisteredOn = DateTime.UtcNow;
            Enabled = true;
        }

        internal Customer(
            Guid id, 
            Address address,
            Contact contact, 
            DateTime birthDate, 
            DateTime registeredOn, 
            bool enabled)
        {
            //internal constructor from Data layer

            Id = id;
            Address = address;
            Contact = contact;
            BirthDate = birthDate;
            RegisteredOn = registeredOn;
            Enabled = enabled;
        }

        public Guid Id { get; }
        public Address Address { get; private set; }
        public Contact Contact { get; }
        public DateTime BirthDate { get; }
        public DateTime RegisteredOn { get; }

        public bool Enabled { get; private set; }

        //Here will be some business logic (methods / properties)
        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }

        public void Move(Address newAddress)
        {
            Address = newAddress;
        }
    }
}
