using Receiptionist.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiptionist.Core.RestResponeBase
{
    public class ResponseData
    {
        public string ErrorMessage { get; set; }
        
        public Visitor visitor { get; set; }

    }
}
