using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstract;
using Domain.Catalog;

namespace Data.Write.Catalog.Repositories
{
    public class ProductRepository : IRepository<Product, Guid>
    {
        private readonly CatalogDataContext _context;

        public ProductRepository(CatalogDataContext context)
        {
            _context = context;
        }

        public Task<Product> Get(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Create(Product aggregate, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product aggregate, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
