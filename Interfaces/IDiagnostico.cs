using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IDiagnostico
    {
        public async Task<List<Diagnostico>> GetAllAsync();
        public async Task<Diagnostico?> GetByIdAsync(int id);
        public async Task<Diagnostico> CreateAsync(Diagnostico diagnostico);
        public async Task<bool> UpdateAsync(int id, Diagnostico diagnostico);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
