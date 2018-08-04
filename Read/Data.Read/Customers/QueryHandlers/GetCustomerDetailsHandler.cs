using System;
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
    [DapperQuery(nameof(Query), nameof(DummyParams))]
    public class GetCustomerDetailsHandler : IQueryHandler<GetCustomerDetails, CustomerDetails>
    {
        private const string Query = @"
        SELECT 
	        c.Id,
	        co.Title,
	        co.FirstName,
	        co.MiddleName,
	        co.LastName,

	        a.CountryCode,
	        a.ZipCode,
	        a.City,
	        a.Street,
	        a.House,
	        a.Apartment,
	        c.BirthDate

        FROM Customer c
        INNER JOIN Contact co ON c.ContactId = co.Id
        INNER JOIN [Address] a on c.AddressId = a.Id
        WHERE c.Id = @id";

        private static readonly object DummyParams = new { id = Guid.NewGuid() };

        private readonly IDbConnectionFactory _factory;

        public GetCustomerDetailsHandler(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<CustomerDetails> Handle(GetCustomerDetails request, CancellationToken cancellationToken)
        {
            using (var con = _factory.CreateConnection())
            {
                var param = new { id = request.Id };
                return await con.QueryFirstOrDefaultAsync<CustomerDetails>(Query, param);
            }
        }
    }
}
