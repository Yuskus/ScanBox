namespace DatabaseModel
{
    public class DocumentEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int WarehouseEmployeeId { get; set; }
        public virtual WarehouseEmployeeEntity? WarehouseEmployee { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual DocumentTypeEntity? DocumentType { get; set; }
        public virtual ICollection<ReceiptEntity> Receipts { get; set; } = [];
        public virtual ICollection<RealizationEntity> Realizations { get; set; } = [];
        public virtual ICollection<MovementHistoryEntity> Movements { get; set; } = [];
    }
}
