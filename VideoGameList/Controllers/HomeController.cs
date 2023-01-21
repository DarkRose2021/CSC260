using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameList.Models;

namespace VideoGameList.Controllers
{
	public class HomeController : Controller
	{
		private static List<Games> Gamelist = new List<Games>
		{
			new Games("Stardew Valley", "PC, PS4, Xbox One, Switch", "Indie, RPG, Simulation", 'E', 2016, "stardew.jpg","", null),
			new Games("Slime Rancher", "PC, PS4, Xbox One", "Action, Adventure, Indie", 'E', 2017, "slimerancher.jpg", "", null),
			new Games("Spirtfarer", "PC, PS4, Switch, Xbox One", "Adventure, Indie, Simulation", 'T', 2020, "spiritfarer.jpg", "", null),
			new Games("Satisfactory","PC", "Adventure, Indie, Strategy", null, 2020, "satifactory.jpg", "", null),
			new Games("House Flipper", "PC", "Indie, Simulation", 'E', 2018, "houseflipper.jpg", "", null),
			new Games("Stray", "PC, PS4 & 5", "Adventure, Indie", 'E', 2022, "stray.jpg", "", null)
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
			ViewBag.count = Gamelist.Count;
			return View(Gamelist);
		}

		[HttpPost]
		public IActionResult Collection(int? id, string LoanedTo)
		{
			DateTime dt = DateTime.Now;
			Games onegame = Gamelist.Find(g => g.Id == id);
			onegame.LoanedTo = LoanedTo;
			onegame.LoanedDate = dt;
			onegame.LoanedDate.Value.ToShortDateString();

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