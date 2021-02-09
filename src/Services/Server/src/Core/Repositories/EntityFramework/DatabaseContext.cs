using Core.Models.Table;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
