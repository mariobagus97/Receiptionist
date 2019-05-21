using Receiptionist.ViewModels;
using Receiptionist.Core.Models;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using Receiptionist.Core.ViewModels;
using Receiptionist.Core.ModelServices;
using Receiptionist.Core.ModelServices.Infrastructure;
using Intersoft.Crosslight.Containers;
using Receiptionist.Core.ModelServices.WebApi;

namespace Receiptionist.Infrastructure
{
    public sealed class CrosslightAppAppService : ApplicationServiceBase
    {
        #region Constructors

        public CrosslightAppAppService(IApplicationContext context)
            : base(context)
        {
        }

        #endregion

        #region Methods

        protected override void OnStart(StartParameter parameter)
        {
            base.OnStart(parameter);
            this.InitializeSettingTable();
            this.Initialize();
           // this.InitializeSetting();
            this.InitializeRepositories();

            this.SetRootViewModel<HomeViewModel>();
        }

        private async void Initialize()
        {
            GeneralSettingRepository generalSettingRepository = new GeneralSettingRepository();

            AppViewModel appViewModel = new AppViewModel();
            appViewModel.Meeting = new Meeting
            {
                Employees = new List<Employee>(),
                Visitors = new List<Visitor>()
            };
            appViewModel.GeneralSetting = await generalSettingRepository.GetSingleAsync();

            if (!string.IsNullOrEmpty(appViewModel.GeneralSetting.GeneralNameJson))
                appViewModel.Setting = SimpleJson.DeserializeObject<Setting>(appViewModel.GeneralSetting.GeneralNameJson);
            else
                appViewModel.Setting = new Setting();
            Container.Current.RegisterInstance(appViewModel);
        }
        
        private void InitializeRepositories()
        {
            Container.Current.Register<IVisitorRepository, VisitorRepository>().WithLifetimeManager(new ContainerLifetime());
            Container.Current.Register<IGeneralSettingRepository, GeneralSettingRepository>().WithLifetimeManager(new ContainerLifetime());
            Container.Current.Register<IMeetingRepository, MeetingRepository>().WithLifetimeManager(new ContainerLifetime());

            SskRestRepository SskRestRepository = new SskRestRepository();
            Container.Current.RegisterInstance(SskRestRepository);
        }

        private void InitializeSettingTable()
        {
            string dbName = "receptionist.db3";

            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            var factory = activatorService.CreateInstance<Func<string, ISQLiteConnection>>();

            ISQLiteConnection db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));

            if (!db.TableExists<GeneralSetting>())
                db.CreateTable<GeneralSetting>();
            //else
            //    db.MigrateTable<Setting>();

            if (db.Table<GeneralSetting>().ToList().Count == 0)
            {
                List<GeneralSetting> generalsetting = new List<GeneralSetting>();
                generalsetting.Add(new GeneralSetting() { SettingId = Guid.NewGuid(), GeneralName = "barcode" });
                db.InsertAll(generalsetting);
            }
        }

    }

    #endregion
}
