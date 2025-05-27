using Microsoft.AspNetCore.Mvc;
using ServiciosTelemedicina.Models.DTOs;
using ServiciosTelemedicina.Services;

namespace ServiciosTelemedicina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacionController : ControllerBase
    {
        private readonly AutenticacionService _service;

        public AutenticacionController(AutenticacionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var respuesta = await _service.AutenticarAsync(dto.Correo, dto.Contrasena);

            if (respuesta == null)
                return Unauthorized("Correo o contraseña incorrectos.");

            return Ok(respuesta);
        }
    }
}