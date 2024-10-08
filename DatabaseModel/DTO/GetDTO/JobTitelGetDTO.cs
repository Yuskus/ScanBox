using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.GetDTO
{
    public class JobTitelGetDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? DutiesDescription { get; set; }
        public double BaseSalary { get; set; }
    }
}
