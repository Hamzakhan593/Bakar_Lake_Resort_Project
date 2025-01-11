
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bakkar_Lake_Web_Application.Models
{
    public class BookingViewModel
    {
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

        [Required(ErrorMessage = "Please select a package.")]
        public int PackageId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        public int TotalDays { get; set; }

        public double Discount { get; set; }

        public decimal Total { get; set; }

        public bool Status { get; set; } 
        
        [ValidateNever]
        public List<Package> Packages { get; set; }


        public void CalculateTotalDays()
        {
            if (CheckInDate < CheckOutDate)
            {
                TotalDays = (CheckOutDate - CheckInDate).Days;
            }
            else
            {
                TotalDays = 0; 
            }
        }

        public void CalculateTotalAmount()
        {
            CalculateDiscount();

            if (Packages != null && Packages.Any())
            {
                var package = Packages
                    .FirstOrDefault(p => p.P_Id == PackageId);

                if (package != null && TotalDays > 0)
                {
                    Total = (package.PackageTotalPrice * TotalDays) - (decimal)Discount;
                }
            }
        }

        public void CalculateDiscount()
        {
            if (PackageId == 1)
            {
                Discount = 0;
            }
            else if (PackageId == 2) 
            {
                Discount = 2000;
            }
            else if (PackageId == 3)
            {
                Discount = 10000;
            }
        }

    }
}

