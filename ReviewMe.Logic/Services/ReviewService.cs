using ReviewMe.Data.Models;
using ReviewMe.Data.Repositories.Abstractions;
using ReviewMe.Logic.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMe.Logic.Services
{
    public class ReviewService : IReviewService
    {
        private IRepository<Review> _reviews;

        public ReviewService(IRepository<Review> repository)
        {
            _reviews = repository;
        }

        public async Task<Review> AddReview(Review review)
        {
            return await _reviews.Create(review);
        }

        public async Task DeleteReview(Guid id)
        {
            await _reviews.Delete(id);
        }

        public async Task<EntitySet<Review>> GetReviews(int? page, int? limit)
        {
            return await _reviews.ReadWithPagination(page, limit);
        }
    }
}
