п»їnamespace DatabaseModel
{
    public class LegalFormEntity
    {
        public int Id { get; set; }
        public required string LegalFormName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<LegalEntityEntity> LegalEntities { get; set; } = [];
    }

}
