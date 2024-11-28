using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bakkar_Lake_Web_Application.Models
{
    public class BookingRoom
    {
        // Primary Key for the BookingRooms (Composite Primary Key is automatically set by EF Core)
        [Key]
        [ForeignKey("Booking")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment the ID if needed
        public int B_Id { get; set; }  // Primary key for the relationship table
        public virtual Booking Booking { get; set; }

        // Foreign Key referencing the Room table (r_Id)
        [ForeignKey("Rooms")]
        public int RoomId { get; set; }  // Foreign key from Rooms

        // Navigation Property to Room
        public virtual Rooms Rooms { get; set; }

    }
}
