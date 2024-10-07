﻿namespace DatabaseModel.DTO.PostDTO
{
    public class CounterpartyPostDTO
    {
        public int Id { get; set; }
        public int CounterpartyTypeId { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }
    }
}
