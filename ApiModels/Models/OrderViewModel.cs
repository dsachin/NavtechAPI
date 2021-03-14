using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navtech.Models
{
    public class OrderViewModel : BaseModel
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentTypeId { get; set; }
        
    }
}