﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.DTO
{
    public class PricesGetDTO
    {
        public int ProductTypeId { get; set; }         
        public double MinPrice { get; set; }
        public double RetailPrice { get; set; }
        public double WholesalePrice { get; set; }
    }
}
