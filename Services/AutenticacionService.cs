using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class AutenticacionService
    {
        private readonly TelemedicinaDbContext _context;

        public AutenticacionService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<string?> AutenticarAsync(string correo, string contrasena)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo && u.Contrasena == contrasena);

            return usuario?.Rol;
        }
    }
}
