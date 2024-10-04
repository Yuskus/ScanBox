using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ProductForReceiptEntityConfiguration : IEntityTypeConfiguration<ProductForReceiptEntity>
    {
        public void Configure(EntityTypeBuilder<ProductForReceiptEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
