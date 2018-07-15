using System;
using Data.Read.Abstract;
using Data.Read.Customers.ReadModels;

namespace Data.Read.Customers.Queries
{
    public class GetCustomerDetails : IQuery<CustomerDetails>
    {
        public Guid Id { get; set; }
    }
}
