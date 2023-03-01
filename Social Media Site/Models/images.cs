using System.ComponentModel.DataAnnotations;

namespace Social_Media_Site.Models
{
	public class images
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string src { get; set; }
		public images() { }

		public images(string src)
		{
			this.src = src;
		}
	}
}
