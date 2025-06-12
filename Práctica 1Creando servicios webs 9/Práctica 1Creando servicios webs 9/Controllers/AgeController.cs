using Microsoft.AspNetCore.Mvc;

namespace Práctica_1Creando_servicios_webs_9.Controllers
{
    public class AgeController : ControllerBase
    {
        [HttpGet("calculate")]
        public IActionResult CalculateAge([FromQuery] DateTime birthDate)
        {
            DateTime today = DateTime.Today;

            if (birthDate > today)
            {
                return BadRequest(new { error = "La fecha de nacimiento no puede ser en el futuro." });
            }

            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;

            return Ok(new
            {
                birthDate = birthDate.ToString("yyyy-MM-dd"),
                age
            });
        }
    }
}
