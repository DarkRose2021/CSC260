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
			//return Redirect("Home/Privacy");
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

		public IActionResult RouteTest(int? id)
		{
			return Content($"id = {id?.ToString() ?? "NULL"}");
		}

		public IActionResult Colors(string colors)
		{
			var colorlist = colors.Split('/');
			return Content(string.Join(",", colorlist));
		}

		public IActionResult ParamTest(int? id)
		{
			return Content($"id = {id?.ToString() ?? "NULL"}");
			//?? = NULL coalescing Operator, if left is null do the right
			//id? = null check, if id is null do not do tostring on right
			//if multi params sent in, priority: form, route, query
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