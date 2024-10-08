using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.PostDTO
{
    internal class SupplierPostDTO //AutoMapper может не сопоставить модель с сущностью Suppiler
    {
        public int CounterpartyId { get; set; }
    }
}
