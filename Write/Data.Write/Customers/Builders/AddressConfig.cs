using Data.Write.Catalog.Entities;
using Data.Write.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Write.Customers.Builders
{
    public class AddressConfig : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            //Fluent Api will be here
            builder.ToTable("address");
        }
    }
}
