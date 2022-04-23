using EFAsNoTrackingBenchmark.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFAsNoTrackingBenchmark.Contexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.; Database=UserDb;Trusted_Connection=True");
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
