using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IMedicamentos
    {
        Task<List<Medicamento>> GetAllAsync();
        Task<Medicamento?> GetByIdAsync(int id);
        Task<Medicamento> CreateAsync(Medicamento medicamento);
        Task<bool> UpdateAsync(int id, Medicamento medicamento);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
