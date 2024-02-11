using Microsoft.EntityFrameworkCore;
using PartyCinema.Server.Models;

namespace PartyCinema.Server
{
    public class AppDbContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.CreatedRoom)
                .WithOne(r => r.CreatedUser)
                .HasForeignKey<Room>(r => r.CreatedUserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.ViewRooms)
                .WithMany(r => r.Viewers);

            base.OnModelCreating(modelBuilder);
        }
    }
}
