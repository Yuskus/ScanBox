using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class PricesEntityConfiguration : IEntityTypeConfiguration<PricesEntity>
    {
        public void Configure(EntityTypeBuilder<PricesEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.ProductTypeId)
                   .HasName("id_prices_pk");

            // имя таблицы

            builder.ToTable("prices_table");

            // имена свойств

            builder.Property(p => p.ProductTypeId)
                   .HasColumnName("product_type_id");

            builder.Property(p => p.MinPrice)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("min_price");

            builder.Property(p => p.RetailPrice)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("retail_price");

            builder.Property(p => p.WholesalePrice)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("wholesale_price");

            // внешние ключи

            builder.HasOne(p => p.ProductType)
                   .WithOne(p => p.ProductPrice)
                   .HasForeignKey<PricesEntity>(p => p.ProductTypeId)
                   .HasConstraintName("1to1_product_type_to_product_price_fk");
        }
    }
}
