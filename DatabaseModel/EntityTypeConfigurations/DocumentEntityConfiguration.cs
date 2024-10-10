п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class DocumentEntityConfiguration : IEntityTypeConfiguration<DocumentEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_document_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("documents_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CreationTime)
                   .HasColumnType("timestamp")
                   .HasColumnName("creation_time");

            builder.Property(p => p.WarehouseEmployeeId)
                   .HasColumnName("warehouse_employee_id");

            builder.Property(p => p.DocumentTypeId)
                   .HasColumnName("document_type_id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё, СЃРІСЏР·Рё 1 РєРѕ РјРЅРѕРіРёРј

            builder.HasOne(p => p.WarehouseEmployee)
                   .WithMany(p => p.Documents)
                   .HasForeignKey(p => p.WarehouseEmployeeId)
                   .HasConstraintName("1tomany_warehouse_employee_to_documents_fk");

            builder.HasOne(p => p.DocumentType)
                   .WithMany(p => p.Documents)
                   .HasForeignKey(p => p.DocumentTypeId)
                   .HasConstraintName("1tomany_document_type_to_documents_fk");

            builder.HasOne(p => p.Counterparty)
                   .WithMany(p => p.Documents)
                   .HasForeignKey(p => p.CounterpartyId)
                   .HasConstraintName("1tomany_counterparty_to_documents_fk");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasMany(p => p.MovementsHistory)
                   .WithOne(p => p.Document)
                   .HasForeignKey(p => p.DocumentId)
                   .HasConstraintName("manyto1_movements_to_documents_fk");

            builder.HasMany(p => p.Shipments)
                   .WithOne(p => p.Document)
                   .HasForeignKey(p => p.DocumentId)
                   .HasConstraintName("manyto1_shipments_to_documents_fk");
        }
    }
}
