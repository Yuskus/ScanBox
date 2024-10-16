namespace ScanBoxWebApi.DTO.PostDTO
{
    public class PricesPostDTO
    {
        public int ProductTypeId { get; set; }
        public double MinPrice { get; set; }
        public double RetailPrice { get; set; }
        public double WholesalePrice { get; set; }
    }
}
