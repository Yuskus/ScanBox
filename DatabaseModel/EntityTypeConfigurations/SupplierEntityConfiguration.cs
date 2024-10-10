п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class SupplierEntityConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_supplier_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("suppliers_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey<SupplierEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_supplier_fk");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё, СЃРІСЏР·Рё РјРЅРѕРіРёРµ Рє РѕРґРЅРѕРјСѓ

            builder.HasMany(p => p.ProductUnits)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey(p => p.SupplierId)
                   .HasConstraintName("manyto1_product_units_to_supplier_fk");
        }
    }
}
