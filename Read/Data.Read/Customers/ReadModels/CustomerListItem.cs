using System;

namespace Data.Read.Customers.ReadModels
{
    public class CustomerListItem
    {
        public CustomerListItem(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
