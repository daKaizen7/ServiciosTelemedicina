using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IAutenticacion
    {
        Task<RespuestaLoginDTO?> AutenticarAsync(string correo, string contrasena);
    }
}
