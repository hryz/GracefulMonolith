using System;
using Application.Abstract;
using MediatR;

namespace Application.Customers.Commands
{
    public class EnableCustomer : ICommand<Unit>
    {
        public EnableCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }

        public Guid CustomerId { get; }
    }
}
