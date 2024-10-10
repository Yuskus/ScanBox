using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class LegalFormEntityConfiguration : IEntityTypeConfiguration<LegalFormEntity>
    {
        public void Configure(EntityTypeBuilder<LegalFormEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_legal_form_pk");

            // имя таблицы

            builder.ToTable("legal_forms_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.LegalFormName)
                   .IsRequired()
                   .HasMaxLength(64)
                   .HasColumnName("legal_form_name");

            builder.Property(p => p.Description)
                   .HasMaxLength(500)
                   .HasColumnName("product_name");

            // внешние ключи

            builder.HasMany(p => p.LegalEntities)
                   .WithOne(p => p.LegalForm)
                   .HasForeignKey(p => p.LegalFormId)
                   .HasConstraintName("manyto1_legal_entities_to_legal_forms_fk");
        }
    }
}
