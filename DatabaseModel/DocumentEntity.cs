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
        public int CounterpartyId { get; set; }
        public virtual CounterpartyEntity? Counterparty { get; set; }
        public virtual ICollection<MovementHistoryEntity> Movements { get; set; } = [];
    }
}
