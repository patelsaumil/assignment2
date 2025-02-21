using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class quetion1j1Controller : ControllerBase

    {
        [HttpPost(template: "DeliveredDroid")]

        public int DeliveredDroid(int Deliveries, int Collisions)
        {


            int score_output = (Deliveries * 50) - (Collisions * 10);

            if (Deliveries > Collisions)
            {
                score_output += 500;
            }

            return score_output;
        }
    }
}
