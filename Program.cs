
using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Services;

namespace ServiciosTelemedicina
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TelemedicinaDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TelemedicinaDB")));

            //Registrar/inyectar los servicios para que queden configuradas correctamente.
            builder.Services.AddScoped<AdministradorService>();
            builder.Services.AddScoped<PacienteService>();
            builder.Services.AddScoped<TerapeutaService>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<DiagnosticoService>();
            builder.Services.AddScoped<CitaService>();
            builder.Services.AddScoped<TratamientoService>();
            builder.Services.AddScoped<HistoriaClinicaService>();
            builder.Services.AddScoped<AntecedenteService>();
            builder.Services.AddScoped<InformeService>();
            builder.Services.AddScoped<NotificacionService>();



            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/", () => "Servidor activo");

            app.Run();

 
        }
    }
}
