/*DTO (Data Transfer Object) es un objeto simple que usamos para transportar datos entre capas de una aplicación 
  especialmente entre la capa de presentación (controladores) y la capa de negocio (servicios, lógica, base de datos).*/
namespace ServiciosTelemedicina.Models.DTOs
{
    public class UsuarioDto
{
    public int Cedula { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Contrasena { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Correo { get; set; }

    public string? Rol { get; set; }
    public string? Direccion { get; set; }    // Paciente
    public string? Cargo { get; set; }        // Terapeuta
    public bool? Activo { get; set; }         // Administrador
    }
}
