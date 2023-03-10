using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social_Media_Site.Interfaces;
using Social_Media_Site.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Social_Media_Site.Controllers
{
	public class HomeController : Controller
	{
		/*private readonly ILogger<HomeController> _logger;*/
		IDataAccessLayer dal;
		public HomeController(IDataAccessLayer indal)
		{
			dal = indal;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public IActionResult BestMovie()
		{
			return Redirect("https://www.dreamworks.com/movies/spirit-stallion-of-the-cimarron");
		}

		public IActionResult Profile(profile profile)
		{
			profile.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
			return View();
		}


		[Authorize, HttpGet]
		public IActionResult editProfile(int? id)
		{
			if (id == null) return NotFound();

			return View(dal.GetProfile(id));
		}

		[Authorize, HttpPost]
		public IActionResult editProfile(profile profile)
		{
			dal.EditPofile(profile);
			TempData["success"] = "'" + profile.OwnerName + "' Updated";
			return RedirectToAction("Collection", "Home");
		}

		[Authorize]
		[HttpGet]
		public IActionResult myPage()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public IActionResult Search(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return View("OthersPage", dal.GetProfile());
			}
			return View("OthersPage", dal.GetProfile().Where(x => x.OwnerName.ToLower().Contains(key.ToLower())));
		}

		[Authorize]
		public IActionResult OthersPage()
		{
			return View();
		}

		[Authorize]
		public IActionResult ViewImages(int id)
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}