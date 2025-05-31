using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Services;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Interfaces;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoriasClinicasController : ControllerBase
    {
        private readonly IHistoriaClinica _service;
        private readonly INotificacion _serviceNoti;

        public HistoriasClinicasController(IHistoriaClinica service, INotificacion serviceNoti)
        {
            _service = service;
            _serviceNoti = serviceNoti;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historias = await _service.GetAllAsync();
            return Ok(historias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var historia = await _service.GetByIdAsync(id);
            if (historia == null)
                return NotFound();
            return Ok(historia);
        }

        [HttpGet("all/{id}")]
        public async Task<IActionResult> GetByIdAll(int id)
        {
            var historia = await _service.GetByIdHistAsync(id);
            if (historia == null)
                return NotFound();
            return Ok(historia);
        }

        [HttpPost]
        public async Task<ActionResult<HistoriasClinica>> Create(HistoriasClinica historiasClinica)
        {
            if (historiasClinica == null)
                return BadRequest("Se debe de enviar la informacion de la historia clinica completa.");
            var created = await _service.CreateAsync(historiasClinica);
            if (created == null)
                return StatusCode(500, "Error al crear la historia clínica.");
            var noti = new Notificacion
            {
                IdUsuario = historiasClinica.IdPaciente,
                Mensaje = "Un terapeuta ha creado una nueva historia clinica",
                Fecha = DateOnly.FromDateTime(DateTime.Now)
            };
            var createdNoti = await _serviceNoti.CreateAsync(noti);
            return CreatedAtAction(nameof(GetById), new { id = created.IdHistClin }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, HistoriasClinica historiaClinica)
        {
            var updated = await _service.UpdateAsync(id, historiaClinica);
            if (!updated)
                return NotFound();
            var noti = new Notificacion
            {
                IdUsuario = historiaClinica.IdPaciente,
                Mensaje = "Un terapeuta ha actualizado una nueva historia clinica",
                Fecha = DateOnly.FromDateTime(DateTime.Now)
            };
            var createdNoti = await _serviceNoti.CreateAsync(noti);
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