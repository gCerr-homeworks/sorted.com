using Sorted.TakeHome.Domain;

namespace Sorted.TakeHome.API.Readings
{

    public class DataSourceReadingsResponse : DataSourceResponseBase
    {        
        public List<RainfallMeasure> Items { get; set; }
    }
}
