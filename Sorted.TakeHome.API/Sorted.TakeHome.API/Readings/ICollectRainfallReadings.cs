using Sorted.TakeHome.Domain;

namespace Sorted.TakeHome.API.Readings;

public interface ICollectRainfallReadings
{
    Task<IEnumerable<RainfallMeasure>> GetStationReadingsAsync(string stationId, int readingsCount);
    Task<bool> StationExistsAsync(string stationId);
}
