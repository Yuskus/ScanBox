namespace DatabaseModel
{
    public class BuyerEntity
    {
        public int Id { get; set; }
        public int? LegalEntityId { get; set; }
        public virtual LegalEntityEntity? LegalEntity { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<RealizationEntity> Realizations { get; set; } = [];
    }
}
