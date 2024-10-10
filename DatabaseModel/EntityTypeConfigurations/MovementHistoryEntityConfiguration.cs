п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class MovementHistoryEntityConfiguration : IEntityTypeConfiguration<MovementHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<MovementHistoryEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_movement_history_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("movements_history_table");

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.DocumentId)
                   .HasColumnName("document_id");

            builder.Property(p => p.ProductUnitId)
                   .HasColumnName("product_unit_id");

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasOne(p => p.Document)
                   .WithMany(p => p.MovementsHistory)
                   .HasForeignKey(p => p.DocumentId)
                   .HasConstraintName("1tomany_document_to_movement_history_fk");

            builder.HasOne(p => p.ProductUnit)
                   .WithMany(p => p.MovementsHistory)
                   .HasForeignKey(p => p.ProductUnitId)
                   .HasConstraintName("1tomany_product_unit_to_movement_history_fk");

        }
    }
}
