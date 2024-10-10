п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_product_category_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("product_category_table");

            // РёРЅРґРµРєСЃС‹

            builder.HasIndex(p => p.CategoryName)
                   .IsUnique();

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CategoryName)
                   .IsRequired()
                   .HasMaxLength(128)
                   .HasColumnName("category_name");

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("category_description");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasMany(p => p.ProductTypes)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .HasConstraintName("manyto1_product_types_to_product_category_fk");
        }
    }
}
