using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database.Stores.Interfaces
{
    public interface IStore<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<T> FindEntityAsync(Func<T, bool> predicate);
    }
}
