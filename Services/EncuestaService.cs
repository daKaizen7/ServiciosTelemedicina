using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class EncuestaService : IEncuesta
    {
        private readonly TelemedicinaDbContext _context;

        public EncuestaService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Encuestas>> GetAllAsync()
        {
            return await _context.Encuestas.ToListAsync();
        }

        public async Task<Encuestas?> GetByIdAsync(int id)
        {
            return await _context.Encuestas.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Encuestas> CreateAsync(Encuestas Encuestas)
        {
            _context.Encuestas.Add(Encuestas);
            await _context.SaveChangesAsync();
            return Encuestas;
        }

        public async Task<bool> UpdateAsync(int id, Encuestas Encuestas)
        {
            if (id != Encuestas.Id)
                return false;

            _context.Entry(Encuestas).State = EntityState.Modified;

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
            var Encuestas = await GetByIdAsync(id);
            if (Encuestas == null)
                return false;

            _context.Encuestas.Remove(Encuestas);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Encuestas.AnyAsync(e => e.Id == id);
        }
    }
}
