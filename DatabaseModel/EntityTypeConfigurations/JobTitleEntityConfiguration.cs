using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class JobTitleEntityConfiguration : IEntityTypeConfiguration<JobTitleEntity>
    {
        public void Configure(EntityTypeBuilder<JobTitleEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
