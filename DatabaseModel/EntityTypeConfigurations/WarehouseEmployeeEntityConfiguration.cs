using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class WarehouseEmployeeEntityConfiguration : IEntityTypeConfiguration<WarehouseEmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<WarehouseEmployeeEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_warehouse_employee_pk");

            // имя таблицы

            builder.ToTable("warehouse_employees_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
