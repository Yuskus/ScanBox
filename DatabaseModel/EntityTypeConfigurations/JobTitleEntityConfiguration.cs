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

            builder.HasIndex(p => p.Name)
                   .IsUnique();

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.Name)
                   .HasMaxLength(100)
                   .HasColumnName("name");

            builder.Property(p => p.DutiesDescription)
                   .HasMaxLength(300)
                   .HasColumnName("duties_description");

            builder.Property(p => p.BaseSalary)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("base_salary");

            // внешние ключи

            builder.HasMany(p => p.WarehouseEmployees)
                   .WithOne(p => p.JobTitle)
                   .HasForeignKey(p => p.JobTitleId)
                   .HasConstraintName("manyto1_warehouse_employees_to_job_title_fk");
        }
    }
}
