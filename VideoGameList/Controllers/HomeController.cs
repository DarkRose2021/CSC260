using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameList.Models;

namespace VideoGameList.Controllers
{
	public class HomeController : Controller
	{
		private static List<Games> Gamelist = new List<Games>
		{
			new Games("Stardew Valley", "Windows PC, PS4, Xbox One, Switch, Mobile", "Indie, RPG, Simulation", 'E', 2016, "stardew.jpg","", null, false),
			new Games("Stray", "Windows PC, PS4, PS5", "Adventure, Indie", 'E', 2022, "stray.jpg", "", null, false),
			new Games("Spirtfarer", "PC, PS4, Switch, Xbox One", "Adventure, Indie, Simulation", 'T', 2020, "spiritfarer.jpg", "", null, false),
			new Games("Satisfactory","PC", "Adventure, Indie, Simulation, Strategy, Early Access", null, 2020, "satifactory.jpg", "", null, false),
			new Games("House Flipper", "PC", "Indie, Simulation", 'E', 2018, "houseflipper.jpg", "", null, false),
			new Games("Sims 4", "PC, PS4, Xbox", "Life simulation game, Free-to-play, Casual game, Simulation Game, Adventure", 'T', 2014, "sims4.png", "", null, false)
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

		[HttpGet]
		public IActionResult Collection()
		{
			return View(Gamelist);
		}

		[HttpPost]
		public IActionResult Collection(int? id, string LoanedTo)
		{
			DateTime dt = DateTime.Now;
			Games onegame = Gamelist.Find(g => g.Id == id);
			onegame.LoanedTo = LoanedTo;
			onegame.LoanedDate = dt;

			return View(Gamelist);
		}

		[HttpPost]
		public IActionResult Return(int? id)
		{
			Games onegame = Gamelist.Find(g => g.Id == id);
			onegame.LoanedDate = null;
			onegame.LoanedTo = null;
			return RedirectToAction("Collection", "Home");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}