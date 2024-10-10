п»їnamespace DatabaseModel
{
    public class ProductCategoryEntity
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<ProductTypeEntity> ProductTypes { get; set; } = [];
    }
}
