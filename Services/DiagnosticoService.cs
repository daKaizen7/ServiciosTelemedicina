using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class DiagnosticoService
    {
        private readonly TelemedicinaDbContext _context;

        public DiagnosticoService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Diagnostico>> GetAllAsync()
        {
            return await _context.Diagnosticos.ToListAsync();
        }

        public async Task<Diagnostico?> GetByIdAsync(int id)
        {
            return await _context.Diagnosticos.FirstOrDefaultAsync(d => d.IdDiagnostico == id);
        }

        public async Task<Diagnostico> CreateAsync(Diagnostico diagnostico)
        {
            _context.Diagnosticos.Add(diagnostico);
            await _context.SaveChangesAsync();
            return diagnostico;
        }

        public async Task<bool> UpdateAsync(int id, Diagnostico diagnostico)
        {
            if (id != diagnostico.IdDiagnostico)
                return false;

            _context.Entry(diagnostico).State = EntityState.Modified;

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
            var diagnostico = await GetByIdAsync(id);
            if (diagnostico == null)
                return false;

            _context.Diagnosticos.Remove(diagnostico);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Diagnosticos.AnyAsync(e => e.IdDiagnostico == id);
        }
    }
}