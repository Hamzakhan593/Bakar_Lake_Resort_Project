
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakkar_Lake_Web_Application.Models
{
    public class Booking
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int B_Id { get; set; }

        [ForeignKey("Customer")]
        public int C_Id { get; set; } 
        
        public virtual Customer Customer { get; set; }

        [ForeignKey("Package")]
        public int P_Id { get; set; } 

        public virtual Package Package { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public double Discount { get; set; }

        public int TotalDays { get; set; } 
        public decimal TotalPrice { get; set; }

        public bool Status { get; set; }

        public ICollection<BookingRoom> BookingRooms { get; set; }
    }
}

