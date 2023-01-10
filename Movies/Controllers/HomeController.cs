using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
	public class HomeController : Controller
	{
		private static int intCount = 0;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			ViewData["Title"] = "Privacy Policy";
			return View();
		}

		public IActionResult Before()
		{
			return View();
		}

		public IActionResult madlib()
		{
			ViewData["Title"] = "Input";
			return View();
		}

		[HttpPost]
		public IActionResult Output(string Firstname)
		{
			ViewBag.FirstName = Firstname;
			return View();
		}

		public IActionResult Counter()
		{
			ViewBag.Count = intCount++;
			ViewData["Count"] = intCount;
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}