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

            builder.ToTable("counterparties_types_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.TypeName)
                   .HasMaxLength(128)
                   .IsRequired()
                   .HasColumnName("type_name");

            // внешние ключи

            builder.HasMany(p => p.Counterparties)
                   .WithOne(p => p.CounterpartyType)
                   .HasForeignKey(p => p.CounterpartyTypeId)
                   .HasConstraintName("manyto1_counterparty_to_counterparty_type_fk");
        }
    }
}
