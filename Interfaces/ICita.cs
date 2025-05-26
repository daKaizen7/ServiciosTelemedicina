using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface ICita
    {
        public async Task<List<Cita>> GetAllAsync();
        public async Task<Cita?> GetByIdAsync(int id);
        public async Task<Cita> CreateAsync(Cita cita);
        public async Task<bool> UpdateAsync(int id, Cita cita);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
