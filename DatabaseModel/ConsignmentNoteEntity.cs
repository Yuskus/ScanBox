namespace DatabaseModel
{
    public class ConsignmentNoteEntity
    {
        public int Id { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int SuppilerId { get; set; }
        public virtual SuppilerEntity? Suppiler { get; set; }
        public int WarehouseEmployeeId { get; set; }
        public virtual WarehouseEmployeeEntity? WarehouseEmployee { get; set; }
        public virtual ICollection<ProductForReceiptEntity> ProductsForReceipt { get; set; } = [];
    }
}
