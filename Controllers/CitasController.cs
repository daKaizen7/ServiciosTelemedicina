using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Services;
using System.Numerics;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ICita _service;
        private readonly INotificacion _serviceNoti;

        public CitasController(ICita service, INotificacion serviceNoti)
        {
            _service = service;
            _serviceNoti = serviceNoti;
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

        [HttpPost]
        public async Task<ActionResult<Cita>> Create(Cita cita, bool validacionNoti)
        {
            if (cita == null)
                return BadRequest("Se debe de enviar la informacion requerida completa.");
            var created = await _service.CreateAsync(cita);
            if (created == null)
                return StatusCode(500, "Error al asignar la cita");
            if (validacionNoti == true)
            {
                var noti = new Notificacion
                {
                    IdUsuario = cita.IdPaciente,
                    Mensaje = "Recordatorio cita",
                    Fecha = cita.Fecha
                };
                var createdNoti = await _serviceNoti.CreateAsync(noti);
            }
            return CreatedAtAction(nameof(GetById), new { id = created.IdCita }, created);

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
