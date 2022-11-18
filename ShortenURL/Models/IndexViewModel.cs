using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ShortenURL.Models;
using Microsoft.AspNetCore.Mvc;

namespace ShortenURL.Models
{
    public class IndexViewModel
    {
        [Required]
        [Display(Name = "Your full URL")]
        public string FullUrl { get; set; } = string.Empty;
    }
}
