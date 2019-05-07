using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
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

        public GeneralSetting GeneralSetting
        {
            get { return Container.Current.Resolve<GeneralSetting>(); }
        }
        public DelegateCommand MeetingCommand { get; set; }
        public DelegateCommand SettingCommand { get; set; }

        #endregion

        #region Methods

        public void ExecuteMeeting(object parameter)
        {
            Setting setting = null;

            if (!string.IsNullOrEmpty(this.GeneralSetting.GeneralNameJson))
                setting = SimpleJson.DeserializeObject<Setting>(GeneralSetting.GeneralNameJson);
            else
                setting = new Setting();

            if (setting.HasBarcode)
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