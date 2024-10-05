using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class IndividualEntityConfiguration : IEntityTypeConfiguration<IndividualEntity>
    {
        public void Configure(EntityTypeBuilder<IndividualEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_individual_pk");

            // имя таблицы

            builder.ToTable("individuals_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
