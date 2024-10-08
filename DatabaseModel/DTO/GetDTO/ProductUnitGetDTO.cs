namespace DatabaseModel.DTO.GetDTO
{
    public class ProductUnitGetDTO
    {
        public int Id { get; set; }
        public required string UniqueBarcode { get; set; }
        public DateOnly ProductionDate { get; set; }
        public double RealizationPrice { get; set; }
        public int ProductTypeId { get; set; }
        public int SupplierId { get; set; }
    }
}
