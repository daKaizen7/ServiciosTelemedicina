using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Services
{
    public class AutenticacionService : IAutenticacion
    {
        private readonly TelemedicinaDbContext _context;

        public AutenticacionService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<RespuestaLoginDTO?> AutenticarAsync(string correo, string contrasena)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Contrasena == contrasena);
            if (usuario == null)
                return null;
            return new RespuestaLoginDTO
            {
                IdUsuario = usuario!.IdUsuario,
                Cedula = usuario!.Cedula,
                Nombre = usuario!.Nombre,
                Apellido = usuario!.Apellido,
                Correo = usuario!.Correo,
                Rol = usuario!.Rol
            };
        }
    }
}
