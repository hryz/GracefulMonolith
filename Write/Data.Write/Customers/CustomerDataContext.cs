using Data.Write.Customers.Builders;
using Data.Write.Customers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Write.Customers
{
    public class CustomerDataContext : DbContext
    {
        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //todo: get all of the configs from DI and apply them in the loop

            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new ContactConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
    }
}
