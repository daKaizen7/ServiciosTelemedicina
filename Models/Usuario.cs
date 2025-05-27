using System;

namespace ServiciosTelemedicina.Models;

public abstract partial class Usuario
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

    public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();

}
