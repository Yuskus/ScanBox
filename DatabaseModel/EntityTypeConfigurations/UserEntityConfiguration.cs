using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_user_entity_pk");

            // имя таблицы

            builder.ToTable("user_entities_table");

            // индексы

            builder.HasIndex(p => p.Username)
                   .IsUnique();

            // свойства

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.Username)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("username");

            builder.Property(p => p.Password)
                   .IsRequired()
                   .HasColumnName("password");

            builder.Property(p => p.Salt)
                   .IsRequired()
                   .HasColumnName("salt");

            builder.Property(p => p.CreatedAt)
                   .HasColumnType("timestamp")
                   .HasColumnName("created_at");

            builder.Property(p => p.Role)
                   .HasColumnName("role");
        }
    }
}
