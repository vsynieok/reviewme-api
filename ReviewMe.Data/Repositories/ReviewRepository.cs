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
            _storageContext.Reviews.Remove(entityToDelete);
            await _storageContext.SaveChangesAsync();
            return;
        }


        public async Task<IEnumerable<Review>> ReadAll()
        {
            return await _storageContext.Reviews.ToListAsync();
        }
    }
}
