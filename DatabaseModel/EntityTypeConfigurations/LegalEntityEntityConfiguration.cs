using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class LegalEntityEntityConfiguration : IEntityTypeConfiguration<LegalEntityEntity>
    {
        public void Configure(EntityTypeBuilder<LegalEntityEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_legal_entity_pk");

            // имя таблицы

            builder.ToTable("legal_entities_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
