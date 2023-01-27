namespace Routing
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

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

			app.MapControllerRoute(
				name: "Chicken",
				pattern: "/EatMoreChicken",
				defaults: new { controller = "Home", action = "Chicken" });

			app.MapControllerRoute(
				name: "HomePage",
				pattern: "/Routing.com",
				defaults: new { controller = "Home", action = "Index" });

			app.MapControllerRoute(
				name: "Cow",
				pattern: "/{id:int}",
				defaults: new { controller = "Home", action = "Cow" });

			app.MapControllerRoute(
				name: "Cow2",
				pattern: "/{id:int}/{cow}",
				defaults: new { controller = "Home", action = "Cow2" });

			app.MapControllerRoute(
				name: "CowGallery",
				pattern: "/AllCows/Gallery/{id:int}",
				defaults: new { controller = "Home", action = "CowGallery" });

			app.MapControllerRoute(
				name: "CowGallery2",
				pattern: "/AllCows/Gallery/{id:int}/Page{num:int}",
				defaults: new { controller = "Home", action = "CowGallery2" });

			app.MapControllerRoute(
				name: "CowGallery3",
				pattern: "/Routing.com/AllCows/Gallery/{id:int}/{num:int}",
				defaults: new { controller = "Home", action = "CowGallery2" });

			app.MapControllerRoute(
				name: "CatchAll",
				pattern: "{*anything}",
				defaults: new { controller = "Home", action = "Index" });

			app.Run();
		}
	}
}