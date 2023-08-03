using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMe.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Read(Guid id);
        Task<IEnumerable<T>> ReadAll();
        Task Delete(Guid id);
    }
}
