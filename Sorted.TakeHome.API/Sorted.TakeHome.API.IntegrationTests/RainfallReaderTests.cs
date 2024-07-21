using FluentAssertions;
using Refit;
using Sorted.TakeHome.API.Readings;

namespace Sorted.TakeHome.API.IntegrationTests
{
    public class RainfallReaderTests
    {
        IRetrieveReadings refitClient;

        public RainfallReaderTests()
        {
            var url = "https://environment.data.gov.uk/flood-monitoring";
            refitClient = RestService.For<IRetrieveReadings>(url);
            
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task can_determine_station_exists()
        {
            var stationId = "E7050";
            var response = await refitClient.StationExistsAsync(stationId);
            response.Should().NotBeNull();
            response.Items.StationReference.Should().Be(stationId);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task can_retrieve_readings()
        {
            var stationId = "E7050";
            var count = 10;
            var response = await refitClient.GetStationReadingsAsync(stationId, count);

            response.Should().NotBeNull();
            response.Items.Should().HaveCount(count);   
        }
    }
}