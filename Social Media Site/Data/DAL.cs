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
			if (id != null)
			{
				return db.profiles.Where(m => m.Id == id).FirstOrDefault();
			}
			return null;

		}

		public IEnumerable<profile> GetProfile()
		{
			return db.profiles.OrderBy(m => m.OwnerName).ToList();
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
