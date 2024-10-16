namespace ScanBoxWebApi.DTO.GetDTO
{
    public class LegalFormGetDTO
    {
        public int Id { get; set; }
        public required string LegalFormName { get; set; }
        public string? Description { get; set; }
    }
}
