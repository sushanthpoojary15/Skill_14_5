using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaboSphere.Common.Model
{
    public class Response
    {

        public string ResponseMessage { get; set; }

        public string ResponseStatusCode { get; set; }


        public DateTime ResponseTime = DateTime.Now;

        public dynamic Result { get; set; }
    }
}
