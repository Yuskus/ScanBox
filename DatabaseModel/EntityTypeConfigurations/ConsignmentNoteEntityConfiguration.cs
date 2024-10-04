using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ConsignmentNoteEntityConfiguration : IEntityTypeConfiguration<ConsignmentNoteEntity>
    {
        public void Configure(EntityTypeBuilder<ConsignmentNoteEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_consignment_note_pk");

            // имя таблицы

            builder.ToTable("consignment_notes");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.ReceiptDate)
                   .HasColumnType("timestamp")
                   .HasColumnName("receipt_date");

            builder.Property(p => p.SuppilerId)
                   .HasColumnName("suppiler_id");

            builder.Property(p => p.WarehouseEmployeeId)
                   .HasColumnName("warehouse_employee_id");

            // внешние ключи, связи 1 к 1

            builder.HasOne(p => p.Suppiler)
                   .WithMany(p => p.ConsignmentNotes)
                   .HasForeignKey(p => p.SuppilerId)
                   .HasConstraintName("suppiler_id_to_consignment_notes_fk");

            builder.HasOne(p => p.WarehouseEmployee)
                   .WithMany(p => p.ConsignmentNotes)
                   .HasForeignKey(p => p.WarehouseEmployeeId)
                   .HasConstraintName("warehouse_employee_to_consignment_notes_fk");

            // внешние ключи, связи 1 ко многим

            builder.HasMany(p => p.ProductsForReceipt)
                   .WithOne(p => p.ConsignmentNote)
                   .HasForeignKey(p => p.ConsignmentNoteId)
                   .HasConstraintName("products_for_receipt_to_consignment_notes_fk");
        }
    }
}
