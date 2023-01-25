using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
	public class Movie
	{
		private static int? nextID = 0;
		public int? Id { get; set; } = nextID++;

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
