using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IPaciente
    {
        public async Task<List<Paciente>> GetAllAsync();
        public async Task<Paciente?> GetByIdAsync(int id);
        public async Task<bool> UpdateAsync(int id, Paciente paciente);
        public async Task<bool> DeleteAsync(int id);
        public async Task<bool> ExistsAsync(int id);
    }
}
