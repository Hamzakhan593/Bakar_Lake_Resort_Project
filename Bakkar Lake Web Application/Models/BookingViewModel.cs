
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakkar_Lake_Web_Application.Models
{
    public class BookingViewModel
    {
        // Customer Information
        [Required]
        public string CustomerName { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^03[0-9]{9}$", ErrorMessage = "Please enter a valid Pakistani mobile number.")]
        public string CustomerPhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}-\d{7}-\d{1}$", ErrorMessage = "CNIC must be in the format XXXXX-XXXXXXX-X.")]
        public string CustomerCNIC { get; set; }

        public string Address { get; set; }

        // Booking Information
        public int PackageId { get; set; }

   
        public int RoomId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public int TotalDays { get; set; }

        public double Discount { get; set; }

        public decimal Total { get; set; }

        public bool Status { get; set; } // Active (true) or Inactive (false)

        // To populate dropdown lists in the view
        public List<Package> Packages { get; set; } 
        public List<Rooms> Rooms { get; set; }

     
            public void CalculateTotalDays()
            {
                if (CheckInDate != null && CheckOutDate != null)
                {
                    TotalDays = (CheckOutDate - CheckInDate).Days;
                }
            }

            // Method to calculate total amount based on days and selected package
            public void CalculateTotalAmount()
            {
            if (Packages !=null )
            {
                var package = Packages.FirstOrDefault(p => p.P_Id == PackageId);
                if (package != null && TotalDays > 0)
                {
                    Total = package.PricePerDay * TotalDays;
                }
            }
                
            }
    }
}

