using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class DocumentTypeEntityConfiguration : IEntityTypeConfiguration<DocumentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_document_type_pk");

            // имя таблицы

            builder.ToTable("document_types_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.DoctypeName)
                   .HasMaxLength(128)
                   .IsRequired()
                   .HasColumnName("doctype_name");

            builder.Property(p => p.Description)
                   .HasMaxLength(255)
                   .IsRequired()
                   .HasColumnName("description");

            // внешние ключи

            builder.HasMany(p => p.Documents)
                   .WithOne(p => p.DocumentType)
                   .HasForeignKey(p => p.DocumentTypeId)
                   .HasConstraintName("manyto1_document_to_doctype_fk");
        }
    }
}
