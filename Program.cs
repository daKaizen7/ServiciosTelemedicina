
using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
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
            builder.Services.AddScoped<IAdministrador, AdministradorService>();
            builder.Services.AddScoped<IPaciente, PacienteService>();
            builder.Services.AddScoped<ITerapeuta, TerapeutaService>();
            builder.Services.AddScoped<IUsuario, UsuarioService>();
            builder.Services.AddScoped<IDiagnostico, DiagnosticoService>();
            builder.Services.AddScoped<ICita, CitaService>();
            builder.Services.AddScoped<ITratamiento, TratamientoService>();
            builder.Services.AddScoped<IHistoriaClinica, HistoriaClinicaService>();
            builder.Services.AddScoped<IAntecedente, AntecedenteService>();
            builder.Services.AddScoped<IInforme, InformeService>();
            builder.Services.AddScoped<INotificacion, NotificacionService>();
            builder.Services.AddScoped<IAutenticacion, AutenticacionService>();
            builder.Services.AddScoped<IMedicamentos, MedicamentoService>();
            builder.Services.AddScoped<ISignosVitales, SignosVitalesService>();
            builder.Services.AddScoped<IEncuesta, EncuestaService>();



            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuración de CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // Cambiar por URL del frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

         

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.MapGet("/", () => "Servidor activo");

            app.Run();

 
        }
    }
}
