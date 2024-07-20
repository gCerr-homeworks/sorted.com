using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sorted.TakeHome.API.Controllers;
using Sorted.TakeHome.API.Model;

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
            var result = (ObjectResult)await controller.GetStationReadings(string.Empty);

            result.StatusCode.Should().Be(400);
            result.Value.Should().BeOfType<ErrorResponse>();
            ((ErrorResponse)result.Value).Details.Any(det => det.PropertyName == "stationId").Should().BeTrue();
        }


        [Fact]
        public async Task rainfallByStation_whenInvalidCount_returns_400Error()
        {
            var result = (ObjectResult) await controller.GetStationReadings("some-station", 101);

            result.StatusCode.Should().Be(400);
            result.Value.Should().BeOfType<ErrorResponse>();
            ((ErrorResponse)result.Value).Details.Any(det => det.PropertyName == "count").Should().BeTrue();
        }
    }
}