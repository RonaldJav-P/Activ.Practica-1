using Microsoft.AspNetCore.Mvc;


namespace Práctica_1Creando_servicios_webs_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]

        public IActionResult Add([FromQuery] double c, [FromQuery] double d)
        {
            var result = c + d;
            return Ok(new { result });

        }

        [HttpGet("subtract")]

        public IActionResult Subtract([FromQuery] double c, [FromQuery] double d)
        {
            var result = c - d;
            return Ok(new { result });
        }


        [HttpGet("multiply")]
        public IActionResult Multiply([FromQuery] double c, [FromQuery] double d)
        {
            var result = c * d;
            return Ok(new { result });
        }


        [HttpGet("divide")]
        public IActionResult Divide([FromQuery] double c, [FromQuery] double d)
        {
            if (d == 0)
            {
                return BadRequest(new { error = "No es posible dividir entre cero." });
            }

            var result = c / d;
            return Ok(new { result });
        }
    }
}
