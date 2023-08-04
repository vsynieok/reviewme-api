using ReviewMe.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMe.Logic.Services.Abstractions
{
    public interface IReviewService
    {
        Task<Review> AddReview(Review review);
        Task<EntitySet<Review>> GetReviews(int? page, int? limit);
        Task DeleteReview(Guid id);
    }
}
