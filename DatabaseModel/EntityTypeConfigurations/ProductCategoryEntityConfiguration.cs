using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ProductCategoryEntityConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_product_category_pk");

            // имя таблицы

            builder.ToTable("product_category_table");

            // индексы

            builder.HasIndex(p => p.CategoryName)
                   .IsUnique();

            // имена свойств

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

            // внешние ключи

            builder.HasMany(p => p.ProductTypes)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .HasConstraintName("manyto1_product_types_to_product_category_fk");
        }
    }
}
