using Intersoft.Crosslight;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.FormMetaData;
using Receiptionist.Core.Models;
using Receiptionist.Core.ModelServices.Infrastructure;
using Receiptionist.Infrastructure;
using System;
using System.ComponentModel;

namespace Receiptionist.Core.ViewModels
{
    public class SettingViewModel : EditorViewModelBase<Setting>
    {
        #region Constructor
        public SettingViewModel()
        {
        }
        #endregion

        #region Properties
        

        public AppViewModel AppViewModel
        {
            get { return Container.Current.Resolve<AppViewModel>(); }
        }

        public IGeneralSettingRepository GeneralSettingRepository
        {
            get { return Container.Current.Resolve<IGeneralSettingRepository>(); }
        }

        public override Type FormMetadataType
        {
            get { return typeof(SettingFormMetaData); }
        }
        #endregion

        #region Method
        protected override void ExecuteCancel(object parameter)
        {
            base.ExecuteCancel(parameter);
        }
        
        protected async override void ExecuteSave(object parameter)
        {
            AppViewModel.GeneralSetting.GeneralNameJson = SimpleJson.SerializeObject(this.Item);
            await GeneralSettingRepository.UpdateAsync(AppViewModel.GeneralSetting);
            AppViewModel.Setting = this.Item;
            base.ExecuteSave(parameter);
        }
        
        public  override void Navigated(NavigatedParameter parameter)
        {
            this.Item = new Setting();
            if (!string.IsNullOrEmpty(AppViewModel.Setting.GeneralName))
                this.Item = AppViewModel.Setting;
            else
            {
                this.Item.GeneralName = AppViewModel.GeneralSetting.GeneralName;
                this.Item.SettingId = AppViewModel.GeneralSetting.SettingId;
            }
            base.Navigated(parameter);
        }

        protected override void OnItemChanged(Setting newItem)
        {
            base.OnItemChanged(newItem);
        }

        protected override void OnItemPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnItemPropertyChanged(e);
        }

        #endregion
    }
}
