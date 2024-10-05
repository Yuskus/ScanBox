using DatabaseModel.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DatabaseModel.Context
{
    public class ScanBoxDbContext : DbContext
    {
        private readonly string? _connectionString;
        public virtual DbSet<BuyerEntity> Buyers { get; set; }
        public virtual DbSet<DocumentEntity> Document { get; set; }
        public virtual DbSet<DocumentTypeEntity> DocumentType { get; set; }
        public virtual DbSet<JobTitleEntity> JobTitles { get; set; }
        public virtual DbSet<LegalEntityEntity> LegalEntities { get; set; }
        public virtual DbSet<LegalFormEntity> LegalForms { get; set; }
        public virtual DbSet<ManufacturerEntity> Manufacturers { get; set; }
        public virtual DbSet<MovementHistoryEntity> MovementHistory { get; set; }
        public virtual DbSet<PricesEntity> PricesList { get; set; }
        public virtual DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public virtual DbSet<ProductTypeEntity> ProductTypes { get; set; }
        public virtual DbSet<ProductUnitEntity> ProductUnits { get; set; }
        public virtual DbSet<RealizationEntity> Realizations { get; set; }
        public virtual DbSet<ReceiptEntity> Receipts { get; set; }
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
            modelBuilder.ApplyConfiguration(new DocumentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new JobTitleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LegalEntityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LegalFormEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MovementHistoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PricesEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductUnitEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RealizationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SuppilerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseEmployeeEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
