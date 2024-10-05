using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ProductUnitEntityConfiguration : IEntityTypeConfiguration<ProductUnitEntity>
    {
        public void Configure(EntityTypeBuilder<ProductUnitEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_product_unit_pk");

            // имя таблицы

            builder.ToTable("product_units_table");

            // индексы

            builder.HasIndex(x => x.UniqueBarcode)
                   .IsUnique();

            // имена свойств

            /*builder.Property(x => x.UID)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")
                   .HasColumnName("UID");*/

            /*builder.Property(x => x.ProductionPlace)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("production_place");*/

            builder.Property(x => x.ProductionDate)
                   .HasColumnName("production_date");

            builder.Property(x => x.ProductTypeId)
                   .HasColumnName("product_type_id");

            builder.Property(x => x.SupplierId)
                   .HasColumnName("supplier_id");

            // внешние ключи, связи 1 ко многим

            builder.HasOne(p => p.ProductType)
                   .WithMany(p => p.ProductUnits)
                   .HasForeignKey(p => p.ProductTypeId)
                   .HasConstraintName("product_type_id_to_product_units_fk");

            builder.HasOne(p => p.Supplier)
                   .WithMany(p => p.ProductUnits)
                   .HasForeignKey(p => p.SupplierId)
                   .HasConstraintName("supplier_id_to_product_units_fk");
        }
    }
}
