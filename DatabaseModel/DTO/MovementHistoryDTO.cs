using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO
{
    public class MovementHistoryDTO
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }        
        public int ProductUnitId { get; set; }       
    }
}
