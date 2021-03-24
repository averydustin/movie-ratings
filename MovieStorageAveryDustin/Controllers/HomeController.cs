using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieStorageAveryDustin.Models;

namespace MovieStorageAveryDustin.Controllers
{
    public class HomeController : Controller
    {
        private MovieDBcontext context { get; set; }

        public HomeController(MovieDBcontext cxt)
        {
            context = cxt;
        }
        

        //Home page view
        public IActionResult Index()
        {
            return View();
        }

        //podcasts view
        public IActionResult Podcasts()
        {
            return View();
        }

        //Movie input form view
        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        //When the movie is submitted it takes your directly to the movie list view
        [HttpPost]
        public IActionResult SubmitMovie(MovieResponse movieResponse)
        {
            if (ModelState.IsValid)
            {
                //TempStorage.SubmitMovie(movieResponse);
                context.Movies.Add(movieResponse);
                context.SaveChanges();
                //When returning view, it excludes any entry with the Title "Independence Day"
                return View("SavedMovies", context.Movies.Where(movieResponse => movieResponse.Title != "Independence Day"));
            } else
            {
                return View("Movies");
            }
        }
        //Movie List View
        public IActionResult SavedMovies(MovieResponse movieResponse)
        {
            //When returning view, it excludes any entry with the Title "Independence Day"
            return View(context.Movies.Where(movieResponse => movieResponse.Title != "Independence Day"));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
