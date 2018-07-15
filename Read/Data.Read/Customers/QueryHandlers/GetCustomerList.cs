using System;
using System.Threading;
using System.Threading.Tasks;
using Dapper.Logging;
using Data.Read.Abstract;
using Data.Read.Customers.Queries;
using Data.Read.Customers.ReadModels;

namespace Data.Read.Customers.QueryHandlers
{
    public class GetCustomerListHandler : IPageHandler<GetCustomerList, CustomerListItem>
    {
        private readonly IDbConnectionFactory _factory;

        public GetCustomerListHandler(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public Task<IPageResult<CustomerListItem>> Handle(GetCustomerList request, CancellationToken cancellationToken)
        {
            using (var con = _factory.CreateConnection())
            {
                throw new NotImplementedException();
            }
        }
    }
}
