using Movies.Validators;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Models
{
    [NinetysMoviesRating]
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a title.")]
        [MaxLength(100)]
        public string title { get; set; }

        [Required]
        [Range(1895, 2023)]
        public int? year { get; set; }

        [Required]
        public float? rating { get; set; }
        public DateTime? date { get; set; }
        public string? image { get; set; }

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
