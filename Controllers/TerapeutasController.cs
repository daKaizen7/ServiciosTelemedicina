using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Services;

namespace ServiciosTelemedicina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerapeutasController : ControllerBase
    {
        private readonly TerapeutaService _service;

        public TerapeutasController(TerapeutaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Terapeuta>>> GetAll()
        {
            var terapeutas = await _service.GetAllAsync();
            return Ok(terapeutas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Terapeuta>> GetById(int id)
        {
            var terapeuta = await _service.GetByIdAsync(id);
            if (terapeuta == null)
                return NotFound();

            return Ok(terapeuta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Terapeuta terapeuta)
        {
            var success = await _service.UpdateAsync(id, terapeuta);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}