using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.GetDTO
{
    public class LegalEntityGetDTO
    {
        public int Id { get; set; }
        public int CounterpartyId { get; set; }
        public int LegalFormId { get; set; }
        public required string NameOfLegalEntity { get; set; }
        public required string DirectorsSurname { get; set; }
        public required string DirectorsName { get; set; }
        public string? DirectorsPatronymic { get; set; }
        public required string INN { get; set; }
        public required string KPP { get; set; }
        public required string OGRN { get; set; }
        public required string LegalAddress { get; set; }
        public string? ContactPerson { get; set; }
    }
}
