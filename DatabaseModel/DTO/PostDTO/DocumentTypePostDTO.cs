using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.PostDTO
{
    public class DocumentTypePostDTO
    {
        public required string DoctypeName { get; set; }
        public required string Description { get; set; }
    }
}
