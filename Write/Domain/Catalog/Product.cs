using System;
using Domain.Abstract;

namespace Domain.Catalog
{
    public class Product : IAggregate<Guid>
    {
        public Guid Id { get; }
    }
}
