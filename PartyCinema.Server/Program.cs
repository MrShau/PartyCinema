using Microsoft.EntityFrameworkCore;
using PartyCinema.Server.Repositories;
using PartyCinema.Server.Repositories.Interfaces;
using PartyCinema.Server.Services;

namespace PartyCinema.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            const string ReactAppHost = "https://localhost:5173";

            builder.Services.AddCors();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
            });

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<JwtService>();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins(ReactAppHost).AllowAnyHeader().AllowCredentials().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
