using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class CounterpartyTypeEntityConfiguration : IEntityTypeConfiguration<CounterpartyTypeEntity>
    {
        public void Configure(EntityTypeBuilder<CounterpartyTypeEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_counterparty_type_pk");

            // имя таблицы

            builder.ToTable("counterpartys_types_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
