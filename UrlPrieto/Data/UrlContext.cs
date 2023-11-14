using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using UrlPrieto.Entities;

namespace UrlPrieto.Data
{
    public class UrlContext : DbContext
    {
        public DbSet<Url> Url { get; set; }
        public DbSet<Categories> Categories { get; set; }

        public DbSet<Users> Users { get; set; }
        public UrlContext(DbContextOptions<UrlContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Url>().HasOne(c => c.Category).WithMany(u => u.urls).HasForeignKey(i => i.IdCategory);
            modelBuilder.Entity<Url>().HasOne(u => u.Users).WithMany(u => u.urls).HasForeignKey(i => i.IdUser);
            modelBuilder.Entity<Categories>().HasData(
              new Categories() { Id = 1, Name = "deportes" },
              new Categories() { Id = 2, Name = "politica" },
              new Categories() { Id = 3, Name = "animales" }
            );
            modelBuilder.Entity<Users>().HasData(
                new Users() { Id = 1, User = "jOAKO", Password = "joakopiola" },
                new Users() { Id = 2, User = "Luliiprie", Password = "112002"}
                );
        }
        
    }
}
