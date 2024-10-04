namespace DatabaseModel
{
    public class ProductTypeEntity
    {
        public int Id { get; set; }
        public required string Barcode { get; set; }
        public required string ProductName { get; set; }
        public double Length { get; set; }
        public double Heigth { get; set; }
        public double Width { get; set; }
        public double Weigth { get; set; }
        public int CategoryId { get; set; }
        public virtual ProductCategoryEntity? Category { get; set; }
        public int ManufacturerId { get; set; }
        public virtual ManufacturerEntity? Manufacturer { get; set; }
        public int ProductPriceId { get; set; }
        public virtual PricesEntity? ProductPrice { get; set; }
        public virtual ICollection<ProductUnitEntity> ProductUnits { get; set; } = [];
        public virtual ICollection<MarkdownEntity> Markdowns { get; set; } = [];
    }
}
