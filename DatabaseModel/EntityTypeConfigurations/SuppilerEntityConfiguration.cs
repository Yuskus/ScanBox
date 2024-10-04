using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class SuppilerEntityConfiguration : IEntityTypeConfiguration<SuppilerEntity>
    {
        public void Configure(EntityTypeBuilder<SuppilerEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_suppiler_pk");

            // имя таблицы

            builder.ToTable("suppilers");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.LegalEntityId)
                   .HasColumnName("legal_entity_id");

            // внешние ключи, связи 1 к 1

            builder.HasOne(p => p.LegalEntity)
                   .WithMany(p => p.Suppliers)
                   .HasForeignKey(p => p.LegalEntityId)
                   .HasConstraintName("legal_entity_id_to_suppiler_fk");

            // внешние ключи, связи 1 ко многим

            builder.HasMany(p => p.ProductUnits)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey(p => p.SupplierId)
                   .HasConstraintName("product_units_to_suppiler_fk");

            builder.HasMany(p => p.ConsignmentNotes)
                   .WithOne(p => p.Suppiler)
                   .HasForeignKey(p => p.SuppilerId)
                   .HasConstraintName("consignment_notes_to_suppiler_fk");
        }
    }
}
