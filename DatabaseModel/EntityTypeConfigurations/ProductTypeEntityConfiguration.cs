п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ProductTypeEntityConfiguration : IEntityTypeConfiguration<ProductTypeEntity>
    {
        public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_product_type_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("product_types_table");

            // РёРЅРґРµРєСЃС‹

            builder.HasIndex(p => p.Barcode)
                   .IsUnique();

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.Barcode)
                   .IsRequired()
                   .HasMaxLength(128)
                   .HasColumnName("barcode");

            builder.Property(p => p.ProductName)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("product_name");

            builder.Property(p => p.Length)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("length");

            builder.Property(p => p.Heigth)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("heigth");

            builder.Property(p => p.Width)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("width");

            builder.Property(p => p.Weigth)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("weigth");

            builder.Property(p => p.CategoryId)
                   .HasColumnName("category_id");

            builder.Property(p => p.ManufacturerId)
                   .HasColumnName("manufacturer_id");

            builder.Property(p => p.ProductPriceId)
                   .HasColumnName("product_price_id");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasOne(p => p.ProductPrice)
                   .WithOne(p => p.ProductType)
                   .HasForeignKey<ProductTypeEntity>(p => p.ProductPriceId)
                   .HasConstraintName("1to1_product_price_id_to_product_types_fk");

            builder.HasOne(p => p.Category)
                   .WithMany(p => p.ProductTypes)
                   .HasForeignKey(p => p.CategoryId)
                   .HasConstraintName("1tomany_category_id_to_product_types_fk");

            builder.HasOne(p => p.Manufacturer)
                   .WithMany(p => p.ProductTypes)
                   .HasForeignKey(p => p.ManufacturerId)
                   .HasConstraintName("1tomany_manufacturer_id_to_product_types_fk");

            builder.HasMany(p => p.ProductUnits)
                   .WithOne(p => p.ProductType)
                   .HasForeignKey(p => p.ProductTypeId)
                   .HasConstraintName("product_units_to_product_types_fk");
        }
    }
}
