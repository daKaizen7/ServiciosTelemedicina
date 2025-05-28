/*DTO (Data Transfer Object) es un objeto simple que usamos para transportar datos entre capas de una aplicación 
  especialmente entre la capa de presentación (controladores) y la capa de negocio (servicios, lógica, base de datos).*/
namespace ServiciosTelemedicina.Models.DTOs
{
    public class ListarUsuarioDTO
    {

        public int IdUsuario { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Rol { get; set; }

    }
}
