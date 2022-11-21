using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortenURL.Models;
using System.Diagnostics;

namespace ShortenURL.Controllers
{
    public class HomeController : Controller
    {
        string shortened = "https://shrtUrl/";
        string userEmail = string.Empty;
        Random Rand = new Random();
        bool isThereSimilar = true;
        int key;
        private readonly ShortenURL.Data.ApplicationContext _context;

        public IList<Url> Url { get; set; } = default!;

        [BindProperty]
        public Url UrlObj { get; set; }

        public HomeController(ShortenURL.Data.ApplicationContext context)
        {
            _context = context;
        }

/*        [HttpGet]
        public async Task OnGetAsync()
        {
            if (_context.Url != null)
            {
                Url = await _context.Url.ToListAsync();
            }
        }*/


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyLinks(MyLinksViewModel model)
        {
            if (_context.Url != null)
            {
                model.Url = await _context.Url.ToListAsync();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                userEmail = User.Identity.Name;
            }

            /*while (true)
            {*/
            shortened = "https://shrtUrl/";
            for (int i = 0; i < 4; i++)
            {
                key = Rand.Next(1, 4);
                switch (key)
                {
                    case 1:
                        shortened += (char)Rand.Next(48, 58);
                        break;
                    case 2:
                        shortened += (char)Rand.Next(65, 91);
                        break;
                    case 3:
                        shortened += (char)Rand.Next(97, 123);
                        break;
                }
            }

            /*foreach (var item in Url)
            {
                if (shortened == item.ShortUrl)
                {
                    isThereSimilar = true;
                    break;
                }
                else
                {
                    isThereSimilar = false;
                }
            }

            if (!isThereSimilar) 
            {
                break;
            }
        }*/
            UrlObj = new Url { UserEmail = userEmail, FullUrl = model.FullUrl, ShortUrl = shortened,  IsPrivate = model.IsPrivate };
            _context.Url.Add(UrlObj);
            await _context.SaveChangesAsync();

            /*if (!ModelState.IsValid)
            {
                return View(model);
            }*/

            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}