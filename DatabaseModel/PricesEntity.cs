﻿namespace DatabaseModel
{
    public class PricesEntity
    {
        public int ProductTypeId { get; set; }
        public virtual ProductTypeEntity? ProductType { get; set; }
        public double MinPrice { get; set; }
        public double RetailPrice { get; set; }
        public double WholesalePrice { get; set; }
        public virtual ICollection<ProductTypeEntity> ProductTypes { get; set; } = [];
    }
}
