using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Models;
using Telemedicina.Services;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : ControllerBase
    {
        private readonly AdministradorService _service;

        public AdministradorController(AdministradorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var admins = await _service.GetAllAsync();
            return Ok(admins);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var admin = await _service.GetByIdAsync(id);
            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Administrador admin)
        {
            var created = await _service.CreateAsync(admin);
            return CreatedAtAction(nameof(GetById), new { id = created.IdUsuario }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Administrador admin)
        {
            var updated = await _service.UpdateAsync(id, admin);
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
