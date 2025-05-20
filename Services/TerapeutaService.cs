using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Services
{
    public class TerapeutaService
    {
        private readonly TelemedicinaDbContext _context;

        public TerapeutaService(TelemedicinaDbContext context)
        {
            _context = context;
        }


        public async Task<List<TerapeutaDTO>> GetAllAsync()
        {
            return await _context.Usuarios
                .OfType<Terapeuta>()
                .Select(t => new TerapeutaDTO
                {
                    IdUsuario = t.IdUsuario,
                    Cedula = t.Cedula,
                    Nombre = t.Nombre,
                    Apellido = t.Apellido,
                    Contrasena = t.Contrasena,
                    Telefono = t.Telefono,
                    Correo = t.Correo,
                    FechaNacimiento = t.FechaNacimiento,
                    Cargo = t.Cargo
                })
                .ToListAsync();
        }

        public async Task<Terapeuta?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.OfType<Terapeuta>()
                .FirstOrDefaultAsync(t => t.IdUsuario == id);
        }

        public async Task<bool> UpdateAsync(int id, Terapeuta terapeuta)
        {
            if (id != terapeuta.IdUsuario)
                return false;

            _context.Entry(terapeuta).State = EntityState.Modified;

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
            var terapeuta = await GetByIdAsync(id);
            if (terapeuta == null)
                return false;

            _context.Usuarios.Remove(terapeuta);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Usuarios.OfType<Terapeuta>().AnyAsync(e => e.IdUsuario == id);
        }
    }
}