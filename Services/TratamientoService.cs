using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class TratamientoService : ITratamiento
    {
        private readonly TelemedicinaDbContext _context;

        public TratamientoService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tratamiento>> GetAllAsync()
        {
            return await _context.Tratamientos.ToListAsync();
        }

        public async Task<Tratamiento?> GetByIdAsync(int id)
        {
            return await _context.Tratamientos.FirstOrDefaultAsync(t => t.IdTratamiento == id);
        }

        public async Task<Tratamiento> CreateAsync(Tratamiento tratamiento)
        {
            _context.Tratamientos.Add(tratamiento);
            await _context.SaveChangesAsync();
            return tratamiento;
        }

        public async Task<bool> UpdateAsync(int id, Tratamiento tratamiento)
        {
            if (id != tratamiento.IdTratamiento)
                return false;

            _context.Entry(tratamiento).State = EntityState.Modified;

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
            var tratamiento = await GetByIdAsync(id);
            if (tratamiento == null)
                return false;

            _context.Tratamientos.Remove(tratamiento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Tratamientos.AnyAsync(e => e.IdTratamiento == id);
        }
    }
}