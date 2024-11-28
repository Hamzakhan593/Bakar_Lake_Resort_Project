
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakkar_Lake_Web_Application.Models
{
    public class Booking
    {
        // Primary Key for b_Id (auto-incremented)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment the b_Id
        public int B_Id { get; set; }

        // Foreign Key referencing Customer (c_Id)
        [ForeignKey("Customer")]
        public int C_Id { get; set; } // Customer's c_Id
        // Navigation property to Customer
        public virtual Customer Customer { get; set; }

        // Foreign Key referencing PakkageDetail (p_Id)
        [ForeignKey("Package")]
        public int P_Id { get; set; } // Pakkage's p_Id

        // Navigation property to PakkageDetail
        public virtual Package Package { get; set; }

        // Check-in date for the booking
        [Required]
        public DateTime CheckInDate { get; set; }

        // Check-out date for the booking
        public DateTime CheckOutDate { get; set; }

        // Discount on the booking
        public double Discount { get; set; }

        // Total price for the booking

        public int TotalDays { get; set; } // New Property
        public decimal Total { get; set; }

        // Booking status (active or inactive)
        public bool Status { get; set; }
    }
}

