using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Services
{
    public class MedicamentosService
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
            return await _context.Medicamentos.FirstOrDefaultAsync(i => i.IdMedicamento == id);
        }

        public async Task<Medicamento> CreateAsync(Medicamento Medicamento)
        {
            _context.Medicamentos.Add(Medicamento);
            await _context.SaveChangesAsync();
            return Medicamento;
        }

        public async Task<bool> UpdateAsync(int id, Medicamento Medicamento)
        {
            if (id != Medicamento.IdMedicamento)
                return false;

            _context.Entry(Medicamento).State = EntityState.Modified;

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
