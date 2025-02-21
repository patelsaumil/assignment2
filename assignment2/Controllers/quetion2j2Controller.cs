using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class quetion2j2Controller : ControllerBase

    {
        [HttpPost("TournamentGroup")]
        public int TournamentGroup([FromBody] string[] gameResults)
        {
            
            if (gameResults.Length != 6)
            {
                return -1;
            }

            int winCount = 0;

            
            for (int i = 0; i < gameResults.Length; i++)
            {
                if (gameResults[i] == "W")
                {
                    winCount++;
                }
            }

            
            if (winCount >= 5)
            {
                return 1;
            }
            else if (winCount >= 3)
            {
                return 2; 
            }
            else if (winCount >= 1)
            {
                return 3; 
            }
            else
            {
                return -1; 
            }
        }
    }
}
