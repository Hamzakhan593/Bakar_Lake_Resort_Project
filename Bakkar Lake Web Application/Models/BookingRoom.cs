using System.ComponentModel.DataAnnotations.Schema;

namespace Bakkar_Lake_Web_Application.Models
{
    public class BookingRoom
    {
        [ForeignKey("Room")]
        public int RoomId { get; set; }

        [ForeignKey("Booking")]
        public int B_Id { get; set; }

        // Navigation properties
        public Room Room { get; set; }
        public Booking Booking { get; set; }
    }

}
