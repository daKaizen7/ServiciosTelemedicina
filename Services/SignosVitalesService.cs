using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class SignosVitalesService : ISignosVitales
    {
        private readonly TelemedicinaDbContext _context;

        public SignosVitalesService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<SignosVitales>> GetAllAsync()
        {
            return await _context.SignosVitales.ToListAsync();
        }

        public async Task<SignosVitales?> GetByIdAsync(int id)
        {
            return await _context.SignosVitales.FirstOrDefaultAsync(n => n.IdSignos == id);
        }

        public async Task<SignosVitales> CreateAsync(SignosVitales signosvitales)
        {
            _context.SignosVitales.Add(signosvitales);
            await _context.SaveChangesAsync();
            return signosvitales;
        }

        public async Task<bool> UpdateAsync(int id, SignosVitales signosvitales)
        {
            if (id != signosvitales.IdSignos)
                return false;

            _context.Entry(signosvitales).State = EntityState.Modified;

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
            var signosvitales = await GetByIdAsync(id);
            if (signosvitales == null)
                return false;

            _context.SignosVitales.Remove(signosvitales);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.SignosVitales.AnyAsync(e => e.IdSignos == id);
        }
    }
}
