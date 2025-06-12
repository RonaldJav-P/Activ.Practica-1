using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Práctica_1Creando_servicios_webs_6.Controllers
{
    public class PasswordController : ControllerBase
    {
        [HttpGet("generate")]
        public IActionResult GeneratePassword([FromQuery] int length, [FromQuery] bool includeSymbols)
        {
            if (length < 4 || length > 100)
            {
                return BadRequest(new { error = "La longitud debe estar entre 4 y 100 caracteres." });
            }

            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            string allChars = letters + digits;
            if (includeSymbols)
            {
                allChars += symbols;
            }

            var random = new Random();
            var password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(allChars.Length);
                password.Append(allChars[index]);
            }

            return Ok(new
            {
                length,
                includeSymbols,
                password = password.ToString()
            });
        }
    }
}
