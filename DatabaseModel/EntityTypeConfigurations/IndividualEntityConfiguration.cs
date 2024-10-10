п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class IndividualEntityConfiguration : IEntityTypeConfiguration<IndividualEntity>
    {
        public void Configure(EntityTypeBuilder<IndividualEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_individual_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("individuals_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            builder.Property(p => p.Surname)
                   .HasMaxLength(255)
                   .HasColumnName("surname");

            builder.Property(p => p.Name)
                   .HasMaxLength(128)
                   .HasColumnName("name");

            builder.Property(p => p.Patronymic)
                   .HasMaxLength(255)
                   .HasColumnName("patronymic");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.Individual)
                   .HasForeignKey<IndividualEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_individual_fk");
        }
    }
}
