using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Navtech.Models
{
    public class ApiResultModel<T>
    {
        public string Response { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string ErrorCode { get; set; }

    }
}