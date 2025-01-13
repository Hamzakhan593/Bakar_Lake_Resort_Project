using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bakkar_Lake_Web_Application.Models
{
    public class Package
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int P_Id { get; set; }

       
       public string PakkageDetail { get; set; }

        
       public decimal PricePerDay { get; set; }

         public decimal PackageTotalPrice { get; set; }

        public bool Status { get; set; }
    }
}
