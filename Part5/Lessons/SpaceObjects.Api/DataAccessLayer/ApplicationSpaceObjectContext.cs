using Microsoft.EntityFrameworkCore;
using SpaceObjects.Api.Models;

namespace SpaceObjects.Api.DataAccessLayer
{
    public class ApplicationSpaceObjectContext : DbContext
    {
        public DbSet<SpaceObject> SpaceObjects { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Asteroid> Asteroids { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<BlackHole> BlackHoles { get; set; }

        public ApplicationSpaceObjectContext(DbContextOptions<ApplicationSpaceObjectContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpaceObject>().ToTable("SpaceObjects");
            modelBuilder.Entity<Star>().ToTable("Stars");
            modelBuilder.Entity<Asteroid>().ToTable("Asteroids");
            modelBuilder.Entity<Planet>().ToTable("Planets");
            modelBuilder.Entity<BlackHole>().ToTable("BlackHole");
        }
    }
}
