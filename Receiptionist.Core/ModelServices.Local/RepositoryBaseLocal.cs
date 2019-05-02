using Intersoft.Crosslight;
using Intersoft.Crosslight.Data.SQLite;
using Intersoft.Crosslight.Mobile;
using Receiptionist.ModelServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receiptionist.Core.ModelServices.Local
{
    public class RepositoryBaseLocal <T> : IRepository<T> where T : class , new()
    {
        #region Constructors

        public RepositoryBaseLocal() : this("receptionist.db3")
        {
        }

        public RepositoryBaseLocal(string dbName)
        {
            this.Db = this.CreateConnection(dbName);
        }

        #endregion

        #region Properties

        public ISQLiteAsyncConnection Db { get; private set; }

        #endregion

        public virtual ISQLiteAsyncConnection CreateConnection(string dbName)
        {
            ILocalStorageService storageService = ServiceProvider.GetService<ILocalStorageService>();
            IActivatorService activatorService = ServiceProvider.GetService<IActivatorService>();
            Func<string, ISQLiteAsyncConnection> factory = activatorService.CreateInstance<Func<string, ISQLiteAsyncConnection>>();
            ISQLiteAsyncConnection db = factory(storageService.GetFilePath(dbName, LocalFolderKind.Data));

            return db;

        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await this.Db.InsertAsync(entity);
            return null;
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            IList<T> items = await this.Db.Table<T>().ToListAsync();
            return items.ToObservable();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            await this.Db.UpdateAsync(entity);
            return null;
        }

        public virtual async Task<T> GetSingleAsync()
        {
            T items = await this.Db.Table<T>().FirstOrDefaultAsync();
            return items;
        }
    }
}
