namespace DatabaseModel
{
    public class CounterpartyEntity
    {
        public int Id { get; set; }
        public int CounterpartyTypeId { get; set; }
        public virtual CounterpartyTypeEntity? CounterpartyType { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public virtual BuyerEntity? Buyer { get; set; }
        public virtual ManufacturerEntity? Manufacturer { get; set; }
        public virtual SuppilerEntity? Suppiler { get; set; }
        public virtual IndividualEntity? Individual { get; set; }
        public virtual LegalEntityEntity? LegalEntity { get; set; }
        public virtual ICollection<DocumentEntity> Documents { get; set; } = [];
    }
}
