using Refit;

namespace Sorted.TakeHome.API.Readings
{
    public interface IRetrieveReadings
    {
        [Get("/id/stations/{id}")]
        Task<DataSourceStationResponse> StationExistsAsync(string id);

        [Get("/id/stations/{id}/readings?_sorted&_limit={count}")]
        Task<DataSourceReadingsResponse> GetStationReadingsAsync(string id, int count);
    }
}
