using Bakkar_Lake_Web_Application.Models;
using Microsoft.EntityFrameworkCore;
namespace Bakkar_Lake_Web_Application.Data
{

    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
            // DbSet properties for each model
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Package> Packages { get; set; }
            public DbSet<Booking> Bookings { get; set; }
            public DbSet<Rooms> Rooms { get; set; }
            public DbSet<BookingRoom> BookingRooms { get; set; }
    }
}
