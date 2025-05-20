using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Services
{
    public class AdministradorService
    {
        private readonly TelemedicinaDbContext _context;

        public AdministradorService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<AdministradorDTO>> GetAllAsync()
        {
            return await _context.Usuarios
                .OfType<Administrador>()
                .Select(t => new AdministradorDTO
                {
                    IdUsuario = t.IdUsuario,
                    Cedula = t.Cedula,
                    Nombre = t.Nombre,
                    Apellido = t.Apellido,
                    Contrasena = t.Contrasena,
                    Telefono = t.Telefono,
                    Correo = t.Correo,
                    FechaNacimiento = t.FechaNacimiento,
                    Activo = t.Activo,
                    Permisos = t.Permisos
                })
                .ToListAsync();
        }

        public async Task<Administrador?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.OfType<Administrador>()
                .FirstOrDefaultAsync(a => a.IdUsuario == id);
        }


        public async Task<bool> UpdateAsync(int id, Administrador admin)
        {
            if (id != admin.IdUsuario)
                return false;

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var admin = await GetByIdAsync(id);
            if (admin == null)
                return false;

            _context.Usuarios.Remove(admin);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Usuarios.OfType<Administrador>().AnyAsync(e => e.IdUsuario == id);
        }
    }
}