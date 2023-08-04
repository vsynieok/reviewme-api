using ReviewMe.Data.Models;
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
        Task<EntitySet<T>> ReadWithPagination(int? page, int? limit);
        Task Delete(Guid id);
    }
}
