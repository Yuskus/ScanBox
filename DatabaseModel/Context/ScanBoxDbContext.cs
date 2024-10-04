using DatabaseModel.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModel.Context
{
    public class ScanBoxDbContext : DbContext
    {
        private readonly string? _connectionString;
        public virtual DbSet<BuyerEntity> Buyers { get; set; }
        public virtual DbSet<ConsignmentNoteEntity> ConsignmentNotes { get; set; }
        public virtual DbSet<JobTitleEntity> JobTitles { get; set; }
        public virtual DbSet<LegalEntityEntity> LegalEntities { get; set; }
        public virtual DbSet<LegalFormEntity> LegalForms { get; set; }
        public virtual DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public virtual DbSet<MarkdownEntity> Markdowns { get; set; }
        public virtual DbSet<PricesEntity> PricesList { get; set; }
        public virtual DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public virtual DbSet<ProductForReceiptEntity> ProductsForReceipts { get; set; }
        public virtual DbSet<ProductForSalesEntity> ProductsForSales { get; set; }
        public virtual DbSet<ProductTypeEntity> ProductTypes { get; set; }
        public virtual DbSet<ProductUnitEntity> ProductUnits { get; set; }
        public virtual DbSet<SalesInvoiceEntity> SalesInvoices { get; set; }
        public virtual DbSet<SuppilerEntity> Suppilers { get; set; }
        public virtual DbSet<WarehouseEmployeeEntity> WarehouseEmployees { get; set; }
        public ScanBoxDbContext() { }
        public ScanBoxDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ScanBoxDbContext(DbContextOptions<ScanBoxDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuyerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ConsignmentNoteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new JobTitleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LegalEntityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LegalFormEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MarkdownEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PricesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductForReceiptEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductForSalesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductUnitEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SalesInvoiceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SuppilerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseEmployeeEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
