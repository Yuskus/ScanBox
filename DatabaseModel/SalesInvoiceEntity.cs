namespace DatabaseModel
{
    public class SalesInvoiceEntity
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public int BuyerId { get; set; }
        public virtual BuyerEntity? Buyer { get; set; }
        public int WarehouseEmployeeId { get; set; }
        public virtual WarehouseEmployeeEntity? WarehouseEmployee { get; set; }
        public virtual ICollection<ProductForSalesEntity> ProductsForSales { get; set; } = [];
    }
}
