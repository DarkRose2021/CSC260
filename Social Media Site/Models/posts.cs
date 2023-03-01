using System.ComponentModel.DataAnnotations;

namespace Social_Media_Site.Models
{
	public class posts
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string image { get; set; }
		[Required]
		public string Content { get; set; }
		public posts() { }
		public posts(string title, string image, string content)
		{
			this.Title = title;
			this.image = image;
			this.Content = content;
		}
	}
}
