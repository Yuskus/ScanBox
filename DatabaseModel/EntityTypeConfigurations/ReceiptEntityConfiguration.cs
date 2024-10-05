using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ReceiptEntityConfiguration : IEntityTypeConfiguration<ReceiptEntity>
    {
        public void Configure(EntityTypeBuilder<ReceiptEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
