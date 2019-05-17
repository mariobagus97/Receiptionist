using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receiptionist.Core.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        #region Constructor
        public AppViewModel()
        {
        }
        #endregion

        #region Properties
        public Meeting Meeting { get; set; }
        public GeneralSetting GeneralSetting { get; set; }
        public Setting Setting { get; set; }
        

        #endregion


        #region Methods

        public void NewMeeting()
        {
            this.Meeting = new Meeting
            {
                Employees = new List<Employee>(),
                Visitors = new List<Visitor>()
            }; 
        }

        public async Task<Meeting> SaveMeeting(Meeting meeting)
        {
            RestRepositoryBase<Meeting> RepositoryMeeting = new RestRepositoryBase<Meeting>();

           Meeting meetings = await RepositoryMeeting.InsertAsync(meeting);

            return meetings;
        }

        #endregion
    }
}
