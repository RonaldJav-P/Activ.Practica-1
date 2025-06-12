using Microsoft.AspNetCore.Mvc;

namespace Práctica_1Creando_servicios_webs_4.Controllers
{
    public class CurrencyController : ControllerBase
    {
        [HttpGet("convert")]
        public IActionResult ConvertCurrency([FromQuery] double amount, [FromQuery] string from, [FromQuery] string to)
        {
            if (amount < 0)
            {
                return BadRequest(new { error = "La cantidad debe ser positiva." });
            }

            var rates = new Dictionary<string, Dictionary<string, double>>
            {
                { "USD", new Dictionary<string, double> { { "EUR", 0.91 }, { "DOP", 58.00 }, { "USD", 1 } } },
                { "EUR", new Dictionary<string, double> { { "USD", 1.10 }, { "DOP", 63.00 }, { "EUR", 1 } } },
                { "DOP", new Dictionary<string, double> { { "USD", 0.017 }, { "EUR", 0.016 }, { "DOP", 1 } } }
            };

            from = from.ToUpper();
            to = to.ToUpper();

            if (!rates.ContainsKey(from) || !rates[from].ContainsKey(to))
            {
                return BadRequest(new { error = "Moneda no soportada. Use USD, EUR o DOP." });
            }

            double rate = rates[from][to];
            double converted = amount * rate;

            return Ok(new
            {
                originalAmount = amount,
                from,
                to,
                convertedAmount = Math.Round(converted, 2),
                exchangeRate = rate
            });
        }
    }
}
