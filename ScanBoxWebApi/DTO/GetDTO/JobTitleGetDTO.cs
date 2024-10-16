namespace ScanBoxWebApi.DTO.GetDTO
{
    public class JobTitleGetDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? DutiesDescription { get; set; }
        public double BaseSalary { get; set; }
    }
}
