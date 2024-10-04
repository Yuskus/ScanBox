namespace DatabaseModel
{
    public class ProductForReceiptEntity
    {
        public int Id { get; set; }
        public int ArrivalReceiptId { get; set; }
        public virtual ConsignmentNoteEntity? ConsignmentNote { get; set; }
        public Guid ProductUnitUID { get; set; }
        public virtual ProductUnitEntity? ProductUnit { get; set; }
        public int Quantity { get; set; }
    }
}
