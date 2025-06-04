
using BGC.Api.Web.Controllers.Boardgames;
using BGC.Api.Web.Data;
using BGC.Api.Web.Models.Boardgames;
using BGC.Api.Web.Models.Collections;
using BGC.Api.Web.Models.Shared;
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

            builder.Services.AddScoped<IRepository<Boardgame>, Repository<Boardgame>>();
            builder.Services.AddScoped<IRepository<Collection>, Repository<Collection>>();

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
