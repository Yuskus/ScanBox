using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ProductForSalesEntityConfiguration : IEntityTypeConfiguration<ProductForSalesEntity>
    {
        public void Configure(EntityTypeBuilder<ProductForSalesEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
