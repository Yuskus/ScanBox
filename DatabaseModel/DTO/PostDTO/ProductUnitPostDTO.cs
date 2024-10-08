﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO.PostDTO
{
    internal class ProductUnitPostDTO
    {
        public required string UniqueBarcode { get; set; }
        public DateOnly ProductionDate { get; set; }
        public double RealizationPrice { get; set; }
        public int ProductTypeId { get; set; }
        public int SupplierId { get; set; }
    }
}
