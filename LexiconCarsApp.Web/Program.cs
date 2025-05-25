using LexiconCarsApp.Web.Services;

namespace LexiconCarsApp.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        //Singleton so that the same instance of CarService is used.
        builder.Services.AddSingleton<CarService>();

        var app = builder.Build();
        //So I can use Jquery.
        app.UseStaticFiles();
        //If not in development mode then use these error handlers.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error/exception");
            app.UseStatusCodePagesWithRedirects("~/error/http/{0}");
        }

        app.MapControllers();

        app.Run();
    }
}
