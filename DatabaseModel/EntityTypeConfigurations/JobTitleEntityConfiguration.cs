using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class JobTitleEntityConfiguration : IEntityTypeConfiguration<JobTitleEntity>
    {
        public void Configure(EntityTypeBuilder<JobTitleEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_job_title_pk");

            // имя таблицы

            builder.ToTable("job_titles_table");

            // индексы
            // имена свойств
            // внешние ключи, связи 1 ко многим
            // внешние ключи, связи многие к одному
        }
    }
}
