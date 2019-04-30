using Receiptionist.Models;
using Intersoft.Crosslight;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Receiptionist.Core.Models
{
    [Serializable]
    public class Employee : ModelBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
           // this.EmployeeMeetings = new HashSet<EmployeeMeeting>();
        }


        public Nullable<System.Guid> EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }

    }
}
