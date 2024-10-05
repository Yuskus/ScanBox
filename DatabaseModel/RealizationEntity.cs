namespace DatabaseModel
{
    public class RealizationEntity
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public virtual DocumentEntity? Document { get; set; }
        public int BuyerId { get; set; }
        public virtual BuyerEntity? Buyer { get; set; }
    }
}
