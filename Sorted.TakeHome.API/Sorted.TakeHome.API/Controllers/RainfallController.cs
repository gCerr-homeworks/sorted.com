﻿using Microsoft.AspNetCore.Mvc;
using Sorted.TakeHome.API.Model;

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
        public async Task<ActionResult> GetStationReadings(string stationId, int count = 10)
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
             

            return Ok(new RainfallReadingResponse());
        }
    }
}
