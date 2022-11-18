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
        public Url Urll { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
                for (int i = 0; i < 4; i++)
                {
                    key = Rand.Next(1, 4);
                    switch (key)
                    {
                        case 1:
                            код,выполняемый если выражение имеет значение1
        break;
                        case 2:
                            код,выполняемый если выражение имеет значение1
        break;
                        case 3:
                            код, выполняемый если выражение имеет значениеN
        break;
                    }
                    После ключ
                }
            }
            Urll = new Url { FullUrl = model.FullUrl };
            _context.Url.Add(Urll);
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