using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navtech.Models
{
    public class CustomerDetailsViewModel: BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
             
    }
}