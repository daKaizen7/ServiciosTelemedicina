using Microsoft.EntityFrameworkCore;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class MedicamentoService : IMedicamentos
    {
        private readonly TelemedicinaDbContext _context;

        public MedicamentoService(TelemedicinaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medicamento>> GetAllAsync()
        {
            return await _context.Medicamentos.ToListAsync();
        }

        public async Task<Medicamento?> GetByIdAsync(int id)
        {
            return await _context.Medicamentos.FirstOrDefaultAsync(d => d.IdMedicamento == id);
        }

        public async Task<Medicamento> CreateAsync(Medicamento medicamento)
        {
            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();
            return medicamento;
        }

        public async Task<bool> UpdateAsync(int id, Medicamento medicamento)
        {
            if (id != medicamento.IdMedicamento)
                return false;

            _context.Entry(medicamento).State = EntityState.Modified;

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
            var Medicamento = await GetByIdAsync(id);
            if (Medicamento == null)
                return false;

            _context.Medicamentos.Remove(Medicamento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Medicamentos.AnyAsync(e => e.IdMedicamento == id);
        }
    }
}
