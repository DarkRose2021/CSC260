namespace VideoGameList.Models
{
	public class Games
	{
		private static int? nextID = 0;
		public int? Id { get; set; } = nextID++;
		public string Title { get; set; } = "[No Title]";
		public string Platform { get; set; } = "";
		public string Genre { get; set; } = "";
		public char? Rating { get; set; } = null;
		public int? ReleaseYear { get; set; } = null;
		public string Image { get; set; } = "";
		public Boolean IsLoaned { get; set; }
		public string? LoanedTo { get; set; } = "";
		public DateOnly? LoanedDate { get; set; } = null;

		public Games() { }

		public Games(string title, string platform, string genre, char? rating, int? releaseYear, string image, string? loanedTo, DateOnly? loanedDate, Boolean isloaned)
		{
			this.Title = title;
			this.Platform = platform;
			this.Genre = genre;
			this.Rating = rating;
			this.ReleaseYear = releaseYear;
			this.Image = image;
			this.LoanedTo = loanedTo;
			this.LoanedDate = loanedDate;
			this.IsLoaned = isloaned;
		}
	}
}
