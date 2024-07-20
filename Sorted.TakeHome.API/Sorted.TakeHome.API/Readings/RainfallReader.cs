using Sorted.TakeHome.Domain;

namespace Sorted.TakeHome.API.Readings;

internal class RainfallReader : ICollectRainfallReadings
{
    private readonly IRetrieveReadings readingsRepository;

    public RainfallReader(IRetrieveReadings readingsRepository)
    {
        this.readingsRepository = readingsRepository;
    }

    public async Task<IEnumerable<RainfallMeasure>> GetStationReadingsAsync(string stationId, int readingsCount)
    {
        var response = await readingsRepository.GetStationReadingsAsync(stationId, readingsCount);

        return response.Items;
    }

    public async Task<bool> StationExistsAsync(string stationId)
    {
        try
        {
            var response = await readingsRepository.StationExistsAsync(stationId);
            if (response == null)
            {
                return false;
            }

            return true;
        }
        catch (Refit.ApiException rftException)
        {
            if(rftException.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }

            throw rftException;
        }

        
    }
 }
