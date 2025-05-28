using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Factories;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Services
{
    public class UsuarioService : IUsuario
    {
        private readonly TelemedicinaDbContext _context;

        public UsuarioService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListarUsuarioDTO>> GetAllAsync()
        {
            return await _context.Usuarios
                .OfType<Usuario>()
                .Select(t => new ListarUsuarioDTO
                {
                    IdUsuario = t.IdUsuario,
                    Cedula = t.Cedula,
                    Nombre = t.Nombre,
                    Apellido = t.Apellido,
                    Contrasena = t.Contrasena,
                    Telefono = t.Telefono,
                    Correo = t.Correo,
                    FechaNacimiento = t.FechaNacimiento,
                    Rol = t.Rol
                })
                .ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task<Usuario> CrearUsuarioAsync(UsuarioDTO dto)
        {
            var usuario = UsuarioFactory.CrearUsuario(dto);//Aquí se llama al Factory Method para crear el usuario según su rol.
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> UpdateAsync(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
                return false;

            _context.Entry(usuario).State = EntityState.Modified;

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
            var usuario = await GetByIdAsync(id);
            if (usuario == null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Usuarios.AnyAsync(e => e.IdUsuario == id);
        }
    }
}