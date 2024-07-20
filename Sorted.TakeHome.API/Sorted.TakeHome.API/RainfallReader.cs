using Sorted.TakeHome.Domain;

namespace Sorted.TakeHome.API
{
    internal class RainfallReader : ICollectRainfallReadings
    {
        public IEnumerable<RainfallMeasure> GetStationReadings(string stationId, int readingsCount)
        {
            throw new NotImplementedException();
        }
    }
}
