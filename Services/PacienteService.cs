using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Services
{
    public class PacienteService
    {
        private readonly TelemedicinaDbContext _context;

        public PacienteService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<PacienteDTO>> GetAllAsync()
        {
            return await _context.Usuarios
                .OfType<Paciente>()
                .Select(t => new PacienteDTO
                {
                    IdUsuario = t.IdUsuario,
                    Cedula = t.Cedula,
                    Nombre = t.Nombre,
                    Apellido = t.Apellido,
                    Contrasena = t.Contrasena,
                    Telefono = t.Telefono,
                    Correo = t.Correo,
                    FechaNacimiento = t.FechaNacimiento,
                    Direccion = t.Direccion 
                })
                .ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.OfType<Paciente>()
                .FirstOrDefaultAsync(p => p.IdUsuario == id);
        }

        public async Task<bool> UpdateAsync(int id, Paciente paciente)
        {
            if (id != paciente.IdUsuario)
                return false;

            _context.Entry(paciente).State = EntityState.Modified;

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
            var paciente = await GetByIdAsync(id);
            if (paciente == null)
                return false;

            _context.Usuarios.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Usuarios.OfType<Paciente>().AnyAsync(e => e.IdUsuario == id);
        }
    }
}