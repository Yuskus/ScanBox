namespace DatabaseModel
{
    public class SuppilerEntity
    {
        public int Id { get; set; }
        public int CounterpartyId { get; set; }
        public virtual CounterpartyEntity? Counterparty { get; set; }
        public virtual ICollection<ProductUnitEntity> ProductUnits { get; set; } = [];
    }
}
