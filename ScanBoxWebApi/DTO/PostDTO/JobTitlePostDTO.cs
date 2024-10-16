namespace ScanBoxWebApi.DTO.PostDTO
{
    public class JobTitlePostDTO
    {
        public required string Name { get; set; }
        public string? DutiesDescription { get; set; }
        public double BaseSalary { get; set; }
    }
}
