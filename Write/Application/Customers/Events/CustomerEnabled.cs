using System;
using Application.Abstract;

namespace Application.Customers.Events
{
    public class CustomerEnabled : IEvent
    {
        public CustomerEnabled(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
