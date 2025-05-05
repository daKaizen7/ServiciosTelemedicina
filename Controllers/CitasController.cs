using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Services;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly CitaService _service;

        public CitasController(CitaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var citas = await _service.GetAllAsync();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cita = await _service.GetByIdAsync(id);
            if (cita == null)
                return NotFound();
            return Ok(cita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cita cita)
        {
            var updated = await _service.UpdateAsync(id, cita);
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
