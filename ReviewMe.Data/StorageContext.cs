using Microsoft.EntityFrameworkCore;
using ReviewMe.Data.Models;

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
        }
    }
}
