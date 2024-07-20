using Sorted.TakeHome.Domain;

namespace Sorted.TakeHome.API.Readings
{
    public class ReadingsSourceResponse
    {
        public ReadingsSourceResponseMetadata Meta { get; set; }
        public List<RainfallMeasure> Items { get; set; }
    }
}
