using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShortenURL.Models
{
    public class UseLinkViewModel
    {
        [Required]
        [Display(Name = "Your short URL")]
        public string ShortUrl { get; set; } = string.Empty;
    }
}
