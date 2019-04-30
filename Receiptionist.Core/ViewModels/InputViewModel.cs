using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ViewModels;
using System;

namespace Receiptionist.ViewModels
{
    public class InputViewModel :ViewModelBase 
    {

        #region Constructors
        public InputViewModel()
        {
            this.SearchCommand = new DelegateCommand(ExecuteScan);
        }

        #endregion

        #region Properties
        public MeetingRepository MeetingRepository { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        public string SearchPin { get; set; }
        public string SearchKey { get; set; }

        #endregion

        #region Methods

        protected async void ExecuteScan(object parameter)
        {
            Meeting Meeting = new Meeting
            {
                MeetingPin = this.SearchPin,
                MeetingKey = this.SearchKey
            };
            
            try
            {
                if (string.IsNullOrEmpty(this.SearchPin) && string.IsNullOrEmpty(this.SearchKey))
                {
                    this.MessagePresenter.Show("Mohon diisi dengan lengkap !");
                }

                else if (!string.IsNullOrEmpty(this.SearchPin) && string.IsNullOrEmpty(this.SearchKey))
                {
                    this.MessagePresenter.Show("Meeting ID harap di isi");
                }

                else if (string.IsNullOrEmpty(this.SearchPin) && !string.IsNullOrEmpty(this.SearchKey))
                {
                    this.MessagePresenter.Show("Meeting Code harap di isi");
                }

                else if (!string.IsNullOrEmpty(this.SearchPin) && !string.IsNullOrEmpty(this.SearchKey))
                {
                    Meeting Meetingin = await this.MeetingRepository.GetMeetingAsync(Meeting);
                    if (Meetingin == null)
                    {
                        this.MessagePresenter.Show("Data tidak ditemukan");
                    }
                    else
                    {
                        this.NavigationService.Navigate<MeetingDetailViewModel>(new NavigationParameter() { Data = Meetingin });
                    }
                }
            }

            catch (Exception ex)
            {
                this.MessagePresenter.Show(ex.Message);
            }
        }
        #endregion
    }
}
