using System.ComponentModel.DataAnnotations;

namespace Bakkar_Lake_Web_Application.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [MaxLength(50)] // Adjust the length as needed
        public string RoomName { get; set; }

        // Navigation property for BookingRooms
        public ICollection<BookingRoom> BookingRooms { get; set; }

    }
}
