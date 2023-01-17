using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameList.Models;

namespace VideoGameList.Controllers
{
	public class HomeController : Controller
	{
		private static List<Games> Gamelist = new List<Games>
		{
			new Games("Stardew Valley", "Windows PC, PlayStation 4, Xbox One, Switch, Mobile", "Indie, RPG, Simulation", 'E', 2016, "~/assets/stardew.jpg","", null, false),
			new Games("Stray", "Windows PC, PlayStation 4, PlayStation 5", "Adventure, Indie", 'E', 2022, "~/assets/stray.jpg", "", null, false),
			new Games("Spirtfarer", "PC, PlayStation 4, Nintendo Switch, Xbox One", "Adventure, Indie, Simulation", 'T', 2020, "~/assets/spiritfarer.jpg", "", null, false),
			new Games(),
			new Games(),
			new Games(),
			new Games(),
			new Games(),
			new Games(),
			new Games(),
			new Games(),
			new Games(),
		};
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult LoanedOut()
		{
			return View();
		}

		public IActionResult Collection()
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