using RMV.DriverExaminer.Services.Interfaces;
using RMV.DriverExaminer.Services.Services;
using RMV.DriverExaminer.Services.Services.Interfaces;
using RMV.DriverExaminer.Web.Middleware;

namespace RMV.DriverExaminer.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient();

            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient<IAppClientsService, AppClientsService>();

            builder.Services.AddTransient<IExamDetailsService, ExamDetailsService>();

            //Register the IExceptionHandler service with dependency injection
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            //call UseExceptionHandler to add the ExceptionHandlerMiddleware to the request pipeline
            app.UseExceptionHandler("/Home/Error");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
