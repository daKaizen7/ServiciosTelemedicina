using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface ITratamiento
    {
        public async Task<List<Paciente>> GetAllAsync();
        public async Task<Tratamiento?> GetByIdAsync(int id);
        public async Task<Tratamiento> CreateAsync(Tratamiento tratamiento);
        public async Task<bool> UpdateAsync(int id, Tratamiento tratamiento);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
