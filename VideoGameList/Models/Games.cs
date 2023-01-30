﻿using System.ComponentModel.DataAnnotations;

namespace VideoGameList.Models
{
	public class Games
	{
		private static int? nextID = 0;
		public int? Id { get; set; } = nextID++;
		[Required(ErrorMessage = "Can't be left empty")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Cant be left empty or under 3 characters")]
		[MinLength(3)]
		public string Platform { get; set; }

		[Required(ErrorMessage = "Genre can't be left empty or under 10 characters")]
		[MinLength(10)]
		public string Genre { get; set; }

		public char? Rating { get; set; }

		[Required(ErrorMessage = "The Release Year must be 4 numbers long and between 1950-2025")]
		[MaxLength(4)]
		[MinLength(4)]
		[Range(1950, 2025)]
		public int ReleaseYear { get; set; }
		public string? Image { get; set; }
		public string? LoanedTo { get; set; }
		public DateTime? LoanedDate { get; set; }

		public Games() { }

		public Games(string title, string platform, string genre, char? rating, int releaseYear, string? image, string? loanedTo, DateTime? loanedDate)
		{
			this.Title = title;
			this.Platform = platform;
			this.Genre = genre;
			this.Rating = rating;
			this.ReleaseYear = releaseYear;
			this.Image = image;
			this.LoanedTo = loanedTo;
			this.LoanedDate = loanedDate;
		}
	}
}
