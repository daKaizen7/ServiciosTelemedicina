using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface INotificacion
    {
        public async Task<List<Notificacion>> GetAllAsync();
        public async Task<Notificacion?> GetByIdAsync(int id);
        public async Task<Notificacion> CreateAsync(Notificacion notificacion);
        public async Task<bool> UpdateAsync(int id, Notificacion notificacion);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
