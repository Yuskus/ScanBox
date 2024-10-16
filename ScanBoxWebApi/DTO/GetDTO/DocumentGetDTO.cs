namespace ScanBoxWebApi.DTO.GetDTO
{
    public class DocumentGetDTO
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int Number { get; set; }
        public int WarehouseEmployeeId { get; set; }
        public int DocumentTypeId { get; set; }
        public int CounterpartyId { get; set; }
    }
}
