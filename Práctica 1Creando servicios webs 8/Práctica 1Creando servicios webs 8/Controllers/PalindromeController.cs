using Microsoft.AspNetCore.Mvc;

namespace Práctica_1Creando_servicios_webs_8.Controllers
{
    public class PalindromeController : ControllerBase

    {
        [HttpGet("check")]
        public IActionResult CheckPalindrome([FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return BadRequest(new { error = "Debe proporcionar una palabra o texto." });
            }

            string cleanedText = text.ToLower().Replace(" ", "");
            string reversedText = new string(cleanedText.Reverse().ToArray());
            bool isPalindrome = cleanedText == reversedText;

            return Ok(new
            {
                text,
                isPalindrome
            });
        }
    }
}
