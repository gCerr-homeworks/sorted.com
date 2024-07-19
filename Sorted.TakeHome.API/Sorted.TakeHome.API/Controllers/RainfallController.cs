using Microsoft.AspNetCore.Mvc;
using Sorted.TakeHome.API.Model;

namespace Sorted.TakeHome.API.Controllers
{
    public class RainfallController : Controller
    {
        public RainfallController() { }


        [HttpGet("/rainfall/id/{stationId}/readings")]
        public RainfallReadingResponse GetStationReadings(string stationId, int count = 10)
        {
            return new RainfallReadingResponse();
        }
    }
}
