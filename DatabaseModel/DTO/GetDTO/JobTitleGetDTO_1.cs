namespace DatabaseModel.DTO.GetDTO
{
    public class JobTitleGetDTO
    {
        public int Id { get; set; }
        public int CounterpartyId { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
    }
}
