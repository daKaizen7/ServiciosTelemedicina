using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IDiagnostico
    {
        Task<List<Diagnostico>> GetAllAsync();
        Task<Diagnostico?> GetByIdAsync(int id);
        Task<Diagnostico> CreateAsync(Diagnostico diagnostico);
        Task<bool> UpdateAsync(int id, Diagnostico diagnostico);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
