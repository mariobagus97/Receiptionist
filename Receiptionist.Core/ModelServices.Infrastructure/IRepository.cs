using System.Threading.Tasks;

namespace Receiptionist.ModelServices
{
    public interface IRepository<T> where T : class
    {
        Task<T>InsertAsync(T entity);
        Task<T>UpdateAsync(T entity);
        Task<T> GetSingleAsync();

        Task<T> GetVisitorAsync(T entity);
        Task<T> GetEmployeeAsync(T entity);
        Task<T> GetMeetingAsync(T entity);
        Task<T> NotifyEmailAsync(T entity);
        
    }
}
