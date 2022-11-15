using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomIdentityApp.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace CustomIdentityApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly CustomIdentityApp.Models.ApplicationContext _context;

        public IndexModel(CustomIdentityApp.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }
        }
    }
}
