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
            TempData["success"] = "Movie Removed";
            return RedirectToAction("MultiMovies", "Movie");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Movie foundmovie = dal.GetMovie(id);
            if (foundmovie == null)
            {
                TempData["Error"] = "Movie not found";
                return RedirectToAction("MultiMovies", "Movie");
            }
            return View(foundmovie);
        }

        [HttpPost]
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return View("MultiMovies", dal.GetMovies());
            }
            return View("MultiMovies", dal.GetMovies().Where(x => x.title.ToLower().Contains(key.ToLower())));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            dal.EditMovie(movie);
            TempData["success"] = "'" + movie.title + "' Updated";
            return RedirectToAction("MultiMovies", "Movie");
        }
    }
}
