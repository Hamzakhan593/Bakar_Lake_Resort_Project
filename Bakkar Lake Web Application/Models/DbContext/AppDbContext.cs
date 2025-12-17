using Bakkar_Lake_Web_Application.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bakkar_Lake_Web_Application.Data
{

    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Package> Packages { get; set; }
            public DbSet<Booking> Bookings { get; set; }
            public DbSet<Room> Rooms { get; set; }
            public DbSet<BookingRoom> BookingRooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingRoom>()
                .HasKey(br => new { br.B_Id, br.RoomId });

            modelBuilder.Entity<BookingRoom>()
                .HasOne(br => br.Booking)
                .WithMany(b => b.BookingRooms)
                .HasForeignKey(br => br.B_Id);

            modelBuilder.Entity<BookingRoom>()
                .HasOne(br => br.Room)
                .WithMany(r => r.BookingRooms)
                .HasForeignKey(br => br.RoomId);

            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Package>()
                .Property(p => p.PackageTotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Package>()
                .Property(p => p.PricePerDay)
                .HasPrecision(18, 2);
        }


    }
}
