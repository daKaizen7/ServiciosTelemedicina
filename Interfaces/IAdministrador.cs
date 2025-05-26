using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IAdministrador
    {
        public async Task<List<Administrador>> GetAllAsync();
        public async Task<Administrador?> GetByIdAsync(int id);
        public async Task<bool> UpdateAsync(int id, Administrador admin);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
