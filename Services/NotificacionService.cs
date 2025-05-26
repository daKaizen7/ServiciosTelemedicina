using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class NotificacionService : INotificacion
    {
        private readonly TelemedicinaDbContext _context;

        public NotificacionService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notificacion>> GetAllAsync()
        {
            return await _context.Notificaciones.ToListAsync();
        }

        public async Task<Notificacion?> GetByIdAsync(int id)
        {
            return await _context.Notificaciones.FirstOrDefaultAsync(n => n.IdNotificacion == id);
        }

        public async Task<Notificacion> CreateAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();
            return notificacion;
        }

        public async Task<bool> UpdateAsync(int id, Notificacion notificacion)
        {
            if (id != notificacion.IdNotificacion)
                return false;

            _context.Entry(notificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(id))
                    return false;
                else
                    throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var notificacion = await GetByIdAsync(id);
            if (notificacion == null)
                return false;

            _context.Notificaciones.Remove(notificacion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Notificaciones.AnyAsync(e => e.IdNotificacion == id);
        }
    }
}