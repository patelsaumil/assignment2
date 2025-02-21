using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class quetion3j1Controller : ControllerBase
    {
        /// <summary>
        /// Calculates the total spiciness of the chili based on the peppers added.
        /// </summary>
        /// <param name="pepperNames">Comma-separated list of pepper names added to the chili.</param>
        /// <returns>The total spiciness value of the chili.</returns>
        [HttpGet("ChiliPeppers")]
        public IActionResult GetTotalSpiciness([FromQuery] string Ingredients)
        {
            var peppershu = new Dictionary<string, int>()
            {
                { "Poblano", 1500 },
                { "Mirasol", 6000 },
                { "Serrano", 15500 },
                { "Cayenne", 40000 },
                { "Thai", 75000 },
                { "Habanero", 125000 }
            };
            string[] peppers = Ingredients.Split(',');

            int totalspiciness = 0;

            for (int i = 0; i < peppers.Length; i++)
            {
                string pepperName = peppers[i];

                if (peppershu.ContainsKey(pepperName))
                {
                    totalspiciness += peppershu[pepperName];
                }
                else
                {
                    return BadRequest($"Invalid Pepper Name: {pepperName}");
                }
            }
            return Ok(totalspiciness);
        }
    }
}
