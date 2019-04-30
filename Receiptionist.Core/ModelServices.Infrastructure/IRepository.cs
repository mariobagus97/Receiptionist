﻿using System.Threading.Tasks;

namespace Receiptionist.ModelServices
{
    public interface IRepository<T> where T : class
    {
        Task<T>InsertAsync(T entity);

    }
}