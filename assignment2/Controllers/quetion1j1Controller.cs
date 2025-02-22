using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class quetion1j1Controller : ControllerBase

    {
        // <summary>
        // This endpoint calculates the score for the "Delivered Droid" based on the number of deliveries and collisions.
        // </summary>
        // <returns>Returns the calculated score based on the formula (Deliveries * 50) - (Collisions * 10) plus a bonus if Deliveries > Collisions.</returns>
        // <example>
        // https://localhost:7021/api/quetion1j1/DeliveredDroid?Deliveries=10&Collisions=3
        // returns 470
        [HttpPost(template: "DeliveredDroid")]

        public int DeliveredDroid(int Deliveries, int Collisions)
        {

            // Calculate the score based on deliveries and collisions
            int score_output = (Deliveries * 50) - (Collisions * 10);
            // Add a bonus of 500 if deliveries are greater than collisions
            if (Deliveries > Collisions)
            {
                score_output += 500;
            }
            // Return the calculated score
            return score_output;
        }
    }
}
