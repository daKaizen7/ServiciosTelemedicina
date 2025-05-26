using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface ITratamiento
    {
        Task<List<Tratamiento>> GetAllAsync();
        Task<Tratamiento?> GetByIdAsync(int id);
        Task<Tratamiento> CreateAsync(Tratamiento tratamiento);
        Task<bool> UpdateAsync(int id, Tratamiento tratamiento);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
