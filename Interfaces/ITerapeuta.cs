using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface ITerapeuta
    {
        public async Task<List<Terapeuta>> GetAllAsync();
        public async Task<Terapeuta?> GetByIdAsync(int id);
        public async Task<bool> UpdateAsync(int id, Terapeuta terapeuta);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
