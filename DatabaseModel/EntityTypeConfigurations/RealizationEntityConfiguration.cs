using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class RealizationEntityConfiguration : IEntityTypeConfiguration<RealizationEntity>
    {
        public void Configure(EntityTypeBuilder<RealizationEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_realization_pk");

            // имя таблицы

            builder.ToTable("realizations_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
