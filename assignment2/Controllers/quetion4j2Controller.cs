using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class quetion4j2Controller : ControllerBase
    {
        // <summary>
        //  if a given 4x4 matrix is a magic square.
        // A magic square is defined as a square matrix where the sum of all rows, columns, and both diagonals are the same.
        // </summary>

        //<returns>Returns "magic" if the matrix is a magic square, otherwise returns "not magic".</returns>
        // <example>
        // GET https://localhost:7021/api/quetion4j2/magicsquare?matrix=16,3,2,13,5,10,11,8,9,6,7,12,4,15,14,1
        // returns "magic"
        [HttpGet("magicsquare")]
        public IActionResult checkmagic([FromQuery] string matrix)
        {
            // Split the matrix string into individual values
            string[] matrixvalues = matrix.Split(',');
            // Validate if the matrix has exactly 16 values
            if (matrixvalues.Length != 16)
            {
                return BadRequest("matrix must have exact 16 value");
            }
            // Initialize the 4x4 matrix
            int[,] square = new int[4, 4];
            // Populate the 4x4 matrix with the values from the input
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    square[i, j] = int.Parse(matrixvalues[i * 4 + j]);
                }
            }
            // Calculate the sum of the first row to set as the target sum
            int targetsum = 0;
            for (int i = 0; i < 4; i++)
            {
                targetsum += square[0, i];
            }
            // Check if all rows have the same sum
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
            // Check if all columns have the same sum
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
            // Check if both diagonals have the same sum
            int diag1sum = 0, diag2sum = 0;
            for (int i = 0; i < 4; i++)
            {
                diag1sum += square[i, i];
                diag2sum += square[i, 3 - i];
            }
            // If diagonal doesn't match the target sum, it's not a magic square
            if ((diag1sum != targetsum || diag2sum != targetsum))
            {
                return Ok("not magic");
            }
            // If all checks passed, it's a magic square
            return Ok("magic");
        }

    }
}
