namespace ScanBoxWebApi.DTO.GetDTO
{
    public class PricesGetDTO
    {
        public int ProductTypeId { get; set; }
        public double MinPrice { get; set; }
        public double RetailPrice { get; set; }
        public double WholesalePrice { get; set; }
    }
}
