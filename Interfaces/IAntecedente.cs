using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IAntecedente
    {
        Task<List<Antecedente>> GetAllAsync();
        Task<Antecedente?> GetByIdAsync(int id);
        Task<Antecedente> CreateAsync(Antecedente antecedente);
        Task<bool> UpdateAsync(int id, Antecedente antecedente);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
