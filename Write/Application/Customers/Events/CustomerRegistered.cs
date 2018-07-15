using Application.Abstract;
using System;

namespace Application.Customers.Events
{
    public class CustomerRegistered : IEvent
    {
        public CustomerRegistered(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
