namespace ScanBoxWebApi.DTO.PostDTO
{
    public class CounterpartyPostDTO
    {
        public int CounterpartyTypeId { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
    }
}
