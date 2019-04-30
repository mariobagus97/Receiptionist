using Receiptionist.Models;
using Intersoft.Crosslight;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Receiptionist.Core.Models
{
    [Serializable]
    public class Visitor : ModelBase
    {
       
        public Visitor()
        {
            //this.VisitorMeetings = new HashSet<VisitorMeeting>();
        }

        public System.Guid VisitorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
    }
}
