using System.ComponentModel.DataAnnotations;

namespace Social_Media_Site.Models
{
	public class profile
	{
		[Key]
		public int Id { get; set; }
		public string? UserID { get; set; }
		public int? Horseage { get; set; }
		public string? Horsename { get; set; }
		[Required(ErrorMessage = "You must enter a name")]
		[MaxLength(50)]
		public string? OwnerName { get; set; }
		public string? breed { get; set; }
		[Required(ErrorMessage = "You must have a picture")]
		public string? img { get; set; }
		public string? bio { get; set; }

		profile() { }

		profile(int? Horseage, string? Horsename, string? breed, string img, string? bio, string? UserID, string? OwnerName)
		{
			this.Horseage = Horseage;
			this.breed = breed;
			this.img = img;
			this.bio = bio;
			this.UserID = UserID;
			this.OwnerName = OwnerName;
			this.Horsename = Horsename;
		}
	}
}
