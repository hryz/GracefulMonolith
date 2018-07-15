using Data.Write.Catalog.Builders;
using Data.Write.Catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Write.Catalog
{
    public class CatalogDataContext : DbContext
    {
        public CatalogDataContext(DbContextOptions<CatalogDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //todo: get all of the configs from DI and apply them in the loop
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
