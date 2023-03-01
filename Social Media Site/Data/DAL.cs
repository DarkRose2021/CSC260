using Social_Media_Site.Interfaces;
using Social_Media_Site.Models;

namespace Social_Media_Site.Data
{
	public class DAL : IDataAccessLayer
	{
		private ApplicationDbContext db;
		public DAL(ApplicationDbContext indb)
		{
			db = indb;
		}

		public bool EditPofile(profile profile)
		{
			if (profile == null)
			{
				return false;
			}
			db.profiles.Update(profile);
			db.SaveChanges();
			return true;
		}

		public profile GetProfile(int? id)
		{
			return db.profiles.Where(m => m.Id == id).FirstOrDefault();
		}

		public IEnumerable<profile> GetProfile()
		{
			return db.profiles.OrderBy(m => m.name).ToList();
		}
		public IEnumerable<images> GetImages()
		{
			return db.images.ToList();
		}
		public IEnumerable<posts> GetPosts()
		{
			return db.posts.ToList();
		}
	}
}
