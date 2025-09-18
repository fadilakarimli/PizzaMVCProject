using Microsoft.AspNetCore.Identity;

namespace PizzaProject.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
