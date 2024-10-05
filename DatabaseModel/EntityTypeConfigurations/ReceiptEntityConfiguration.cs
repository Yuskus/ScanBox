using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class ReceiptEntityConfiguration : IEntityTypeConfiguration<ReceiptEntity>
    {
        public void Configure(EntityTypeBuilder<ReceiptEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_receipt_pk");

            // имя таблицы

            builder.ToTable("receipts_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
