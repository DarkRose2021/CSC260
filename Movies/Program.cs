using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Interfaces;

namespace Movies
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.AddTransient<IDataAccessLayer, MovieListDAL>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			//app.MapControllerRoute(
			//	name: "PizzaRouteTest",
			//	//pattern: "pizza",
			//	//pattern: "pizza/[id]",
			//	//pattern: "pizza/{id?}",
			//	pattern: "pizza/{id:int?}",
			//	defaults: new { controller = "Home", action = "RouteTest" });

			//app.MapControllerRoute(
			//	name: "Colors",
			//	pattern: "home/colors/{*color}",
			//	defaults: new { controller = "Home", action = "Colors" });

			//app.MapControllerRoute(
			//	name: "CatchAll",
			//	pattern: "{*anything}",
			//	defaults: new { controller = "Home", action = "error" });

			app.Run();
		}
	}
}