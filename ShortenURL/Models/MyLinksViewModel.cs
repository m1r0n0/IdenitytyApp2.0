using Microsoft.EntityFrameworkCore;

namespace ShortenURL.Models
{
    public class MyLinksViewModel
    {
        public IList<Url> Url { get; set; } = default!;
    }
}
