using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticosController : ControllerBase
    {
        private readonly DiagnosticoService _service;

        public DiagnosticosController(DiagnosticoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diagnosticos = await _service.GetAllAsync();
            return Ok(diagnosticos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var diagnostico = await _service.GetByIdAsync(id);
            if (diagnostico == null)
                return NotFound();
            return Ok(diagnostico);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Diagnostico diagnostico)
        {
            var updated = await _service.UpdateAsync(id, diagnostico);
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