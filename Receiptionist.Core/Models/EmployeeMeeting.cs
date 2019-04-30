using Receiptionist.Models;
using Intersoft.Crosslight;
using System;
using System.Runtime.Serialization;

namespace Receiptionist.Core.Models
{
    [Serializable]
    public class EmployeeMeeting : ModelBase
    {
        #region Constructors
        public EmployeeMeeting()
        {

        }
        #endregion


        #region Properties

        public System.Guid EmployeeMeetingID { get; set; }
        public Nullable<System.Guid> MeetingID { get; set; }
        public Nullable<System.Guid> EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Meeting Meeting { get; set; }

        #endregion
    }
}
