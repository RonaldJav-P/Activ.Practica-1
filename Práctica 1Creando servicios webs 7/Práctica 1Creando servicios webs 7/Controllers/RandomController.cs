using Microsoft.AspNetCore.Mvc;

namespace Práctica_1Creando_servicios_webs_7.Controllers
{
    public class RandomController : ControllerBase
    {
        [HttpGet("Random")]
        public IActionResult GetRandomNumber([FromQuery] int min, [FromQuery] int max)
        {
            if (min > max)
            {
                return BadRequest(new { error = "El valor mínimo no puede ser mayor que el valor máximo." });
            }

            var random = new Random();
            int result = random.Next(min, max + 1);

            return Ok(new
            {
                min,
                max,
                randomNumber = result
            });
        }
    }
}
