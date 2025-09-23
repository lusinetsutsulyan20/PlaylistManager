using Microsoft.EntityFrameworkCore;
using PlaylistManager.DB;
using Core.Interfaces;
using DAL.Repositories;
using Service.Interfaces;
using Service.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PlaylistManager.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // PostgreSQL DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Repositories 
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            builder.Services.AddScoped<ISongRepository, SongRepository>();
            builder.Services.AddScoped<IPlaylistSongRepository, PlaylistSongRepository>();

            // Services 
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPlaylistService, PlaylistService>();
            builder.Services.AddScoped<ISongService, SongService>();
            builder.Services.AddScoped<IPlaylistSongService, PlaylistSongService>();

            // Controllers and Swagger 
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Middleware
            app.UseHttpsRedirection(); // <--- Add this
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlaylistManager API v1");
                c.RoutePrefix = string.Empty; // Swagger available at root: http://localhost:5251/
            });

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
