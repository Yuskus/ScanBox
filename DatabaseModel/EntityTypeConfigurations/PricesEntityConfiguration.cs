using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class PricesEntityConfiguration : IEntityTypeConfiguration<PricesEntity>
    {
        public void Configure(EntityTypeBuilder<PricesEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.ProductTypeId)
                   .HasName("id_prices_pk");

            // имя таблицы

            builder.ToTable("prices_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
