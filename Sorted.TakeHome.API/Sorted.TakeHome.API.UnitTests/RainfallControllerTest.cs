using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sorted.TakeHome.API.Controllers;
using Sorted.TakeHome.API.Model;
using Sorted.TakeHome.API.Readings;
using Sorted.TakeHome.Domain;

namespace Sorted.TakeHome.API.UnitTests
{
    public class RainfallControllerTest
    {
        private RainfallController controller;
        private Mock<ICollectRainfallReadings> rainfallReaderMock;

        public RainfallControllerTest()
        {
            rainfallReaderMock = new Mock<ICollectRainfallReadings> ();
            controller = new RainfallController (rainfallReaderMock.Object);
        }

        [Fact]
        public async Task rainfallByStation_whenInvalidStatioId_returns_400Error()
        {
            var result = (ObjectResult)await controller.GetStationReadingsAsync(string.Empty);

            result.StatusCode.Should().Be(400);
            result.Value.Should().BeOfType<ErrorResponse>();
            ((ErrorResponse)result.Value).Details.Any(det => det.PropertyName == "stationId").Should().BeTrue();
        }


        [Fact]
        public async Task rainfallByStation_whenInvalidCount_returns_400Error()
        {
            var result = (ObjectResult) await controller.GetStationReadingsAsync("some-station", 101);

            result.StatusCode.Should().Be(400);
            result.Value.Should().BeOfType<ErrorResponse>();
            ((ErrorResponse)result.Value).Details.Any(det => det.PropertyName == "count").Should().BeTrue();
        }

        [Fact]
        public async Task rainfallByStation_whenStationUnknown_returns_404Error()
        {
            var stationId = "some-station";
            rainfallReaderMock.Setup(rr => rr.StationExistsAsync(stationId)).Returns(Task.FromResult(false));

            var result = (ObjectResult)await controller.GetStationReadingsAsync(stationId);

            result.StatusCode.Should().Be(404);
            result.Value.Should().BeOfType<ErrorResponse>();
        }

        [Fact]
        public async Task rainfallByStation_whenInternalError_returns_500Error()
        {
            var stationId = "some-station";
            var count = 10;
            rainfallReaderMock.Setup(rr => rr.StationExistsAsync(stationId)).Returns(Task.FromResult(true));
            rainfallReaderMock.Setup(rr => rr.GetStationReadingsAsync(stationId, count)).Throws<Exception>();

            var result = (ObjectResult)await controller.GetStationReadingsAsync(stationId, count);

            result.StatusCode.Should().Be(500);
            result.Value.Should().BeOfType<ErrorResponse>();
        }

        [Fact]
        public async Task rainfallByStation_when_validRequest_returns_200Readings()
        {
            var stationId = "some-station";
            var count = 10;
            rainfallReaderMock.Setup(rr => rr.StationExistsAsync(stationId)).Returns(Task.FromResult(true));

            var result = (ObjectResult)await controller.GetStationReadingsAsync(stationId, count);

            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<RainfallReadingResponse>();
        }

    }
}