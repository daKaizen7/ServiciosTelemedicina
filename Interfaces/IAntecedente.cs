using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IAntecedente
    {
        public async Task<List<Antecedente>> GetAllAsync();
        public async Task<Antecedente?> GetByIdAsync(int id);
        public async Task<Antecedente> CreateAsync(Antecedente antecedente);
        public async Task<bool> UpdateAsync(int id, Antecedente antecedente);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
