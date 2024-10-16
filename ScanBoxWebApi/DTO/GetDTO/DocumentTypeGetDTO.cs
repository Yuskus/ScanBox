namespace ScanBoxWebApi.DTO.GetDTO
{
    public class DocumentTypeGetDTO
    {
        public int Id { get; set; }
        public required string DoctypeName { get; set; }
        public required string Description { get; set; }
    }
}
