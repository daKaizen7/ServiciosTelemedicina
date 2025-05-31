using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class HistoriaClinicaService : IHistoriaClinica
    {
        private readonly TelemedicinaDbContext _context;

        public HistoriaClinicaService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<HistoriasClinica>> GetAllAsync()
        {
            return await _context.HistoriasClinicas.ToListAsync();
        }

        public async Task<HistoriasClinica?> GetByIdAsync(int id)
        {
            return await _context.HistoriasClinicas.FirstOrDefaultAsync(h => h.IdPaciente == id);
        }
        public async Task<List<HistoriasClinica>> GetByIdHistAsync(int id)
        {
            return await _context.HistoriasClinicas.Where(h => h.IdPaciente == id).ToListAsync();
        }
        public async Task<HistoriasClinica> CreateAsync(HistoriasClinica historiaClinica)
        {
            _context.HistoriasClinicas.Add(historiaClinica);
            await _context.SaveChangesAsync();
            return historiaClinica;
        }

        public async Task<bool> UpdateAsync(int id, HistoriasClinica historiaClinica)
        {
            if (id != historiaClinica.IdHistClin)
                return false;

            _context.Entry(historiaClinica).State = EntityState.Modified;

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
            var historia = await GetByIdAsync(id);
            if (historia == null)
                return false;

            _context.HistoriasClinicas.Remove(historia);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.HistoriasClinicas.AnyAsync(e => e.IdHistClin == id);
        }
    }
}