namespace DatabaseModel
{
    public class PricesEntity
    {
        public int ProductTypeId { get; set; } // PK & FK
        public virtual ProductTypeEntity? ProductType { get; set; }
        public double MinPrice { get; set; }
        public double RetailPrice { get; set; }
        public double WholesalePrice { get; set; }
    }
}
