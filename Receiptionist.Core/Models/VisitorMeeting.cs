using Receiptionist.Models;
using Intersoft.Crosslight;
using System;
using System.Runtime.Serialization;

namespace Receiptionist.Core.Models
{
    [Serializable]
    public class VisitorMeeting : ModelBase
    {
        #region Constructors
        public VisitorMeeting()
        {
        }
        #endregion


        #region Properties

        public Guid VisitorMeetingID { get; set; }
        public Nullable<System.Guid> MeetingID { get; set; }
        public Nullable<System.Guid> VisitorID { get; set; }

        public virtual Meeting Meeting { get; set; }
        public virtual Visitor Visitor { get; set; }

        #endregion
    }
}
