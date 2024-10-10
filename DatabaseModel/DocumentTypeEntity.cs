namespace DatabaseModel
{
    public class DocumentTypeEntity
    {
        public int Id { get; set; }
        public required string DoctypeName { get; set; }
        public required string Description { get; set; }
        public virtual ICollection<DocumentEntity> Documents { get; set; } = [];
    }
}
