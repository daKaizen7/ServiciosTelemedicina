using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IHistoriaClinica
    {
        Task<List<HistoriasClinica>> GetAllAsync();
        Task<HistoriasClinica> GetByIdAsync(int id);
        Task<HistoriasClinica> CreateAsync(HistoriasClinica historiaClinica);
        Task<bool> UpdateAsync(int id, HistoriasClinica historiaClinica);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
