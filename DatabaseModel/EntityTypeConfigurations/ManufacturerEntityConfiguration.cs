п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ManufacturerEntityConfiguration : IEntityTypeConfiguration<ManufacturerEntity>
    {
        public void Configure(EntityTypeBuilder<ManufacturerEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_manufacturer_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("manufacturers_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

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
