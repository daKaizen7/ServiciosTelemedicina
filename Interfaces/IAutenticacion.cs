using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IAutenticacion
    {
        Task<string?> AutenticarAsync(string correo, string contrasena);
    }
}
