using Refit;

namespace Sorted.TakeHome.API.Readings
{
    public interface IRetrieveReadings
    {
        [Get("/id/stations/{id}")]
        Task<object> StationExistsAsync(string id);

        [Get("/id/stations/{id}/readings")]
        Task<object> GetStationReadingsAsync(string id);
    }
}
