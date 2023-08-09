using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReviewMe.Data;
using ReviewMe.Data.Models;
using ReviewMe.Data.Repositories;
using ReviewMe.Data.Repositories.Abstractions;
using ReviewMe.Logic.Services;
using ReviewMe.Logic.Services.Abstractions;
using System.Linq;

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

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var storage = serviceScope.ServiceProvider.GetRequiredService<StorageContext>();

                if (storage.Database.GetPendingMigrations().Count() > 0)
                {
                    storage.Database.Migrate();
                }
            }
        }
    }
}
