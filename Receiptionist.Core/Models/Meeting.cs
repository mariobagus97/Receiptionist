using Receiptionist.Models;
using Intersoft.Crosslight;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Receiptionist.Core.Models
{
    [Serializable]
    public class Meeting : ModelBase
    {
        #region Constructors
       public Meeting()
        {
        }
        #endregion

        #region Properties

        public System.Guid MeetingID { get; set; }
        public string MeetingPin { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string Purpose { get; set; }
        public string MeetingKey { get; set; }

        public string NameEmployee { get; set; }
        public string NameVisitor { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Visitor> Visitors { get; set; }

        #endregion
        
    }
}
