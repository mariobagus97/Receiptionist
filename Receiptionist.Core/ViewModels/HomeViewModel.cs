using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.ViewModels;
using Receiptionist.Infrastructure;

namespace Receiptionist.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        #region Constructors

        public  HomeViewModel()
        {
            this.MeetingCommand = new DelegateCommand(ExecuteMeeting);
            this.SettingCommand = new DelegateCommand(ExecuteSetting);
        }
        #endregion

        #region Properties

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }

        public DelegateCommand MeetingCommand { get; set; }
        public DelegateCommand SettingCommand { get; set; }

        #endregion

        #region Methods

        public void ExecuteMeeting(object parameter)
        {
            if (this.AppViewModel.Setting.HasBarcode)
                this.NavigationService.Navigate<IntroViewModel>(new NavigationParameter());
            else
                this.NavigationService.Navigate<SearchPhoneViewModel>(new NavigationParameter());
        }

        public void ExecuteSetting(object parameter)
        {
            this.NavigationService.Navigate<SettingViewModel>(new NavigationParameter());
        }

        #endregion
    }
}