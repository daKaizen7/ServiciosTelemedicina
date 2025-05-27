using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TratamientosController : ControllerBase
    {
        private readonly TratamientoService _service;

        public TratamientosController(TratamientoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tratamientos = await _service.GetAllAsync();
            return Ok(tratamientos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tratamiento = await _service.GetByIdAsync(id);
            if (tratamiento == null)
                return NotFound();
            return Ok(tratamiento);
        }

        [HttpPost]
        public async Task<ActionResult<Tratamiento>> Create(Tratamiento tratamientos)
        {
            if (tratamientos == null)
                return BadRequest("Se debe de enviar el Tratamiento completo");
            var created = await _service.CreateAsync(tratamientos);
            if (created == null)
                return StatusCode(500, "Error al crear el Tratamiento");
            return CreatedAtAction(nameof(GetById), new { id = created.IdTratamiento }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tratamiento tratamiento)
        {
            var updated = await _service.UpdateAsync(id, tratamiento);
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