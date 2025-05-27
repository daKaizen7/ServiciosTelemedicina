using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Interfaces;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AntecedentesController : ControllerBase
    {
        private readonly AntecedenteService _service;

        public AntecedentesController(AntecedenteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var antecedentes = await _service.GetAllAsync();
            return Ok(antecedentes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var antecedente = await _service.GetByIdAsync(id);
            if (antecedente == null)
                return NotFound();
            return Ok(antecedente);
        }

        [HttpPost]
        public async Task<ActionResult<Antecedente>> Create(Antecedente antecedente)
        {
            if (antecedente == null)
                return BadRequest("Se debe de enviar el antecedente completo");
            var created = await _service.CreateAsync(antecedente);
            if (created == null)
                return StatusCode(500, "Error al crear el antecedente");
            return CreatedAtAction(nameof(GetById), new { id = created.IdAntecedente }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Antecedente antecedente)
        {
            var updated = await _service.UpdateAsync(id, antecedente);
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