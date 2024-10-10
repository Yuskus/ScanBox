п»їnamespace DatabaseModel
{
    public class CounterpartyTypeEntity
    {
        public int Id { get; set; }
        public required string TypeName { get; set; }
        public virtual ICollection<CounterpartyEntity> Counterparties { get; set; } = [];
    }
}
