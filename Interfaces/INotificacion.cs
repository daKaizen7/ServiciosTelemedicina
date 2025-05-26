using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface INotificacion
    {
        Task<List<Notificacion>> GetAllAsync();
        Task<Notificacion?> GetByIdAsync(int id);
        Task<Notificacion> CreateAsync(Notificacion notificacion);
        Task<bool> UpdateAsync(int id, Notificacion notificacion);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
