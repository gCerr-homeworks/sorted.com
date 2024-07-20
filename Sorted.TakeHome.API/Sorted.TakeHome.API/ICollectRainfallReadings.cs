using Sorted.TakeHome.Domain;

namespace Sorted.TakeHome.API
{
    public interface ICollectRainfallReadings
    {
        IEnumerable<RainfallMeasure> GetStationReadings(string stationId, int readingsCount);
    }
}
