namespace ScanBoxWebApi.DTO.PostDTO
{
    public class ProductUnitPostDTO
    {
        public required string UniqueBarcode { get; set; }
        public DateOnly ProductionDate { get; set; }
        public double RealizationPrice { get; set; }
        public int ProductTypeId { get; set; }
        public int SupplierId { get; set; }
    }
}
