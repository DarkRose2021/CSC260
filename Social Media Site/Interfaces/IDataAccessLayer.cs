using Social_Media_Site.Models;

namespace Social_Media_Site.Interfaces
{
	public interface IDataAccessLayer
	{
		bool EditPofile(profile profile);
		profile GetProfile(int? id);
	}
}
