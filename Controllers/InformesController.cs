using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Interfaces;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformesController : ControllerBase
    {
        private readonly IInforme _service;

        public InformesController(IInforme service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var informes = await _service.GetAllAsync();
            return Ok(informes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var informe = await _service.GetByIdAsync(id);
            if (informe == null)
                return NotFound();
            return Ok(informe);
        }

        [HttpPost]
        public async Task<ActionResult<Informe>> Create(Informe informe)
        {
            if (informe == null)
                return BadRequest("Se debe de enviar el informe completo");
            var created = await _service.CreateAsync(informe);
            if (created == null)
                return StatusCode(500, "Error al crear el informe");
            return CreatedAtAction(nameof(GetById), new { id = created.IdInforme }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Informe informe)
        {
            var updated = await _service.UpdateAsync(id, informe);
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