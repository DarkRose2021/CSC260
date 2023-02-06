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

        public void EditMovie(Movie movie)
        {
            MoviesList[MoviesList.FindIndex(x => x.Id == movie.Id)] = movie;
        }

        public Movie GetMovie(int? id)
        {
            Movie foundMovie = MoviesList.Find(x => x.Id == id);
            return foundMovie;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return MoviesList;
        }

        public void RemoveMovie(int? id)
        {
            Movie findMovie = MoviesList.Find(x => x.Id == id);
            MoviesList.Remove(findMovie);
        }
    }
}
