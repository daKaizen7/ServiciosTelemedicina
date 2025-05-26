using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Interfaces
{
    public interface ITerapeuta
    {
        Task<List<TerapeutaDTO>> GetAllAsync();
        Task<Terapeuta?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Terapeuta terapeuta);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
