using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Bakkar_Lake_Web_Application.Models
{
    public class AdminVM
    {
      
        public int P_Id { get; set; }


        public string PakkageDetail { get; set; }


        public decimal PricePerDay { get; set; }

        public decimal PackageTotalPrice { get; set; }

        public bool Status { get; set; }

       
        public int RoomId { get; set; }

        public string RoomName { get; set; }
    }
}
