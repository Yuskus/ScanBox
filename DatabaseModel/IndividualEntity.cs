namespace DatabaseModel
{
    public class IndividualEntity
    {
        public int Id { get; set; }
        public int CounterpartyId { get; set; }
        public virtual CounterpartyEntity? Counterparty { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
    }
}
