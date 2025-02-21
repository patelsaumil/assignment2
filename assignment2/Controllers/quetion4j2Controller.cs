using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class quetion4j2Controller : ControllerBase
    {
        [HttpGet("magicsquare")]
        public IActionResult checkmagic([FromQuery] string matrix)
        {
            string[] matrixvalues = matrix.Split(',');
            if (matrixvalues.Length != 16)
            {
                return BadRequest("matrix must have exact 16 value");
            }

            int[,] square = new int[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    square[i, j] = int.Parse(matrixvalues[i * 4 + j]);
                }
            }

            int targetsum = 0;
            for (int i = 0; i < 4; i++)
            {
                targetsum += square[0, i];
            }

            for (int i = 0; i < 4; i++)
            {
                int rowsum = 0;
                for (int j = 0; j < 4; j++)
                {
                    rowsum += square[i, j];
                }
                if (rowsum != targetsum)
                {
                    return Ok("not magic");
                }
            }
            for (int i = 0; i < 4; i++)
            {
                int colsum = 0;
                for (int j = 0; j < 4; j++)
                {
                    colsum += square[i, j];

                }
                if (colsum != targetsum)
                {
                    return Ok("not magic");
                }
            }
            int diag1sum = 0, diag2sum = 0;
            for (int i = 0; i < 4; i++)
            {
                diag1sum += square[i, i];
                diag2sum += square[i, 3 - i];
            }
            if ((diag1sum != targetsum || diag2sum != targetsum))
            {
                return Ok("not magic");
            }
            return Ok("magic");
        }

    }
}
