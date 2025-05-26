using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class InformeService : IInforme
    {
        private readonly TelemedicinaDbContext _context;

        public InformeService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Informe>> GetAllAsync()
        {
            return await _context.Informes.ToListAsync();
        }

        public async Task<Informe?> GetByIdAsync(int id)
        {
            return await _context.Informes.FirstOrDefaultAsync(i => i.IdInforme == id);
        }

        public async Task<Informe> CreateAsync(Informe informe)
        {
            _context.Informes.Add(informe);
            await _context.SaveChangesAsync();
            return informe;
        }

        public async Task<bool> UpdateAsync(int id, Informe informe)
        {
            if (id != informe.IdInforme)
                return false;

            _context.Entry(informe).State = EntityState.Modified;

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
            var informe = await GetByIdAsync(id);
            if (informe == null)
                return false;

            _context.Informes.Remove(informe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Informes.AnyAsync(e => e.IdInforme == id);
        }
    }
}