namespace DatabaseModel.DTO.PostDTO
{
    public class IndividualPostDTO
    {
        public int CounterpartyId { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
    }
}
