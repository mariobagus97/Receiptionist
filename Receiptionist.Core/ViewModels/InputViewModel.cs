using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Core.ViewModels;
using Receiptionist.Infrastructure;
using System;

namespace Receiptionist.ViewModels
{
    public class InputViewModel : ViewModelBase
    {

        #region Constructors
        public InputViewModel()
        {
            this.SearchCommand = new DelegateCommand(ExecuteScan);
            this.Meeting = new Meeting();
        }

        #endregion

        #region Properties
        public MeetingRepository MeetingRepository { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        public string SearchPin { get; set; }
        public string SearchKey { get; set; }
        public Meeting Meeting { get; set; }

        //public IVisitorRepository VisitorRepository
        //{
        //    get { return Container.Current.Resolve<IVisitorRepository>(); }
        //}

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }

        #endregion

        #region Methods

        protected async void ExecuteScan(object parameter)
        {
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
                    Meeting.MeetingPin = this.SearchPin;
                    Meeting.MeetingKey = this.SearchKey;
                    
                    Meeting Meetingin = await this.MeetingRepository.GetMeetingAsync(Meeting);
                    if (Meetingin == null)
                    {
                        this.MessagePresenter.Show("Data tidak ditemukan");
                    }
                    else
                    {
                        AppViewModel.Meeting = Meetingin;
                        this.NavigationService.Navigate<MeetingDetailViewModel>(new NavigationParameter() );
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
