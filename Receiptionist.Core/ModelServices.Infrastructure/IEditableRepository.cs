using Receiptionist.ModelServices;
using System.Threading.Tasks;

namespace Receiptionist.Core.ModelServices.Infrastructure
{
    public interface IEditableRepository<T> : IRepository<T> where T : class
    {
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}