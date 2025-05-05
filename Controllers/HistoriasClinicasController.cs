using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoriasClinicasController : ControllerBase
    {
        private readonly HistoriaClinicaService _service;

        public HistoriasClinicasController(HistoriaClinicaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historias = await _service.GetAllAsync();
            return Ok(historias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var historia = await _service.GetByIdAsync(id);
            if (historia == null)
                return NotFound();
            return Ok(historia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HistoriasClinica historiaClinica)
        {
            var updated = await _service.UpdateAsync(id, historiaClinica);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}