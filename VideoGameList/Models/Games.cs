namespace VideoGameList.Models
{
	public class Games
	{
		private static int? nextID = 0;
		public int? Id { get; set; } = nextID++;
		public string Title { get; set; } = "[No Title]";
		public string Platform { get; set; } = "";
		public string Genre { get; set; } = "";
		public float? Rating { get; set; } = null;
		public int? ReleaseYear { get; set; } = null;
		public string Image { get; set; } = "";
		public string? LoanedTo { get; set; } = null;
		public DateOnly? LoanedDate { get; set; } = null;

		public Games() { }

		public Games(int? id, string title, string platform, string genre, float? rating, int? releaseYear, string image, string? loanedTo, DateOnly? loanedDate)
		{
			Id = id;
			Title = title;
			Platform = platform;
			Genre = genre;
			Rating = rating;
			ReleaseYear = releaseYear;
			Image = image;
			LoanedTo = loanedTo;
			LoanedDate = loanedDate;
		}
	}
}
