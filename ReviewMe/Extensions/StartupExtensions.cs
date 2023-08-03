using Microsoft.Extensions.DependencyInjection;
using ReviewMe.Data.Models;
using ReviewMe.Data.Repositories;
using ReviewMe.Data.Repositories.Abstractions;
using ReviewMe.Logic.Services;
using ReviewMe.Logic.Services.Abstractions;

namespace ReviewMe.API.Extensions
{
    public static class StartupExtensions
    {
        public static void InjectServices(this IServiceCollection collection)
        {
            collection.AddScoped<IRepository<Review>, ReviewRepository>();
        }

        public static void InjectRepositories(this IServiceCollection collection)
        {
            collection.AddScoped<IReviewService, ReviewService>();
        }
    }
}
