using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ProductUnitEntityConfiguration : IEntityTypeConfiguration<ProductUnitEntity>
    {
        public void Configure(EntityTypeBuilder<ProductUnitEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
