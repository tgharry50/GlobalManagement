
using GlobalManagement.AddinationalFunctions;
using GlobalManagement.Database;
using Microsoft.EntityFrameworkCore;

namespace GlobalManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<GlobalDatabase>(o =>
            {
                o.UseSqlServer(builder.Configuration.GetConnectionString("Remote"));
            });
            builder.Services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.Configuration.GetConnectionString("Remote");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Development Enviroment Started: {DateTime.Now}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Production Enviroment Started: {DateTime.Now}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            app.UseAuthorization();
            app.UseCors(app =>
            {
                app.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
