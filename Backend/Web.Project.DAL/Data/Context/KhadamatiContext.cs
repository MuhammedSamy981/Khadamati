using FinalProject.Dal;
using FinalProject.Dal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplications4.DAL
{
    public class KhadamatiContext : IdentityDbContext<User>
    {
        public DbSet<BookMark> BookMarks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ServiceRequest> Requests { get; set; }
        public DbSet<Service> Services { get; set; }
        public KhadamatiContext(DbContextOptions options) : base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ServiceRequest>()
           .HasOne(e => e.User) // reference
           .WithMany(e => e.UserRequests); // collection

            modelBuilder.Entity<ServiceRequest>()
            .HasOne(e => e.Provider) // reference
            .WithMany(e => e.ProviderRequests); // collection

            modelBuilder.Entity<ServiceRequest>()
            .HasOne(e => e.Service) // reference
            .WithMany(e => e.Requests); // collection

            modelBuilder.Entity<BookMark>()
            .HasOne(e => e.Service) // reference
            .WithMany(e => e.BookMarks)// collection
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
            .HasOne(e => e.Service) // reference
            .WithMany(e => e.Ratings)// collection
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}