namespace ServiciosTelemedicina.Models.DTOs
{
    public class RespuestaLoginDTO
    {
        public int IdUsuario { get; set; }
        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Rol { get; set; }
        
    }
}
