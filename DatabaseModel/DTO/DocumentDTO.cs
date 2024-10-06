using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public int WarehouseEmployeeId { get; set; }        
        public int DocumentTypeId { get; set; }       
        public int CounterpartyId { get; set; }       
    }
}
