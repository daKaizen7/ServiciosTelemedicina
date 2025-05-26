namespace ServiciosTelemedicina.Models.DTOs
{
    public class PacienteDTO
    {
    public int IdUsuario { get; set; }
    public int Cedula { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Contrasena { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public string? Direccion { get; set; }    // Paciente

    }
}
