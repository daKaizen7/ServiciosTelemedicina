using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;

namespace ServiciosTelemedicina.Interfaces
{
    public interface IPaciente
    {
        Task<List<PacienteDTO>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Paciente paciente);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
