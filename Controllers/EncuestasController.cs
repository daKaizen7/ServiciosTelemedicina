using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Services;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncuestasController : ControllerBase
    {
        private readonly IEncuesta _service;

        public EncuestasController(IEncuesta service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var encuestas = await _service.GetAllAsync();
            return Ok(encuestas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var encuestas = await _service.GetByIdAsync(id);
            if (encuestas == null)
                return NotFound();
            return Ok(encuestas);
        }

        [HttpPost]
        public async Task<ActionResult<Encuestas>> Create(Encuestas encuestas)
        {
            if (encuestas == null)
                return BadRequest("Se debe de enviar la encuestas completa");
            var created = await _service.CreateAsync(encuestas);
            if (created == null)
                return StatusCode(500, "Error al crear la encuesta");
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Encuestas encuestas)
        {
            var updated = await _service.UpdateAsync(id, encuestas);
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
