using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface ISignosVitales
    {
        Task<List<SignosVitales>> GetAllAsync();
        Task<SignosVitales?> GetByIdAsync(int id);
        Task<SignosVitales> CreateAsync(SignosVitales signosvitales);
        Task<bool> UpdateAsync(int id, SignosVitales signosvitales);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
