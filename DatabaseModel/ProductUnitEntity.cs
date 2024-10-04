namespace DatabaseModel
{
    public class ProductUnitEntity
    {
        public Guid UID { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductTypeEntity? ProductType { get; set; }
        public required string ProductionPlace { get; set; }
        public DateOnly ProductionDate { get; set; }
        public int SupplierId { get; set; }
        public virtual SuppilerEntity? Supplier { get; set; }
        public virtual ICollection<ProductForReceiptEntity> ProductsForReceipt { get; set; } = [];
    }
}
