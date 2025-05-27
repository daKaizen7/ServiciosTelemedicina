using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IEncuesta
    {
        Task<List<Encuestas>> GetAllAsync();
        Task<Encuestas?> GetByIdAsync(int id);
        Task<Encuestas> CreateAsync(Encuestas encuestas);
        Task<bool> UpdateAsync(int id, Encuestas encuestas);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
