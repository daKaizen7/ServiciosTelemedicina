using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;

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
        public async Task<IActionResult> Create(Antecedente antecedente)
        {
            var created = await _service.CreateAsync(antecedente);
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