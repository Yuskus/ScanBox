namespace DatabaseModel
{
    public class BuyerEntity
    {
        public int Id { get; set; }
        public int CounterpartyId { get; set; }
        public virtual CounterpartyEntity? Counterparty { get; set; }
    }
}
