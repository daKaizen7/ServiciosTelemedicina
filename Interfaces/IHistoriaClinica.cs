using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IHistoriaClinica
    {
        public async Task<List<HistoriasClinica>> GetAllAsync();
        public async Task<HistoriasClinica?> GetByIdAsync(int id);
        public async Task<HistoriasClinica> CreateAsync(HistoriasClinica historiaClinica);
        public async Task<bool> UpdateAsync(int id, HistoriasClinica historiaClinica);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
