using Data.Write.Catalog.Entities;
using Data.Write.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Write.Customers.Builders
{
    public class CustomerConfig : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            //Fluent Api will be here
            builder.ToTable("customer");
        }
    }
}
