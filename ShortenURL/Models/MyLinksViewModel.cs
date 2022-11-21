using Microsoft.EntityFrameworkCore;

namespace ShortenURL.Models
{
    public class MyLinksViewModel
    {
        private readonly ShortenURL.Data.ApplicationContext _context;

        public MyLinksViewModel(ShortenURL.Data.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Url> Url { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Url != null)
            {
                Url = await _context.Url.ToListAsync();
            }
        }
    }
}
