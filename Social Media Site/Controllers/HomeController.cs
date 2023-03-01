using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social_Media_Site.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Social_Media_Site.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		/*IDataAccessLayer dal;
        public HomeController(IDataAccessLayer indal)
        {
            dal = indal;
        }*/
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		[Authorize]
		public IActionResult editProfile()
		{
			return View();
		}

		[Authorize]
		public IActionResult AddProfile()
		{
			string x;
			x = User.FindFirstValue(ClaimTypes.NameIdentifier);
			/*if (ModelState.IsValid)
            {
                profile.Id = x;
            }*/
			return Content(x);
		}

		[Authorize]
		[HttpGet]
		public IActionResult myPage()
		{
			return View();
		}

		[Authorize]
		public IActionResult OthersPage()
		{
			return View();
		}

		[Authorize]
		public IActionResult ViewImages()
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