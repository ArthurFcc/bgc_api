using BGC.Api.Web.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace BGC.Api.Web
{
    public class Program
    {
        public static void Main(string[ ] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddOpenApi(options =>
            {
                options.AddScalarTransformers();
            });

            builder.Services.AddDbContext<BGCDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            var app = builder.Build();

            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.DarkMode = true;
                options.Theme = ScalarTheme.DeepSpace;
                options.Title = "BGC | Boardgame Collector API";
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCors("*");
            app.Run();
        }
    }
}
