using Movies.Interfaces;
using Movies.Models;

namespace Movies.Data
{
    public class MovieListDAL : IDataAccessLayer
    {
        private static List<Movie> MoviesList = new List<Movie>
        {
            new Movie("Hunger Games", 2012, 4.5f),
            new Movie("Saving Private Ryan", 1998, 5.0f),
            new Movie("Woknda Forever", 2022, 4.7f)
        };

        public void AddMovie(Movie movie)
        {
            MoviesList.Add(movie);
        }

        public void EditMovie(Movie movie)
        {
            int i;
            i = MoviesList.FindIndex(x => x.Id == movie.Id);
            MoviesList[i] = movie;
        }

        public Movie GetMovie(int? id)
        {

        }

        public IEnumerable<Movie> GetMovies()
        {
            return MoviesList;
        }

        public void RemoveMovie(int? id)
        {
            Movie findMovie = MoviesList.Find(x => x.Id == id);
            if (findMovie != null)
            {
                MoviesList.Remove(findMovie);
            }
        }
    }
}
