﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO
{
    public class DocumentTypeDTO
    {
        public int Id { get; set; }
        public required string DoctypeName { get; set; }
        public required string Description { get; set; }        
    }
}