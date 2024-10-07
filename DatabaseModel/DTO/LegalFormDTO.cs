﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO
{
    public class LegalFormDTO
    {
        public int Id { get; set; }
        public required string LegalFormName { get; set; }
        public string? Description { get; set; }
    }
}