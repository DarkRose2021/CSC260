using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Interfaces;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        //link to data access layer
        IDataAccessLayer dal = new MovieListDAL();

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
                dal.AddMovie(m);
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
            return View(dal.GetMovies());
        }

        public IActionResult Delete(int? id)
        {
            dal.RemoveMovie(id);
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
            /*int i;
            i = MoviesList.FindIndex(x => x.Id == movie.Id);
            MoviesList[i] = movie;*/
            TempData["success"] = "'" + movie.title + "' Updated";
            return RedirectToAction("MultiMovies", "Movie");
        }
    }
}
