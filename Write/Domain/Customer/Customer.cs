using System;
using Domain.Abstract;

namespace Domain.Customer
{
    public class Customer : IAggregate<Guid>
    {
        public Guid Id { get; }
    }
}
