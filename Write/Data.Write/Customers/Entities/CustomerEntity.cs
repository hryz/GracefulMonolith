using System;

namespace Data.Write.Customers.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public Guid AddressId { get; set; }
        public Guid ContactId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisteredOn { get; set; }
        public bool Enabled { get; set; }

        public AddressEntity Address { get; set; }
        public ContactEntity Contact { get; set; }
    }
}
