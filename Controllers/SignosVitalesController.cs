using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignosVitalesController : ControllerBase
    {

        private readonly ISignosVitales _service;

        public SignosVitalesController(ISignosVitales service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var signosvitales = await _service.GetAllAsync();
            return Ok(signosvitales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var signosvitales = await _service.GetByIdAsync(id);
            if (signosvitales == null)
                return NotFound();
            return Ok(signosvitales);
        }

        [HttpPost]
        public async Task<ActionResult<SignosVitales>> Create(SignosVitales signosvitales)
        {
            if (signosvitales == null)
                return BadRequest("Se debe de enviar los signosvitales completo");
            var created = await _service.CreateAsync(signosvitales);
            if (created == null)
                return StatusCode(500, "Error al crear los signosvitales");
            return CreatedAtAction(nameof(GetById), new { id = created.IdSignos }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SignosVitales signosvitales)
        {
            var updated = await _service.UpdateAsync(id, signosvitales);
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
