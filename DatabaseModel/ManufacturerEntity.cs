namespace DatabaseModel
{
    public class ManufacturerEntity
    {
        public int Id { get; set; }
        public int LegalEntityId { get; set; }
        public virtual LegalEntityEntity? LegalEntity { get; set; }
        public virtual ICollection<ProductTypeEntity> ProductTypes { get; set; } = [];
    }
}
