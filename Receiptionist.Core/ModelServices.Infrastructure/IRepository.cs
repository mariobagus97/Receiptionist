using System.Collections.Generic;
using System.Threading.Tasks;

namespace Receiptionist.ModelServices
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetSingleAsync();
        Task<IList<T>> GetAllAsync();
    }
}
