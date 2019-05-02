using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Core.ViewModels;
using Receiptionist.Infrastructure;
using System.Collections.Generic;

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
            Setting setting = new Setting();

            if (GeneralSetting.GeneralNameJson != null)
            {
                setting = SimpleJson.DeserializeObject<Setting>(GeneralSetting.GeneralNameJson);
            }
            else
            {
                setting.HasBarcode = false;
            }

            if (setting == null || setting.HasBarcode == true  )
            {
                this.NavigationService.Navigate<IntroViewModel>(new NavigationParameter());
            }
            else if (setting.HasBarcode == false )
            {
                this.NavigationService.Navigate<SearchPhoneViewModel>(new NavigationParameter());
            }
        }

        public void ExecuteSetting(object parameter)
        {
            this.NavigationService.Navigate<SettingViewModel>(new NavigationParameter());
        }
        #endregion
    }
}