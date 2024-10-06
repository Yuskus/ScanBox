using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO
{
    public class CounterpartyDTO
    {
        public int Id { get; set; }
        public int CounterpartyTypeId { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; }       
    }
}
