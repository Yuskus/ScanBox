using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class MovementHistoryEntityConfiguration : IEntityTypeConfiguration<MovementHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<MovementHistoryEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_movement_history_pk");

            // имя таблицы

            builder.ToTable("movements_history_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
