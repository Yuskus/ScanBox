using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class IndividualEntityConfiguration : IEntityTypeConfiguration<IndividualEntity>
    {
        public void Configure(EntityTypeBuilder<IndividualEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_individual_pk");

            // имя таблицы

            builder.ToTable("individuals_table");

            // имена свойств

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

            // внешние ключи

            builder.HasOne(p => p.Counterparty)
                   .WithOne(p => p.Individual)
                   .HasForeignKey<IndividualEntity>(p => p.CounterpartyId)
                   .HasConstraintName("1to1_counterparty_to_individual_fk");
        }
    }
}
