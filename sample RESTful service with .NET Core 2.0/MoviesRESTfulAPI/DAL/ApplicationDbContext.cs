using Microsoft.EntityFrameworkCore;
using MoviesRESTfulAPI.Models;

namespace MoviesRESTfulAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actors> Actors { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActors>()
                .HasKey(ma => new { ma.ActorsId, ma.MoviesId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
