﻿using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Display(Name = "Your short URL")]
        public string ShortUrl { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Private link?")]
        public bool IsPrivate { get; set; }
    }
}
