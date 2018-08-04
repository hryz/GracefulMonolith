using System.Threading.Tasks;
using Dapper.Testing;
using Data.Read.Customers.QueryHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Integration
{
    [TestClass]
    public class DapperTests
    {
        private const string ConnectionString = "Server=.;Database=gm;Trusted_Connection=True;";

        [ClassInitialize]
        public static async Task ClassInit(TestContext _)
        {
            await DryRun.EnableSafeMode(ConnectionString);
        }

        [DataTestMethod]
        [DapperDataSource(typeof(GetCustomerListHandler))]
        public async Task DapperQueriesWork(QueryContext ctx)
        {
            await DryRun.ExecuteQuery(ctx);
        }

        [ClassCleanup]
        public static async Task ClassCleanup()
        {
            await DryRun.DisableSafeMode();
        }
    }
}
