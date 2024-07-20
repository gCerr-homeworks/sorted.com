using Microsoft.AspNetCore.Mvc;
using Sorted.TakeHome.API.Model;
using Sorted.TakeHome.API.Readings;

namespace Sorted.TakeHome.API.Controllers
{
    public class RainfallController : Controller
    {
        private readonly ICollectRainfallReadings rainfallReader;

        public RainfallController(ICollectRainfallReadings rainfallReader)
        {
            this.rainfallReader = rainfallReader;
        }

        [HttpGet("/rainfall/id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]        
        [ProducesResponseType(typeof(ErrorResponse), 404)]        
        [ProducesResponseType(typeof(ErrorResponse), 500)]        
        public async Task<ActionResult> GetStationReadingsAsync(string stationId, int count = 10)
        {
            if (string.IsNullOrWhiteSpace(stationId))
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "Invalid request",
                    Details = new List<ErrorDetail> {
                        new ErrorDetail {
                            PropertyName = "stationId",
                            Message = "empty string or whitespace"
                        }
                    }
                };
                return BadRequest(errorResponse);
            }

            if (count < 0 || count > 100)
            {
                var errorResponse = new ErrorResponse {
                    Message = "Invalid request",
                    Details = new List<ErrorDetail> {
                        new ErrorDetail {
                            PropertyName = "count",
                            Message = "Out of range allowed [1 to 100]"
                        }
                    }
                };
                return BadRequest(errorResponse);
            }
            
            if(!await rainfallReader.StationExistsAsync(stationId))
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "Station not found"                    
                };
                return NotFound(errorResponse);
            }

            try
            {
                var data = await rainfallReader.GetStationReadingsAsync(stationId, count);
                return Ok(new RainfallReadingResponse());
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "Ooops... something went wrong! Apologies, we'll do better next time"
                };
                return StatusCode(500, errorResponse);
            }

            
        }
    }
}
