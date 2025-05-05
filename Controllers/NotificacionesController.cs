using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesController : ControllerBase
    {
        private readonly NotificacionService _service;

        public NotificacionesController(NotificacionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notificaciones = await _service.GetAllAsync();
            return Ok(notificaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var notificacion = await _service.GetByIdAsync(id);
            if (notificacion == null)
                return NotFound();
            return Ok(notificacion);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notificacion notificacion)
        {
            var created = await _service.CreateAsync(notificacion);
            return CreatedAtAction(nameof(GetById), new { id = created.IdNotificacion }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Notificacion notificacion)
        {
            var updated = await _service.UpdateAsync(id, notificacion);
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