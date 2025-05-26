using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class AntecedenteService : IAntecedente
    {
        private readonly TelemedicinaDbContext _context;

        public AntecedenteService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Antecedente>> GetAllAsync()
        {
            return await _context.Antecedentes.ToListAsync();
        }

        public async Task<Antecedente?> GetByIdAsync(int id)
        {
            return await _context.Antecedentes.FirstOrDefaultAsync(a => a.IdAntecedente == id);
        }

        public async Task<Antecedente> CreateAsync(Antecedente antecedente)
        {
            _context.Antecedentes.Add(antecedente);
            await _context.SaveChangesAsync();
            return antecedente;
        }

        public async Task<bool> UpdateAsync(int id, Antecedente antecedente)
        {
            if (id != antecedente.IdAntecedente)
                return false;

            _context.Entry(antecedente).State = EntityState.Modified;

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
            var antecedente = await GetByIdAsync(id);
            if (antecedente == null)
                return false;

            _context.Antecedentes.Remove(antecedente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Antecedentes.AnyAsync(e => e.IdAntecedente == id);
        }
    }
}