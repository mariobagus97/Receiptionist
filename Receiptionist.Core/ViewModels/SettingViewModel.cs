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
        
        public GeneralSetting GeneralSetting
        {
            get { return Container.Current.Resolve<GeneralSetting>(); }
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
            string data = SimpleJson.SerializeObject(this.Item);

            GeneralSetting.GeneralNameJson = data;

            await GeneralSettingRepository.UpdateAsync(GeneralSetting);
            base.ExecuteSave(parameter);
        }
        
        public  override void Navigated(NavigatedParameter parameter)
        {
            this.Item = new Setting();
            if (GeneralSetting.GeneralNameJson != null)
            {
                this.Item = SimpleJson.DeserializeObject<Setting>(GeneralSetting.GeneralNameJson);
            }
            else
            {
                this.Item.GeneralName = GeneralSetting.GeneralName;
                this.Item.SettingId = GeneralSetting.SettingId;
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
