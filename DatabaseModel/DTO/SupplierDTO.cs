using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO
{
    internal class SupplierDTO //AutoMapper может не сопоставить модель с сущностью Suppiler
    {
        public int Id { get; set; }
        public int CounterpartyId { get; set; }       
    }
}
