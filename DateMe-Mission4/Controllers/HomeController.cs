using DateMe_Mission4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe_Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesInfoContext moviesInfoContext { get; set; }

        //constructor
        public HomeController(ILogger<HomeController> logger, MoviesInfoContext moviesVar)
        {
            _logger = logger;
            moviesInfoContext = moviesVar;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Baconsale()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MoviesForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MoviesForm(Movies re)
        {
            moviesInfoContext.Add(re);
            moviesInfoContext.SaveChanges();

            return View("ConfirmationPage", re);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
