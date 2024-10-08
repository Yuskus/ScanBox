using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.GetDTO
{
    public class CounterpartyTypeGetDTO
    {
        public int Id { get; set; }
        public required string TypeName { get; set; }
    }
}
