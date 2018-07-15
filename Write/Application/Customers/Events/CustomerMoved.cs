using System;
using Application.Abstract;

namespace Application.Customers.Events
{
    public class CustomerMoved : IEvent
    {
        public CustomerMoved(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
