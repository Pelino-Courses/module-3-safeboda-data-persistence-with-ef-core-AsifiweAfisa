using Microsoft.EntityFrameworkCore;
using SafeBoda.Core;

namespace SafeBoda.Infrastructure
{
    public class SafeBodaDbContext : DbContext
    {
        public SafeBodaDbContext(DbContextOptions<SafeBodaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rider> Riders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ComplexProperty(e => e.Start);
                entity.ComplexProperty(e => e.End);
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}