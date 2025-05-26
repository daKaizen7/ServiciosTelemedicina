using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IAdministrador
    {
        Task<List<AdministradorDTO>> GetAllAsync();
        Task<Administrador?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Administrador admin);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
