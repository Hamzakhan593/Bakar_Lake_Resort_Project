using Microsoft.AspNetCore.Identity;
namespace Bakkar_Lake_Web_Application
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } // For storing the user's full name
        public bool IsAdmin { get; set; }    // To differentiate admin users
    }
    
}
