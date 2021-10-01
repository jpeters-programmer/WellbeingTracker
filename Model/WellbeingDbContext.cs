#nullable disable
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
namespace Model
{
    public class WellbeingDbContext : DbContext
    {
        public DbSet<TrackedItem> TrackedItems {get;set;}
        public DbSet<TrackingEntry> TrackingEntries {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<TrackingSetup> TrackingSetups {get;set;}
        public DbSet<Trackable> Trackables {get;set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .Entity<User>()
                .HasOne<TrackingSetup>(x => x.TrackingSetup)
                .WithOne(x => x.User)
                .HasForeignKey<TrackingSetup>(x => x.UserGuid);
        }
    }
}