using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Interfaces;
using ServiciosTelemedicina.Models;
using ServiciosTelemedicina.Models.DTOs;
using ServiciosTelemedicina.Services;

namespace ServiciosTelemedicina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _service;

        public UsuariosController(IUsuario service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _service.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }


        [HttpPost]//Para seguir el Factory Method, los usuarios unicamente se crean mediante el controlador de usuarios. 
        public async Task<ActionResult<Usuario>> CrearUsuario([FromBody] UsuarioDto dto)//Se usa el dto
        {
            var created = await _service.CrearUsuarioAsync(dto);//Luego, toda la lógica de creación se delega al servicio.

            return CreatedAtAction(nameof(GetById), new { id = created.IdUsuario }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            var success = await _service.UpdateAsync(id, usuario);
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