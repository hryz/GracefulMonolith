using System;
using Application.Abstract;

namespace Application.Customers.Events
{
    public class CustomerDisabled : IEvent
    {
        public CustomerDisabled(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
