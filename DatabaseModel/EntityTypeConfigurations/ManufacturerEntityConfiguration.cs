using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ManufacturerEntityConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_manufacturer_pk");

            // имя таблицы

            builder.ToTable("manufacturers_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // внешние ключи

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.Manufacturer)
                   .HasForeignKey<ManufacturerEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_manufacturer_fk");

            builder.HasMany(p => p.ProductTypes)
                   .WithOne(p => p.Manufacturer)
                   .HasForeignKey(p => p.ManufacturerId)
                   .HasConstraintName("manyto1_product_types_to_manufacturer_fk");
        }
    }
}
