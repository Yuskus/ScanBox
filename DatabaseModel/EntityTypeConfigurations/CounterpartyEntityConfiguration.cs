п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class CounterpartyEntityConfiguration : IEntityTypeConfiguration<CounterpartyEntity>
    {
        public void Configure(EntityTypeBuilder<CounterpartyEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_counterparty_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("counterpartys_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyTypeId)
                   .HasColumnName("counterparty_type_id");

            builder.Property(p => p.Address)
                   .HasMaxLength(300)
                   .IsRequired()
                   .HasColumnName("address");

            builder.Property(p => p.Phone)
                   .HasMaxLength(30)
                   .IsRequired()
                   .HasColumnName("phone");

            builder.Property(p => p.Email)
                   .HasMaxLength(128)
                   .HasColumnName("email");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasOne(p => p.Buyer)
                   .WithOne(p => p.Counterparty)
                   .HasForeignKey<BuyerEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_buyer_to_counterparty_fk");

            builder.HasOne(p => p.Manufacturer)
                   .WithOne(p => p.Counterparty)
                   .HasForeignKey<ManufacturerEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_manufacturer_to_counterparty_fk");

            builder.HasOne(p => p.Supplier)
                   .WithOne(p => p.Counterparty)
                   .HasForeignKey<SupplierEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_suppiler_to_counterparty_fk");

            builder.HasOne(p => p.Individual)
                   .WithOne(p => p.Counterparty)
                   .HasForeignKey<IndividualEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_individual_to_counterparty_fk");

            builder.HasOne(p => p.LegalEntity)
                   .WithOne(p => p.Counterparty)
                   .HasForeignKey<LegalEntityEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_legal_entity_to_counterparty_fk");

            builder.HasOne(p => p.CounterpartyType)
                   .WithMany(p => p.Counterparties)
                   .HasForeignKey(p => p.CounterpartyTypeId)
                   .HasConstraintName("1tomany_counterparty_type_to_counterparty_fk");

            builder.HasMany(p => p.Documents)
                   .WithOne(p => p.Counterparty)
                   .HasForeignKey(p => p.CounterpartyId)
                   .HasConstraintName("manyto1_documents_to_counterparty_fk");
        }
    }
}
