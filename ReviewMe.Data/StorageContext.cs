using Microsoft.EntityFrameworkCore;
using ReviewMe.Data.Models;
using System;

namespace ReviewMe.Data
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options) { }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Review>(e =>
            {
                e.HasKey(r => r.Id);
                e.Property(r => r.Id).ValueGeneratedOnAdd();
                e.Property(r => r.LastModified).HasDefaultValueSql("getutcdate()");
            });

            builder.Entity<Review>(e =>
            {
                e.HasData(
                    new Review
                    {
                        Id = Guid.NewGuid(),
                        Name = "Андрій Соловйов",
                        Rating = 5,
                        Comment = "Чудовий готель! Привітний персонал, бездоганна чистота та неймовірний вид з вікна. Обов'язково повернуся!",
                        LastModified = DateTime.UtcNow
                    },
                    new Review
                    {
                        Id = Guid.NewGuid(),
                        Name = "Катерина Петренко",
                        Rating = 4,
                        Comment = "Загалом, гарний відпочинок. Номери комфортні, але вранці було трохи шумно через ремонт.",
                        LastModified = DateTime.UtcNow
                    },
                    new Review
                    {
                        Id = Guid.NewGuid(),
                        Name = "Максим Іванов",
                        Rating = 3,
                        Comment = "Середній готель. Відсутність басейну та обмежена кількість страв на сніданок розчарували.",
                        LastModified = DateTime.UtcNow
                    },
                    new Review
                    {
                        Id = Guid.NewGuid(),
                        Name = "Лілія Григорова",
                        Rating = 5,
                        Comment = "Найкраще місце для відпочинку. Розкішні номери, привітний персонал та чудовий вигляд на море.",
                        LastModified = DateTime.UtcNow
                    },
                    new Review
                    {
                        Id = Guid.NewGuid(),
                        Name = "Андрій Коваль",
                        Rating = 2,
                        Comment = "Незадовільний сервіс. Брудний номер, некомпетентний персонал. Не рекомендую.",
                        LastModified = DateTime.UtcNow
                    });
            });
        }
    }
}
