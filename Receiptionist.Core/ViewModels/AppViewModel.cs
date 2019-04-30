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
            MeetingRepository = new MeetingRepository();
        }
        #endregion

        #region Fields
        
        #endregion

        #region Properties
        public Meeting Meeting { get; set; }
        private MeetingRepository MeetingRepository;
        #endregion


        #region Methods

        public async Task<Meeting> CreateMeeting (Meeting meeting)
        {
            Meeting = await this.MeetingRepository.InsertAsync(meeting);
            return Meeting;
        }
        #endregion
    }
}
