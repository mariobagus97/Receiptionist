using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ViewModels;
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
            GeneralSettingRepository = new GeneralSettingRepository();
        }

        #endregion
        
        #region Properties

        public GeneralSettingRepository GeneralSettingRepository { get; set; }
        public DelegateCommand MeetingCommand { get; set; }
        public DelegateCommand SettingCommand { get; set; }
       

        #endregion

        #region Methods
        
        public async void ExecuteMeeting(object parameter)
        {
            IList<GeneralSetting> generalsetting = await GeneralSettingRepository.GetAllAsync();

            Setting setting = new Setting();

            foreach (var settings in generalsetting)
            {
                setting = SimpleJson.DeserializeObject<Setting>(settings.GeneralNameJson);
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

        public async void ExecuteSetting(object parameter)
        {
            Setting setting = new Setting();

            GeneralSetting generalsetting = await GeneralSettingRepository.GetSingleAsync();

            if (generalsetting.GeneralNameJson != null)
            {
                setting = SimpleJson.DeserializeObject<Setting>(generalsetting.GeneralNameJson);
            }
            else
            {
                setting.GeneralName = generalsetting.GeneralName;
                setting.SettingId = generalsetting.SettingId;
            }
            this.NavigationService.Navigate<SettingViewModel>(new NavigationParameter() {Data = setting } );
        }
        #endregion
    }
}