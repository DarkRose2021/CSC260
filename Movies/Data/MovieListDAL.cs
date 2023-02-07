using Movies.Interfaces;
using Movies.Models;

namespace Movies.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        /*private static List<Movie> MoviesList = new List<Movie>
        {
            new Movie("Hunger Games", 2012, 4.5f),
            new Movie("Saving Private Ryan", 1998, 5.0f),
            new Movie("Woknda Forever", 2022, 4.7f)
        };*/

        private AppDbContext db;
        public MovieListDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddMovie(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void EditMovie(int id)
        {
            /*int i;
            Movie movie;
            movie = db.Movies.Where(x => x.Id == id).FirstOrDefault();
            db.Movies.Update(movie);
            db.SaveChanges();*/
        }

        public void EditMovie(Movie movie)
        {
            /*MoviesList[MoviesList.FindIndex(x => x.Id == movie.Id)] = movie;*/
            db.Movies.Update(movie);
            db.SaveChanges();
        }

        public Movie GetMovie(int? id)
        {
            /*Movie foundMovie = db.Movies.Find(m => m.Id == id).FirstOrDefault();
            return foundMovie;*/
            return db.Movies.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return db.Movies.OrderBy(m => m.title).ToList();
        }

        public void RemoveMovie(int? id)
        {
            /*Movie findMovie = MoviesList.Find(x => x.Id == id);
            MoviesList.Remove(findMovie);*/
            Movie foundmovie = GetMovie(id);
            db.Movies.Remove(foundmovie);
            db.SaveChanges();
        }
    }
}
