using Microsoft.AspNetCore.Mvc;

namespace Sorted.TakeHome.API.Controllers
{
    public class RainfallController : Controller
    {
        public RainfallController() { }


        [HttpGet("/rainfall/id/{stationId}/readings")]
        public IEnumerable<int> GetStationReadings(string stationId, int count = 10)
        {
            return Array.Empty<int>();
        }
    
        

    }
}
