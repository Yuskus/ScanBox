using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.GetDTO
{
    internal class WarehouseEmployeeGetDTO
    {
        public int Id { get; set; }
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
