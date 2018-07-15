using System;
using Application.Abstract;
using MediatR;

namespace Application.Customers.Commands
{
    public class DisableCustomer : ICommand<Unit>
    {
        public DisableCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
