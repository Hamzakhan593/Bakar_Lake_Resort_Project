
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakkar_Lake_Web_Application.Models
{
        public class Customer
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int C_Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("customerName", TypeName = "varchar(100)")]
        public string CustomerName { get; set; }
            
        [Required]
        [Phone]
        [RegularExpression(@"^03[0-9]{9}$", ErrorMessage = "Please enter a valid Pakistani mobile number.")]
        [Column("customerPhoneNumber", TypeName = "varchar(100)")]   
        public string CustomerPhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email must be a valid Gmail address.")]
        [Column("customerEmail", TypeName = "varchar(100)")]
        public string CustomerEmail { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Customer CNIC must be exactly 15 characters.")]
        [RegularExpression(@"^\d{5}-\d{7}-\d{1}$", ErrorMessage = "CNIC must be in the format XXXXX-XXXXXXX-X.")]
        public string CustomerCNIC { get; set; }

        [Column("Address", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
