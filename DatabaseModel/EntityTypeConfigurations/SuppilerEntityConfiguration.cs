using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class SuppilerEntityConfiguration : IEntityTypeConfiguration<SuppilerEntity>
    {
        public void Configure(EntityTypeBuilder<SuppilerEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_suppiler_pk");

            // имя таблицы

            builder.ToTable("suppilers_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // внешние ключи

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.Suppiler)
                   .HasForeignKey<SuppilerEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_suppiler_fk");

            // внешние ключи, связи многие к одному

            builder.HasMany(p => p.ProductUnits)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey(p => p.SupplierId)
                   .HasConstraintName("manyto1_product_units_to_suppiler_fk");
        }
    }
}
