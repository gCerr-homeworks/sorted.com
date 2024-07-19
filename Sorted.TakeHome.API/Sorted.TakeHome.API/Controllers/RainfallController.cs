using Microsoft.AspNetCore.Mvc;
using Sorted.TakeHome.API.Model;

namespace Sorted.TakeHome.API.Controllers
{
    public class RainfallController : Controller
    {
        public RainfallController() { }


        [HttpGet("/rainfall/id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), 200)]
        [ProducesResponseType(typeof(Error), 400)]        
        public RainfallReadingResponse GetStationReadings(string stationId, int count = 10)
        {
            return new RainfallReadingResponse();
        }
    }
}
