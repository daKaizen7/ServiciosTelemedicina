using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IUsuario
    {
        public async Task<List<Usuario>> GetAllAsync();
        public async Task<Usuario?> GetByIdAsync(int id);
        public async Task<Usuario> CrearUsuarioAsync(UsuarioDto dto);
        public async Task<bool> UpdateAsync(int id, Usuario usuario);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
