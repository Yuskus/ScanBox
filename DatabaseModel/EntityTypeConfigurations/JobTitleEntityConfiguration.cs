п»їusing Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class JobTitleEntityConfiguration : IEntityTypeConfiguration<JobTitleEntity>
    {
        public void Configure(EntityTypeBuilder<JobTitleEntity> builder)
        {
            // РїРµСЂРІРёС‡РЅС‹Р№ РєР»СЋС‡

            builder.HasKey(p => p.Id)
                   .HasName("id_job_title_pk");

            // РёРјСЏ С‚Р°Р±Р»РёС†С‹

            builder.ToTable("job_titles_table");

            // РёРЅРґРµРєСЃС‹

            builder.HasIndex(p => p.Name)
                   .IsUnique();

            // РёРјРµРЅР° СЃРІРѕР№СЃС‚РІ

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

            // РІРЅРµС€РЅРёРµ РєР»СЋС‡Рё

            builder.HasMany(p => p.WarehouseEmployees)
                   .WithOne(p => p.JobTitle)
                   .HasForeignKey(p => p.JobTitleId)
                   .HasConstraintName("manyto1_warehouse_employees_to_job_title_fk");
        }
    }
}
