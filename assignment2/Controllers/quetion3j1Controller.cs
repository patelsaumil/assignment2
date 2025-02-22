using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class quetion3j1Controller : ControllerBase
    {
        // <summary>
        // calculates the total spiciness of chili based on the peppers added.
        // It takes a comma-separated list of pepper names and sums their corresponding Scolville Heat Units (SHU) values.
        // Returns the total spiciness value (sum of SHU values of the peppers) if all peppers are valid.
        // Returns a BadRequest response with an error message if any pepper name is invalid.
        // <example>
        // GET https://localhost:7021/api/quetion3j1/ChiliPeppers?Ingredients=Poblano,Cayenne,Thai
        // returns 118000

        [HttpGet("ChiliPeppers")]
        public IActionResult GetTotalSpiciness([FromQuery] string Ingredients)
        {
            // Dictionary for storing SHU values for different peppers
            var peppershu = new Dictionary<string, int>()
            {
                { "Poblano", 1500 },
                { "Mirasol", 6000 },
                { "Serrano", 15500 },
                { "Cayenne", 40000 },
                { "Thai", 75000 },
                { "Habanero", 125000 }
            };
            // Split the input string by commas to get individual pepper names
            string[] peppers = Ingredients.Split(',');

            int totalspiciness = 0;
            // Iterate over the peppers and sum their SHU values
            for (int i = 0; i < peppers.Length; i++)
            {
                string pepperName = peppers[i];
                // Check if the pepper is valid and add its SHU value to the total spiciness
                if (peppershu.ContainsKey(pepperName))
                {
                    totalspiciness += peppershu[pepperName];
                }
                else
                {
                    // Return an error if an invalid pepper name is encountered
                    return BadRequest($"Invalid Pepper Name: {pepperName}");
                }
            }
            // Return the total spiciness value if all peppers are valid
            return Ok(totalspiciness);
        }
    }
}
