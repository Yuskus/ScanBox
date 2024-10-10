п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class LegalEntityEntityConfiguration : IEntityTypeConfiguration<LegalEntityEntity>
    {
        public void Configure(EntityTypeBuilder<LegalEntityEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_legal_entity_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("legal_entities_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            builder.Property(p => p.LegalFormId)
                   .HasColumnName("legal_form_id");

            builder.Property(p => p.NameOfLegalEntity)
                   .HasMaxLength(128)
                   .IsRequired()
                   .HasColumnName("name_of_legal_entity");

            builder.Property(p => p.DirectorsSurname)
                   .HasMaxLength(255)
                   .IsRequired()
                   .HasColumnName("directors_surname");

            builder.Property(p => p.DirectorsName)
                   .HasMaxLength(128)
                   .IsRequired()
                   .HasColumnName("directors_name");

            builder.Property(p => p.DirectorsPatronymic)
                   .HasMaxLength(255)
                   .HasColumnName("directors_patronymic");

            builder.Property(p => p.INN)
                   .HasMaxLength(32)
                   .IsRequired()
                   .HasColumnName("INN");

            builder.Property(p => p.KPP)
                   .HasMaxLength(32)
                   .IsRequired()
                   .HasColumnName("KPP");

            builder.Property(p => p.OGRN)
                   .HasMaxLength(32)
                   .IsRequired()
                   .HasColumnName("OGRN");

            builder.Property(p => p.LegalAddress)
                   .HasMaxLength(300)
                   .IsRequired()
                   .HasColumnName("legal_adress");

            builder.Property(p => p.ContactPerson)
                   .HasMaxLength(300)
                   .HasColumnName("contact_person");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.LegalEntity)
                   .HasForeignKey<LegalEntityEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_legal_entity_fk");

            builder.HasOne(p => p.LegalForm)
                   .WithMany(p => p.LegalEntities)
                   .HasForeignKey(p => p.LegalFormId)
                   .HasConstraintName("1tomany_legal_form_to_legal_entity_fk");
        }
    }
}
