using Microsoft.AspNetCore.Mvc;


namespace Práctica_1Creando_servicios_webs_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetWelcomeMessage([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(new { message = "El parámetro 'name' es obligatorio." });
            }

            var response = new
            {
                message = $"¡Bienvenido, {name}!"
            };

            return Ok(response);
        }
    }
}
