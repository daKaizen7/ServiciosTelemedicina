using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IInforme
    {
        Task<List<Informe>> GetAllAsync();
        Task<Informe?> GetByIdAsync(int id);
        Task<Informe> CreateAsync(Informe informe);
        Task<bool> UpdateAsync(int id, Informe informe);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
