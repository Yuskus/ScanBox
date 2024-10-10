using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.GetDTO
{
    public class ShipmentGetDTO
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }        
        public int ProductUnitId { get; set; }        
    }
}
