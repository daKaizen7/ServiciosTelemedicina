using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class CitaService
    {
        private readonly TelemedicinaDbContext _context;

        public CitaService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cita>> GetAllAsync()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<Cita?> GetByIdAsync(int id)
        {
            return await _context.Citas.FirstOrDefaultAsync(c => c.IdCita == id);
        }

        public async Task<Cita> CreateAsync(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<bool> UpdateAsync(int id, Cita cita)
        {
            if (id != cita.IdCita)
                return false;

            _context.Entry(cita).State = EntityState.Modified;

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
            var cita = await GetByIdAsync(id);
            if (cita == null)
                return false;

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Citas.AnyAsync(e => e.IdCita == id);
        }
    }
}
