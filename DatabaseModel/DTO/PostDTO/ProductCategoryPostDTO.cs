﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.PostDTO
{
    public class ProductCategoryPostDTO
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
