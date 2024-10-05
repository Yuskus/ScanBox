namespace DatabaseModel
{
    public class ProductUnitEntity
    {
        public int Id { get; set; }
        public required string UniqueBarcode { get; set; }
        public DateOnly ProductionDate { get; set; }
        public double RealizationPrice { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductTypeEntity? ProductType { get; set; }
        public int SupplierId { get; set; }
        public virtual SuppilerEntity? Supplier { get; set; }
        public virtual ICollection<MovementHistoryEntity> MovementsHistory { get; set; } = [];
    }
}
