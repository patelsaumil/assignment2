using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class quetion2j2Controller : ControllerBase

    {
        // <summary>
        // which group a player is placed in based on their game results.
        // The player plays 6 games, and the result of each game is represented by either "W" win or "L" loss
        // </summary>
        // <returns>
        // Returns the group the player belongs to:
        // Group 1 if the player wins 5 or 6 games.
        // Group 2 if the player wins 3 or 4 games.
        // Group 3 if the player wins 1 or 2 games.
        // -1 if the player wins 0 games or if the input is invalid 
        // </returns>
        // <example>
        // POST /api/quetion2j2/TournamentGroup with ["W", "L", "W", "W", "L", "W"]
        // returns 2
        [HttpPost("TournamentGroup")]
        public int TournamentGroup([FromBody] string[] gameResults)
        {
            // Check if the input contains exactly 6 results 
            if (gameResults.Length != 6)
            {
                return -1; //Invalid input if there are not exactly 6 results
            }

            int winCount = 0;
            // Count the number of wins ("W")

            for (int i = 0; i < gameResults.Length; i++)
            {
                if (gameResults[i] == "W")
                {
                    winCount++;
                }
            }

            // Determine the group based on the number of wins
            if (winCount >= 5)
            {
                return 1;// Group 1 if 5 or 6 wins
            }
            else if (winCount >= 3)
            {
                return 2; // Group 2 if 3 or 4 wins
            }
            else if (winCount >= 1)
            {
                return 3; // Group 3 if 1 or 2 wins
            }
            else
            {
                return -1; // -1 if 0 wins
            }
        }
    }
}
