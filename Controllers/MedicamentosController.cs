using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Services;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentosController : ControllerBase
    {
        private readonly MedicamentoService _service;

        public MedicamentosController(MedicamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Medicamentoss = await _service.GetAllAsync();
            return Ok(Medicamentoss);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Medicamentos = await _service.GetByIdAsync(id);
            if (Medicamentos == null)
                return NotFound();
            return Ok(Medicamentos);
        }

        [HttpPost]
        public async Task<ActionResult<Medicamento>> Create(Medicamento medicamentos)
        {
            if (medicamentos == null)
                return BadRequest("Se debe de enviar el Medicamento completo");
            var created = await _service.CreateAsync(medicamentos);
            if (created == null)
                return StatusCode(500, "Error al crear el Medicamento");
            return CreatedAtAction(nameof(GetById), new { id = created.IdMedicamento }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Medicamento medicamentos)
        {
            var updated = await _service.UpdateAsync(id, medicamentos);
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
