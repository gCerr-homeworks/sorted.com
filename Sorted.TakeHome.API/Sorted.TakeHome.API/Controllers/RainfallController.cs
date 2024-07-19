using Microsoft.AspNetCore.Mvc;
using Sorted.TakeHome.API.Model;

namespace Sorted.TakeHome.API.Controllers
{
    public class RainfallController : Controller
    {
        public RainfallController() { }


        [HttpGet("/rainfall/id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]        
        [ProducesResponseType(typeof(ErrorResponse), 404)]        
        [ProducesResponseType(typeof(ErrorResponse), 500)]        
        public RainfallReadingResponse GetStationReadings(string stationId, int count = 10)
        {
            return new RainfallReadingResponse();
        }
    }
}
