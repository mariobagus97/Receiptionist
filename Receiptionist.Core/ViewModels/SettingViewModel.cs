using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Mobile;
using Intersoft.Crosslight.ViewModels;
using Receiptionist.Core.FormMetaData;
using Receiptionist.Core.Models;
using System;
using System.ComponentModel;

namespace Receiptionist.Core.ViewModels
{
    public class SettingViewModel : EditorViewModelBase<Setting>
    {
        #region Constructor
        public SettingViewModel()
        {
            string dbName = "receptionist.db3";

            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteAsyncConnection>>();

            this.Db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));

        }
        #endregion

        #region Properties
        protected ISQLiteAsyncConnection Db
        {
            get; set;
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
            
            GeneralSetting generalsetting = new GeneralSetting()
            { SettingId = this.Item.SettingId, GeneralName = this.Item.GeneralName, GeneralNameJson = data };
            
            await Db.UpdateAsync(generalsetting);
            base.ExecuteSave(parameter);
        }
        
        public  override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
            this.Item = parameter.Data as Setting;
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
