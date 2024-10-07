using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO
{
    public class IndividualGetDTO
    {
        public int Id { get; set; }
        public int CounterpartyId { get; set; }      
        public required string Surname { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
    }
}
