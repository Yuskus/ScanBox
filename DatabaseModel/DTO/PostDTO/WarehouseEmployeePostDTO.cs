п»їnamespace DatabaseModel.DTO.PostDTO
{
    public class WarehouseEmployeePostDTO
    {
        public int JobTitleId { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly Birthday { get; set; }
        public DateOnly HireDate { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
    }
}
