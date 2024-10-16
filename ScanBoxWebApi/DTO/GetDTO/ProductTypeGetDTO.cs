namespace ScanBoxWebApi.DTO.GetDTO
{
    public class ProductTypeGetDTO
    {
        public int Id { get; set; }
        public required string Barcode { get; set; }
        public required string ProductName { get; set; }
        public double Length { get; set; }
        public double Heigth { get; set; }
        public double Width { get; set; }
        public double Weigth { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public int ProductPriceId { get; set; }
    }
}
