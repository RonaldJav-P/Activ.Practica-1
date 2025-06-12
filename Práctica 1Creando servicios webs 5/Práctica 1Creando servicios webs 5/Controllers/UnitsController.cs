using Microsoft.AspNetCore.Mvc;

namespace Práctica_1Creando_servicios_webs_5.Controllers
{
    public class UnitsController : ControllerBase
    {
        [HttpGet("convert")]
        public IActionResult ConvertUnits([FromQuery] string from, [FromQuery] string to, [FromQuery] double value)
        {
            from = from.ToLower();
            to = to.ToLower();

            if (value < 0)
            {
                return BadRequest(new { error = "El valor debe ser positivo." });
            }

            double result;

            if (from == "km" && to == "miles")
            {
                result = value * 0.621371;
            }
            else if (from == "miles" && to == "km")
            {
                result = value / 0.621371;
            }
            else if (from == "lbs" && to == "kg")
            {
                result = value * 0.453592;
            }
            else if (from == "kg" && to == "lbs")
            {
                result = value / 0.453592;
            }
            else
            {
                return BadRequest(new { error = "Conversión no soportada. Usa km, miles, lbs o kg." });
            }

            return Ok(new
            {
                from,
                to,
                originalValue = value,
                convertedValue = Math.Round(result, 4)
            });
        }
    }
}
