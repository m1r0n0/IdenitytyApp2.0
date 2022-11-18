using Microsoft.AspNetCore.Identity;

namespace ShortenURL.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
