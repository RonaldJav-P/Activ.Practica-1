using Microsoft.AspNetCore.Mvc;


namespace Práctica_1Creando_servicios_webs_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureController : ControllerBase
    {

        [HttpGet("toFahrenheit")]
        public IActionResult ToFahrenheit([FromQuery] double celsius)
        {
            double fahrenheit = (celsius * 9 / 5) + 32;
            return Ok(new { celsius, fahrenheit });
        }

        [HttpGet("toCelsius")]
        public IActionResult ToCelsius([FromQuery] double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;
            return Ok(new { fahrenheit, celsius });
        }
    }
}
