using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navtech.Models
{
    public class ProductViewModel: BaseModel
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public double StockQuantity { get; set; }
       
    }
}