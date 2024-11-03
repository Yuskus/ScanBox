using System.ComponentModel.DataAnnotations;

namespace DatabaseModel
{
    public class WarehouseEmployeeEntity
    {
        public int Id { get; set; }
        public int JobTitleId { get; set; }
        public virtual JobTitleEntity? JobTitle { get; set; }
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly Birthday { get; set; }
        public DateOnly HireDate { get; set; }
        public required string Address { get; set; }

        [Phone]
        public required string Phone { get; set; }
        public virtual ICollection<DocumentEntity> Documents { get; set; } = [];
    }
}
