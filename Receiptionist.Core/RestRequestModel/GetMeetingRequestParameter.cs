using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receiptionist.Core.RestRequestModel
{
   public class GetMeetingRequestParameter
    {
        public string MeetingKey { get; set; }
        public string MeetingPin { get; set; }
    }
}
