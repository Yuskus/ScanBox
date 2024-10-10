using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class BuyerEntityConfiguration : IEntityTypeConfiguration<BuyerEntity>
    {
        public void Configure(EntityTypeBuilder<BuyerEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_buyer_pk");

            // имя таблицы

            builder.ToTable("buyers_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.CounterpartyId)
                   .HasColumnName("counterparty_id");

            // внешние ключи

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.Buyer)
                   .HasForeignKey<BuyerEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_buyer_fk");
        }
    }
}
