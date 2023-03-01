using System.ComponentModel.DataAnnotations;

namespace Social_Media_Site.Models
{
	public class profile
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public int age { get; set; }
		[Required]
		public string name { get; set; }
		[Required]
		public string OwnerName { get; set; }
		public string breed { get; set; }
		public string img { get; set; }
		public string bio { get; set; }

		profile() { }

		profile(int age, string name, string breed, string img, string bio)
		{
			this.age = age;
			this.name = name;
			this.breed = breed;
			this.img = img;
			this.bio = bio;
		}
	}
}
