using Microsoft.EntityFrameworkCore;
using ReviewMe.Data.Models;
using ReviewMe.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMe.Data.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        private StorageContext _storageContext;

        public ReviewRepository(StorageContext context)
        {
            _storageContext = context;
        }

        public async Task<Review> Create(Review entity)
        {
            var result = await _storageContext.Reviews.AddAsync(entity);
            await _storageContext.SaveChangesAsync();

            return result.Entity;
        }
        public async Task<Review> Read(Guid id)
        {
            return await _storageContext.Reviews.FindAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var entityToDelete = await this.Read(id);
            if (entityToDelete == null) throw new InvalidOperationException();
            _storageContext.Reviews.Remove(entityToDelete);
            await _storageContext.SaveChangesAsync();
            return;
        }


        public async Task<EntitySet<Review>> ReadWithPagination(int? page, int? limit)
        {
            IEnumerable<Review> result;

            if (page == null || limit == null)
            {
                result = await _storageContext.Reviews.OrderByDescending(x => x.LastModified).ToListAsync();
                return new EntitySet<Review> { Items = result, Page = 1, TotalPages = 1 };
            }

            result = await _storageContext.Reviews.OrderByDescending(x => x.LastModified).Skip(((page ?? 1) - 1) * limit ?? 1).Take(limit ?? 1).ToListAsync();
            var pageCount = Convert.ToInt32(Math.Ceiling((await _storageContext.Reviews.CountAsync()) / (decimal)limit));
            return new EntitySet<Review> { Items = result, Page = page ?? 1, TotalPages = pageCount == 0 ? 1 : pageCount };
        }
    }
}
