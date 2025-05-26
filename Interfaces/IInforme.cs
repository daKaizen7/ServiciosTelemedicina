using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IInforme
    {
        public async Task<List<Informe>> GetAllAsync();
        public async Task<Informe?> GetByIdAsync(int id);
        public async Task<Informe> CreateAsync(Informe informe);
        public async Task<bool> UpdateAsync(int id, Informe informe);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
