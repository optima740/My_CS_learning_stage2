using Microsoft.EntityFrameworkCore;
using Space.Models;

namespace Space.DataAccessLayer
{
    public class SpaceObjectContext : DbContext
    {
        public DbSet<SpaceObject> SpaceObjects { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<Asteroid> Asteroids { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<BlackHole> BlackHoles { get; set; }      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseSqlite("Filename=Space.db");
        }

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
