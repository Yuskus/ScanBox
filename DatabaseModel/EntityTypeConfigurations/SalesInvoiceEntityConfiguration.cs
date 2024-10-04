using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class SalesInvoiceEntityConfiguration : IEntityTypeConfiguration<SalesInvoiceEntity>
    {
        public void Configure(EntityTypeBuilder<SalesInvoiceEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
