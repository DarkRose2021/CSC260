using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> MoviesList = new List<Movie>
        {
            new Movie("Hunger Games", 2012, 4.5f),
            new Movie("Saving Private Ryan", 1998, 5.0f),
            new Movie("Woknda Forever", 2022, 4.7f)
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("Iron Man", 2008, 5.0f);
            return View(m);
        }

        public IActionResult MultiMovies()
        {

            return View(MoviesList);
        }
    }
}
