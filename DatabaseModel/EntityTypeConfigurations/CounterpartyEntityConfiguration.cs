using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class CounterpartyEntityConfiguration : IEntityTypeConfiguration<CounterpartyEntity>
    {
        public void Configure(EntityTypeBuilder<CounterpartyEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_counterparty_pk");

            // имя таблицы

            builder.ToTable("counterpartys_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
