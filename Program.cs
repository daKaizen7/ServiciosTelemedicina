
using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Models;
using Telemedicina.Services;

namespace ServiciosTelemedicina
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Registrar el servicio AdministradorService
            builder.Services.AddScoped<AdministradorService>();

            builder.Services.AddDbContext<TelemedicinaDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TelemedicinaDB")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/", () => "Servidor activo");

            app.Run();

 
        }
    }
}
