using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ShipmentEntityConfiguration : IEntityTypeConfiguration<ShipmentEntity>
    {
        public void Configure(EntityTypeBuilder<ShipmentEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_shipment_pk");

            // имя таблицы

            builder.ToTable("shipments_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.DocumentId)
                   .HasColumnName("document_id");

            builder.Property(p => p.ProductUnitId)
                   .HasColumnName("product_unit_id");

            // внешние ключи

            builder.HasOne(p => p.Document)
                   .WithMany(p => p.Shipments)
                   .HasForeignKey(p => p.DocumentId)
                   .HasConstraintName("1tomany_document_to_shipment_fk");

            builder.HasOne(p => p.ProductUnit)
                   .WithMany(p => p.Shipments)
                   .HasForeignKey(p => p.ProductUnitId)
                   .HasConstraintName("1tomany_product_unit_to_shipment_fk");
        }
    }
}
