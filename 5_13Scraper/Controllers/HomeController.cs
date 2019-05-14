using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _5_13Scraper.Models;

namespace _5_13Scraper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Article> items = Api.ScrapeTls();
            return View(items);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
