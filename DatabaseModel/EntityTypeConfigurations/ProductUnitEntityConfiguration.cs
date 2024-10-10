п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ProductUnitEntityConfiguration : IEntityTypeConfiguration<ProductUnitEntity>
    {
        public void Configure(EntityTypeBuilder<ProductUnitEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_product_unit_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("product_units_table");

            // РёРЅРґРµРєСЃС‹

            builder.HasIndex(x => x.UniqueBarcode)
                   .IsUnique();

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(x => x.Id)
                   .HasColumnName("id");

            builder.Property(p => p.UniqueBarcode)
                   .IsRequired()
                   .HasMaxLength(128)
                   .HasColumnName("unique_barcode");

            builder.Property(x => x.ProductionDate)
                   .HasColumnName("production_date");

            builder.Property(x => x.RealizationPrice)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("realization_price");

            builder.Property(x => x.ProductTypeId)
                   .HasColumnName("product_type_id");

            builder.Property(x => x.SupplierId)
                   .HasColumnName("supplier_id");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasOne(p => p.ProductType)
                   .WithMany(p => p.ProductUnits)
                   .HasForeignKey(p => p.ProductTypeId)
                   .HasConstraintName("1tomany_product_type_id_to_product_units_fk");

            builder.HasOne(p => p.Supplier)
                   .WithMany(p => p.ProductUnits)
                   .HasForeignKey(p => p.SupplierId)
                   .HasConstraintName("1tomany_supplier_to_product_units_fk");

            builder.HasMany(p => p.MovementsHistory)
                   .WithOne(p => p.ProductUnit)
                   .HasForeignKey(p => p.ProductUnitId)
                   .HasConstraintName("manyto1_movements_history_to_product_unit_fk");

            builder.HasMany(p => p.Shipments)
                   .WithOne(p => p.ProductUnit)
                   .HasForeignKey(p => p.ProductUnitId)
                   .HasConstraintName("manyto1_shipments_to_product_unit_fk");
        }
    }
}
