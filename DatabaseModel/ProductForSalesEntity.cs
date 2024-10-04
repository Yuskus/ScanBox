namespace DatabaseModel
{
    public class ProductForSalesEntity
    {
        public int Id { get; set; }
        public int SalesInvoiceId { get; set; }
        public virtual SalesInvoiceEntity? SalesInvoice { get; set; }
        public Guid ProductUnitUID { get; set; }
        public virtual ProductUnitEntity? ProductUnit { get; set; }
        public int Quantity { get; set; }
    }
}
