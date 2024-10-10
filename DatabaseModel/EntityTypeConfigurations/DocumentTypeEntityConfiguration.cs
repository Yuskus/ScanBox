п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class DocumentTypeEntityConfiguration : IEntityTypeConfiguration<DocumentTypeEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_document_type_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("document_types_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

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

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasMany(p => p.Documents)
                   .WithOne(p => p.DocumentType)
                   .HasForeignKey(p => p.DocumentTypeId)
                   .HasConstraintName("manyto1_document_to_doctype_fk");
        }
    }
}
