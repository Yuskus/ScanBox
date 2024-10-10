using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class DocumentEntityConfiguration : IEntityTypeConfiguration<DocumentEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_document_pk");

            // имя таблицы

            builder.ToTable("documents_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.Number)
                   .HasColumnName("number");

            builder.Property(p => p.CreationTime)
                   .HasColumnType("timestamp")
                   .HasColumnName("creation_time");

            builder.Property(p => p.WarehouseEmployeeId)
                   .HasColumnName("warehouse_employee_id");

            builder.Property(p => p.DocumentTypeId)
                   .HasColumnName("document_type_id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // внешние ключи, связи 1 ко многим

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

            // внешние ключи

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
