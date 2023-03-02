using System.ComponentModel.DataAnnotations;

namespace Social_Media_Site.Models
{
	public class posts
	{
		[Key]
		public int Id { get; set; }
		public string? UserID { get; set; }
		[Required(ErrorMessage = "You must enter a title")]
		[MaxLength(150)]
		public string? Title { get; set; }
		public string? image { get; set; }
		[Required(ErrorMessage = "You must enter content when making a post")]
		public string? Content { get; set; }
		public posts() { }
		public posts(string? title, string? image, string? content, string? UserID)
		{
			this.Title = title;
			this.image = image;
			this.Content = content;
			this.UserID = UserID;
		}
	}
}
