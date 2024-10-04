namespace DatabaseModel
{
    public class MarkdownEntity
    {
        public int Id { get; set; }
        public required string UniqueBarcode { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductTypeEntity? ProductType { get; set; }
        public double CurrentPrice { get; set; }
        public string? MarkdownReason { get; set; }
    }
}
