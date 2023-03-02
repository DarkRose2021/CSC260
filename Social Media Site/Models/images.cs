using System.ComponentModel.DataAnnotations;

namespace Social_Media_Site.Models
{
	public class images
	{
		[Key]
		public int Id { get; set; }
		public string? UserID { get; set; }
		[Required(ErrorMessage = "Can't add an image without an url")]
		public string? src { get; set; }
		public images() { }

		public images(string? src, string? UserID)
		{
			this.src = src;
			this.UserID = UserID;
		}
	}
}
