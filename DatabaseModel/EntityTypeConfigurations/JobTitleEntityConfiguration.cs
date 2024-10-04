using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class JobTitleEntityConfiguration : IEntityTypeConfiguration<JobTitleEntity>
    {
        public void Configure(EntityTypeBuilder<JobTitleEntity> builder)
        {
            // первичный ключ
            // имя таблицы
            // индексы
            // имена свойств
            // внешние ключи, связи 1 к 1
            // внешние ключи, связи 1 ко многим
        }
    }
}
