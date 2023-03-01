using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Social_Media_Site.Models;

namespace Social_Media_Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<profile> profiles { get; set; }
        public DbSet<images> images { get; set; }
        public DbSet<posts> posts { get; set; }
    }
}