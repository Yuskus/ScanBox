using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseModel.EntityTypeConfigurations
{
    internal class SalesInvoiceEntityConfiguration : IEntityTypeConfiguration<SalesInvoiceEntity>
    {
        /*public virtual BuyerEntity? Buyer { get; set; }

        public virtual WarehouseEmployeeEntity? WarehouseEmployee { get; set; }
        public virtual ICollection<ProductForSalesEntity> ProductsForSales { get; set; } = [];*/
        public void Configure(EntityTypeBuilder<SalesInvoiceEntity> builder)
        {
            // первичный ключ

            builder.HasKey(p => p.Id)
                   .HasName("id_sales_invoice_pk");

            // имя таблицы

            builder.ToTable("sales_invoices");

            // имена свойств

            builder.Property(p => p.Id)
                   .HasColumnName("id");

            builder.Property(p => p.SaleDate)
                   .HasColumnType("timestamp")
                   .HasColumnName("sale_date");

            builder.Property(p => p.BuyerId)
                   .HasColumnName("buyer_id");

            builder.Property(p => p.WarehouseEmployeeId)
                   .HasColumnName("warehouse_employee_id");

            // внешние ключи, связи 1 к 1

            builder.HasOne(p => p.Buyer)
                   .WithMany(p => p.SalesInvoices)
                   .HasForeignKey(p => p.BuyerId)
                   .HasConstraintName("buyer_id_to_sales_invoices_fk");

            builder.HasOne(p => p.WarehouseEmployee)
                   .WithMany(p => p.SalesInvoices)
                   .HasForeignKey(p => p.WarehouseEmployeeId)
                   .HasConstraintName("warehouse_employee_id_to_sales_invoices_fk");

            // внешние ключи, связи 1 ко многим

            builder.HasMany(p => p.ProductsForSales)
                   .WithOne(p => p.SalesInvoice)
                   .HasForeignKey(p => p.SalesInvoiceId)
                   .HasConstraintName("products_for_sales_to_sales_invoices_fk");
        }
    }
}
