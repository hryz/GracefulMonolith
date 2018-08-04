using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Dapper.Logging;
using Dapper.Testing;
using Data.Read.Abstract;
using Data.Read.Customers.Queries;
using Data.Read.Customers.ReadModels;

namespace Data.Read.Customers.QueryHandlers
{
    [DapperQuery(nameof(CountQuery))]
    [DapperQuery(nameof(PageQuery), nameof(DummyParams))]
    public class GetCustomerListHandler : IPageHandler<GetCustomerList, CustomerListItem>
    {
        private const string CountQuery = @"
        SELECT COUNT(*)
        FROM Customer c";

        private const string PageQuery = @"
        SELECT 
            c.Id,
	        co.FirstName,
	        co.LastName
        FROM Customer c
        INNER JOIN Contact co ON c.ContactId = co.Id
        ORDER BY co.FirstName, co.LastName
	        OFFSET @skip ROWS
	        FETCH NEXT @take ROWS ONLY";

        private static readonly object DummyParams = new
        {
            skip = 50,
            take = 25
        };

        private readonly IDbConnectionFactory _factory;

        public GetCustomerListHandler(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IPageResult<CustomerListItem>> Handle(GetCustomerList request, CancellationToken cancellationToken)
        {
            using (var con = _factory.CreateConnection())
            {
                //here can be much more parameters like TenantId, or SearchPhrase
                var param = new
                {
                    skip = request.Skip(),
                    take = request.Take()
                };

                var count = await con.ExecuteScalarAsync<int>(CountQuery);
                var page = await con.QueryAsync<CustomerListItem>(PageQuery, param);

                return this.Result(count, page);
            }
        }
    }
}
