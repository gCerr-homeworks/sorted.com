using Sorted.TakeHome.Domain;

namespace Sorted.TakeHome.API
{
    internal class RainfallReader : ICollectRainfallReadings
    {
        public Task<IEnumerable<RainfallMeasure>> GetStationReadingsAsync(string stationId, int readingsCount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StationExistsAsync(string stationId)
        {
            throw new NotImplementedException();
        }
    }
}
