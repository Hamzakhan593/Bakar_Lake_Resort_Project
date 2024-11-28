using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakkar_Lake_Web_Application.Models
{
    public class Package
    {
        // Primary Key for P_Id (auto-increment)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment the P_Id
        public int P_Id { get; set; }

        // Package Detail (Description of the package)
       public string PakkageDetail { get; set; }

        // Price Per Day for the package
       public decimal PricePerDay { get; set; }

        // Total Price of the package
         public decimal TotalPrice { get; set; }

        public bool Status { get; set; }
    }
}
