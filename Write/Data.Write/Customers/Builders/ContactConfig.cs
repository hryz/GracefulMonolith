using Data.Write.Catalog.Entities;
using Data.Write.Customers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Write.Customers.Builders
{
    public class ContactConfig : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            //Fluent Api will be here
        }
    }
}
