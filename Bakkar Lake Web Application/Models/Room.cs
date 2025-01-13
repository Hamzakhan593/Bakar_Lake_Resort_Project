using System.ComponentModel.DataAnnotations;

namespace Bakkar_Lake_Web_Application.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [MaxLength(50)] 
        public string RoomName { get; set; }

        
        public ICollection<BookingRoom> BookingRooms { get; set; }

    }
}
