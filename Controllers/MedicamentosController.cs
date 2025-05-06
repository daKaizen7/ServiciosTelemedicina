using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Services;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentosController : ControllerBase
    {
        private readonly MedicamentosService _service;

        public MedicamentosController(MedicamentosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medicamentos = await _service.GetAllAsync();
            return Ok(medicamentos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var medicamento = await _service.GetByIdAsync(id);
            if (medicamento == null)
                return NotFound();
            return Ok(medicamento);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Medicamento medicamento)
        {
            var created = await _service.CreateAsync(medicamento);
            return CreatedAtAction(nameof(GetById), new { id = created.IdMedicamento }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Medicamento medicamento)
        {
            var updated = await _service.UpdateAsync(id, medicamento);
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
