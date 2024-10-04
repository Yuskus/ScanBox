using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class MarkdownEntityConfiguration : IEntityTypeConfiguration<MarkdownEntity>
    {
        public void Configure(EntityTypeBuilder<MarkdownEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
