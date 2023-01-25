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

        [HttpGet]//create forms loads
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]//create form saves
        public IActionResult Create(Movie m)
        {
            if (m.title == "Garfield" || m.title == "garfield")
            {
                ModelState.AddModelError("title", "You're not allowed add this movie");
            }
            if (ModelState.IsValid)
            {
                MoviesList.Add(m);
                TempData["success"] = "Movie Added";
                return RedirectToAction("MultiMovies", "Movie");
            }
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

        public IActionResult Delete(int? id)
        {
            Movie foundMovie = MoviesList.Find(x => x.Id == id);
            TempData["success"] = "'" + foundMovie.title + "' Removed";
            MoviesList.Remove(foundMovie);

            return RedirectToAction("MultiMovies", "Movie");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            Movie foundMovie = MoviesList.Find(x => x.Id == id);
            if (foundMovie == null) return NotFound();

            return View(foundMovie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            int i;
            i = MoviesList.FindIndex(x => x.Id == movie.Id);
            MoviesList[i] = movie;
            TempData["success"] = "'" + movie.title + "' Updated";
            return RedirectToAction("MultiMovies", "Movie");
        }
    }
}
