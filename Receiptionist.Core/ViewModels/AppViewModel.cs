using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using System.Threading.Tasks;

namespace Receiptionist.Core.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        #region Constructor
        public AppViewModel()
        {
            _meetingRepository = new MeetingRepository();
        }
        #endregion

        #region Fields
        private Meeting _meeting;
        private MeetingRepository _meetingRepository;
        #endregion

        #region Properties
        public Meeting Meeting { get; set; }
        #endregion


        #region Methods

        public async Task<Meeting> CreateMeeting (Meeting meeting)
        {
            Meeting = await this._meetingRepository.InsertAsync(meeting);
            return Meeting;
        }
        #endregion
    }
}
