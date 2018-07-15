using Data.Read.Abstract;
using Data.Read.Customers.ReadModels;

namespace Data.Read.Customers.Queries
{
    public class GetCustomerList : IPageQuery<CustomerListItem>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
