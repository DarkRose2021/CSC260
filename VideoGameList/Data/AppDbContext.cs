using Microsoft.EntityFrameworkCore;
using VideoGameList.Models;

namespace VideoGameList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Games> games { get; set; }
    }
}
