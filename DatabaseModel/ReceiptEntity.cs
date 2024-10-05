namespace DatabaseModel
{
    public class ReceiptEntity
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public virtual DocumentEntity? Document { get; set; }
        public int SuppilerId { get; set; }
        public virtual SuppilerEntity? Suppiler { get; set; }
    }
}
