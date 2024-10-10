using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class WarehouseEmployeeEntityConfiguration : IEntityTypeConfiguration<WarehouseEmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<WarehouseEmployeeEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_warehouse_employee_pk");

            // имя таблицы

            builder.ToTable("warehouse_employees_table");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.JobTitleId)
                   .HasColumnName("JobTitleId");

            builder.Property(p => p.Surname)
                   .HasMaxLength(255)
                   .IsRequired()
                   .HasColumnName("surname");

            builder.Property(p => p.Name)
                   .HasMaxLength(128)
                   .IsRequired()
                   .HasColumnName("name");

            builder.Property(p => p.Patronymic)
                   .HasMaxLength(255)
                   .HasColumnName("patronymic");

            builder.Property(p => p.Birthday)
                   .HasColumnName("birthday");

            builder.Property(p => p.HireDate)
                   .HasColumnName("hire_date");

            builder.Property(p => p.Address)
                   .HasMaxLength(300)
                   .IsRequired()
                   .HasColumnName("address");

            builder.Property(p => p.Phone)
                   .HasMaxLength(30)
                   .IsRequired()
                   .HasColumnName("phone");

            // внешние ключи

            builder.HasOne(p => p.JobTitle)
                   .WithMany(p => p.WarehouseEmployees)
                   .HasForeignKey(p => p.JobTitleId)
                   .HasConstraintName("1tomany_job_title_to_warehouse_employee_fk");

            builder.HasMany(p => p.Documents)
                   .WithOne(p => p.WarehouseEmployee)
                   .HasForeignKey(p => p.WarehouseEmployeeId)
                   .HasConstraintName("manyto1_documents_to_warehouse_employee_fk");
        }
    }
}
