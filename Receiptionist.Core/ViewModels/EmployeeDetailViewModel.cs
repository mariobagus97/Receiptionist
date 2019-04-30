using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Intersoft.Crosslight;
using System.Collections.Generic;
using System.Text;

namespace Receiptionist.Core.ViewModels
{
    public class EmployeeDetailViewModel : EditorViewModelBase<Employee>
    {
        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            Meeting meeting = new Meeting();
            meeting = parameter.Data as Meeting;

            Employee emplo = new Employee();

            foreach (var meetingin in meeting.Employees)
            {
                emplo.Name = meetingin.Name;
                emplo.Company = meetingin.Company;
            }
            this.Item = emplo;
        }
    }
}
