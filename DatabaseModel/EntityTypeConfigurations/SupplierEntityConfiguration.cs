using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class SupplierEntityConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_supplier_pk");

            // имя таблицы

            builder.ToTable("suppliers_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // внешние ключи

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey<SupplierEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_supplier_fk");

            // внешние ключи, связи многие к одному

            builder.HasMany(p => p.ProductUnits)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey(p => p.SupplierId)
                   .HasConstraintName("manyto1_product_units_to_supplier_fk");
        }
    }
}
