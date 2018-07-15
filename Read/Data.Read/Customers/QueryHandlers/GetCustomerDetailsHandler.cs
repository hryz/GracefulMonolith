using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Dapper.Logging;
using Data.Read.Abstract;
using Data.Read.Customers.Queries;
using Data.Read.Customers.ReadModels;

namespace Data.Read.Customers.QueryHandlers
{
    public class GetCustomerDetailsHandler : IQueryHandler<GetCustomerDetails, CustomerDetails>
    {
        private readonly IDbConnectionFactory _factory;

        public GetCustomerDetailsHandler(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public Task<CustomerDetails> Handle(GetCustomerDetails request, CancellationToken cancellationToken)
        {
            using (var con = _factory.CreateConnection())
            {
                throw new NotImplementedException();
            }
        }
    }
}
