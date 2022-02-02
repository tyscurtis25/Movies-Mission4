using DateMe_Mission4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MoviesInfoContext moviesInfoContext { get; set; }

        //constructor
        public HomeController(MoviesInfoContext moviesVar)
        {
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
            ViewBag.Categories = moviesInfoContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MoviesForm(Movies mov)
        {
            if (ModelState.IsValid) //validation for form
            {
                moviesInfoContext.Add(mov);
                moviesInfoContext.SaveChanges();

                return View("ConfirmationPage", mov);
            }
            else //if invalid
            {
                ViewBag.Categories = moviesInfoContext.Categories.ToList();
                return View(mov);
            }
        }

        [HttpGet]
        public IActionResult MoviesCollection()
        {
            var collections = moviesInfoContext.Responses
                .Include(x => x.Category)
                //.Where(x => x.Edited == false)
                .OrderBy(x => x.Title)
                .ToList();

            return View(collections);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = moviesInfoContext.Categories.ToList();

            var entry = moviesInfoContext.Responses
                .Single(x => x.MovieID == movieid);

            return View("MoviesForm", entry);
        }

        [HttpPost]
        public IActionResult Edit(Movies instance) //instance is just an instance of Movies on the form
        {
            if (ModelState.IsValid)
            {
                moviesInfoContext.Update(instance);
                moviesInfoContext.SaveChanges();

                return RedirectToAction("MoviesCollection");
            }
            else //if invalid
            {
                ViewBag.Categories = moviesInfoContext.Categories.ToList();
                return View(instance);
            }
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var entry = moviesInfoContext.Responses.Single(x => x.MovieID == movieid);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(Movies movie)
        {
            moviesInfoContext.Remove(movie);
            moviesInfoContext.SaveChanges();

            return RedirectToAction("MoviesCollection");
        }

    }
}
