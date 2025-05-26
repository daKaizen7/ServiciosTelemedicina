using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IUsuario
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> CrearUsuarioAsync(UsuarioDto dto);
        Task<bool> UpdateAsync(int id, Usuario usuario);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
