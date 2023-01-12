namespace Movies.Models
{
    public class Movie
    {
        private static int? nextID = 0;
        public int? Id { get; set; } = nextID++;
        public string title { get; set; } = "[No Title]";
        public int? year { get; set; } = 1930;
        public float? rating { get; set; } = 0.0f;
        public DateTime? date { get; set; }
        public string image { get; set; }

        public Movie() { }

        public Movie(string strTitle, int intYear, float fltRating)
        {
            this.title = strTitle;
            this.year = intYear;
            this.rating = fltRating;
        }

        public override string ToString()
        {
            return $"{title} - {year} - {rating} stars";
        }
    }
}
