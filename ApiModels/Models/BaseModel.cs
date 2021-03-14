using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navtech.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int Status { get; set; }
    }

}