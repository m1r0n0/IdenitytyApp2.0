using Microsoft.AspNetCore.Mvc;
using ShortenURL.Models;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace ShortenURL.Controllers
{
    public class HomeController : Controller
    {
        string shortened = "https://shrtUrl/";
        Random Rand = new Random();
        bool flag = false;
        int key;
        private readonly ShortenURL.Data.ApplicationContext _context;

        public HomeController(ShortenURL.Data.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Url UrlObj { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
            if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync(); //adding this from Index.cshrml.cs to make cycle (1) work 
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            while (!flag)
            {
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

                foreach (Url item in model)
                {
                    if (shortened == item.ShortUrl) //(1)
                }
            }



            UrlObj = new Url { FullUrl = model.FullUrl };
            _context.Url.Add(UrlObj);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}