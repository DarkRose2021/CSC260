using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        //will create a movies table mapped to movie model
        public DbSet<Movie> Movies { get; set; }
    }
}
