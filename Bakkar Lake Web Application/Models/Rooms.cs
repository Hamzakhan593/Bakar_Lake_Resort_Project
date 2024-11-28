using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakkar_Lake_Web_Application.Models
{
    public class Rooms
    {
        // Primary Key for RoomId
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment RoomId
        public int RoomId { get; set; }

        // RoomType (Required)
        public string RoomType { get; set; }
        public bool Status { get; set; }
    }
}