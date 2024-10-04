using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class WarehouseEmployeeEntityConfiguration : IEntityTypeConfiguration<WarehouseEmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<WarehouseEmployeeEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
