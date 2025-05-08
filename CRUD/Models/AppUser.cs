using Microsoft.AspNetCore.Identity;

namespace CRUD.Models
{
    public class AppUser : IdentityUser
    {
        public string? Occupation { get; set; }
    }
}
