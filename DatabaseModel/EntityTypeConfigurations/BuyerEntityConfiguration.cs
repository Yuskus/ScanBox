п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class BuyerEntityConfiguration : IEntityTypeConfiguration<BuyerEntity>
    {
        public void Configure(EntityTypeBuilder<BuyerEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_buyer_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("buyers_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.Buyer)
                   .HasForeignKey<BuyerEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_buyer_fk");
        }
    }
}
