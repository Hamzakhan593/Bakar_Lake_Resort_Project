using Microsoft.AspNetCore.Identity;
namespace Bakkar_Lake_Web_Application
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } 
        public bool IsAdmin { get; set; }    
    }
    
}
