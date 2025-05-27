using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Interfaces;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiagnosticosController : ControllerBase
    {
        private readonly IDiagnostico _service;

        public DiagnosticosController(IDiagnostico service)
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

        [HttpPost]
        public async Task<ActionResult<Diagnostico>> Create(Diagnostico diagnostico)
        {
            if (diagnostico == null)
                return BadRequest("Se debe de enviar el diagnostico completo");
            var created = await _service.CreateAsync(diagnostico);
            if (created == null)
                return StatusCode(500, "Error al crear el diagnostico");
            return CreatedAtAction(nameof(GetById), new { id = created.IdDiagnostico }, created);
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